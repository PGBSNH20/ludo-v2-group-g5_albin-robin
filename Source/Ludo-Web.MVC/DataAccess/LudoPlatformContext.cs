using Ludo_Web.MVC.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Ludo_Web.MVC.DataAccess
{
    public class LudoPlatformContext : DbContext
    {
        public LudoPlatformContext(DbContextOptions<LudoPlatformContext> options) : base(options) { }
        public DbSet<AccountToken> AccountTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
        }

    }
}