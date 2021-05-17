using System;
using System.Collections.Generic;
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

namespace MovieRentalSystemWPF
{
    /// <summary>
    /// Logika interakcji dla klasy ViewsPage.xaml
    /// </summary>
    public partial class ViewsPage : Page
    {
        public DBConnector Connector { get; set; }

        public ViewsPage()
        {
            InitializeComponent();
        }

        public ViewsPage(DBConnector connector) : this()
        {
            Connector = connector;
        }
    }
}
