using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;

        public UserRepository(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public User FindBy(int id)
        {
            return _dataBaseSqlServerEntityFramework.GetById<User>(item => item.Id == id);
        }

        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return _dataBaseSqlServerEntityFramework.FindBy(predicate);
        }

        public void Add(User item)
        {
            _dataBaseSqlServerEntityFramework.InsertForSystem(item);
        }

        public void Update(User item)
        {
            _dataBaseSqlServerEntityFramework.UpdateForSystem(item);
        }

        public void Remove(User item)
        {
            _dataBaseSqlServerEntityFramework.LogicRemoveForSystem(item);
        }

        public User FindUserByPublicKey(string publicKey)
        {
            return _dataBaseSqlServerEntityFramework.FindBy<User>(user => user.PublicKey == publicKey).FirstOrDefault();
        }
    }
}