using Ludo_Web.MVC_Game.Models;
using System;
using System.Collections.Generic;
using Ludo_Web.MVC_Game.GameEngine.GameSquares;
using static Ludo_Web.MVC_Game.Models.ModelEnum;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public class GameAction
    {
        private readonly IBoardCollection _boardCollection;

        public GameAction(IBoardCollection collection)
        {
            _boardCollection = collection;
        }
        public static event Action<Pawn, int> OnMoveEvent;
        public static event Action<TeamColor> OnTakeOutTwoEvent;

        public static event Action<Pawn> OnBounceEvent;
        public static event Action<Pawn, int> OnGoalEvent;
        public static event Action<Pawn> OnAllTeamPawnsOutEvent;
        public static event Action<Pawn, TeamColor, int> OnEradicationEvent;
        public static event Action<TeamColor> GameLoserEvent;
        public static event Action GameOverEvent;
        public static event Action<Pawn> OnSafeZoneEvent;

        public void Act(Pawn[] pawns, int diceRoll)
        {
            if (pawns.Length == 0) return;
            if (pawns.Length == 2)
            {
                foreach (var p in pawns)
                {
                    Move(p, 1);
                }
                return;
            }
            if (pawns.Length == 1)
            {
                Move(pawns[0], diceRoll);
            }
            throw new Exception("Invalid pawn count");
        }
        private void Move(Pawn pawn, int dice)
        {
            var tempSquare = _boardCollection.CurrentSquare(pawn);
            bool startingSquareIsSafeZoneSquare = tempSquare is SafezoneSquare;

            bool bounced = false;

            for (var i = 0; i < dice; i++)
            {
                var lastIteration = i == dice - 1;

                if (tempSquare is GoalSquare || bounced == true)
                {
                    tempSquare = _boardCollection.PastSquare(tempSquare, pawn.Color);
                    bounced = true;
                }
                else
                {
                    tempSquare = _boardCollection.GetNext(tempSquare, pawn.Color);
                }
                if (lastIteration == true && tempSquare is GoalSquare)
                {
                    ChangeCoordinates(pawn, _boardCollection.GoalSquare());

                    if (_boardCollection.GetTeamPawns(pawn.Color).Count == 0)
                        OnAllTeamPawnsOutEvent?.Invoke(pawn);
                    else
                        OnGoalEvent?.Invoke(pawn, _boardCollection.GetTeamPawns(pawn.Color).Count);

                    bool onlyOneTeamLeft = _boardCollection.TeamsLeft().Count == 1;
                    if (onlyOneTeamLeft)
                    {
                        GameLoserEvent?.Invoke(_boardCollection.TeamsLeft()[0]);
                        GameOverEvent?.Invoke();
                    }
                    return;
                }
            }

            TeamColor? enemyColor = null;
            int pawnsToEradicate = 0;
            var enemies = _boardCollection.EnemiesOnSquare(tempSquare, pawn.Color);
            if (enemies.Count > 0)
            {
                enemyColor = enemies[0].Color;
                pawnsToEradicate = enemies.Count;
                var eradicateBase = _boardCollection.BaseSquare((TeamColor)enemyColor);
                ChangeCoordinates(enemies, eradicateBase);
            }

            if (pawnsToEradicate != 0) OnEradicationEvent?.Invoke(pawn, (TeamColor)enemyColor, pawnsToEradicate);
            ChangeCoordinates(pawn, tempSquare);

            if (bounced == true) OnBounceEvent?.Invoke(pawn);
            if (tempSquare is SafezoneSquare && startingSquareIsSafeZoneSquare == false) OnSafeZoneEvent?.Invoke(pawn);
        }

        private void ChangeCoordinates(List<Pawn> pawns, GameSquare targetSquare)
        {
            foreach (var p in pawns)
            {
                ChangeCoordinates(p, targetSquare);
            }
        }
        private void ChangeCoordinates(Pawn pawn, GameSquare targetSquare)
        {
            if (targetSquare is GoalSquare)
            {
                pawn.X = 0;
                pawn.Y = 0;
                return;
            }
            pawn.X = targetSquare.BoardX;
            pawn.Y = targetSquare.BoardY;
        }
    }
}
