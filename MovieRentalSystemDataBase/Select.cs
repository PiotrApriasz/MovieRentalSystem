using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase
{
    public class Select : Query
    {
        public Select(DBConnector connector, string queryText) : base(connector)
        {
            QueryText = queryText;
        }

        public DataTable ExecuteQuerySelect()
        {
            if (Connector.OpenConnection())
            {
                try
                {
                    var cmd = new MySqlCommand(QueryText, Connector.Connection);
                    var dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable("worker");
                    dt.Load(dr);
                    return dt;
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
    }
}
