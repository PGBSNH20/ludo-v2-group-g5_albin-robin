﻿namespace Ludo_Web.MVC_Game.Models
{
    public class Pawn
    {
        public ModelEnum.TeamColor Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Pawn(ModelEnum.TeamColor color)
        {
            Color = color;
        }
    }
}