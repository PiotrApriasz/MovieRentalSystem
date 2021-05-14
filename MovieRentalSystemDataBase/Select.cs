using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase
{
    public class Select : QueryMaker
    {
        public Select(DBConnector connector, string queryText) : base(connector)
        {
            QueryText = queryText;
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection);
            var dr = cmd.ExecuteReader();
            DataTable dt = new DataTable("worker");
            dt.Load(dr);
            return dt;
        }
    }
}
