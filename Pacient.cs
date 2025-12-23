using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zad8_trpo
{
    public class Pacient : INotifyPropertyChanged
    {
        private int _id = 0;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private string _name = "";
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _lastName = "";
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        private string _middleName = "";
        public string MiddleName
        {
            get => _middleName;
            set { _middleName = value; OnPropertyChanged(); }
        }

        private DateTime _birthday = new DateTime(1920, 01, 01);
        public DateTime Birthday
        {
            get => _birthday;
            set { _birthday = value; OnPropertyChanged(); }
        }
        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        private DateTime _lastAppointment = DateTime.Today;
        public DateTime LastAppointment
        {
            get => _lastAppointment;
            set { _lastAppointment = value; OnPropertyChanged(); }
        }
        private int _lastDoctor = 0;
        public int LastDoctor
        {
            get => _lastDoctor;
            set { _lastDoctor = value; OnPropertyChanged(); }
        }

        private string _diagnosis = "";
        public string Diagnosis
        {
            get => _diagnosis;
            set { _diagnosis = value; OnPropertyChanged(); }
        }

        private string _recomendations = "";
        public string Recomendations
        {
            get => _recomendations;
            set { _recomendations = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}