using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MovieRentalSystemDataBase;
using MovieRentalSystemDataBase.Procedures;

namespace MovieRentalSystemWPF.Procedures
{
    /// <summary>
    /// Logika interakcji dla klasy DeleteRentalPage.xaml
    /// </summary>
    public partial class DeleteRentalPage : Page
    {
        private DBConnector Connector { get; set; }
        public DeleteRentalPage()
        {
            InitializeComponent();
        }

        public DeleteRentalPage(DBConnector connector) : this()
        {
            Connector = connector;
        }

        private void DeleteRentalButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MovieTitleBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(SurnameBox.Text))
            {
                MessageBox.Show("Provide all data");
            }
            else
            {
                DeleteRentalProcedure deleteRental = new DeleteRentalProcedure(Connector, MovieTitleBox.Text,
                    NameBox.Text, SurnameBox.Text);

                try
                {
                    var dt = deleteRental.ExecuteQuery();
                    DataRow row = dt.Rows[0];

                    MessageBox.Show(int.Parse(row["AffectedRows"].ToString() ?? string.Empty) > 0
                        ? "Successfully deleted rental!"
                        : "There is nothing to delete");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }
    }
}
