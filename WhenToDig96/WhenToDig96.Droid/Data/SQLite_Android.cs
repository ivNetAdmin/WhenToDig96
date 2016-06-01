
using SQLite.Net;
using SQLite.Net.Async;
using System;
using System.IO;
using WhenToDig96.Data;
using WhenToDig96.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace WhenToDig96.Droid.Data
{
    //public class SQLite_Android : ISQLite
    //{
    //    public SQLite_Android()
    //    {
    //    }

    //    public SQLiteAsyncConnection GetConnection()
    //    {
    //        var sqliteFilename = "WTD.db3";
    //        // Documents folder
    //        string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    //        var path = Path.Combine(documentsPath, sqliteFilename);

    //        SQLite.Net.Interop.ISQLitePlatform platform = null;

    //        var param = new SQLiteConnectionString(path, false);
    //        var connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, param));
    //        return connection;
    //    }
    //}


    public class SQLite_Android : ISQLite
    {

        private SQLiteConnectionWithLock _conn;

        public SQLite_Android()
        {
        }

        private string GetDatabasePath()
        {
            var sqliteFilename = "Wtd.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var dbpath = GetDatabasePath();

            var platForm = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

            var connectionFactory = new Func<SQLiteConnectionWithLock>(
                () =>
                {
                    if (_conn == null)
                    {
                        _conn =
                            new SQLiteConnectionWithLock(platForm,
                                new SQLiteConnectionString(dbpath, storeDateTimeAsTicks: false));
                    }
                    return _conn;
                });

            return new SQLiteAsyncConnection(connectionFactory);
        }

    }

}