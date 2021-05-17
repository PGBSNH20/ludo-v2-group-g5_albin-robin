using LudoAPI.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace LudoAPI.DataAccess
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