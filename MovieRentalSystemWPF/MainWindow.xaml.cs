using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieRentalSystemWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
            WorkerInfoTextBlock.Text = $"{Name} {Surname}";
            MainPage mainPage = new MainPage();
            MainFrame.Navigate(mainPage);
        }
    }
}
