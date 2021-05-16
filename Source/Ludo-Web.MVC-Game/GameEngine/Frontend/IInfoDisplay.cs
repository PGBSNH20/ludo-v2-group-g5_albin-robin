using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine.Frontend
{
    public interface IInfoDisplay
    {
        void Update(string newString);
        public void UpdateDiceRoll(GamePlayer player, int result);
        public void UpdateDiceRoll(Stephan stephan, int result);
    }
}
