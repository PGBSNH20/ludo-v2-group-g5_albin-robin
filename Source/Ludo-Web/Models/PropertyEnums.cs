using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludo_Web.Models
{
    //https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations //ValueConversion
    //https://www.entityframeworktutorial.net/EntityFramework5/enum-in-entity-framework5.aspx //Enumsettings in SSM
    public static class PropertyEnums
    {
        public enum TeamColor
        {
            Yellow,
            Blue,
            Green,
            Red
        }
        public enum EndPosition
        {
            First,
            Second,
            Third,
            Fourth
        }
        public enum GameStatus
        {
            Created,
            WaitingForAllPlayers,
            Playing,
            Paused,
            Aborted,
            Exception,
            Ended
        }
        public enum PlayerType
        {
            StephanAI,
            Amateur,
            Professional
        }
    }
}
