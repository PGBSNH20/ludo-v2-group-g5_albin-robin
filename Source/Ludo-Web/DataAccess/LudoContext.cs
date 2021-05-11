using Ludo_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ludo_Web.DataAccess
{
    public class LudoContext : DbContext
    {
        public LudoContext(DbContextOptions<LudoContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStat> GameStats { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
    }
}