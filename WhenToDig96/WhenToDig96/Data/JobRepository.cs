

using SQLite.Net.Async;
using SQLite.Net.Interop;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig96.Data.Entities;

namespace WhenToDig96.Data
{
    public class JobRepository
    {
        private SQLiteAsyncConnection _connection;

        public async Task InitializeAsync()
        {
            //string path, ISQLitePlatform sqlitePlatform
            //  _connection = SQLiteDatabase.GetConnection(path, sqlitePlatform);

            _connection = Xamarin.Forms.DependencyService.Get<ISQLite>().GetAsyncConnection();

            // Create Job table if need be
            await _connection.CreateTableAsync<Job>();
        }

        public async Task<Job> CreateAsync(string name)
        {
            var entity = new Job()
            {
               // Name = name
            };
            var count = await _connection.InsertAsync(entity);
            return (count == 1) ? entity : null;
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            //.OrderBy(m => m.Name)
            var entities = await _connection.Table<Job>().ToListAsync();
            return entities;
        }
    }
}
