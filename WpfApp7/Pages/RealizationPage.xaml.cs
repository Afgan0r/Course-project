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
                "FROM dbo.Cell";
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
            FillComboBoxes();
            FillRealizationPage();
        }

        private void Page_Unloaded_1(object sender, RoutedEventArgs e)
        {

        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string wheelModel = WheelsComboBox.SelectedValue.ToString();
            int wheelCount = int.Parse(HowManyRealizeTextBox.Text);
            if (wheelCount <= 0)
            {
                HowManyRealizeTextBox.Text = null;
                WheelsComboBox.SelectedIndex = -1;
            }
            switch (wheelModel)
            {
                
            }
            FillRealizationPage();
            HowManyRealizeTextBox.Text = null;
            WheelsComboBox.SelectedIndex = -1;
        }
    }
}
