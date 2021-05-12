using System.Linq;
using Ludo_Web.DataEntity.Models.Account;
using Ludo_Web.DataEntity.Models.LudoModels;

namespace Ludo_Web.DataEntity.DataAccess
{
    public interface ILudoRepository
    {
        IQueryable<Player> Players { get; }
        IQueryable<Game> Games { get; }
        IQueryable<AccountToken> AccountTokens { get; }
        void Add<TEntityType>(TEntityType entity);
        void Update<TEntityType>(TEntityType entity);
        void Remove<TEntityType>(TEntityType entity);
        void SaveChanges();
    }
}
