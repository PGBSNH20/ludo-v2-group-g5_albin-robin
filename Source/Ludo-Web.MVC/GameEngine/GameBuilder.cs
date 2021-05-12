﻿using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using Ludo_Web.MVC.GameEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.MVC.GameEngine
{
    public class GameBuilder :
        IGameBuilderMapBoard,
        IGameBuilderAddDice,
        IGameBuilderSetInfoDisplay,
        IGameBuilderLoadOrNew,
        IGameBuilderNewGame,
        IGameBuilderLoadPawns,
        IGameBuilderGamePlay,
        IGameBuilderNewGamePlay,
        IGameBuilderStartingColor,
        IGameBuilderLoadPlayers,
        IGameBuilderSaveConfig
    {
        private IDice _dice { get; set; }
        private List<TeamColor> _teamColors { get; set; } = new();
        private List<PawnSavePoint> _pawnSavePoints { get; set; } = new();
        private TeamColor _first { get; set; }
        private List<Player> _Players { get; set; } = new();
        private bool _enableSaving { get; set; }
        private void AddColor(TeamColor color)
        {
            if (_teamColors.Contains(color)) throw new Exception("There can only be one player per color");
            _teamColors.Add(color);
        }
        public static IGameBuilderMapBoard StartBuild() => new GameBuilder();
        public IGameBuilderAddDice MapBoard(string filePath)
        {
            BoardFinder.BoardSquares = BoardOrm.Map(filePath);
            return this;
        }
        public IGameBuilderSetInfoDisplay AddDice(IDice dice)
        {
            _dice = dice;
            return this;
        }
        public IGameBuilderLoadOrNew SetInfoDisplay(IInfoDisplay infoDisplay)
        {
            return this;
        }
        public IGameBuilderLoadPawns LoadGame()
        {
            return this;
        }
        public IGameBuilderLoadPlayers LoadPawns(List<PawnSavePoint> savePoints)
        {
            GameSetup.LoadSavedPawns(savePoints);
            _pawnSavePoints = savePoints;
            
            return this;
        }
        public IGameBuilderStartingColor LoadPlayers(Func<IController> humanController)
        {
            var colorTypeList = _pawnSavePoints.Select(x => (x.Color, x.PlayerType)).Distinct().ToList();

            foreach (var colorType in colorTypeList)
            {
                if (colorType.PlayerType == 0)
                {
                    AddHumanPlayer(colorType.Color, humanController());
                }
                if (colorType.PlayerType == 1)
                {
                    AddAIPlayer(colorType.Color);
                }
            }
            return this;
        }

        private void AddHumanPlayer(TeamColor color, object consoleDefaults)
        {
            throw new NotImplementedException();
        }

        public IGameBuilderNewGame NewGame()
        {
            return this;
        }
        public IGameBuilderSaveConfig StartingColor(TeamColor? color)
        {
            if (color != null && _teamColors.Contains((TeamColor)color)) _first = (TeamColor)color;
            else _first = _teamColors[0];
            if (!_teamColors.Contains((TeamColor)color)) throw new Exception("Teamcolor for first player is not present in the game");

            return this;
        }
        public IGameBuilderNewGamePlay AddHumanPlayer(TeamColor color, IController control)
        {
            AddColor(color);
            _Players.Add(new HumanPlayer(color,  control));
            return this;
        }
        public IGameBuilderNewGamePlay AddAIPlayer(TeamColor color, bool log = false)
        {
            AddColor(color);

            if (log)
                _Players.Add(new Stephan(color, new StephanLog(color)));
            else
                _Players.Add(new Stephan(color));
            return this;
        }
        public IGameBuilderStartingColor SetUpPawns()
        {
            GameSetup.NewGame(BoardFinder.BoardSquares, _teamColors.ToArray());
            return this;
        }
        public IGameBuilderGamePlay DisableSaving() => this;
        public IGameBuilderGamePlay EnableSavingToDb()
        {
            _enableSaving = true;
            return this;
        }

        public GamePlay ToGamePlay()
        {
            var firstPlayer = _Players.Find(x => x.Color == _first);
            var gamePlay = new GamePlay(_Players, _dice, firstPlayer);
            //if (_enableSaving == true) DatabaseManagement.SaveInit(gamePlay);
            return gamePlay;
        }
    }
}
