using Ludo_Web.DataEntity.Models.Account;
using Ludo_Web.DataEntity.Models.LudoModels;
using Microsoft.EntityFrameworkCore;

namespace Ludo_Web.DataEntity.DataAccess
{
    public class LudoContext : DbContext
    {
        public LudoContext(DbContextOptions<LudoContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<AccountToken> AccountTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }

    }
}