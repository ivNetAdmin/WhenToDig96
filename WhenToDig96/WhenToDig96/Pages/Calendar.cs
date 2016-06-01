
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
        }
    }
}
