
using LudoEngine.Enum;
using LudoEngine.Models;
using System.Collections.Generic;

namespace LudoEngine.BoardCollection.Models
{
    public class BaseSquare : GameSquare
    {
        public BaseSquare(int boardX, int boardY, TeamColor? color, BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = color;
            Pawns = new List<Pawn>();
        }
    }
}