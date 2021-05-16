using Ludo_Web.MVC_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ludo_Web.MVC_Game.Models.ModelEnum;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public static class GameEvent
    {

        public static event Action<Pawn> OnBounceEvent;
        public static event Action<Pawn, int> OnGoalEvent;
        public static event Action<Pawn, TeamColor, int> OnEradicationEvent;
        public static event Action<TeamColor> GameLoserEvent;
        public static event Action<Pawn> OnSafeZoneEvent;
        public static event Action GameOverEvent;
        
        public static event Action<Pawn> OnAllTeamPawnsOutEvent;
        public static event Action<GamePlayer, int> HumanThrowEvent;
        public static event Action<Stephan, int> StephanThrowEvent;
        public static event Action<GamePlayer> OnTakeOutTwoPossibleEvent;
    }
}
