
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using WhenToDig96.Data.Entities;
using WhenToDig96.Services.Interfaces;
using Xamarin.Forms;

namespace WhenToDig96.ViewModels
{
    public class JobViewModel : BaseViewModel
    {
        private static IJobService JobService { get; } = DependencyService.Get<IJobService>();

        public JobViewModel(Page page)
        {
            page.Appearing += async (sender, e) =>
                 {
                     await AddJob();
                     await BindJobs();
                 };
        }

        private IList<Job> _jobs;
        public IList<Job> Jobs
        {
            get { return _jobs; }
            private set { SetPropertyValue(ref _jobs, value); }
        }

        private async Task AddJob()
        {
            await JobService.Add("Cakes");
        }

        private async Task BindJobs()
        {
            Jobs = await JobService.GetAll();
        }
    }
}