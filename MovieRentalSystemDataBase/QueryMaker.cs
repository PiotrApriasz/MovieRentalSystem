using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase
{
    /// <summary>
    /// Base class for queries
    /// </summary>
    public abstract class QueryMaker
    {
        #region Properties

        /// <summary>
        /// Stores all query
        /// </summary>
        protected string QueryText { get; set; }

        /// <summary>
        /// Instance of DBConnector class. Uses to connect or disconnect data base
        /// </summary>
        protected DBConnector Connector { get; }

        #endregion

        #region Constructor

        protected QueryMaker(DBConnector connector)
        {
            Connector = connector;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Abstract method which allows to set code for specific query
        /// Return and no return queries approved 
        /// </summary>
        /// <returns></returns>
        protected abstract DataTable SetQuery();

        /// <summary>
        /// Function which executes earlier builded query
        /// Error handling for MySQL errors 
        /// </summary>
        public DataTable ExecuteQuery()
        {
            if (!Connector.OpenConnection()) return null;
            try
            {
                return SetQuery();
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 1064:
                        throw new Exception("There is a syntax error in your query!");
                    case 1054:
                        throw new Exception("Unknown column!");
                    case 1146:
                        throw new Exception("Table you entered doesn't exists");
                    case 1644:
                        throw new Exception(e.Message);
                    default:
                        throw new Exception("Something is wrong with your query!");
                }
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Something went wrong!");
            }
            finally
            {
                Connector.CloseConnection();
            }
        }

        #endregion
    }

    
}