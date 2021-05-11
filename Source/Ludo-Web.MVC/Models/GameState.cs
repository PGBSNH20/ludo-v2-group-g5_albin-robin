using System;
using System.Collections.Generic;
using static Ludo_Web.MVC.Models.PropertyEnums;

namespace Ludo_Web.MVC.Models
{
    public record GameState
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public TeamColor TeamColor { get; set; }
        public string PawnCoordinates { get; set; }
        public EndPosition EndPosition { get; set; }
    }
}