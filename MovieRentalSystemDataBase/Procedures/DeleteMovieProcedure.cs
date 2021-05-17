using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
    public class DeleteMovieProcedure : QueryMaker
    {
        public string MovieTitle { get; set; }

        public DeleteMovieProcedure(DBConnector connector, string movieTitle) : base(connector)
        {
            QueryText = "delete_movie";
            MovieTitle = movieTitle;
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new MySqlParameter("Title", MovieTitle));
            
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
