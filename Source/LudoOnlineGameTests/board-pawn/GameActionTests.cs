using Ludo_Web.MVC_Game.DataAccess.LudoORM;
using Ludo_Web.MVC_Game.GameEngine;
using Ludo_Web.MVC_Game.Models;
using Ludo_Web.MVC_Game.Models.GameSquares;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Ludo_Web.MVC_Game.Models.ModelEnum;

namespace LudoOnlineGameTests.board_pawn
{
    public class GameActionTests
    {
        public static GameSquare BaseSquare(List<GameSquare> squares, TeamColor color)
    => squares.Find(x => x.GetType() == typeof(BaseSquare) && x.Color == color);
        public static GameSquare StartSquare(List<GameSquare> squares, TeamColor color)
            => squares.Find(x => x.GetType() == typeof(StartSquare) && x.Color == color);
        [Fact]
        public void MoveToExit_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map1.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);

            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = BaseSquare(squares, TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            action.Move(bluePawn, 7);
            var current = squares.Find(x => x.Pawns.Contains(bluePawn));

            Assert.IsType<ExitSquare>(current);
        }
        [Fact]
        public void MoveToFinish_AndRemoveFromBoard_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map1.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);

            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = BaseSquare(squares, TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            action.Move(bluePawn, 8);
            var current = squares.Find(x => x.Pawns.Contains(bluePawn));

            Assert.True(current == null);
        }
        [Fact]
        public void BlueBounceFromFinish_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map4.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);

            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = BaseSquare(squares, TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);
            action.Move(bluePawn, 7);

            var expectedSquare = squares[1];
            var square = squares.Find(x => x.Pawns.Contains(bluePawn));
            Assert.True(expectedSquare == square);
        }
        [Fact]
        public void RedExitSquare_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map3.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var BoardFind = new BoardFind(board);
            var action = new GameAction(board);

            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = StartSquare(squares, TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            action.Move(redPawn, 1);
            var square = BoardFind.FindPawnSquare(redPawn);
            Assert.IsType<ExitSquare>(square);
        }
        [Fact]
        public void RedSafeZoneSquare_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map3.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);
            var redPawn = new Pawn(TeamColor.Red);

            var startSquare = BoardFind.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            action.Move(redPawn, 2);
            var square = BoardFind.FindPawnSquare(redPawn);
            Assert.IsType<SafezoneSquare>(square);
        }
        [Fact]
        public void RedGoal_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map3.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = BoardFind.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            action.Move(redPawn, 3);
            var pawns = BoardFind.AllBaseAndPlayingPawns();
            Assert.True(pawns.Count == 0);
        }
        [Fact]
        public void RedGoalBounce_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map3.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = BoardFind.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            action.Move(redPawn, 4);
            var expectedSquare = squares[2];

            Assert.True(expectedSquare.Pawns.Count == 1);
        }
        [Fact]
        public void RedGoalBounce2_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map3.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = BoardFind.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);
            
            action.Move(redPawn, 5);
            var expectedSquare = squares[1];

            Assert.True(expectedSquare.Pawns.Count == 1);
        }
        [Fact]
        public void MoveUpNotFinish_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map1.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            var redPawn = new Pawn(TeamColor.Red);
            var start = squares.Find(x => x.BoardX == 0 && x.BoardY == 1);
            start.Pawns.Add(redPawn);

            action.Move(redPawn, 7);
            var current = squares.Find(x => x.Pawns.Contains(redPawn));

            Assert.IsType<StandardSquare>(current);
        }
        [Fact]
        public void ErradicateOne_AssertBaseSquare()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map1.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = BoardFind.BaseSquare(TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            var redPawn = new Pawn(TeamColor.Red);
            var start = squares.Find(x => x.BoardX == 0 && x.BoardY == 1);
            start.Pawns.Add(redPawn);

            action.Move(bluePawn, 1);
            var current = squares.Find(x => x.Pawns.Contains(redPawn));

            Assert.IsType<BaseSquare>(current);
        }
        [Fact]
        public void ErradicateTwo_AssertTwoInBase()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map1.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);
            
            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = BoardFind.BaseSquare(TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            var redPawn = new Pawn(TeamColor.Red);
            var redPawn2 = new Pawn(TeamColor.Red);
            var start = squares.Find(x => x.BoardX == 0 && x.BoardY == 1);
            start.Pawns.Add(redPawn);
            start.Pawns.Add(redPawn2);

            action.Move(bluePawn, 1);
            var redsBased = BoardFind.PawnsInBase(TeamColor.Red);
            Assert.True(redsBased.Count == 2);
        }
        [Fact]
        public void GameSetup_fourRed_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map1.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Red });
            var redsBased = BoardFind.PawnsInBase(TeamColor.Red);

            Assert.True(redsBased.Count == 4);
        }
        [Fact]
        public void GameSetup_fourBlue_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map-2p.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Green });
            var bluesBased = BoardFind.PawnsInBase(TeamColor.Blue);

            Assert.True(bluesBased.Count == 4);
        }
        [Fact]
        public void GameSetUp_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map-2p.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Green });
            var greensBased = BoardFind.PawnsInBase(TeamColor.Green);

            Assert.True(greensBased.Count == 4);
        }
        [Fact]
        public void GetTeamPawns_AssertTrue()
        {
            var squares = BoardOrm.Map(@"board-pawn/test-map-2p.txt");
            var board = new LudoBoard() { GameSquares = squares };
            var action = new GameAction(board);
            var BoardFind = new BoardFind(board);

            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Green });

            var bluePawns = BoardFind.GetTeamPawns(TeamColor.Blue);

            Assert.True(bluePawns.Count == 4);
        }
        private class BoardFind
        {
            private List<GameSquare> BoardSquares { get; set; }
            public BoardFind(LudoBoard board)
            {
                BoardSquares = board.GameSquares.ToList();
            }
            public List<Pawn> PawnsInBase(TeamColor color) =>
                BoardSquares.Find(x => x.GetType() == typeof(BaseSquare) && x.Color == color).Pawns;
            public GameSquare FindPawnSquare(Pawn pawn) => BoardSquares.Find(x => x.Pawns.Contains(pawn));
            public List<Pawn> AllBaseAndPlayingPawns() => BoardSquares.SelectMany(x => x.Pawns).ToList();
            public GameSquare StartSquare(TeamColor color)
                => BoardSquares.Find(x => x.GetType() == typeof(StartSquare) && x.Color == color);
            public GameSquare BaseSquare(TeamColor color)
        => BoardSquares.Find(x => x.GetType() == typeof(BaseSquare) && x.Color == color);
           
            public List<Pawn> GetTeamPawns(TeamColor color) => BoardSquares.SelectMany(x => x.Pawns).Where(x => x.Color == color).ToList();
        }
    }
}
