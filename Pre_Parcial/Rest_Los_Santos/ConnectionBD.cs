using System.Data;
using Npgsql;

namespace Rest_Los_Santos
{
    public class ConnectionBD
    {
        private static string _host = "127.0.0.1",
            _database = "Los_Santos_Rest.",
            _userId = "postgres",
            _password = "uca";

        private static string _sConnection =
            $"Server={_host};Port=5432;User Id={_userId};Password={_password};Database={_database};";
        // $"sslmode=Require;Trust Server Certificate=true";


        public static DataTable ExecuteQuery(string query)
        {

            NpgsqlConnection connection = new NpgsqlConnection(_sConnection);
            DataSet ds = new DataSet();

            connection.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);

            connection.Close();

            return ds.Tables[0];
        }

        public static void ExecuteNonquery(string act)
        {

            NpgsqlConnection connection = new NpgsqlConnection(_sConnection);

            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}