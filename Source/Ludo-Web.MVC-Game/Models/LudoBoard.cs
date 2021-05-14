using System.Collections.Generic;

namespace Ludo_Web.MVC_Game.Models
{
    public class LudoBoard
    {
        public int Id { get; set; }
        public ICollection<GameSquare> GameSquares { get; set; }
    }
}
