using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoEngine.BoardCollection.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Url { get; set; }
        ICollection<GamePlayer> GamePlayers { get; set; }
        public LudoBoard Board { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
    }
}
