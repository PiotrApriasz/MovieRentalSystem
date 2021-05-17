using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Views
{
    public class DetailedRentalsView : QueryMaker
    {
        public DetailedRentalsView(DBConnector connector) : base(connector)
        {
            QueryText = "SELECT * FROM a_detailed_list_of_rental";
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection);
            var dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            return dt;  
        }
    }
}
