using System.Collections.Generic;

namespace Ludo_Web.MVC_Game.Models
{
    public abstract class GameSquare
    {
        public int Id { get; set; }//only db
        public int LudoBoardId { get; set; } //only db
        public ModelEnum.TeamColor? Color { get; set; }
        public int BoardX { get; set; }
        public int BoardY { get; set; }
        public List<Pawn> Pawns { get; set; } //Map to ICollection
        public ModelEnum.BoardDirection DefaultDirection { get; set; }
        public virtual ModelEnum.BoardDirection DirectionNext(ModelEnum.TeamColor Color) => DefaultDirection;
    }
}