namespace Ludo_Web.MVC.Models
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
        public enum EndResult
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4
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
        public enum Language
        {
            en_US,
            sv_SE
        }
    }
}
