using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_Web.MVC.Models
{
    public class LudoBoard
    {
        public int Id { get; set; }
        public ICollection<GameSquare> GameSquares { get; set; }
    }
}
