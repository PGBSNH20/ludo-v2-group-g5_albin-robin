using Ludo_Web.MVC_Game.Models;
using Ludo_Web.MVC_Platform.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Ludo_Web.MVC_Game.DataAccess
{
    public class LudoGameContext : DbContext
    {
        public LudoGameContext(DbContextOptions<LudoGameContext> options) : base(options) { }
        public DbSet<GamePlayer> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<AccountToken> AccountTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }

    }
}