
using WhenToDig96.Services;
using WhenToDig96.ViewModels;
using Xamarin.Forms;

namespace WhenToDig96.Pages
{
    public class Calendar : ContentPage
    {
        //JobService _jobService;

        public Calendar()
        {
            var jobvm = new JobViewModel(this);

            this.Content = new ListView
            {
                ItemsSource = jobvm.Jobs,
                ItemTemplate = new DataTemplate(() =>
                {

                    var job = new Label
                    {
                       // Text = "Cakes"
                    };
                    job.SetBinding(Label.TextProperty, "Name");

                    var viewCell = new ViewCell
                    {
                        View = job
                    };

                    return viewCell;
                })

            };
        }
    }
}
