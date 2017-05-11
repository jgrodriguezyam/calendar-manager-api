using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CalendarManager.DataAccess.Listeners;

namespace CalendarManager.EntityFramework.DataBase
{
    public class DataBaseSqlServerEntityFramework : IDataBaseSqlServerEntityFramework
    {
        public CalendarManagerContext DbContext;
        public DbContextTransaction DbContextTransaction;
        public IAuditEventListener AuditEventListener;

        public void Insert<T>(T objectToInsert) where T : class
        {
            AuditEventListener.OnPreInsert(objectToInsert);
            DbContext.Set<T>().Add(objectToInsert);
            DbContext.SaveChanges();
        }

        public void InsertForSystem<T>(T objectToInsert) where T : class
        {
            AuditEventListener.OnPreInsertForSystem(objectToInsert);
            DbContext.Set<T>().Add(objectToInsert);
            DbContext.SaveChanges();
        }

        public void InsertMiddleEntity<T>(T objectToInsert) where T : new()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T objectToUpdate) where T : class
        {
            AuditEventListener.OnPreUpdate(objectToUpdate);
            DbContext.SaveChanges();
        }

        public void UpdateForSystem<T>(T objectToUpdate) where T : class
        {
            AuditEventListener.OnPreUpdateForSystem(objectToUpdate);
            DbContext.SaveChanges();
        }

        public void Remove<T>(T objectToRemove) where T : new()
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveById<T>(int id) where T : new()
        {
            throw new NotImplementedException();
        }

        public void RemoveMiddleEntity<T>(T objectToRemove) where T : class
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DbContext.Set<T>().FirstOrDefault(predicate);
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DbContext.Set<T>().FirstOrDefault(predicate);
        }

        public void LogicRemoveById<T>(int id) where T : new()
        {
            throw new NotImplementedException();
        }

        public void LogicRemove<T>(T objectToRemove) where T : new()
        {
            AuditEventListener.OnPreDelete(objectToRemove);
            DbContext.SaveChanges();
        }

        public void LogicRemoveForSystem<T>(T objectToRemove) where T : new()
        {
            AuditEventListener.OnPreDeleteForSystem(objectToRemove);
            DbContext.SaveChanges();
        }

        public IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public int Count<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            DbContextTransaction.Commit();
            DbContext.Dispose();
        }

        public void Rollback()
        {
            DbContextTransaction.Rollback();
            DbContext.Dispose();
        }

        public void UpdateHmac<T>(string publicKey, string time, int id) where T : new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new NotImplementedException();
        }

        public void InsertAll<T>(IEnumerable<T> objectsToInsert) where T : new()
        {
            throw new NotImplementedException();
        }

        public CalendarManagerContext GetDbContext()
        {
            return DbContext;
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return DbContext.Set<T>();
        }
    }
}