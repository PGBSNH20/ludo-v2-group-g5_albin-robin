﻿using System.Linq;
using Ludo_Web.MVC_Game.Models;
using Ludo_Web.MVC_Platform.Models.Account;

namespace Ludo_Web.MVC_Game.DataAccess
{
    public interface ILudoGameRepository
    {
        IQueryable<GamePlayer> Players { get; }
        IQueryable<Game> Games { get; }
        IQueryable<AccountToken> AccountTokens { get; }
        void Add<TEntityType>(TEntityType entity);
        void Update<TEntityType>(TEntityType entity);
        void Remove<TEntityType>(TEntityType entity);
        void SaveChanges();
    }
}
