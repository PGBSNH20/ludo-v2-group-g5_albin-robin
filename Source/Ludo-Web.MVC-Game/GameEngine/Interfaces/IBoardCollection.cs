using System.Collections.Generic;
using Ludo_Web.MVC_Game.GameEngine.GameSquares;
using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.GameEngine.Interfaces
{
    public interface IBoardCollection
    {
        void SetAllPawn(List<Pawn> pawns);
        List<ModelEnum.TeamColor> TeamsLeft();
        List<Pawn> EnemiesOnSquare(GameSquare targetSquare, ModelEnum.TeamColor color);
        bool IsOccupiedByTeam(ModelEnum.TeamColor color, GameSquare square);
        List<Pawn> PawnsInBase(ModelEnum.TeamColor color);
        List<Pawn> PawnsOnSquare(GameSquare square);
        List<Pawn> GetFreeTeamPawns(ModelEnum.TeamColor color);
        GameSquare CurrentSquare(Pawn pawn);
        GameSquare PastSquare(GameSquare square, ModelEnum.TeamColor color);
        List<Pawn> GetTeamPawns(ModelEnum.TeamColor color);
        Pawn FurthestPawn(ModelEnum.TeamColor color);
        List<GameSquare> EnemySquares(ModelEnum.TeamColor color);
        GameSquare GoalSquare();
        List<GameSquare> SafeZoneSquares(ModelEnum.TeamColor color);
        GameSquare StartSquare(ModelEnum.TeamColor color);
        GameSquare BaseSquare(ModelEnum.TeamColor color);
        List<GameSquare> TeamPath(ModelEnum.TeamColor color);
        GameSquare GetNext(GameSquare square, ModelEnum.TeamColor color);
        GameSquare GetBack(GameSquare square, ModelEnum.TeamColor color);
    }
}