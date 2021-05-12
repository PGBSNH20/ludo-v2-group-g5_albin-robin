using static Ludo_Web.DataEntity.Models.ModelEnum;

namespace Ludo_Web.DataEntity.Models.LudoModels
{
    public class PawnSavePoint
    {
        public int Id { get; set; }
        public TeamColor Color { get; set; }
        public int PlayerType { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}
