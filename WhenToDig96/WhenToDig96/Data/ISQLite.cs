using SQLite;

namespace WhenToDig96.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
