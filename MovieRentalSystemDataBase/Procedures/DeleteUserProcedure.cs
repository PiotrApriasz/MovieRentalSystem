using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
    public class DeleteUserProcedure : QueryMaker
    {
        public int? ClientId { get; set; }

        public DeleteUserProcedure(DBConnector connector, int? clientId) : base(connector)
        {
            QueryText = "delete_user";
            ClientId = clientId;
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new MySqlParameter("clientID", ClientId));
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
