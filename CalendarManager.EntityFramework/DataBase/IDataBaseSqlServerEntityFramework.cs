using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CalendarManager.EntityFramework.DataBase
{
    public interface IDataBaseSqlServerEntityFramework
    {
        void Insert<T>(T objectToInsert) where T : class;
        void InsertForSystem<T>(T objectToInsert) where T : class;
        void InsertMiddleEntity<T>(T objectToInsert) where T : new();
        void Update<T>(T objectToUpdate) where T : class;
        void UpdateForSystem<T>(T objectToUpdate) where T : class;
        void Remove<T>(T objectToRemove) where T : new();
        void Remove<T>(Expression<Func<T, bool>> predicate);
        void RemoveById<T>(int id) where T : new();
        void RemoveMiddleEntity<T>(T objectToRemove) where T : class;
        T GetById<T>(Expression<Func<T, bool>> predicate) where T : class;
        T FirstOrDefault<T>(Expression<Func<T, bool>> predicate) where T : class;
        void LogicRemoveById<T>(int id) where T : new();
        void LogicRemove<T>(T objectToRemove) where T : new();
        void LogicRemoveForSystem<T>(T objectToRemove) where T : new();
        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        //IEnumerable<T> FindExpressionVisitor<T>(SqlServerExpressionVisitor<T> sqlExpressionVisitor) where T : new();
        //int Count<T>(SqlServerExpressionVisitor<T> sqlExpressionVisitor) where T : new();
        int Count<T>(Expression<Func<T, bool>> predicate);
        void Commit();
        void Rollback();
        void UpdateHmac<T>(string publicKey, string time, int id) where T : new();
        IEnumerable<T> FindAll<T>();
        void InsertAll<T>(IEnumerable<T> objectsToInsert) where T : new();
        CalendarManagerContext GetDbContext();
    }
}