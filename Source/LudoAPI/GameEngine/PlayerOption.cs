using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public class PlayerOption
    {
        public PlayerOption(Pawn[] pawns, bool canTakeOutTwo, int diceRoll)
        {
            PawnsToMove = pawns;
            CanTakeOutTwo = canTakeOutTwo;
            DiceRoll = diceRoll;
        }
        public Pawn[] PawnsToMove { get; set; }
        public bool CanTakeOutTwo { get; set; }
        public int DiceRoll { get; set; }
    }
}
