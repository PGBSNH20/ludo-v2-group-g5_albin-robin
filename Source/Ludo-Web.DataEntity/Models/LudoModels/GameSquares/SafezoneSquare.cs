using System.Collections.Generic;
using static Ludo_Web.DataEntity.Models.ModelEnum;

namespace Ludo_Web.DataEntity.Models.LudoModels.GameSquares
{
    public class SafezoneSquare : GameSquare
    {
        public SafezoneSquare(int boardX, int boardY, TeamColor? color, BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = color;
            Pawns = new List<Pawn>();
        }
    }
}