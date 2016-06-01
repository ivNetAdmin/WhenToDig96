
using WhenToDig96.Services;
using Xamarin.Forms;

namespace WhenToDig96.Pages
{
    public class Calendar : ContentPage
    {
        JobService _jobService;

        public Calendar()
        {
            _jobService = new JobService();

            _jobService.Add("Tom");
            _jobService.Add("Dick");
            _jobService.Add("Sally");

            var jobs = _jobService.GetAll();
        }
    }
}
