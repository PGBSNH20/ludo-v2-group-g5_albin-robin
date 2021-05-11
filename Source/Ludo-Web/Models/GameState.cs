using System;
using System.Collections.Generic;

namespace Ludo_Web.Models
{
    public record GameState
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string TeamColor { get; set; }
        public string PawnCoordinates { get; set; }
        public int EndPosition { get; set; } //Is Enum
    }
}