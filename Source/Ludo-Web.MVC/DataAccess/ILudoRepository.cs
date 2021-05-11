using Ludo_Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludo_Web.DataAccess
{
    interface ILudoRepository
    {
        IQueryable<Player> Players { get; }
        IQueryable<Game> Games { get; }
        IQueryable<UserToken> UserTokens { get; }
        IQueryable<GameState> GameStates { get; }
        IQueryable<GamePosition> GamePositions { get; }
        void Add<TEntityType>(TEntityType entity);
        void Update<TEntityType>(TEntityType entity);
        void Remove<TEntityType>(TEntityType entity);
        void SaveChanges();
    }
}
