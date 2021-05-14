using System.Linq;
using Ludo_Web.MVC_Platform.Models.Account;

namespace Ludo_Web.MVC_Platform.DataAccess
{
    public class DbPlatformRepository : ILudoPlatformRepository
    {
        private readonly LudoPlatformContext _db;
        public DbPlatformRepository(LudoPlatformContext db) => _db = db;
        public IQueryable<AccountToken> AccountTokens => _db.AccountTokens;
        public void Add<TEntityType>(TEntityType entity) => _db.Add(entity);
        public void Remove<TEntityType>(TEntityType entity) => _db.Remove(entity);
        public void SaveChanges() => _db.SaveChanges();
        public void Update<TEntityType>(TEntityType entity) => _db.Remove(entity);
    }
}
