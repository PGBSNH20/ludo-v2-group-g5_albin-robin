using Ludo_Web.MVC_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ludo_Web.MVC_Game.GameEngine.GameSquares;
using static Ludo_Web.MVC_Game.Models.ModelEnum;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public class GameAction
    {
        private List<GameSquare> _boardSquares;
        public GameAction(LudoBoard board)
        {
            _boardSquares = board.GameSquares.ToList();
        }

        public static event Action<Pawn> OnBounceEvent;
        public static event Action<Pawn, int> OnGoalEvent;
        public static event Action<Pawn> OnAllTeamPawnsOutEvent;
        public static event Action<Pawn, TeamColor, int> OnEradicationEvent;
        public static event Action<TeamColor> GameLoserEvent;
        public static event Action GameOverEvent;
        public static event Action<Pawn> OnSafeZoneEvent;

        public void Move(Pawn pawn, int dice)
        {
            var tempSquare = CurrentSquare(pawn);
            var boardSquares = _boardSquares.ToList();
            bool startingSquareIsSafeZoneSquare = tempSquare is SafezoneSquare;

            tempSquare.Pawns.Remove(pawn);

            bool lastIteration;
            bool bounced = false;

            for (var i = 0; i < dice; i++)
            {
                lastIteration = i == dice - 1;

                if (tempSquare is GoalSquare || bounced == true)
                {
                    tempSquare = PastSquare(boardSquares, tempSquare, pawn.Color);
                    bounced = true;
                }
                else
                {
                    tempSquare = NextSquare(boardSquares, tempSquare, pawn.Color);
                }
                if (lastIteration == true && tempSquare is GoalSquare)
                {
                    pawn.IsSelected = false;

                    if (GetTeamPawns(pawn.Color).Count == 0)
                        OnAllTeamPawnsOutEvent?.Invoke(pawn);
                    else
                        OnGoalEvent?.Invoke(pawn, GetTeamPawns(pawn.Color).Count);

                    bool onlyOneTeamLeft = AllPlayingPawns().Select(x => x.Color).ToList().Count == 1;
                    if (onlyOneTeamLeft)
                    {
                        GameLoserEvent?.Invoke(AllPlayingPawns().Select(x => x.Color).ToList()[0]);
                        GameOverEvent?.Invoke();
                    }
                    return;
                }
            }

            TeamColor? enemyColor = null;
            int pawnsToEradicate = 0;
            if (tempSquare.Pawns.Count != 0 && tempSquare.Pawns[0].Color != pawn.Color)
            {
                enemyColor = tempSquare.Pawns[0].Color;
                pawnsToEradicate = tempSquare.Pawns.Count;
                var eradicateBase = BaseSquare((TeamColor)enemyColor);
                eradicateBase.Pawns.AddRange(tempSquare.Pawns);
                tempSquare.Pawns.Clear();
            }

            if (pawnsToEradicate != 0) OnEradicationEvent?.Invoke(pawn, (TeamColor)enemyColor, pawnsToEradicate);
            tempSquare.Pawns.Add(pawn);
            if (bounced == true) OnBounceEvent?.Invoke(pawn);
            if (tempSquare is SafezoneSquare && startingSquareIsSafeZoneSquare == false) OnSafeZoneEvent?.Invoke(pawn);

            pawn.IsSelected = false;
        }
        private (int X, int Y) NextDiff(BoardDirection direction)
        {
            return
            direction == BoardDirection.Up ? (0, -1) :
            direction == BoardDirection.Right ? (1, 0) :
            direction == BoardDirection.Down ? (0, 1) :
            direction == BoardDirection.Left ? (-1, 0) : (0, 0);
        }
        private GameSquare PastSquare(List<GameSquare> squares, GameSquare square, TeamColor color)
        {
            var defaultDirection = square.DirectionNext(color);
            var backDirection = ReverseDirection(defaultDirection);
            var diff = NextDiff(backDirection);
            var nextSquare = squares.Find(x => x.BoardX == square.BoardX + diff.X && x.BoardY == square.BoardY + diff.Y) ?? throw new NullReferenceException();
            return nextSquare;
        }
        private GameSquare CurrentSquare(Pawn pawn)
        {
            return _boardSquares.First(x => x.Pawns.Contains(pawn));
        }
        private GameSquare NextSquare(List<GameSquare> squares, GameSquare square, TeamColor color)
        {
            var diff = NextDiff(square.DirectionNext(color));
            var nextSquare = squares.Find(x => x.BoardX == square.BoardX + diff.X && x.BoardY == square.BoardY + diff.Y) ?? throw new NullReferenceException();
            return nextSquare;
        }
        private List<Pawn> AllPlayingPawns() => _boardSquares.FindAll(x => x.GetType() != typeof(BaseSquare) && x.GetType() != typeof(GoalSquare)).SelectMany(x => x.Pawns).ToList();
        private List<Pawn> GetTeamPawns(TeamColor color) => _boardSquares.SelectMany(x => x.Pawns).Where(x => x.Color == color).ToList();
        private GameSquare BaseSquare(TeamColor color) => _boardSquares.Find(x => x.GetType() == typeof(BaseSquare) && x.Color == color);
        private BoardDirection ReverseDirection(BoardDirection direction)
        {
            return
            direction == BoardDirection.Down ? BoardDirection.Up :
            direction == BoardDirection.Up ? BoardDirection.Down :
            direction == BoardDirection.Left ? BoardDirection.Right : BoardDirection.Left;
        }
    }
}
