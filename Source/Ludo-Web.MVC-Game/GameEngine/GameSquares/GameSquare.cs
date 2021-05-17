using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine.GameSquares
{
    public abstract class GameSquare
    {
        public ModelEnum.TeamColor? Color { get; set; }
        public int BoardX { get; set; }
        public int BoardY { get; set; }
        public ModelEnum.BoardDirection DefaultDirection { get; set; }
        public virtual ModelEnum.BoardDirection DirectionNext(ModelEnum.TeamColor color) => DefaultDirection;
    }
}