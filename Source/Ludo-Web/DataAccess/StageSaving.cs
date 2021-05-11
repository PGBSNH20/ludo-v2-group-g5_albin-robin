using Ludo_Web.Models;
using LudoEngine.Models;
using System.Collections.Generic;

namespace Ludo_Web.DataAccess
{
    public static class StageSaving {
        public static List<Pawn> Pawns { get; set;}

        public static string Game { get; set; }

        public static List<string> Players { get; set; }

        public static List<PawnSavePoint> TeamPosition { get; set; }

        public static int CurrentTeam { get; set; }
    }

}