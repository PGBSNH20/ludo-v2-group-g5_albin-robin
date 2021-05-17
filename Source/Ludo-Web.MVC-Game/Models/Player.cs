using Ludo_Web.MVC_Game.GameEngine;
using Ludo_Web.MVC_Game.GameEngine.Interfaces;

namespace Ludo_Web.MVC_Game.Models
{
    public abstract record Player : IGamePlayer
    {
        public int PlayerId { get; set; }
        public bool CanThrow { get; set; }
        public int Result { get; set; }

        public ModelEnum.TeamColor Color { get; set; }
        public abstract Pawn[] ChoosePlay(PlayerOption playerOption);
    }
}
