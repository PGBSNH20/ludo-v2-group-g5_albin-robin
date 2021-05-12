using System.Collections.Generic;
using static Ludo_Web.DataEntity.Models.ModelEnum;

namespace Ludo_Web.DataEntity.Models.LudoModels.GameSquares
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