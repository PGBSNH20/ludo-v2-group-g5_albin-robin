using Ludo_Web.MVC_Game.GameEngine.Interfaces;

namespace Ludo_Web.MVC_Game.Models
{
    public abstract class GamePlayer
    {
        public int Id { get; set; }
        //public int Id { get; set; } //public PlayerID foreign key
        public ModelEnum.TeamColor Color { get; set; }
        public bool IsActive { get; set; }
        public int Result { get; set; }
        public abstract void Play(IDice dice);
    }
}
