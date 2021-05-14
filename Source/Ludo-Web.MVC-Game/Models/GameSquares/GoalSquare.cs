using System.Collections.Generic;

namespace Ludo_Web.MVC_Game.Models.GameSquares
{
    public class GoalSquare : GameSquare
    {
        public GoalSquare(int boardX, int boardY)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = 0;
            Color = null;
            Pawns = new List<Pawn>();
        }
        public override ModelEnum.BoardDirection DirectionNext(ModelEnum.TeamColor Color)
        {
            return
               Color == ModelEnum.TeamColor.Yellow ? ModelEnum.BoardDirection.Up :
               Color == ModelEnum.TeamColor.Blue ? ModelEnum.BoardDirection.Right :
               Color == ModelEnum.TeamColor.Red ? ModelEnum.BoardDirection.Down : ModelEnum.BoardDirection.Left;
        }
    }
}