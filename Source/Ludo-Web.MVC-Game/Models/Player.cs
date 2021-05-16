using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludo_Web.MVC_Game.Models
{
    public record Player
    {
        public int AccountId { get; set; }
        public ICollection<Pawn> Pawns { get; set; }
        public int Result { get; set; }
        public bool CanThrow { get; set; }
    }
}
