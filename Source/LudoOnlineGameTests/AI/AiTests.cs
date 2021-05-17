using Xunit;
using System;
using System.Collections.Generic;
using Ludo_Web.MVC_Game.GameEngine;
using Ludo_Web.MVC_Game.Models.GamePlayers;
using static Ludo_Web.MVC_Game.Models.ModelEnum;
using Ludo_Web.MVC_Game.GameEngine.Dice;
using Ludo_Web.MVC_Game.Models;

namespace LudoOnlineGameTests.AI
{
    public class AiTests
    {
        [Fact]
        public void Stephan_Choices_AssertErradicate()
        {
            SquareCollection.Init(@"AI/ai-test-map1.txt");

            var stephan = new Stephan(TeamColor.Blue, null);
            var dice = new RiggedDice(new[] { 2 });

            var pawn1 = new Pawn(TeamColor.Blue);
            var pawn2 = new Pawn(TeamColor.Blue);
            var enemyPawn = new Pawn(TeamColor.Green);
            var squarePawn1 = SquareCollection.BoardSquares.Find(x => x.BoardX == 0 && x.BoardY == 1);
            var squarePawn2 = SquareCollection.BoardSquares.Find(x => x.BoardX == 1 && x.BoardY == 1);
            var squareEnemy = SquareCollection.BoardSquares.Find(x => x.BoardX == 2 && x.BoardY == 1);
            var enemyBase = SquareCollection.BaseSquare(TeamColor.Green);

            squarePawn1.Pawns.Add(pawn1);
            squarePawn2.Pawns.Add(pawn2);
            squareEnemy.Pawns.Add(enemyPawn);

            stephan.ChoosePlay(TODO);

            Assert.True(squarePawn1.Pawns.Count == 0);

        }
        [Fact]
        public void StephanRollSix_AssertTakeOutTwo()
        {
            SquareCollection.Init(@"AI/ai-test-map1.txt");
            var squares = SquareCollection.BoardSquares;
            GameSetup.NewGame(squares, new TeamColor[] { TeamColor.Blue });
            var dice = new RiggedDice(new[] { 6, 1 });

            var stephan = new Stephan(TeamColor.Blue, null);
            stephan.ChoosePlay(TODO);
            var startSquare = SquareCollection.StartSquare(TeamColor.Blue);
            var pawns = startSquare.Pawns;
            Assert.True(pawns.Count == 2);
        }
    }
}
