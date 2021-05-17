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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieRentalSystemDataBase;
using MovieRentalSystemDataBase.Procedures;
using MovieRentalSystemWPF.Procedures;

namespace MovieRentalSystemWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DBConnector Connector { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(DBConnector connector, string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
            WorkerInfoTextBlock.Text = $"{Name} {Surname}";
            MainPage mainPage = new MainPage();
            Connector = connector;
            MainFrame.Navigate(mainPage);
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void StartPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            MainFrame.Navigate(mainPage);
        }

        private void RentMovieButton_Click(object sender, RoutedEventArgs e)
        {
            RentMoviePage rentMovie = new RentMoviePage(Connector);
            MainFrame.Navigate(rentMovie);
        }

        private void DeleteRentalButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRentalPage deleteRental = new DeleteRentalPage(Connector);
            MainFrame.Navigate(deleteRental);
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserPage addUser = new AddUserPage(Connector);
            MainFrame.Navigate(addUser);
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteUserPage deleteUser = new DeleteUserPage(Connector);
            MainFrame.Navigate(deleteUser);
        }

        private void AddMovieButton_Click(object sender, RoutedEventArgs e)
        {
            AddMoviePage addMovie = new AddMoviePage(Connector);
            MainFrame.Navigate(addMovie);
        }
    }
}
