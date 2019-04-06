using System.Data.SqlClient;
using System.Windows;
using static WpfApp7.SQL;
using WpfApp7.Pages;

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
        //static Page1 page1 = new Page1();
        //static Page2 page2 = new Page2();
        static CheckCellsPage CheckCellsPage = new CheckCellsPage();
        static CompleteWheelsPage CompleteWheelsPage = new CompleteWheelsPage();
        static RealizationPage RealizationPage = new RealizationPage();
        static ReceptionPage ReceptionPage = new ReceptionPage();

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            var connection = connectToDatabase();
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

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Window.Visibility = Visibility.Hidden;
            LogInWindow.Visibility = Visibility.Visible;
            MainMenu.Content = null;
            ErrorLabel.Content = "";
            
        }

        private void ReceptionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CompleteWheelsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckCellsButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = CheckCellsPage;
        }

        private void RealizationButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
