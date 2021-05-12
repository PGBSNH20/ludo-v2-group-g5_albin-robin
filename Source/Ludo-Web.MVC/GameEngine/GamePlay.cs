﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.GameEngine.Interfaces;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.MVC.GameEngine
{
    public class GamePlay
    {
        private IDice dice { get; set; }
        public GamePlay(List<Player> players, IDice dice, Player first = null)
        {
            this.dice = dice;
            Players = players;
            OrderOfTeams = OrderOfTeams.Intersect(players.Select(x => x.Color)).ToList();
            if (first != null) SetFirstTeam(first.Color);
        }

        public static event Action<GamePlay> GameStartEvent;
        public static event Action <GamePlay>OnPlayerEndsRoundEvent;
        public void Start()
        {
            GameStartEvent?.Invoke(this);
            while (true)
            {
                CurrentPlayer().Play(dice);
                BoardFinder.AllPlayingPawns().ForEach(x => x.IsSelected = false);
                OnPlayerEndsRoundEvent?.Invoke(this);
                NextPlayer();
            }
        }

        private List<TeamColor> OrderOfTeams = new List<TeamColor>
        {
            TeamColor.Blue,
            TeamColor.Red,
            TeamColor.Green,
            TeamColor.Yellow
        };
        public List<Player> Players { get; set; }
        private int iCurrentTeam { get; set; }
        public void SetFirstTeam(TeamColor color) => iCurrentTeam = OrderOfTeams.FindIndex(x => x == color);
        public void NextPlayer()
        {
            //StageSaving.CurrentTeam = iCurrentTeam;
            
            iCurrentTeam++;
            iCurrentTeam = iCurrentTeam >= Players.Count ? 0 : iCurrentTeam;
        }
        public TeamColor NextPlayerForSave()
        {
            int i = iCurrentTeam + 1;
            i = i >= Players.Count ? 0 : i;
            return OrderOfTeams[i];
        }
        public Player CurrentPlayer() => Players.Find(x => x.Color == OrderOfTeams[iCurrentTeam]);
        //public Player CurrentPlayer(bool stageSaving) => Players.Find(x => x.Color == OrderOfTeams[StageSaving.CurrentTeam]);
    }
}