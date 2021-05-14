using Ludo_Web.MVC_Game.Models;
using System.Collections.Generic;

namespace Ludo_Web.MVC_Game.GameEngine
{
    public interface IBoardSearch
    { 
        List<Pawn> AllBaseAndPlayingPawns();
        List<Pawn> AllPlayingPawns();
        GameSquare BaseSquare(ModelEnum.TeamColor color);
        GameSquare FindPawnSquare(Pawn pawn);
        GameSquare GetBack(List<GameSquare> squares, GameSquare square, ModelEnum.TeamColor color);
        GameSquare GetNext(List<GameSquare> squares, GameSquare square, ModelEnum.TeamColor color);
        List<Pawn> GetTeamPawns(ModelEnum.TeamColor color);
        bool IsMoreThenOneTeamLeft();
        List<Pawn> OutOfBasePawns(ModelEnum.TeamColor color);
        List<GameSquare> PawnBoardSquares(ModelEnum.TeamColor color);
        List<Pawn> PawnsInBase(ModelEnum.TeamColor color);
        ModelEnum.BoardDirection ReverseDirection(ModelEnum.BoardDirection direction);
        GameSquare StartSquare(ModelEnum.TeamColor color);
        List<GameSquare> TeamPath(ModelEnum.TeamColor color);
    }
}