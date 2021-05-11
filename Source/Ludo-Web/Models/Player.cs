namespace Ludo_Web.Models
{
    public record Player
    {
        public int Id { get; set; }
        public Game Games { get; set; }
        public string PlayerName { get; set; }
        public string EmailAdress { get; set; }
        public string Language { get; set; }
        public string PlayerType { get; set; }
    }
}