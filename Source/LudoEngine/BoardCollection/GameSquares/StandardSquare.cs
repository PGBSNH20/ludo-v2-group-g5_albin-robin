
using LudoEngine.Enum;
using LudoEngine.Models;
using System.Collections.Generic;

namespace LudoEngine.BoardCollection.Models
{
    public class StandardSquare : GameSquare
    {
        public StandardSquare(int boardX, int boardY, BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = null;
            Pawns = new List<Pawn>();
        }
    }
}