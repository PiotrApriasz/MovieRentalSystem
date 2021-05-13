using System;
using System.Data;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
    public class RentMovieProcedure : Query
    {
        public string MovieTitle { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CreditCardNumber { get; set; }
        public string NumberCVV { get; set; }

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

        public override void ExecuteQuery()
        {
            if (Connector.OpenConnection())
            {
                try
                {
                    var cmd = new MySqlCommand(QueryText, Connector.Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("movieTitle", MovieTitle));
                    cmd.Parameters.Add(new MySqlParameter("Name", Name));
                    cmd.Parameters.Add(new MySqlParameter("Surname", Surname));
                    cmd.Parameters.Add(new MySqlParameter("CreditCardNumber", CreditCardNumber));
                    cmd.Parameters.Add(new MySqlParameter("CVVNumber", NumberCVV));
                    cmd.ExecuteNonQuery();
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
                        case 1644:
                            throw new(e.Message);
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
