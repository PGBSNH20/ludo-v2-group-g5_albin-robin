using System;
using System.Collections.Generic;
using static Ludo_Web.MVC.Models.PropertyEnums;

namespace Ludo_Web.MVC.Models
{
    public record GamePosition
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public TeamColor TeamColor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}