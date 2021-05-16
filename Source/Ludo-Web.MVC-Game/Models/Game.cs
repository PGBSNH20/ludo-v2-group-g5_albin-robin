using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ludo_Web.MVC_Game.GameEngine;

namespace Ludo_Web.MVC_Game.Models
{
    public record Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        ICollection<GamePlayer> Players { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ModelEnum.GameStatus GameStatus { get; set; }
    }
}