using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
    public class DeleteRentalProcedure : QueryMaker
    {
        private string MovieTitle { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }

        public DeleteRentalProcedure(DBConnector connector, string movie,
            string name, string surname) : base(connector)
        {
            QueryText = "delete_rental";
            MovieTitle = movie;
            Name = name;
            Surname = surname;
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new MySqlParameter("movieTitle", MovieTitle));
            cmd.Parameters.Add(new MySqlParameter("Name", Name));
            cmd.Parameters.Add(new MySqlParameter("Surname", Surname));
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
