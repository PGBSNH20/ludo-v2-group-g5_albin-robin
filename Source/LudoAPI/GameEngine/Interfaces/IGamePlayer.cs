using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine.Interfaces
{
    public interface IGamePlayer
    {
        ModelEnum.TeamColor Color { get; set; }
        Pawn[] ChoosePlay(PlayerOption playerOption);
    }
}