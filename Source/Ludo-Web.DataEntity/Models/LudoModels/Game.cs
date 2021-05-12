using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Ludo_Web.DataEntity.Models.ModelEnum;

namespace Ludo_Web.DataEntity.Models.LudoModels
{
    public record Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        ICollection<Player> Players { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public GameStatus GameStatus { get; set; }
    }
}