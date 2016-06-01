
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig96.Data.Entities;

namespace WhenToDig96.Services.Interfaces
{
    public interface IJobService
    {
        Task Add(string name);

        Task<IList<Job>> GetAll();
    }
}
