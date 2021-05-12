
using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using Ludo_Web.MVC.GameEngine;
using Ludo_Web.MVC.GameEngine.Interfaces;
using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.MVC.GameEngine
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
        public static List<TeamColor> Load(List<GameSquare> gameSquares, List<(TeamColor color, (int X, int Y) position)> teamCoords)
        {
            foreach (var teamCoord in teamCoords)
                gameSquares.Find(x => x.BoardX == teamCoord.position.X && x.BoardY == teamCoord.position.Y).Pawns.Add(new Pawn(teamCoord.color));

            return teamCoords.Select(x => x.color).Distinct().ToList();;
        }
        public static void NewGame(List<GameSquare> gameSquares, TeamColor[] colors = null)
        {
            colors = colors ?? new TeamColor[] { TeamColor.Blue, TeamColor.Red, TeamColor.Green, TeamColor.Yellow };

            var teamCoords = new List<(TeamColor color, (int X, int Y) position)>();
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
