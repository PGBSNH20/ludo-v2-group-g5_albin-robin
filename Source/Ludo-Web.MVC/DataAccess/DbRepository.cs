﻿using Ludo_Web.MVC.Models; using static Ludo_Web.MVC.Models.ModelEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ludo_Web.DataAccess
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
