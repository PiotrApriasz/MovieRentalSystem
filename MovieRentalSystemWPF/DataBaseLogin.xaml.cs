﻿using System;
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
using System.Windows.Shapes;
using MovieRentalSystemDataBase;

namespace MovieRentalSystemWPF
{
    /// <summary>
    /// Logika interakcji dla klasy DataBaseLogin.xaml
    /// </summary>
    public partial class DataBaseLogin : Window
    {
        public DBConnector Connector { get; set; }
        public DataBaseLogin()
        {
            InitializeComponent();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DataBaseLoginTextBox.Text)
                || string.IsNullOrWhiteSpace(DataBaseLoginTextBox.Text))
            {
                MessageBox.Show("Please provide informations!");
            }
            else
            {
                //test connection and go to next window
                Connector = new DBConnector(DataBaseLoginTextBox.Text,
                    DataBasePassTextBox.Text);

                try
                {
                    Connector.OpenConnection();

                    Connector.CloseConnection();

                    LoginWindow login = new LoginWindow(Connector, DataBaseLoginTextBox.Text,
                        DataBasePassTextBox.Text);
                    login.Show();
                    Close();

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
