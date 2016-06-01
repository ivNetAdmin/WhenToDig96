
using WhenToDig96.Data;
using WhenToDig96.Data.Entities;

namespace WhenToDig96.Services
{
    public class JobService
    {
        private IRepository<Job> _repository;

        public JobService()
        {
             _repository = new Repository<Job>();
        }
    }
}
