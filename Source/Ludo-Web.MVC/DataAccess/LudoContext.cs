using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using Microsoft.EntityFrameworkCore;
using System;
using static Ludo_Web.MVC.Models.ModelEnum;

namespace Ludo_Web.DataAccess
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