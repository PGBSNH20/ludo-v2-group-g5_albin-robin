
using LudoEngine.Enum;
using LudoEngine.Models;
using System.Collections.Generic;

namespace LudoEngine.BoardCollection.Models
{
    public class GoalSquare : GameSquare
    {
        public GoalSquare(int boardX, int boardY)
        {
            BoardX = boardX;
            BoardY = boardY;
            DefaultDirection = 0;
            Color = null;
            Pawns = new List<Pawn>();
        }
        public override BoardDirection DirectionNext(TeamColor Color)
        {
            return
               Color == TeamColor.Yellow ? BoardDirection.Up :
               Color == TeamColor.Blue ? BoardDirection.Right :
               Color == TeamColor.Red ? BoardDirection.Down : BoardDirection.Left;
        }
    }
}