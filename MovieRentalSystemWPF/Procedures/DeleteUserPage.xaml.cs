using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Common;
using MovieRentalSystemDataBase;
using MovieRentalSystemDataBase.Procedures;

namespace MovieRentalSystemWPF.Procedures
{
    /// <summary>
    /// Logika interakcji dla klasy DeleteUserPage.xaml
    /// </summary>
    public partial class DeleteUserPage : Page
    {
        private DBConnector Connector { get; set; }

        public DeleteUserPage()
        {
            InitializeComponent();
        }

        public DeleteUserPage(DBConnector connector) : this()
        {
            Connector = connector;
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClientIdBox.Text))
            {
                MessageBox.Show("Provide all data");
            }
            else
            {
                DeleteUserProcedure deleteUser = new DeleteUserProcedure(Connector, ClientIdBox.Text.NullNumber());

                try
                {
                    var dt = deleteUser.ExecuteQuery();
                    DataRow row = dt.Rows[0];

                    if (int.Parse(row["AffectedRows"].ToString() ?? string.Empty) > 0)
                    {
                        MessageBox.Show("Successfully deleted user");
                    }
                    else
                    {
                        MessageBox.Show("Nothing has been changed!");
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
