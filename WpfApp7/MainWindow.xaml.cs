using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
using static WpfApp7.SQL;
using static WpfApp7.GridTable;

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

        private void OpenPage1_Click(object sender, RoutedEventArgs e)
        {
            //MainMenu.Content = page1;
        }

        private void OpenPag2_Click(object sender, RoutedEventArgs e)
        {
            //MainMenu.Content = page2;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            //SqlConnection connection = connectToDatabase();
            //SqlDataReader reader = null;
           // string selectString = "select [Login], [Password] from [dbo].[SignIn]";
            //SqlCommand command = new SqlCommand(selectString, connection);
            // reader = command.ExecuteReader();
            //while (reader.Read())
            //{
                //if (reader[0].ToString().Equals(LoginField.Text)
                   //&&
                    //reader[1].ToString().Equals(PasswordField.Password))
                //{
                    LogInWindow.Visibility = Visibility.Hidden;
                    Window.Visibility = Visibility.Visible;
                //}
            //}
            //ErrorLabel.Content = "Введеный логин или пароль неверны.\nПроверьте входные данные";
            //connection.Close();
            
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Window.Visibility = Visibility.Hidden;
            LogInWindow.Visibility = Visibility.Visible;
            MainMenu.Content = null;
            
        }
    }
}
