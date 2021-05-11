using System.Collections.Generic;

namespace Ludo_Web.Models
{
    public class PlayerGame
    {
        public int PlayerId { get; set; }
        public ICollection<Player> Player { get; set; }
        public int GameId { get; set; }
        public ICollection<Game> Game { get; set; }
    }
}