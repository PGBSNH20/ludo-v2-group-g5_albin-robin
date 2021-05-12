﻿
using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using System.Collections.Generic;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.MVC.Models
{
    public abstract class GameSquare
    {
        public int Id { get; set; }//only db
        public int LudoBoardId { get; set; } //only db
        public TeamColor? Color { get; set; }
        public int BoardX { get; set; }
        public int BoardY { get; set; }
        public List<Pawn> Pawns { get; set; } //Map to ICollection
        public BoardDirection DefaultDirection { get; set; }
        public virtual BoardDirection DirectionNext(TeamColor Color) => DefaultDirection;
    }
}