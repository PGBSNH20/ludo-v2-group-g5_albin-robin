﻿
using LudoEngine.Enum;
using LudoEngine.Models;
using System.Collections.Generic;

namespace LudoEngine.BoardCollection.Models
{
    public class ExitSquare : GameSquare
    {
        public ExitSquare(int boardX, int boardY, TeamColor? color, BoardDirection direction)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = direction;
            Color = color;
            Pawns = new List<Pawn>();
        }
        public override BoardDirection DirectionNext(TeamColor Color)
        {
            if (this.Color == Color)
            {
                return
                    Color == TeamColor.Yellow ? BoardDirection.Up :
                    Color == TeamColor.Blue ? BoardDirection.Right :
                    Color == TeamColor.Red ? BoardDirection.Down : BoardDirection.Left;
            }
            else
                return DefaultDirection;
        }
    }
}