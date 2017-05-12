using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Repositories
{
    public class SharedLocationRepository : ISharedLocationRepository
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;

        public SharedLocationRepository(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public SharedLocation FindBy(int id)
        {
            return _dataBaseSqlServerEntityFramework.GetById<SharedLocation>(item => item.Id == id);
        }

        public IEnumerable<SharedLocation> FindBy(Expression<Func<SharedLocation, bool>> predicate)
        {
            return _dataBaseSqlServerEntityFramework.FindBy(predicate);
        }

        public void Add(SharedLocation item)
        {
            _dataBaseSqlServerEntityFramework.InsertForSystem(item);
        }

        public void Update(SharedLocation item)
        {
            _dataBaseSqlServerEntityFramework.UpdateForSystem(item);
        }

        public void Remove(SharedLocation item)
        {
            _dataBaseSqlServerEntityFramework.LogicRemoveForSystem(item);
        }
    }
}