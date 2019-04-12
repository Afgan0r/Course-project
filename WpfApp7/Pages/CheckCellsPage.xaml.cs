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
    /// Логика взаимодействия для CheckCellsPage.xaml
    /// </summary>
    public partial class CheckCellsPage : Page
    {
        public CheckCellsPage()
        {
            InitializeComponent();
            FillCellPage();
        }

        internal new void Content()
        {
            throw new NotImplementedException();
        }

        private void FillCellPage()
        {
            var selectString = "SELECT dbo.Cell.number_of_cell, dbo.Floor.name_of_floor, dbo.Cell.name_of_cell, dbo.Cell.specification, dbo.Cell.contains_wheel, dbo.Cell.maximum_contains " +
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
    }
}
