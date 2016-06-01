﻿
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite.Net.Async;
using WhenToDig96.Data.Entities;

namespace WhenToDig96.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SQLiteAsyncConnection _connection;

        public Repository()
        {
            _connection = Xamarin.Forms.DependencyService.Get<ISQLite>().GetAsyncConnection();
            Initialise();
        }

        private async void Initialise()
        {
            await _connection.CreateTableAsync<Job>();
            await _connection.CreateTableAsync<Plant>();
            await _connection.CreateTableAsync<Variety>();
            await _connection.CreateTableAsync<Location>();
            await _connection.CreateTableAsync<Frost>();
        }

        public AsyncTableQuery<T> AsQueryable()
        {
            return _connection.Table<T>();
        }

        public async Task<List<T>> Get()
        {
            return await _connection.Table<T>().ToListAsync();
        }

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _connection.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = query.OrderBy<TValue>(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _connection.FindAsync<T>(id);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _connection.FindAsync<T>(predicate);
        }

        public async Task<int> Insert(T entity)
        {
            return await _connection.InsertAsync(entity);
        }

        public async Task<int> Update(T entity)
        {
            return await _connection.UpdateAsync(entity);
        }

        public async Task<int> Delete(T entity)
        {
            return await _connection.DeleteAsync(entity);
        }
       
    }
}
