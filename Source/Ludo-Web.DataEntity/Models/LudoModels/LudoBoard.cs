using System.Collections.Generic;

namespace Ludo_Web.DataEntity.Models.LudoModels
{
    public class LudoBoard
    {
        public int Id { get; set; }
        public ICollection<GameSquare> GameSquares { get; set; }
    }
}
