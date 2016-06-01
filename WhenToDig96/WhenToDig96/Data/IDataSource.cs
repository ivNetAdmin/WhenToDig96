
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhenToDig96.Data
{
    public interface IDataSource<T>
    {
        Task SaveItem(T item);
        Task DeleteItem(int id);
        Task<T> GetItem(int id);
        Task<ICollection<T>> GetItems(int start = 0, int count = 100, string query = "");
    }
}
