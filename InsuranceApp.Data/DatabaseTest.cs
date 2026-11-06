using Microsoft.Data.SqlClient;

namespace InsuranceApp.Data
{
    public class DatabaseTest
    {
        private readonly DatabaseConnection _databaseConnection;

        public DatabaseTest()
        {
            _databaseConnection = new DatabaseConnection();
        }

        /// <summary>
        /// Test funkčního připojejí k databázi
        /// </summary>
        public void TestConnection()
        {
            using SqlConnection connection =
                _databaseConnection.CreateConnection();

            connection.Open();

            Console.WriteLine("Připojení k databázi funguje!");

            using SqlCommand command = new SqlCommand(
                "SELECT DB_NAME()",
                connection);

            string? databaseName = command.ExecuteScalar()?.ToString();

            Console.WriteLine($"Databáze: {databaseName}");

            connection.Close();
        }
    }
}
