using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
   public class CheckDelaysProcedure : QueryMaker
    {
        public CheckDelaysProcedure(DBConnector connector) : base(connector)
        {
            QueryText = "check_if_delayed";
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection) { CommandType = CommandType.StoredProcedure };

            int affectedRows = cmd.ExecuteNonQuery();

            var dt = new DataTable();
            dt.Columns.Add("AffectedRows");
            var row = dt.NewRow();
            row["AffectedRows"] = affectedRows;
            dt.Rows.Add(row);

            return dt;
        }
    }
}
