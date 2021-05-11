using System.ComponentModel.DataAnnotations;
using static Ludo_Web.MVC.Models.PropertyEnums;

namespace Ludo_Web.MVC.Models
{
    public record Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public PlayerType PlayerType { get; set; }
    }
}