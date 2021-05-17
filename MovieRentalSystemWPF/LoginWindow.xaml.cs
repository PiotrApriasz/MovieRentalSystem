using System;
using System.Windows;
using MovieRentalSystemDataBase;
using MovieRentalSystemDataBase.QueryTypes;

namespace MovieRentalSystemWPF
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public DBConnector Connector { get; set; }
        public string DataBaseLogin { get; set; }
        public string DataBasePass { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
        }

        public LoginWindow(DBConnector connector, string dataBaseLogin, string dataBasePass) : this()
        {
            Connector = connector;
            DataBaseLogin = dataBaseLogin;
            DataBasePass = dataBasePass;
            DBUserTextBlock.Text = dataBaseLogin;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(WorkerIdTextBox.Text))
            {
                MessageBox.Show("Enter ID!");
            }
            else
            {
                var select = new Select(Connector, "select * from workers where worker_id = " +
                                                   $"'{WorkerIdTextBox.Text}'");

                try
                {
                    var worker = select.ExecuteQuery();

                    if (worker.Rows.Count >0)
                    {
                        var workerId = worker.Rows[0]["worker_id"].ToString();
                        var name = worker.Rows[0]["first_name"].ToString();
                        var surname = worker.Rows[0]["last_name"].ToString();

                        //MessageBox.Show("Worker found!");

                        MainWindow window = new MainWindow(Connector, name, surname);
                        window.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect worker id!");
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
