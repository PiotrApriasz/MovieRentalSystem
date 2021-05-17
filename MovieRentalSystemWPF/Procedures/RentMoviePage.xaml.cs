using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MovieRentalSystemDataBase;
using MovieRentalSystemDataBase.Procedures;

namespace MovieRentalSystemWPF.Procedures
{
    /// <summary>
    /// Logika interakcji dla klasy RentMoviePage.xaml
    /// </summary>
    public partial class RentMoviePage : Page
    {
        private DBConnector Connector { get; set; }

        public RentMoviePage()
        {
            InitializeComponent();
        }

        public RentMoviePage(DBConnector connector) : this()
        {
            Connector = connector;
        }

        private void RentMovieButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MovieTitleBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(SurnameBox.Text) ||
                string.IsNullOrWhiteSpace(CreditCardBox.Text) ||
                string.IsNullOrWhiteSpace(CVVNumberBox.Text))
            {
                MessageBox.Show("Provide all data");
            }
            else
            {
                RentMovieProcedure rentMovie = new RentMovieProcedure(Connector, MovieTitleBox.Text,
                    NameBox.Text, SurnameBox.Text, CreditCardBox.Text, CVVNumberBox.Text);

                try
                {
                    var dt = rentMovie.ExecuteQuery();
                    DataRow row = dt.Rows[0];

                    if (int.Parse(row["AffectedRows"].ToString() ?? string.Empty) > 0)
                    {
                        MessageBox.Show("Successfully added rental!");
                    }
                    
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}
