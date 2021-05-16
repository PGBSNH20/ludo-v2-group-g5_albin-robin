using System.Collections.Generic;
using Ludo_Web.MVC_Game.GameEngine.GameSquares;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public class LudoBoard
    {
        public int Id { get; set; }
        public ICollection<GameSquare> GameSquares { get; set; }
    }
}
