using static Ludo_Web.MVC.Models.PropertyEnums;

namespace Ludo_Web.MVC.Models
{
    public record Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public PlayerType PlayerType { get; set; }
    }
}