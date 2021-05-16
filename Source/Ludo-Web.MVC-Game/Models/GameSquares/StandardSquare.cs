using Ludo_Web.MVC_Game.GameEngine;
using System.Collections.Generic;

namespace Ludo_Web.MVC_Game.Models.GameSquares
{
    public class StandardSquare : GameSquare
    {
        public StandardSquare(int boardX, int boardY, ModelEnum.BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = null;
            Pawns = new List<Pawn>();
        }
    }
}