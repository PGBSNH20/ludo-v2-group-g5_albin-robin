using LudoEngine.Enum;
using LudoEngine.GameLogic.Interfaces;

namespace LudoEngine.BoardCollection.Models
{
    public abstract class GamePlayer
    {
        public int Id { get; set; }
        //public int Id { get; set; } //public PlayerID foreign key
        public TeamColor Color { get; set; }
        public bool IsActive { get; set; }
        public int Result { get; set; }
        public abstract void Play(IDice dice);
    }
}
