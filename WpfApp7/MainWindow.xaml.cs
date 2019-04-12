using System.Data.SqlClient;
using System.Windows;
using static WpfApp7.SQL;
using WpfApp7.Pages;
using System;
using System.Data;

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Window.Visibility = Visibility.Hidden;
        }
        static CheckCellsPage checkCellsPage = new CheckCellsPage();
        static CompleteWheelsPage completeWheelsPage = new CompleteWheelsPage();
        static RealizationPage realizationPage = new RealizationPage();
        static ReceptionPage receptionPage = new ReceptionPage();  
                              
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = connectToDatabase())
            {
                var selectString = "select [Login], [Password] from [dbo].[SignIn]";
                var command = new SqlCommand(selectString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString().Equals(LoginField.Text) && reader[1].ToString().Equals(PasswordField.Password))
                    {
                        LogInWindow.Visibility = Visibility.Hidden;
                        Window.Visibility = Visibility.Visible;
                        LoginField.Text = "";
                        PasswordField.Password = "";
                    }
                }
                ErrorLabel.Content = "Введеный логин или пароль неверны.\nПроверьте входные данные";
                connection.Close();
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Window.Visibility = Visibility.Hidden;
            LogInWindow.Visibility = Visibility.Visible;
            MainMenu.Content = null;
            ErrorLabel.Content = "";
        }

        private void ReceptionButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = receptionPage;
        }

        private void CompleteWheelsButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = completeWheelsPage;       
        }

        private void CheckCellsButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = checkCellsPage;
        }

        private void RealizationButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = realizationPage;
        }
    }
}
