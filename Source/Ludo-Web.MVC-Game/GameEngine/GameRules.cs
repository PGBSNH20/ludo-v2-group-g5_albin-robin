using System.Collections.Generic;
using System.Linq;
using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public static class GameRules
    {
        public static List<Pawn> SelectablePawns(ModelEnum.TeamColor color, int dieRoll)
        {
            var pawnsInBase = BoardFinder.PawnsInBase(color);
            var activeSquares = BoardFinder.PawnBoardSquares(color);

            if (dieRoll == 1 || dieRoll == 6)
                return activeSquares.SelectMany(x => x.Pawns).Concat(pawnsInBase).ToList();
            else
                return activeSquares.SelectMany(x => x.Pawns).ToList(); 
        }
        //public static void SaveFirstTime(TeamColor currentTurn) => DatabaseManagement.SaveAndGetGame(currentTurn);
        public static bool CanTakeOutTwo(ModelEnum.TeamColor color, int diceRoll) => BoardFinder.PawnsInBase(color).Count > 1 && diceRoll == 6;
    }
}
