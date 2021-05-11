using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Ludo_Web.MVC.Models.PropertyEnums;

namespace Ludo_Web.MVC.Models
{
    public record GameState
    {
        public Game Game { get; set; }
        public Player Player { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        [Required]
        public TeamColor TeamColor { get; set; }
        public EndResult? EndResult { get; set; }
    }
}