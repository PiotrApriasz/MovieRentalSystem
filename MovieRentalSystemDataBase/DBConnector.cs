using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase
{
     public class DBConnector
    {
        #region Variables

        /// <summary>
        /// Indicates where our server is hosted. Here it is localhost
        /// </summary>
        private string _server;

        /// <summary>
        /// Will be used to store database name to use in program
        /// </summary>
        private string _database;

        /// <summary>
        /// MySQL username
        /// </summary>
        private string _uid;

        /// <summary>
        /// MySQL password
        /// </summary>
        private string _password;

        #endregion

        #region Properties

        /// <summary>
        /// Will be used to open a connection to the database
        /// </summary>
        public MySqlConnection Connection { get; set; }

        #endregion

        #region Constructor

        public DBConnector(string username, string password)
        {
            _server = "localhost";
            _database = "wypozyczalnia";
            _uid = username;
            _password = password;
            string connectionString;
            connectionString = "SERVER=" + _server + ";" + "DATABASE=" +
                               _database + ";" + "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";

            Connection = new MySqlConnection(connectionString);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Open connection to database
        /// </summary>
        /// <returns></returns>
        public bool OpenConnection()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        throw new ArgumentException("Cannot connect to server!");
                    case 1045:
                        throw new ArgumentException("Invalid username or password, please try again");
                }

                return false;
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        /// <returns></returns>
        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        #endregion
    }
}
