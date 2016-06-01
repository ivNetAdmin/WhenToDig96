
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhenToDig96.Data;
using WhenToDig96.Data.Entities;
using WhenToDig96.Helpers;
using WhenToDig96.Services;
using WhenToDig96.Services.Interfaces;
using WhenToDig96.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(JobService))]
namespace WhenToDig96.Services
{
    public class JobService : IJobService
    {
        private IRepository<Job> _repository;
        private IMapper _mapper;

        private static readonly AsyncLock Locker = new AsyncLock();

        public JobService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Job, JobViewModel>();
            });

            _mapper = mapperConfig.CreateMapper();

            _repository = new Repository<Job>();
        }

        public async Task Add(string name)
        {
            var entity = new Job
            {
                Name = name
            };

            using (await Locker.LockAsync())
            {
                await _repository.Insert(entity);
            }
        }

        public async Task<IList<Job>> GetAll()
        {
            using (await Locker.LockAsync())
            {
                return await _repository.Get();
            }
        }

        //public async Task<Job> Add(string name)
        //{
        //    var entity = new Job
        //    {
        //        Name = name
        //    };

        //    await _repository.Insert(entity).ConfigureAwait(false);

        //    return entity;
        //}

        //public async Task<List<JobViewModel>> GetAll()
        //{
        //    var jobs = await _repository.Get().ConfigureAwait(false);

        //    var jobViewModels = await Task.Run(() =>
        //        _mapper.Map<List<Job>, List<JobViewModel>>(jobs)
        //    ).ConfigureAwait(false);

        //    return jobViewModels;
        //}
    }
}
