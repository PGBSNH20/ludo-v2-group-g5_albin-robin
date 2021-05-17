using Ludo_Web.MVC_Game.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public class PawnComparer : IEqualityComparer<Pawn>
    {
        public bool Equals(Pawn a, Pawn b)
        {
            if
                (
                a.X == b.X &&
                a.Y == b.Y &&
                a.Color == b.Color
                ) return true;
            return false;
        }

        public int GetHashCode([DisallowNull] Pawn obj) => HashCode.Combine(obj.Color, obj.X, obj.Y);
    }
}
