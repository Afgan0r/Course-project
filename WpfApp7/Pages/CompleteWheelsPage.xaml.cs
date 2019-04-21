using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp7.Pages
{
    /// <summary>
    /// Логика взаимодействия для CompleteWheelsPage.xaml
    /// </summary>
    public partial class CompleteWheelsPage : Page
    {
        public CompleteWheelsPage()
        {
            InitializeComponent();       
        }            
        

        private void FillCompleteWheelsPage()
        {
            string selectTubeString = "SELECT name_of_tube, how_many_took, withdraw FROM dbo.Tube";
            string selectTyreString = "SELECT name_of_tyre, how_many_took, withdraw FROM dbo.Tyre";
            using (var connection = connectToDatabase())
            {
                var commandTube = new SqlCommand(selectTubeString, connection);
                var dataAdapterTube = new SqlDataAdapter(commandTube);
                var dataTableTube = new DataTable("TubeView");
                dataAdapterTube.Fill(dataTableTube);
                TubeDataGridComplete.ItemsSource = dataTableTube.DefaultView;

                var commandTyre = new SqlCommand(selectTyreString, connection);
                var dataAdapterTyre = new SqlDataAdapter(commandTyre);
                var dataTableTyre = new DataTable("TyreView");
                dataAdapterTyre.Fill(dataTableTyre);
                TyreDataGridComplete.ItemsSource = dataTableTyre.DefaultView;
            }
        }

        private void CompleteWheelsWithoutTubeButton_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = connectToDatabase())
            {
                string selectString = "SELECT name_of_tyre, how_many_took, withdraw, is_need_tube, tube_for_tyre FROM dbo.Tyre";
                var tyreCommand = new SqlCommand(selectString, connection);
                var reader = tyreCommand.ExecuteReader();
                while(reader.Read())
                {
                    if (reader[3].ToString().Equals("False"))
                    {
                        string nameOfTyre = reader[0].ToString();
                        int withdrawTyre = int.Parse(reader[1].ToString());
                        ChangeWithdrawInTyreTable(nameOfTyre,withdrawTyre);
                        CountTyresWithdrawInDataGrid.Visibility = Visibility.Visible;
                        FillCompleteWheelsPage();
                    }
                }
                connection.Close();
            }
        }

        private void CompleteWheelsWithTubeButton_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = connectToDatabase())
            {
                string selectString = "SELECT name_of_tyre, how_many_took, withdraw, is_need_tube, tube_for_tyre FROM dbo.Tyre";
                var command = new SqlCommand(selectString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[3].ToString().Equals("True"))
                    {
                        string nameOfTyre = reader[0].ToString();
                        string requiredTube = reader[4].ToString();                        
                        CompleteToTubeTypeWheels(nameOfTyre, requiredTube);
                        CountTyresWithdrawInDataGrid.Visibility = Visibility.Visible;
                        CountTubesWithdrawInDataGrid.Visibility = Visibility.Visible;                        
                        FillCompleteWheelsPage();
                    }
                }
                connection.Close();
            }
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DeleteEmptyTubeAndTyreRows();
            RefreshWithdrawInTables();
            FillCompleteWheelsPage();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            DeleteEmptyTubeAndTyreRows();
            RefreshWithdrawInTables();
            CountTubesWithdrawInDataGrid.Visibility = Visibility.Hidden;
            CountTyresWithdrawInDataGrid.Visibility = Visibility.Hidden;
        }



        //useless things
        
        private void Page_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }
        private void Page_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            
        }
        private void CompleteWheelsWithoutTubeButton_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
