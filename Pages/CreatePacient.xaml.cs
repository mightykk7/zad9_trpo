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
    /// Логика взаимодействия для CreatePacient.xaml
    /// </summary>
    public partial class CreatePacient : Page
    {
        public Pacient CurrentPacient { get; set; }
        public ObservableCollection<Pacient> _pacients { get; set; } = new();
        public CreatePacient(ObservableCollection<Pacient> Pacients)
        {
            _pacients = Pacients;
            CurrentPacient = new Pacient();
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CurrentPacient.Name == "" || CurrentPacient.LastName == "" || CurrentPacient.MiddleName == "" || CurrentPacient.PhoneNumber == "")
            {

                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Random rnd = new Random();
            int id = rnd.Next(1, 100000);
            CurrentPacient.Id = id;
            var Json = JsonSerializer.Serialize(CurrentPacient);
            File.WriteAllText($"P_{CurrentPacient.Id}.txt", Json);
            MessageBox.Show("Пользователь добавлен успешно", $"ID = {CurrentPacient.Id}", MessageBoxButton.OK, MessageBoxImage.Information);
            _pacients.Add(CurrentPacient);
            NavigationService.GoBack();
        }
    }
}
