using LudoEngine.Models;
using System.Collections.Generic;

namespace LudoEngine.DbModel
{
    public static class StageSaving {
        public static List<Pawn> Pawns { get; set;}

        public static OldGame Game { get; set; }

        public static List<Player> Players { get; set; }

        public static List<PawnSavePoint> TeamPosition { get; set; }

        public static int CurrentTeam { get; set; }
    }

}