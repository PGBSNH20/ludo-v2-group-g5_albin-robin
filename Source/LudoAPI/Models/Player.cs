using LudoAPI.DataAccess;
using LudoAPI.GameEngine.Interfaces;

namespace LudoAPI.Models
{
    public abstract class Player
    {
        public int Id { get; set; }
        //public int Id { get; set; } //public PlayerID foreign key
        public ModelEnum.TeamColor Color { get; set; }
        public bool IsActive { get; set; }
        public int Result { get; set; }
        public abstract void Play(IDice dice);
    }
}
