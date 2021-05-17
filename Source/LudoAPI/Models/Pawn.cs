using System;
using System.Linq;
using LudoAPI.DataAccess;
using LudoAPI.GameEngine;
using LudoAPI.Models.GameSquares;

namespace LudoAPI.Models
{
    public class Pawn
    {
        public ModelEnum.TeamColor Color { get; set; }
        public bool IsSelected { get; set; }
        public Pawn(ModelEnum.TeamColor color)
        {
            Color = color;
        }

        public static event Action<Pawn> OnBounceEvent;
        public static event Action<Pawn, int> OnGoalEvent;
        public static event Action<Pawn> OnAllTeamPawnsOutEvent;
        public static event Action<Pawn, ModelEnum.TeamColor, int> OnEradicationEvent;
        public static event Action<ModelEnum.TeamColor> GameLoserEvent;
        public static event Action GameOverEvent;
        public static event Action<Pawn> OnSafeZoneEvent;
        public GameSquare CurrentSquare() => BoardFinder.BoardSquares.Find(x => x.Pawns.Contains(this));
        public void Move(int dice)
        {
            var tempSquare = CurrentSquare();
            bool startingSquareIsSafeZoneSquare = tempSquare is SafezoneSquare;
            tempSquare.Pawns.Remove(this);

            bool lastIteration;
            bool bounced = false;

            for (var i = 0; i < dice; i++)
            {
                lastIteration = i == dice - 1;

                if (tempSquare is GoalSquare || bounced == true)
                {
                    tempSquare = BoardFinder.GetBack(BoardFinder.BoardSquares, tempSquare, Color);
                    bounced = true;
                }
                else
                {
                    tempSquare = BoardFinder.GetNext(BoardFinder.BoardSquares, tempSquare, Color);
                }
                if (lastIteration == true && tempSquare is GoalSquare)
                {
                    this.IsSelected = false;

                    if (BoardFinder.GetTeamPawns(Color).Count == 0)
                        OnAllTeamPawnsOutEvent?.Invoke(this);
                    else
                        OnGoalEvent?.Invoke(this, BoardFinder.GetTeamPawns(Color).Count);

                    bool onlyOneTeamLeft = BoardFinder.AllPlayingPawns().Select(x => x.Color).ToList().Count == 1;
                    if (onlyOneTeamLeft)
                    {
                        GameLoserEvent?.Invoke(BoardFinder.AllPlayingPawns().Select(x => x.Color).ToList()[0]);
                        GameOverEvent?.Invoke();
                    }
                    return;
                }
            }

            ModelEnum.TeamColor? enemyColor = null;
            int pawnsToEradicate = 0;
            if (tempSquare.Pawns.Count != 0 && tempSquare.Pawns[0].Color != Color)
            {
                enemyColor = tempSquare.Pawns[0].Color;
                pawnsToEradicate = tempSquare.Pawns.Count;
                var eradicateBase = BoardFinder.BaseSquare((ModelEnum.TeamColor)enemyColor);
                eradicateBase.Pawns.AddRange(tempSquare.Pawns);
                tempSquare.Pawns.Clear();
            }

            if (pawnsToEradicate != 0) OnEradicationEvent?.Invoke(this, (ModelEnum.TeamColor)enemyColor, pawnsToEradicate);
            tempSquare.Pawns.Add(this);
            if (bounced == true) OnBounceEvent?.Invoke(this);
            if (tempSquare is SafezoneSquare && startingSquareIsSafeZoneSquare == false) OnSafeZoneEvent?.Invoke(this);

            this.IsSelected = false;
        }
    }
}