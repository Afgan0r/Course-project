using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ReceptionPage.xaml
    /// </summary>
    public partial class ReceptionPage : Page
    {
        public ReceptionPage()
        {
            InitializeComponent();
            FillComboBoxes();
            FillReceptionPage();
        }
        private ObservableCollection<string> tyreList = new ObservableCollection<string>();
        private ObservableCollection<string> tubeList = new ObservableCollection<string>();
        
        private void FillReceptionPage()
        {
            string selectTubeString = "SELECT name_of_tube, how_many_took FROM dbo.Tube";
            string selectTyreString = "SELECT name_of_tyre, how_many_took FROM dbo.Tyre";
            using (var connection = connectToDatabase())
            {
                var commandTube = new SqlCommand(selectTubeString, connection);
                var dataAdapterTube = new SqlDataAdapter(commandTube);
                var dataTableTube = new DataTable("TubeView");
                dataAdapterTube.Fill(dataTableTube);
                TubeDataGrid.ItemsSource = dataTableTube.DefaultView;

                var commandTyre = new SqlCommand(selectTyreString, connection);
                var dataAdapterTyre = new SqlDataAdapter(commandTyre);
                var dataTableTyre = new DataTable("TyreView");
                dataAdapterTyre.Fill(dataTableTyre);
                TyreDataGrid.ItemsSource = dataTableTyre.DefaultView;
            }
        }
        private void FillComboBoxes() //TyreModelComboBox, TubeModelComboBox
        {
            //needed tubes
            tyreList.Add("NORTEC ER-112 а/п 12.00-20 ТТ");
            tubeList.Add("12.00-20 а/камера");

            tyreList.Add("NORTEC IM-14 сх/п 9.00-16");
            tubeList.Add("9.00-16 сх/камера");       
            
            tyreList.Add("NORTEC IM-15 сх/п 6.50-16 6PR");
            tubeList.Add("6.50-16 сх/камера");
            //Not needed tubes
            tyreList.Add("NORTEC AC 200 сх/п 420/70R24 б/к");
            tyreList.Add("NORTEC ER-218 а/п 10.00-16,5 10PR TL");
            tyreList.Add("NORTEC ER-218 а/п 12.00-16,5 10PR TL");
            tyreList.Add("NORTEC ER-218 а/п 12.00-16,5 12PR TL");
            //filling TyreModelComboBox and TubeModelComboBox
            TyreModelComboBox.ItemsSource = tyreList;
            TubeModelComboBox.ItemsSource = tubeList;
        }

        private void InsertTyreDataInDataBase_Click(object sender, RoutedEventArgs e)
        {
            string tyreModel = TyreModelComboBox.SelectedValue.ToString();
            int tyreCount = int.Parse(CountOfTyres.Text);
            switch (tyreModel)
            {
                //needed tubes
                case "NORTEC ER-112 а/п 12.00-20 ТТ":
                    InsertIntoTyreTable(tyreModel, tyreCount, true, "12.00-20 а/камера");
                    break;
                case "NORTEC IM-14 сх/п 9.00-16":
                    InsertIntoTyreTable(tyreModel, tyreCount, true, "9.00-16 сх/камера");
                    break;
                case "NORTEC IM-15 сх/п 6.50-16 6PR":
                    InsertIntoTyreTable(tyreModel, tyreCount, true, "6.50-16 сх/камера");
                    break;
                //not needed tubes
                case "NORTEC AC 200 сх/п 420/70R24 б/к":
                    InsertIntoTyreTable(tyreModel, tyreCount, false, "");
                    break;
                case "NORTEC ER-218 а/п 10.00-16,5 10PR TL":
                    InsertIntoTyreTable(tyreModel, tyreCount, false, "");
                    break;
                case "NORTEC ER-218 а/п 12.00-16,5 10PR TL":
                    InsertIntoTyreTable(tyreModel, tyreCount, false, "");
                    break;
                case "NORTEC ER-218 а/п 12.00-16,5 12PR TL":
                    InsertIntoTyreTable(tyreModel, tyreCount, false, "");
                    break;
            }
            FillReceptionPage();
            CountOfTyres.Text = null;
            TyreModelComboBox.SelectedIndex = -1;            
        }

        private void InsertTubeDataInDataBase_Click(object sender, RoutedEventArgs e)
        {
            string tubeModel = TubeModelComboBox.SelectedValue.ToString();
            int tubeCount = int.Parse(CountOfTubes.Text);
            switch (tubeModel)
            {
                case "12.00-20 а/камера":
                    InsertIntoTubeTable(tubeModel, tubeCount);
                    break;
                case "9.00-16 сх/камера":
                    InsertIntoTubeTable(tubeModel, tubeCount);
                    break;
                case "6.50-16 сх/камера":
                    InsertIntoTubeTable(tubeModel, tubeCount);
                    break;
            }
            FillReceptionPage();
            CountOfTubes.Text = null;
            TubeModelComboBox.SelectedIndex = -1;
        }
    }
}
