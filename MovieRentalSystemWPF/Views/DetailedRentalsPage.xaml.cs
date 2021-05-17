using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using MovieRentalSystemDataBase;
using MovieRentalSystemDataBase.Views;

namespace MovieRentalSystemWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DetailedRentalsPage.xaml
    /// </summary>
    public partial class DetailedRentalsPage : Page
    {
        private DBConnector Connector { get; set; }
        public DetailedRentalsPage()
        {
            InitializeComponent();
        }

        public DetailedRentalsPage(DBConnector connector) : this()
        {
            Connector = connector;

            DetailedRentalsView detailedRentals = new DetailedRentalsView(Connector);

            try
            {
                var dt = detailedRentals.ExecuteQuery();
                DataGrid.DataContext = dt.DefaultView;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

    }
}
