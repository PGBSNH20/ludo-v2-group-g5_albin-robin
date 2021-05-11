using Ludo_Web.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static Ludo_Web.MVC.Models.PropertyEnums;

namespace Ludo_Web.DataAccess
{
    public class LudoContext : DbContext
    {
        public LudoContext(DbContextOptions<LudoContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<GamePosition> GamePositions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameState>()
                .HasKey(o => new { o.GameId, o.PlayerId }); //Composite key => only same player once in every game.
            modelBuilder.Entity<GameState>()
                .HasAlternateKey(o => new { o.TeamColor, o.GameId }); //Unique constraint color and game => no duplicate colors.
            modelBuilder.Entity<GameState>()
                .HasAlternateKey(o => new { o.EndResult, o.GameId, });

            modelBuilder.Entity<Player>()
                .HasAlternateKey(o => new { o.EmailAdress });

            modelBuilder.Entity<Player>()
                .Property(p => p.PlayerType)
                .HasConversion(x => x.ToString(), x => (PlayerType)Enum.Parse(typeof(PlayerType), x));

            modelBuilder.Entity<Player>()
               .Property(p => p.Language)
               .HasConversion(x => x.ToString(), x => (Language)Enum.Parse(typeof(Language), x));

            modelBuilder.Entity<GameState>()
               .Property(p => p.TeamColor)
               .HasConversion(x => x.ToString(), x => (TeamColor)Enum.Parse(typeof(TeamColor), x));
            
            modelBuilder.Entity<GameState>()
               .Property(p => p.EndResult)
               .HasConversion(x => (int)x, x => (EndResult)x);

            modelBuilder.Entity<Game>()
                .Property(p => p.GameStatus)
                .HasConversion(x => x.ToString(), x => (GameStatus)Enum.Parse(typeof(GameStatus), x));
        }

    }
}