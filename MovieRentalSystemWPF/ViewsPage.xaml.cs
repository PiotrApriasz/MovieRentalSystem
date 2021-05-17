using System;
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
using MovieRentalSystemDataBase.QueryTypes;

namespace MovieRentalSystemWPF
{
    /// <summary>
    /// Logika interakcji dla klasy ViewsPage.xaml
    /// </summary>
    public partial class ViewsPage : Page
    {
        public DBConnector Connector { get; set; }
        public string Query { get; set; }

        public ViewsPage()
        {
            InitializeComponent();
        }

        public ViewsPage(DBConnector connector) : this()
        {
            Connector = connector;
            Query = "SELECT * FROM users;";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBox.SelectedIndex)
            {
                case 0:
                    Query = "SELECT * FROM users;";
                    break;
                case 1:
                    Query = "SELECT * FROM addresses;";
                    break;
                case 2:
                    Query = "SELECT * FROM directors;";
                    break;
                case 3:
                    Query = "SELECT * FROM movie_genres;";
                    break;
                case 4:
                    Query = "SELECT * FROM movies;";
                    break;
                case 5:
                    Query = "SELECT * FROM rentals;";
                    break;
                case 6:
                    Query = "SELECT * FROM workers;";
                    break;
            }

            var view = new Select(Connector, Query);

            try
            {
                var viewDataTable = view.ExecuteQuery();
                DataGrid.DataContext = viewDataTable.DefaultView;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
