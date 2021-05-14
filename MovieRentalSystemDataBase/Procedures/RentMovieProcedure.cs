using System;
using System.Data;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
    public class RentMovieProcedure : QueryMaker
    {
        private string MovieTitle { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }
        private string CreditCardNumber { get; set; }
        private string NumberCVV { get; set; }

        public RentMovieProcedure(DBConnector connector, string movieTitle,
            string name, string surname, string creditCard, string numberCvv) : base(connector)
        {
            QueryText = "rent_movie";
            MovieTitle = movieTitle;
            Name = name;
            Surname = surname;
            CreditCardNumber = creditCard;
            NumberCVV = numberCvv;
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection) {CommandType = CommandType.StoredProcedure};
            cmd.Parameters.Add(new MySqlParameter("movieTitle", MovieTitle));
            cmd.Parameters.Add(new MySqlParameter("Name", Name));
            cmd.Parameters.Add(new MySqlParameter("Surname", Surname));
            cmd.Parameters.Add(new MySqlParameter("CreditCardNumber", CreditCardNumber));
            cmd.Parameters.Add(new MySqlParameter("CVVNumber", NumberCVV));
            cmd.ExecuteNonQuery();

            return null;
        }
    }
}
