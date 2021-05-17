using System.Data;
using MySqlConnector;

namespace MovieRentalSystemDataBase.QueryTypes
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
