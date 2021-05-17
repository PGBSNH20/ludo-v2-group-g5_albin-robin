using LudoAPI.DataAccess;

namespace LudoAPI.Models
{
    public class PawnSavePoint
    {
        public int Id { get; set; }
        public ModelEnum.TeamColor Color { get; set; }
        public int PlayerType { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}
