using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
    public class AddMovieProcedure : QueryMaker
    {
        public string Title { get; set; }
        public string GenreName { get; set; }
        public string DurationTime { get; set; }
        public string DirectorName { get; set; }
        public string DirectorSurname { get; set; }
        public int ForAdults { get; set; }
        public decimal Money { get; set; }
        public string ProductionYear { get; set; }

        public AddMovieProcedure(DBConnector connector, string title, string genreName, string durationTime,
            string directorName, string directorSurname, int forAdults, decimal money, string productionYear) : base(connector)
        {
            QueryText = "add_movie";
            Title = title;
            GenreName = genreName;
            DurationTime = durationTime;
            DirectorName = directorName;
            DirectorSurname = directorSurname;
            ForAdults = forAdults;
            Money = money;
            ProductionYear = productionYear;
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new MySqlParameter("Title", Title));
            cmd.Parameters.Add(new MySqlParameter("GenreName", GenreName));
            cmd.Parameters.Add(new MySqlParameter("durationTime", DurationTime));
            cmd.Parameters.Add(new MySqlParameter("directorName", DirectorName));
            cmd.Parameters.Add(new MySqlParameter("directorSurname", DirectorSurname));
            cmd.Parameters.Add(new MySqlParameter("forAdults", ForAdults));
            cmd.Parameters.Add(new MySqlParameter("Money", Money));
            cmd.Parameters.Add(new MySqlParameter("productionYear", ProductionYear));
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
