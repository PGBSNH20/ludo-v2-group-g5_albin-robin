using LudoAPI.Models;
using LudoAPI.Models.GamePlayers;

namespace LudoAPI.GameEngine.Interfaces
{
    public interface IInfoDisplay
    {
        void Update(string newString);
        public void UpdateDiceRoll(Player player, int result);
        public void UpdateDiceRoll(Stephan stephan, int result);
    }
}
