﻿using System.Collections.Generic;

namespace Ludo_Web.MVC_Game.Models.GameSquares
{
    public class StartSquare : GameSquare
    {
        public StartSquare(int boardX, int boardY, ModelEnum.TeamColor? color, ModelEnum.BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = color;
            Pawns = new List<Pawn>();
        }
    }
}