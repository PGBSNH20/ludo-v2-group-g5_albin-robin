using System.ComponentModel.DataAnnotations;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.MVC.Models
{
    public record Account
    {
        public int Id { get; set; }
        [Required]
        public string PlayerName { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Language Language { get; set; }
    }
}