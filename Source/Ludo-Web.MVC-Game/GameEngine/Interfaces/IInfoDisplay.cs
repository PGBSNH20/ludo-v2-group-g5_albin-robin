using Ludo_Web.MVC_Game.Models;
using Ludo_Web.MVC_Game.Models.GamePlayers;

namespace Ludo_Web.MVC_Game.GameEngine.Interfaces
{
    public interface IInfoDisplay
    {
        void Update(string newString);
        public void UpdateDiceRoll(Player player, int result);
        public void UpdateDiceRoll(Stephan stephan, int result);
    }
}
