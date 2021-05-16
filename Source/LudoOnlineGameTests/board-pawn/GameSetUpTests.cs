
using Xunit;
using System.Collections.Generic;
using Ludo_Web.MVC_Game.Models;
using Ludo_Web.MVC_Game.GameEngine;
using static Ludo_Web.MVC_Game.Models.ModelEnum;
using Ludo_Web.MVC_Game.GameEngine.Dice;
using System;
using Ludo_Web.MVC_Game.GameEngine.Frontend;

namespace LudoOnlineGameTests.board_pawn
{
    public class InfoDisplayStub : IInfoDisplay
    {
        public void Update(string newString)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDiceRoll(GamePlayer player, int result)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDiceRoll(Stephan stephan, int result)
        {
            throw new System.NotImplementedException();
        }
    }
    public class IControllerStub : IController
    {
        public event Action SelectionUpEvent;
        public event Action SelectionDownEvent;
        public event Action TakeOutTwoPressEvent;
        public event Action OnConfirmEvent;

        public void Activate()
        {
            throw new NotImplementedException();
        }
    }
    public class GameSetupTests
    {
        [Fact]
        public void LoadOnePawn_AssertTrue()
        {
            var savePoint = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 4,
                Color = TeamColor.Blue
            };
            GameBuilder.StartBuild()
                .MapBoard(@"board-pawn/test-copy_BoardMap.txt")
                .AddDice(new Dice(1, 6))
                .SetInfoDisplay(null)
                .LoadGame()
                .LoadPawns(new List<PawnSavePoint> { savePoint });

            var pawns = BoardFinder.GetTeamPawns(TeamColor.Blue);
            Assert.True(pawns.Count == 1);
        }
        [Fact]
        public void LoadTwoPawn_Stands_AssertTrue()
        {
            var savePoint = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 4,
                Color = TeamColor.Blue
            };
            var savePoint2 = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 4,
                Color = TeamColor.Blue
            };
            var loaded = GameBuilder.StartBuild()
                .MapBoard(@"board-pawn/test-copy_BoardMap.txt")
                .AddDice(new Dice(1, 6))
                .SetInfoDisplay(null)
                .LoadGame()
                .LoadPawns(new List<PawnSavePoint> { savePoint, savePoint2 });

            var square = BoardFinder.BoardSquares.Find(x => x.BoardX == savePoint.XPosition && x.BoardY == savePoint.YPosition);

            Assert.True(square.Pawns.Count == 2);
        }
        [Fact]
        public void LoadHumanPlayer_AssertTrue()
        {
            var savePoint = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 4,
                Color = TeamColor.Blue,
            };
            var game = GameBuilder.StartBuild()
            .MapBoard(@"board-pawn/test-copy_BoardMap.txt")
            .AddDice(new Dice(1, 6))
            .SetInfoDisplay(new InfoDisplayStub())
            .LoadGame()
            .LoadPawns(new List<PawnSavePoint> { savePoint })
            .LoadPlayers(() => new IControllerStub())
            .StartingColor(TeamColor.Blue)
            .DisableSaving()
            .ToGamePlay();

            var players = game.Players;

            Assert.True(players.Count == 1);
        }
        [Fact]
        public void Load3HumanPlayer_AssertTrue()
        {
            var savePoint = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 4,
                Color = TeamColor.Blue
            };
            var savePoint2 = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 3,
                Color = TeamColor.Red
            };
            var savePoint3 = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 2,
                Color = TeamColor.Yellow
            };
            var savePoint4 = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 1,
                Color = TeamColor.Yellow
            };
            var game = GameBuilder.StartBuild()
            .MapBoard(@"board-pawn/test-copy_BoardMap.txt")
            .AddDice(new Dice(1, 6))
            .SetInfoDisplay(new InfoDisplayStub())
            .LoadGame()
            .LoadPawns(new List<PawnSavePoint> { savePoint, savePoint2, savePoint3, savePoint4 })
            .LoadPlayers(() => new IControllerStub())
            .StartingColor(TeamColor.Blue)
            .DisableSaving()
            .ToGamePlay();

            var players = game.Players;

            Assert.True(players.Count == 3);
        }
        [Fact]
        public void Load1HumanPlayer1Ai_AssertTrue()
        {
            var savePointHuman = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 4,
                Color = TeamColor.Blue,
                PlayerType = 0

            };
            var savePointStephan = new PawnSavePoint()
            {
                XPosition = 4,
                YPosition = 3,
                Color = TeamColor.Red,
                PlayerType = 1

            };

            var game = GameBuilder.StartBuild()
            .MapBoard(@"board-pawn/test-copy_BoardMap.txt")
            .AddDice(new Dice(1, 6))
            .SetInfoDisplay(new InfoDisplayStub())
            .LoadGame()
            .LoadPawns(new List<PawnSavePoint> { savePointHuman, savePointStephan })
            .LoadPlayers(() => new IControllerStub())
            .StartingColor(TeamColor.Blue)
            .EnableSavingToDb()
            .ToGamePlay();

            var gamePlayers = game.Players;
            var aiExists = game.Players.Exists(x => x is Stephan);

            Assert.True(aiExists == true);
        }

    }
}
