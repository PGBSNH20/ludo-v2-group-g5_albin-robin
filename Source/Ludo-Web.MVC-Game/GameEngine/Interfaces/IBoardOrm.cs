using System.Collections.Generic;
using Ludo_Web.MVC_Game.GameEngine.GameSquares;

namespace Ludo_Web.MVC_Game.GameEngine.Interfaces
{
    public interface IBoardOrm
    {
        public List<GameSquare> Map();
    }
}