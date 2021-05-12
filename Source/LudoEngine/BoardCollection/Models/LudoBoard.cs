using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoEngine.BoardCollection.Models
{
    public class LudoBoard
    {
        public int Id { get; set; }
        public ICollection<GameSquare> GameSquares { get; set; }
    }
}
