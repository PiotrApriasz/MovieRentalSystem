#nullable enable
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MovieRentalSystemDataBase.Procedures
{
    public class AddUserProcedure : QueryMaker
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Email { get; set; }
        private string BirthDate { get; set; }
        private string CreditCard { get; set; }
        private string Cvv { get; set; }
        private string? City { get; set; }
        private string? BuildingNumber { get; set; }
        private string? FlatNumber { get; set; }
        private string? Street { get; set; }
        private string? PostalCode { get; set; }
        private int? CurrentAddressId { get; set; }

        public AddUserProcedure(DBConnector connector, string name, string surname, 
            string email, string birthDate, string creditCard, string cvv, 
            string? city, string? buildingNumber, string? flatNumber, 
            string? street, string? postalCode, int? currentAddressId) : base(connector)
        {
            QueryText = "add_new_user";
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthDate;
            CreditCard = creditCard;
            Cvv = cvv;
            City = city;
            BuildingNumber = buildingNumber;
            FlatNumber = flatNumber;
            Street = street;
            PostalCode = postalCode;
            CurrentAddressId = currentAddressId;
        }

        protected override DataTable SetQuery()
        {
            var cmd = new MySqlCommand(QueryText, Connector.Connection) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new MySqlParameter("firstName", Name));
            cmd.Parameters.Add(new MySqlParameter("lastName", Surname));
            cmd.Parameters.Add(new MySqlParameter("Email1", Email));
            cmd.Parameters.Add(new MySqlParameter("birthDate", BirthDate));
            cmd.Parameters.Add(new MySqlParameter("creditCard", CreditCard));
            cmd.Parameters.Add(new MySqlParameter("cvvCode", Cvv));
            cmd.Parameters.Add(new MySqlParameter("City1", City));
            cmd.Parameters.Add(new MySqlParameter("buildingNumber", BuildingNumber));
            cmd.Parameters.Add(new MySqlParameter("flatNumber", FlatNumber));
            cmd.Parameters.Add(new MySqlParameter("Street1", Street));
            cmd.Parameters.Add(new MySqlParameter("postalCode", PostalCode));
            cmd.Parameters.Add(new MySqlParameter("addressIDCurrent", CurrentAddressId));
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
