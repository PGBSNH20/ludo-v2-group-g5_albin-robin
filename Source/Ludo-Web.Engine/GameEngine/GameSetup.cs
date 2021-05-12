using System.Collections.Generic;
using System.Linq;

namespace Ludo_Web.Engine.GameEngine
{
    public static class GameSetup
    { 
        public static void LoadSavedPawns(List<PawnSavePoint> savePoints)
        {
            foreach (var sp in savePoints)
            {
                var squareToPut = BoardFinder.BoardSquares.Find(bs => sp.XPosition == bs.BoardX && sp.YPosition == bs.BoardY);
                squareToPut.Pawns.Add(new Pawn(sp.Color));
            }
        }
        public static List<ModelEnum.TeamColor> Load(List<GameSquare> gameSquares, List<(ModelEnum.TeamColor color, (int X, int Y) position)> teamCoords)
        {
            foreach (var teamCoord in teamCoords)
                gameSquares.Find(x => x.BoardX == teamCoord.position.X && x.BoardY == teamCoord.position.Y).Pawns.Add(new Pawn(teamCoord.color));

            return teamCoords.Select(x => x.color).Distinct().ToList();;
        }
        public static void NewGame(List<GameSquare> gameSquares, ModelEnum.TeamColor[] colors = null)
        {
            colors = colors ?? new ModelEnum.TeamColor[] { ModelEnum.TeamColor.Blue, ModelEnum.TeamColor.Red, ModelEnum.TeamColor.Green, ModelEnum.TeamColor.Yellow };

            var teamCoords = new List<(ModelEnum.TeamColor color, (int X, int Y) position)>();
            int pawnsCount = colors == null ? 16 : 4 * colors.Count();
            List<BaseSquare> bases = gameSquares.FindAll(x => x.GetType() == typeof(BaseSquare)).Select(x => (BaseSquare)x).ToList();

            int iTeam = 0;
            for (int i = 1; i <= pawnsCount; i++)
            {
                var teamColor = colors[iTeam];
                bases.Find(x => x.Color == teamColor).Pawns.Add(new Pawn(teamColor));
                if (i % 4 == 0) iTeam++;
            }
        }
    }
}
