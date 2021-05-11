using Ludo_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using static Ludo_Web.Models.PropertyEnums;

namespace Ludo_Web.DataAccess
{
    public class LudoContext : DbContext
    {
        public LudoContext(DbContextOptions<LudoContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameState> GameStates { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameState>()
                .HasKey(o => new { o.GameId, o.PlayerId }); //Composite key => only same player once in every game.
            modelBuilder.Entity<GameState>()
                .HasAlternateKey(o => new { o.TeamColor, o.GameId }); //Unique constraint color and game => no duplicate colors.

            modelBuilder.Entity<Player>()
                .HasAlternateKey(o => new { o.EmailAdress });

            modelBuilder.Entity<Player>()
                .Property(p => p.PlayerType)
                .HasConversion(x => x.ToString(), x => (PlayerType)Enum.Parse(typeof(PlayerType), x));
            
            modelBuilder.Entity<GameState>()
               .Property(p => p.TeamColor)
               .HasConversion(x => x.ToString(), x => (TeamColor)Enum.Parse(typeof(TeamColor), x));
            
            modelBuilder.Entity<GameState>()
               .Property(p => p.EndPosition)
               .HasConversion(x => x.ToString(), x => (EndPosition)Enum.Parse(typeof(EndPosition), x));

            modelBuilder.Entity<Game>()
                .Property(p => p.GameStatus)
                .HasConversion(x => x.ToString(), x => (GameStatus)Enum.Parse(typeof(GameStatus), x));
        }

    }
}