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

namespace Zad8_trpo.Pages
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Doctor CurrentDoctor { get; set; }
        public Register()
        {
            CurrentDoctor = new Doctor();
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDoctor.Name == null || CurrentDoctor.LastName == null || CurrentDoctor.MiddleName == null || CurrentDoctor.Specialisation == null || CurrentDoctor.Password == null || CurrentDoctor.PasswordConfirm == null)
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (CurrentDoctor.Password != CurrentDoctor.PasswordConfirm)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Random rnd = new Random();
            int id = rnd.Next(1, 100000);
            CurrentDoctor.Id = id;
            var Json = JsonSerializer.Serialize(CurrentDoctor);
            File.WriteAllText($"D_{CurrentDoctor.Id}.txt", Json);
            MessageBox.Show("Регистрация прошла успешно", $"ID = {CurrentDoctor.Id}", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
