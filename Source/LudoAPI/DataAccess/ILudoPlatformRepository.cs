using System.Linq;
using LudoAPI.Models.Account;

namespace LudoAPI.DataAccess
{
    public interface ILudoPlatformRepository
    {
        IQueryable<AccountToken> AccountTokens { get; }
        void Add<TEntityType>(TEntityType entity);
        void Update<TEntityType>(TEntityType entity);
        void Remove<TEntityType>(TEntityType entity);
        void SaveChanges();
    }
}
