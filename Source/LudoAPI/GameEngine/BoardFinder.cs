using System;
using System.Collections.Generic;
using System.Linq;
using LudoAPI.DataAccess;
using LudoAPI.DataAccess.LudoORM;
using LudoAPI.Models;
using LudoAPI.Models.GameSquares;

namespace LudoAPI.GameEngine
{
    public static class BoardFinder
    {
        public static List<GameSquare> BoardSquares { get; set; }

        private const string _filePath = @"LudoORM/Map/BoardMap.txt";
        public static void Init(string filePath = _filePath)
        {
            BoardSquares = BoardOrm.Map(filePath);
        }
        public static void Init(LudoBoard board)
        {
            BoardSquares = board.GameSquares.ToList();
        }
        private static List<GameSquare> GetTeamSquares(ModelEnum.TeamColor color) =>
        BoardSquares.FindAll(x => x.Pawns.Count > 0).FindAll(x => x.Pawns[0].Color == color);
        public static List<GameSquare> PawnBoardSquares(ModelEnum.TeamColor color) =>
            GetTeamSquares(color).FindAll(x => x.GetType() != typeof(BaseSquare) && x.GetType() != typeof(GoalSquare));
        public static List<Pawn> PawnsInBase(ModelEnum.TeamColor color) =>
            BoardSquares.Find(x => x.GetType() == typeof(BaseSquare) && x.Color == color).Pawns;
        public static List<Pawn> PawnsInGoal(ModelEnum.TeamColor color) =>
            BoardSquares.Find(x => x.GetType() == typeof(GoalSquare)).Pawns.FindAll(x => x.Color == color);
        public static GameSquare FindPawnSquare(Pawn pawn) => BoardSquares.Find(x => x.Pawns.Contains(pawn));
        public static List<Pawn> AllBaseAndPlayingPawns() => BoardFinder.BoardSquares.SelectMany(x => x.Pawns).ToList();
        public static List<Pawn> OutOfBasePawns(ModelEnum.TeamColor color) => AllPlayingPawns().FindAll(x => x.Color == color);
        public static List<Pawn> AllPlayingPawns() => BoardSquares.FindAll(x => x.GetType() != typeof(BaseSquare) && x.GetType() != typeof(GoalSquare)).SelectMany(x => x.Pawns).ToList();
        public static bool IsMoreThenOneTeamLeft() => BoardSquares.SelectMany(x => x.Pawns).Select(x => x.Color).Distinct().ToList().Count > 1;
        public static GameSquare StartSquare(ModelEnum.TeamColor color)
            => BoardSquares.Find(x => x.GetType() == typeof(StartSquare) && x.Color == color);
        public static GameSquare BaseSquare(ModelEnum.TeamColor color)
    => BoardSquares.Find(x => x.GetType() == typeof(BaseSquare) && x.Color == color);
        public static List<GameSquare> TeamPath(ModelEnum.TeamColor color)
        {
            var teamSquares = new List<GameSquare>();
            var baseSquare = BaseSquare(color);
            teamSquares.Add(baseSquare);
            GameSquare temp = baseSquare;
            while (temp.GetType() != typeof(GoalSquare))
            {
                temp = GetNext(BoardSquares, temp, color);
                teamSquares.Add(temp);
            }
            return teamSquares;
        }
        public static List<Pawn> GetTeamPawns(ModelEnum.TeamColor color) => BoardSquares.SelectMany(x => x.Pawns).Where(x => x.Color == color).ToList();
        private static (int X, int Y) NextDiff(ModelEnum.BoardDirection direction) =>
                direction == ModelEnum.BoardDirection.Up ? (0, -1) :
                direction == ModelEnum.BoardDirection.Right ? (1, 0) :
                direction == ModelEnum.BoardDirection.Down ? (0, 1) :
                direction == ModelEnum.BoardDirection.Left ? (-1, 0) : (0, 0);
        public static GameSquare GetNext(List<GameSquare> squares, GameSquare square, ModelEnum.TeamColor color)
        {
            var diff = NextDiff(square.DirectionNext(color));
            var nextSquare = squares.Find(x => x.BoardX == square.BoardX + diff.X && x.BoardY == square.BoardY + diff.Y) ?? throw new NullReferenceException();
            return nextSquare;
        }
        public static ModelEnum.BoardDirection ReverseDirection(ModelEnum.BoardDirection direction) =>
            direction == ModelEnum.BoardDirection.Down ? ModelEnum.BoardDirection.Up :
            direction == ModelEnum.BoardDirection.Up ? ModelEnum.BoardDirection.Down :
            direction == ModelEnum.BoardDirection.Left ? ModelEnum.BoardDirection.Right : ModelEnum.BoardDirection.Left;

        public static GameSquare GetBack(List<GameSquare> squares, GameSquare square, ModelEnum.TeamColor color)
        {
            var defaultDirection = square.DirectionNext(color);
            var backDirection = ReverseDirection(defaultDirection);
            var diff = NextDiff(backDirection);
            var nextSquare = squares.Find(x => x.BoardX == square.BoardX + diff.X && x.BoardY == square.BoardY + diff.Y) ?? throw new NullReferenceException();
            return nextSquare;
        }
    }
}
