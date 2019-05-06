using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using static WpfApp7.SQL;

namespace WpfApp7.Pages
{
    /// <summary>
    /// Логика взаимодействия для RealizationPage.xaml
    /// </summary>
    public partial class RealizationPage : Page
    {
        public RealizationPage()
        {
            InitializeComponent();
            
        }

        ObservableCollection<string> wheelsList = new ObservableCollection<string>();

        private void FillRealizationPage()
        {
            string selectString = "SELECT name_of_wheel, how_many_took " +
                "FROM dbo.Realization";
            using (var connection = connectToDatabase())
            {
                var command = new SqlCommand(selectString, connection);
                var dataAdapter = new SqlDataAdapter(command);
                var dataTable = new DataTable("RealizationTable");
                dataAdapter.Fill(dataTable);
                RealizationDataGrid.ItemsSource = dataTable.DefaultView;
                connection.Close();
            }
            
        }

        private void FillComboBoxes ()
        {
            string selectString = "SELECT specification " +
                "FROM dbo.Cell " +
                "WHERE contains_wheel > 0";
            using (var connection = connectToDatabase())
            {
                var command = new SqlCommand(selectString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    wheelsList.Add(reader[0].ToString());
                }
                WheelsComboBox.ItemsSource = wheelsList;
                connection.Close();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DeleteAllRowsInRealizationTable();
            FillRealizationPage();
            FillComboBoxes();
        }

        private void Page_Unloaded_1(object sender, RoutedEventArgs e)
        {
            DeleteAllRowsInRealizationTable();
            FillComboBoxes();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string wheelModel = WheelsComboBox.SelectedValue.ToString();
            int wheelCount = int.Parse(HowManyRealizeTextBox.Text);
            if (wheelCount <= 0)
            {
                HowManyRealizeTextBox.Text = null;
                WheelsComboBox.SelectedIndex = -1;
                return;
            }            
            FillRealizationPage();
            switch (wheelModel)
            {
                case "NORTEC IM-14 сх/ш 9.00-16":
                    InsertIntoRealizationTable(wheelModel, wheelCount);
                    break;
                case "NORTEC ER-112 а/ш 12.00-20 ТТ":
                    InsertIntoRealizationTable(wheelModel, wheelCount);
                    break;
                case "NORTEC IM-15 сх/ш 6.50-16 6PR":
                    InsertIntoRealizationTable(wheelModel, wheelCount);
                    break;
                case "NORTEC AC 200 сх/ш 420/70R24 б/к":
                    InsertIntoRealizationTable(wheelModel, wheelCount);
                    break;
                case "NORTEC ER-218 а/ш 10.00-16,5 10PR TL":
                    InsertIntoRealizationTable(wheelModel, wheelCount);
                    break;
                case "NORTEC ER-218 а/ш 12.00-16,5 10PR TL":
                    InsertIntoRealizationTable(wheelModel, wheelCount);
                    break;
                case "NORTEC ER-218 а/ш 12.00-16,5 12PR TL":
                    InsertIntoRealizationTable(wheelModel, wheelCount);
                    break;
            }
            FillRealizationPage();
            HowManyRealizeTextBox.Text = null;
            WheelsComboBox.SelectedIndex = -1;
        }
    }
}
