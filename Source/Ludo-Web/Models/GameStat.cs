using System;
using System.Collections.Generic;

namespace Ludo_Web.Models
{
    public record GameStat
    {
        public int PlayerId { get; set; }
        public ICollection<Player> Player { get; set; }
        public int GameId { get; set; }
        public string TeamColor { get; set; }
        public ICollection<Game> Game { get; set; }
        public string PawnCoordinates { get; set; }
        public int EndPosition { get; set; }

    }
}