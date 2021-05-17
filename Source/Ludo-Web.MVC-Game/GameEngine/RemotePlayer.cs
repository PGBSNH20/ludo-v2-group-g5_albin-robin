using Ludo_Web.MVC_Game.GameEngine.Interfaces;
using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public record RemotePlayer : Player, IGamePlayer
    {
        public override Pawn[] ChoosePlay(PlayerOption playerOption)
        {
            //await frontend result
            return new Pawn[0];
        }
    }
}
