using Microsoft.Data.SqlClient;

namespace InsuranceApp.Data
{
    internal class DatabaseConnection
    {
        private readonly string _connectionString =
            "Data Source=YUMPC;" +
            "Initial Catalog=Database;" +
            "Integrated Security=True;" +
            "Encrypt=True;" +
            "Trust Server Certificate=True";

        /// <summary>
        /// Vytvoření nového připojení k databázi, most.
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
