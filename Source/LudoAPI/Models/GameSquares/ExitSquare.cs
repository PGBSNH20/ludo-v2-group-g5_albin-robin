using System.Collections.Generic;
using LudoAPI.DataAccess;

namespace LudoAPI.Models.GameSquares
{
    public class ExitSquare : GameSquare
    {
        public ExitSquare(int boardX, int boardY, ModelEnum.TeamColor? color, ModelEnum.BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = color;
            Pawns = new List<Pawn>();
        }
        public override ModelEnum.BoardDirection DirectionNext(ModelEnum.TeamColor Color)
        {
            if (this.Color == Color)
            {
                return
                    Color == ModelEnum.TeamColor.Yellow ? ModelEnum.BoardDirection.Up :
                    Color == ModelEnum.TeamColor.Blue ? ModelEnum.BoardDirection.Right :
                    Color == ModelEnum.TeamColor.Red ? ModelEnum.BoardDirection.Down : ModelEnum.BoardDirection.Left;
            }
            else
                return DefaultDirection;
        }
    }
}