using System;
using System.Windows;
using System.Windows.Controls;
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
                case 7:
                    Query = "SELECT * FROM a_detailed_list_of_rental;";
                    break;
                case 8:
                    Query = "SELECT * FROM genres_count_by_movies;";
                    break;
                case 9:
                    Query = "SELECT * FROM informations_about_films;";
                    break;
                case 10:
                    Query = "SELECT * FROM user_account_summary;";
                    break;
                case 11:
                    Query = "SELECT * FROM users_age;";
                    break;
                case 12:
                    Query = "SELECT * FROM users_and_adresses;";
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
