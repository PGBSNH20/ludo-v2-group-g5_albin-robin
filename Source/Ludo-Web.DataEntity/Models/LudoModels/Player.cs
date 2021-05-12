using Ludo_Web.Engine.Interfaces;
using static Ludo_Web.DataEntity.Models.ModelEnum;

namespace Ludo_Web.DataEntity.Models.LudoModels
{
    public abstract class Player
    {
        public int Id { get; set; }
        //public int Id { get; set; } //public PlayerID foreign key
        public TeamColor Color { get; set; }
        public bool IsActive { get; set; }
        public int Result { get; set; }
        public abstract void Play(IDice dice);
    }
}
