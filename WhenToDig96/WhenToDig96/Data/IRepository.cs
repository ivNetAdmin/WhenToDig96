
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WhenToDig96.Data
{
    //public interface IDataSource<T>
    //{
    //    Task SaveItem(T item);
    //    Task DeleteItem(int id);
    //    Task<T> GetItem(int id);
    //    Task<ICollection<T>> GetItems(int start = 0, int count = 100, string query = "");
    //}

    public interface IRepository<T> where T : class
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        AsyncTableQuery<T> AsQueryable();
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
    }
}
