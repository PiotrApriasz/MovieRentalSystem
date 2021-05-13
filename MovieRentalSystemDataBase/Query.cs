using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase
{
    /// <summary>
    /// Base class for queries
    /// </summary>
    public abstract class Query
    {
        #region Properties

        /// <summary>
        /// Text where start text of query is stored. You can set this in inheriting class
        /// </summary>
        protected string StartText { get; init; }

        /// <summary>
        /// Stores all query
        /// </summary>
        protected string QueryText { get; set; }

        /// <summary>
        /// Stores number of table which user choosen 
        /// </summary>
        protected int Table { get; set; }

        /// <summary>
        /// Instance of Helper class
        /// </summary>
        //protected Helper Helper { get; }

        /// <summary>
        /// Instance of DBConnector class. Uses to connect or disconnect data base
        /// </summary>
        protected DBConnector Connector { get; }

        #endregion

        #region Constructor

        protected Query(DBConnector connector)
        {
            Connector = connector;
            //Helper = new Helper(Connector);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Function which executes earlier builded query
        /// Error handling for MySQL errors 
        /// </summary>
        public virtual void ExecuteQuery()
        {
            if (Connector.OpenConnection())
            {
                try
                {
                    var cmd = new MySqlCommand(QueryText, Connector.Connection);
                    int numberOfRows = cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    switch (e.Number)
                    {
                        case 1064:
                            throw new("There is a syntax error in your query!");
                        case 1054:
                            throw new("Unknown column!");
                        case 1146:
                            throw new("Table you entered doesn't exists");
                        default:
                            throw new("Something is wrong with your query!");
                    }
                }
                catch (InvalidOperationException)
                {
                    throw new("Something went wrong!");
                }
                finally
                {
                    Connector.CloseConnection();
                }
            }
            else
            {
                throw new("Can't open connection with data base");
            }
        }

        #endregion
    }
}