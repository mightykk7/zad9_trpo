using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Zad8_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public Doctor CurrentDoctor { get; set; }
        public ObservableCollection<Pacient> Pacients { get; set; } = new();
        public Pacient? SelectedPacient { get; set; }
        public MainPage(Doctor EnterDoctor)
        {
            CurrentDoctor = EnterDoctor;
            LoadAllPacients();
            DataContext = this;
            InitializeComponent();
        }
        private void LoadAllPacients()
        {
            var files = Directory.GetFiles(".","P_*.txt");
            foreach (var file in files)
            {
                string json = File.ReadAllText(file);
                var pacient = JsonSerializer.Deserialize<Pacient>(json);
                Pacients.Add(pacient);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePacient(Pacients));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartReceiving(CurrentDoctor, Pacients,SelectedPacient));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SelectedPacient == null) return;
            NavigationService.Navigate(new UpdatePacient(SelectedPacient));
        }
    }
}
