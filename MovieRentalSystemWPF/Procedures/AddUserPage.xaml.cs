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
using Common;

namespace MovieRentalSystemWPF.Procedures
{
    /// <summary>
    /// Logika interakcji dla klasy AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private DBConnector Connector { get; set; }
        public AddUserPage()
        {
            InitializeComponent();
        }

        public AddUserPage(DBConnector connector) : this()
        {
            Connector = connector;
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(SurnameBox.Text) ||
                string.IsNullOrWhiteSpace(EmailBox.Text) ||
                string.IsNullOrWhiteSpace(BirthDateBox.Text) ||
                string.IsNullOrWhiteSpace(CreditCardBox.Text) ||
                string.IsNullOrWhiteSpace(CvvBox.Text))
            {
                MessageBox.Show("Provide needed information");
            }
            else
            {
                AddUserProcedure addUser = new AddUserProcedure(Connector, NameBox.Text, SurnameBox.Text,
                    EmailBox.Text, BirthDateBox.Text, CreditCardBox.Text, CvvBox.Text, CityBox.Text.NullString(),
                    BuildingBox.Text.NullString(), FlatBox.Text.NullString(), StreetBox.Text.NullString(), PostalCodeBox.Text.NullString(),
                    AddressIdBox.Text.NullNumber());

                try
                {
                    var dt = addUser.ExecuteQuery();
                    DataRow row = dt.Rows[0];

                    if (int.Parse(row["AffectedRows"].ToString() ?? string.Empty) > 0)
                    {
                        MessageBox.Show("Successfully added user!");
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
