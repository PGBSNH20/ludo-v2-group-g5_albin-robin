using System.ComponentModel.DataAnnotations;
using LudoAPI.DataAccess;

namespace LudoAPI.Models.Account
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
        public ModelEnum.Language Language { get; set; }
    }
}