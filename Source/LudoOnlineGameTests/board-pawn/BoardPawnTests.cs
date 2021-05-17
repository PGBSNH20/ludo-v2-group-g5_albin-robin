using Ludo_Web.MVC_Game.GameEngine;
using Ludo_Web.MVC_Game.GameEngine.GameSquares;
using Ludo_Web.MVC_Game.Models;
using Xunit;
using static Ludo_Web.MVC_Game.Models.ModelEnum;

namespace LudoOnlineGameTests.board_pawn
{
    public class BoardPawnTests
    {
        [Fact]
        public void MoveToExit_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map1.txt");
            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = SquareCollection.BaseSquare(TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            bluePawn.Move(7);
            var current = bluePawn.CurrentSquare();

            Assert.IsType<ExitSquare>(current);
        }
        [Fact]
        public void MoveToFinish_AndRemoveFromBoard_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map1.txt");
            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = SquareCollection.BaseSquare(TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            bluePawn.Move(8);
            var current = bluePawn.CurrentSquare();

            Assert.True(current == null);
        }
        [Fact]
        public void BlueBounceFromFinish_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map4.txt");
            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = SquareCollection.BaseSquare(TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);
            bluePawn.Move(7);
            var expectedSquare = SquareCollection.BoardSquares[1];
            var square = bluePawn.CurrentSquare();

            Assert.True(expectedSquare == square);
        }
        [Fact]
        public void RedExitSquare_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map3.txt");
            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = SquareCollection.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            redPawn.Move(1);
            var square = SquareCollection.FindPawnSquare(redPawn);
            Assert.IsType<ExitSquare>(square);
        }
        [Fact]
        public void RedSafeZoneSquare_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map3.txt");
            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = SquareCollection.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            redPawn.Move(2);
            var square = SquareCollection.FindPawnSquare(redPawn);
            Assert.IsType<SafezoneSquare>(square);
        }
        [Fact]
        public void RedGoal_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map3.txt");
            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = SquareCollection.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            redPawn.Move(3);
            var pawns = SquareCollection.AllBaseAndPlayingPawns();
            Assert.True(pawns.Count == 0);
        }
        [Fact]
        public void RedGoalBounce_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map3.txt");
            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = SquareCollection.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            var squarse = SquareCollection.BoardSquares;
            redPawn.Move(4);
            var expectedSquare = SquareCollection.BoardSquares[2];

            Assert.True(expectedSquare.Pawns.Count == 1);
        }
        [Fact]
        public void RedGoalBounce2_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map3.txt");
            var redPawn = new Pawn(TeamColor.Red);
            var startSquare = SquareCollection.StartSquare(TeamColor.Red);
            startSquare.Pawns.Add(redPawn);

            var squares = SquareCollection.BoardSquares;
            redPawn.Move(5);
            var expectedSquare = SquareCollection.BoardSquares[1];

            Assert.True(expectedSquare.Pawns.Count == 1);
        }
        [Fact]
        public void MoveUpNotFinish_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map1.txt");
            var squares = SquareCollection.BoardSquares;
            var redPawn = new Pawn(TeamColor.Red);
            var start = SquareCollection.BoardSquares.Find(x => x.BoardX == 0 && x.BoardY == 1);
            start.Pawns.Add(redPawn);

            redPawn.Move(7);
            var current = redPawn.CurrentSquare();

            Assert.IsType<StandardSquare>(current);
        }
        [Fact]
        public void ErradicateOne_AssertBaseSquare()
        {
            SquareCollection.Init(@"board-pawn/test-map1.txt");
            var squares = SquareCollection.BoardSquares;
            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = SquareCollection.BaseSquare(TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            var redPawn = new Pawn(TeamColor.Red);
            var start = SquareCollection.BoardSquares.Find(x => x.BoardX == 0 && x.BoardY == 1);
            start.Pawns.Add(redPawn);

            bluePawn.Move(1);
            var current = redPawn.CurrentSquare();

            Assert.IsType<BaseSquare>(current);
        }
        [Fact]
        public void ErradicateTwo_AssertTwoInBase()
        {
            SquareCollection.Init(@"board-pawn/test-map1.txt");
            var squares = SquareCollection.BoardSquares;
            var bluePawn = new Pawn(TeamColor.Blue);
            var baseSquare = SquareCollection.BaseSquare(TeamColor.Blue);
            baseSquare.Pawns.Add(bluePawn);

            var redPawn = new Pawn(TeamColor.Red);
            var redPawn2 = new Pawn(TeamColor.Red);
            var start = SquareCollection.BoardSquares.Find(x => x.BoardX == 0 && x.BoardY == 1);
            start.Pawns.Add(redPawn);
            start.Pawns.Add(redPawn2);

            bluePawn.Move(1);
            var redsBased = SquareCollection.PawnsInBase(TeamColor.Red);

            Assert.True(redsBased.Count == 2);
        }
        [Fact]
        public void GameSetup_fourRed_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map1.txt");
            var squares = SquareCollection.BoardSquares;
            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Red });
            var redsBased = SquareCollection.PawnsInBase(TeamColor.Red);

            Assert.True(redsBased.Count == 4);
        }
        [Fact]
        public void GameSetup_fourBlue_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map-2p.txt");
            var squares = SquareCollection.BoardSquares;
            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Green });
            var bluesBased = SquareCollection.PawnsInBase(TeamColor.Blue);

            Assert.True(bluesBased.Count == 4);
        }
        [Fact]
        public void GameSetUp_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map-2p.txt");
            var squares = SquareCollection.BoardSquares;
            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Green });
            var greensBased = SquareCollection.PawnsInBase(TeamColor.Green);

            Assert.True(greensBased.Count == 4);
        }
        [Fact]
        public void GetTeamPawns_AssertTrue()
        {
            SquareCollection.Init(@"board-pawn/test-map-2p.txt");
            var squares = SquareCollection.BoardSquares;
            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue, TeamColor.Green });

            var bluePawns = SquareCollection.GetTeamPawns(TeamColor.Blue);

            Assert.True(bluePawns.Count == 4);
        }
    }
}
