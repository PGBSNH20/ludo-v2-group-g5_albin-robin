using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine.Interfaces
{
    public interface IOptionsValidator
    {
        PlayerOption GetPlayerOption(ModelEnum.TeamColor color, int diceRoll);
        bool ValidateResponse(PlayerOption option, Pawn[] pawnResponse);
    }
}