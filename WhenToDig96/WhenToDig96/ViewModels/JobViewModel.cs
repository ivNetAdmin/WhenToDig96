
using System.ComponentModel;

namespace WhenToDig96.ViewModels
{
    public class JobViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public JobViewModel()
        {

        }

        private string _name;
        public string Name
        {
            set
            {
                if(_name != value)
                {
                    _name = value;
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
            get
            {
                return _name;
            }
        }
    }
}
