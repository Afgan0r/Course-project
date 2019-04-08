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

        public static void FillCellPage()
        {
            //TODO CREATE DATAGRID MANUALY
            //var selectString = "SELECT dbo.Cell.number_of_cell, dbo.Floor.name_of_floor, dbo.Cell.name_of_cell, dbo.Cell.specification, dbo.Cell.contains_wheel, dbo.Cell.maximum_contains " +
            //    "FROM dbo.Cell INNER JOIN dbo.Floor " +
            //    "ON dbo.Cell.floor_of_cell = dbo.Floor.id_floor";
            //using (var connection = connectToDatabase())
            //{
            //    var command = new SqlCommand(selectString, connection);
            //    var dataAdapter = new SqlDataAdapter(command);
            //    var dataTable = new DataTable("CellsWithFloor");
            //    dataAdapter.Fill(dataTable);
            //    checkCellsPage.CheckCellWithFloorDataGrid.ItemsSource = dataTable.DefaultView;
            //    connection.Close();
            //}
        }

        public static void FillReceptionPage()
        {
            //TODO CREATE DATAGRID MANUALY           
        }
        public static void FillCompleteWheelsPage()
        {
            //TODO CREATE DATAGRID MANUALY
        }

        public static void FillRealizationPage()
        {
            //TODO CREATE DATAGRID MANUALY
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            //using (var connection = connectToDatabase())
            //{

            //    try
            //    {
            //        var selectString = "select [Login], [Password] from [dbo].[SignIn]";
            //        var command = new SqlCommand(selectString, connection);
            //        var reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            if (reader[0].ToString().Equals(LoginField.Text) && reader[1].ToString().Equals(PasswordField.Password))
            //            {
            LogInWindow.Visibility = Visibility.Hidden;
            Window.Visibility = Visibility.Visible;
            LoginField.Text = "";
            PasswordField.Password = "";
            //            }
            //        }
            //        ErrorLabel.Content = "Введеный логин или пароль неверны.\nПроверьте входные данные";
            //    }
            //    catch (Exception exc)
            //    {
            //        Console.WriteLine(exc);
            //    }
            //    finally
            //    {
            //        connection.Close();
            //    }
            //}
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
            FillReceptionPage();
        }

        private void CompleteWheelsButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = completeWheelsPage;            
            FillCompleteWheelsPage();
        }

        private void CheckCellsButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = checkCellsPage;
            FillCellPage();
        }

        private void RealizationButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Content = realizationPage;
            FillRealizationPage();
        }
    }
}
