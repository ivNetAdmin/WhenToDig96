
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        internal void Add(string name)
        {
            var entity = new Job
            {
                Name = name
            };

            _repository.Insert(entity);
        }

        internal Task<List<Job>> GetAll()
        {
            return _repository.Get();
        }
    }
}
