using System.Linq;
using Ludo_Web.MVC_Platform.Models.Account;

namespace Ludo_Web.MVC_Platform.DataAccess
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
