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
    /// Logika interakcji dla klasy CheckDelaysPage.xaml
    /// </summary>
    public partial class CheckDelaysPage : Page
    {
        private DBConnector Connector { get; set; }

        public CheckDelaysPage()
        {
            InitializeComponent();
        }

        public CheckDelaysPage(DBConnector connector) : this()
        {
            Connector = connector;
        }

        private void CheckDelaysButton_Click(object sender, RoutedEventArgs e)
        {
            CheckDelaysProcedure checkDelays = new CheckDelaysProcedure(Connector);

            try
            {
                var dt = checkDelays.ExecuteQuery();
                DataRow row = dt.Rows[0];

                if (int.Parse(row["AffectedRows"].ToString() ?? string.Empty) > 0)
                {
                    NumberBlock.Text = row["AffectedRows"].ToString();
                }
                else
                {
                    NumberBlock.Text = "0";
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
