using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine.Interfaces
{
    public interface IGameAction
    {
        void Act(Pawn[] pawns, int diceRoll);
    }
}