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
using MovieRentalSystemDataBase.Procedures;

namespace MovieRentalSystemWPF.Procedures
{
    /// <summary>
    /// Logika interakcji dla klasy AddMoviePage.xaml
    /// </summary>
    public partial class AddMoviePage : Page
    {
        private DBConnector Connector { get; set; }

        public AddMoviePage()
        {
            InitializeComponent();
        }

        public AddMoviePage(DBConnector connector) : this()
        {
            Connector = connector;
        }

        private void AddMovieButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text) ||
                string.IsNullOrWhiteSpace(GenreNameBox.Text) ||
                string.IsNullOrWhiteSpace(DurationTimeBox.Text) ||
                string.IsNullOrWhiteSpace(DirectorNameBox.Text) ||
                string.IsNullOrWhiteSpace(DirectorSurnameBox.Text) ||
                string.IsNullOrWhiteSpace(FForAdultsBox.Text) ||
                string.IsNullOrWhiteSpace(MoneyBox.Text) ||
                string.IsNullOrWhiteSpace(ProductionYearBox.Text))
            {
                MessageBox.Show("Provide all data");
            }
            else
            {
                AddMovieProcedure addMovie = new AddMovieProcedure(Connector, TitleBox.Text,
                    GenreNameBox.Text, DurationTimeBox.Text, DirectorNameBox.Text,
                    DirectorSurnameBox.Text, int.Parse(FForAdultsBox.Text),
                    decimal.Parse(MoneyBox.Text), ProductionYearBox.Text);

                try
                {
                    var dt = addMovie.ExecuteQuery();
                    DataRow row = dt.Rows[0];

                    if (int.Parse(row["AffectedRows"].ToString() ?? string.Empty) > 0)
                    {
                        MessageBox.Show("Successfully added movie!");
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
