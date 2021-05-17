using System.Collections.Generic;

namespace LudoAPI.Models
{
    public class LudoBoard
    {
        public int Id { get; set; }
        public ICollection<GameSquare> GameSquares { get; set; }
    }
}
