using LudoEngine.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Ludo_Web.Models.PropertyEnums;

namespace Ludo_Web.Models
{
    public record Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string URL { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public GameStatus GameStatus { get; set; }
    }
}