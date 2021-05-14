using System.Linq;
using Ludo_Web.MVC.Models.Account;
using Ludo_Web.MVC_Game.Models;

namespace Ludo_Web.MVC_Game.DataAccess
{
    public class DbGameRepository : ILudoGameRepository
    {
        private readonly LudoGameContext _db;
        public DbGameRepository(LudoGameContext db) => _db = db;
        public IQueryable<Player> Players => _db.Players;
        public IQueryable<Game> Games => _db.Games;
        public IQueryable<AccountToken> AccountTokens => _db.AccountTokens;
        public void Add<TEntityType>(TEntityType entity) => _db.Add(entity);
        public void Remove<TEntityType>(TEntityType entity) => _db.Remove(entity);
        public void SaveChanges() => _db.SaveChanges();
        public void Update<TEntityType>(TEntityType entity) => _db.Remove(entity);
    }
}
