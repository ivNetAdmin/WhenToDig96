
using SQLite;

namespace WhenToDig96.Data.Entities
{
    public class BaseEntity 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
