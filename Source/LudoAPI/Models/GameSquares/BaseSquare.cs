using System.Collections.Generic;
using LudoAPI.DataAccess;

namespace LudoAPI.Models.GameSquares
{
    public class BaseSquare : GameSquare
    {
        public BaseSquare(int boardX, int boardY, ModelEnum.TeamColor? color, ModelEnum.BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = color;
            Pawns = new List<Pawn>();
        }
    }
}