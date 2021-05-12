using System.Linq;
using Ludo_Web.DataEntity.Models.Account;
using Ludo_Web.DataEntity.Models.LudoModels;

namespace Ludo_Web.DataEntity.DataAccess
{
    public class DbRepository : ILudoRepository
    {
        private readonly LudoContext _db;
        public DbRepository(LudoContext db) => _db = db;
        public IQueryable<Player> Players => _db.Players;
        public IQueryable<Game> Games => _db.Games;
        public IQueryable<AccountToken> AccountTokens => _db.AccountTokens;
        public void Add<TEntityType>(TEntityType entity) => _db.Add(entity);
        public void Remove<TEntityType>(TEntityType entity) => _db.Remove(entity);
        public void SaveChanges() => _db.SaveChanges();
        public void Update<TEntityType>(TEntityType entity) => _db.Remove(entity);
    }
}
