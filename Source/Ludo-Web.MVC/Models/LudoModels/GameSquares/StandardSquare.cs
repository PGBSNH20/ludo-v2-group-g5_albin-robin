
using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using System.Collections.Generic;

namespace Ludo_Web.MVC.Models
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