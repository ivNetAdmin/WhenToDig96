
using SQLite.Net.Async;

namespace WhenToDig96.Data
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}

