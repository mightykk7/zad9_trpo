using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Collections.ObjectModel;

namespace Zad8_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartReceiving.xaml
    /// </summary>
    public partial class StartReceiving : Page
    {
        public Pacient EnterPacient { get; set; }
        public Doctor EnterDoctor { get; set; }
        private ObservableCollection<Pacient> _pacients;
        private Pacient? _selectedPacient;
        public StartReceiving(Doctor doctor, ObservableCollection<Pacient> Pacients, Pacient? SelectedPacient = null)
        {
            _selectedPacient = SelectedPacient;
            _pacients = Pacients;
            EnterDoctor = doctor;
            if (_selectedPacient != null)
            {
                EnterPacient = new Pacient
                {
                    Id = _selectedPacient.Id,
                    Name = _selectedPacient.Name,
                    MiddleName = _selectedPacient.MiddleName,
                    LastName = _selectedPacient.LastName,
                    Birthday = _selectedPacient.Birthday,
                    PhoneNumber = _selectedPacient.PhoneNumber,
                    LastAppointment = _selectedPacient.LastAppointment,
                    LastDoctor = _selectedPacient.LastDoctor,
                    Diagnosis = _selectedPacient.Diagnosis,
                    Recomendations = _selectedPacient.Recomendations
                };
            }
            else
            {
                EnterPacient = new Pacient();
            }
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (EnterPacient.Diagnosis == "" || EnterPacient.Recomendations == "")
            {
                MessageBox.Show("Диагноз и рекоменадции обязательны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EnterPacient.LastDoctor = EnterDoctor.Id;
            var Json = JsonSerializer.Serialize(EnterPacient);
            _selectedPacient.LastDoctor = EnterPacient.LastDoctor;
            _selectedPacient.Diagnosis = EnterPacient.Diagnosis;
            _selectedPacient.Recomendations = EnterPacient.Recomendations;
            File.WriteAllText($"P_{EnterPacient.Id}.txt", Json);
            MessageBox.Show("Изменения сохранены", $"ID = {EnterPacient.Id}", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }
    }
}
