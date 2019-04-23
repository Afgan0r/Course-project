using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using static WpfApp7.SQL;

namespace WpfApp7.Pages
{
    /// <summary>
    /// Логика взаимодействия для CheckCellsPage.xaml
    /// </summary>
    public partial class CheckCellsPage : Page
    {
        public CheckCellsPage()
        {
            InitializeComponent();
            
        }

        internal new void Content()
        {
            throw new NotImplementedException();
        }

        private void FillCellPage()
        {
            var selectString = "SELECT dbo.Cell.number_of_cell, dbo.Floor.name_of_floor, dbo.Cell.specification, dbo.Cell.contains_wheel " +
                "FROM dbo.Cell INNER JOIN dbo.Floor " +
                "ON dbo.Cell.floor_of_cell = dbo.Floor.id_floor";
            using (var connection = connectToDatabase())
            {
                var command = new SqlCommand(selectString, connection);
                var dataAdapter = new SqlDataAdapter(command);
                var dataTable = new DataTable("CellsWithFloor");
                dataAdapter.Fill(dataTable);
                CheckCellWithFloorDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
        }

        private void CheckCellWithFloorDataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            FillCellPage();
        }
    }
}
