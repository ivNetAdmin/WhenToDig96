using System;
using Xamarin.Forms;
using System.IO;
using WhenToDig96.Droid.Data;
using WhenToDig96.Data;

[assembly: Dependency(typeof(SQLite_Android))]

namespace WhenToDig96.Droid.Data
{
    class SQLite : ISQLite
    {
        public SQLite_Android()
        {
        }
        #region ISQLite implementation
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "WTGSQLite.db3";
            // Documents folder
            string documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal); 

            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection 
            return conn;
        }
        #endregion
    }
}
