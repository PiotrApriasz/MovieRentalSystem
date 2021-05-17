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
    /// Logika interakcji dla klasy DeleteMoviePage.xaml
    /// </summary>
    public partial class DeleteMoviePage : Page
    {
        private DBConnector Connector { get; set; }

        public DeleteMoviePage()
        {
            InitializeComponent();
        }

        public DeleteMoviePage(DBConnector connector) : this()
        {
            Connector = connector;
        }

        private void DeleteMovieButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text))
            {
                MessageBox.Show("Provide all data");
            }
            else
            {
                DeleteMovieProcedure deleteMovie = new DeleteMovieProcedure(Connector, TitleBox.Text);

                try
                {
                    var dt = deleteMovie.ExecuteQuery();
                    DataRow row = dt.Rows[0];

                    if (int.Parse(row["AffectedRows"].ToString() ?? string.Empty) > 0)
                    {
                        MessageBox.Show("Successfully deleted movie!");
                    }
                    else
                    {
                        MessageBox.Show("There is no movie like this!");
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
