using System.Collections.Generic;
using LudoAPI.DataAccess;

namespace LudoAPI.Models.GameSquares
{
    public class SafezoneSquare : GameSquare
    {
        public SafezoneSquare(int boardX, int boardY, ModelEnum.TeamColor? color, ModelEnum.BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = color;
            Pawns = new List<Pawn>();
        }
    }
}