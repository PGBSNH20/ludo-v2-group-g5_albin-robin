using LudoEngine.BoardCollection.Models;
using LudoEngine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LudoEngine.DbModel
{
    public class LudoContextMod : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<GameSquare> GameSquares { get; set; }
        public DbSet<LudoBoard> LudoBoards { get; set; }
        public DbSet<Pawn> Pawns { get; set; }
        public LudoContextMod() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"Server=DESKTOP-4AJB8DD\\SQLEXPRESS;Database=LudoBase_0.01;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}