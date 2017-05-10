using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.EntityFramework.DataBase;
using CalendarManager.Model;

namespace CalendarManager.EntityFramework.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IDataBaseSqlServerEntityFramework _dataBaseSqlServerEntityFramework;

        public LocationRepository(IDataBaseSqlServerEntityFramework dataBaseSqlServerEntityFramework)
        {
            _dataBaseSqlServerEntityFramework = dataBaseSqlServerEntityFramework;
        }

        public Location FindBy(int id)
        {
            return _dataBaseSqlServerEntityFramework.GetById<Location>(item => item.Id == id);
        }

        public IEnumerable<Location> FindBy(Expression<Func<Location, bool>> predicate)
        {
            return _dataBaseSqlServerEntityFramework.FindBy(predicate);
        }

        public void Add(Location item)
        {
            _dataBaseSqlServerEntityFramework.InsertForSystem(item);
        }

        public void Update(Location item)
        {
            _dataBaseSqlServerEntityFramework.UpdateForSystem(item);
        }

        public void Remove(Location item)
        {
            _dataBaseSqlServerEntityFramework.LogicRemoveForSystem(item);
        }
    }
}