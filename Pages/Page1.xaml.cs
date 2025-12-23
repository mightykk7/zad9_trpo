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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Doctor EnterDoctor { get; set; }
        public Page1()
        {
            EnterDoctor = new Doctor();
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Id = EnterDoctor.Id;
            var Password = EnterDoctor.Password;
            if (string.IsNullOrEmpty(Id.ToString()) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Заполните все поля для входа", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!int.TryParse(Id.ToString(), out int id))
            {
                MessageBox.Show("В поле ID можно вводить только цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string path = $"D_{EnterDoctor.Id}.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var Json = File.ReadAllText(path);
            var doctor = JsonSerializer.Deserialize<Doctor>(Json);
            if (doctor.Password != Password)
            {
                MessageBox.Show("Пароль неверный", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                EnterDoctor.Id = doctor.Id;
                EnterDoctor.Name = doctor.Name;
                EnterDoctor.LastName = doctor.LastName;
                EnterDoctor.MiddleName = doctor.MiddleName;
                EnterDoctor.Specialisation = doctor.Specialisation;
                EnterDoctor.Password = doctor.Password;
                MessageBox.Show("Вход прошёл успешно", $"ID = {EnterDoctor.Id}", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new MainPage(EnterDoctor));
            }
        }
    }
}
