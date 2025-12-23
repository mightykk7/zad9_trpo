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
using System.Numerics;

namespace Zad8_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdatePacient.xaml
    /// </summary>
    public partial class UpdatePacient : Page
    {
        public Pacient CurrentPacient { get; set; }
        public UpdatePacient(Pacient? SelectedPacient = null)
        {
            CurrentPacient = SelectedPacient;
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (CurrentPacient.Name == "" || CurrentPacient.LastName == "")
            {
                MessageBox.Show("Имя и Фамилия обязательны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var Json = JsonSerializer.Serialize(CurrentPacient);
            File.WriteAllText($"P_{CurrentPacient.Id}.txt", Json);
            MessageBox.Show("Изменения сохранены", $"ID = {CurrentPacient.Id}", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string path = $"P_{CurrentPacient.Id}.txt";
            var Json = File.ReadAllText(path);
            var foundPacient = JsonSerializer.Deserialize<Pacient>(Json);
            CurrentPacient.Id = foundPacient.Id;
            CurrentPacient.Name = foundPacient.Name;
            CurrentPacient.LastName = foundPacient.LastName;
            CurrentPacient.MiddleName = foundPacient.MiddleName;
            CurrentPacient.Diagnosis = foundPacient.Diagnosis;
            CurrentPacient.Recomendations = foundPacient.Recomendations;
            CurrentPacient.Birthday = foundPacient.Birthday;
            CurrentPacient.LastAppointment = foundPacient.LastAppointment;
        }
    }
}
