using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Repositories
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;

        public FriendshipRepository(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public Friendship FindBy(int id)
        {
            return _dataBaseSqlServerEntityFramework.GetById<Friendship>(item => item.Id == id);
        }

        public IEnumerable<Friendship> FindBy(Expression<Func<Friendship, bool>> predicate)
        {
            return _dataBaseSqlServerEntityFramework.FindBy(predicate);
        }

        public void Add(Friendship item)
        {
            _dataBaseSqlServerEntityFramework.InsertForSystem(item);
        }

        public void Update(Friendship item)
        {
            _dataBaseSqlServerEntityFramework.UpdateForSystem(item);
        }

        public void Remove(Friendship item)
        {
            _dataBaseSqlServerEntityFramework.LogicRemoveForSystem(item);
        }
    }
}