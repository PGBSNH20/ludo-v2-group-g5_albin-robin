using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.GameEngine.Interfaces;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.MVC.Models
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
