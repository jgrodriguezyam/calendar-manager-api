using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;

        public CheckInRepository(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public CheckIn FindBy(int id)
        {
            return _dataBaseSqlServerEntityFramework.GetById<CheckIn>(item => item.Id == id);
        }

        public IEnumerable<CheckIn> FindBy(Expression<Func<CheckIn, bool>> predicate)
        {
            return _dataBaseSqlServerEntityFramework.FindBy(predicate);
        }

        public void Add(CheckIn item)
        {
            _dataBaseSqlServerEntityFramework.InsertForSystem(item);
        }

        public void Update(CheckIn item)
        {
            _dataBaseSqlServerEntityFramework.UpdateForSystem(item);
        }

        public void Remove(CheckIn item)
        {
            _dataBaseSqlServerEntityFramework.LogicRemoveForSystem(item);
        }
    }
}