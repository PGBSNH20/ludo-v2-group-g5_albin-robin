using LudoEngine.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ludo_Web.Models
{
    public record Game
    {
        public int Id { get;}
        public string GuidID { get; }
        public Player CurrentPlayer { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string GameStatus { get; set; }
    }
}