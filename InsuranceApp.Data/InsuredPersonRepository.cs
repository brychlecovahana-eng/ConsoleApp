using InsuranceApp.Data.Models;
using Microsoft.Data.SqlClient;

namespace InsuranceApp.Data
{
    public class InsuredPersonRepository
    {
        private readonly DatabaseConnection _database;

        public InsuredPersonRepository()
        {
            _database = new DatabaseConnection();
        }

        /// <summary>
        /// Vložení DbModelu pojištěné osoby do databáze
        /// </summary>
        /// <param name="insuredPerson">DbModel pojištěné osoby</param>
        public void AddInsuredPersonDB(InsuredPersonDbModel insuredPerson)
        {
            //Logika pro vložení
            using SqlConnection connection =
                _database.CreateConnection();

            connection.Open();

            using SqlCommand command = new SqlCommand(
                @$"INSERT INTO [InsuredPersons] ([FirstName],[LastName],[Age],[Phone]) 
                VALUES (
                    '{insuredPerson.FirstName}', 
                    '{insuredPerson.LastName}',
                    {insuredPerson.Age},
                    '{insuredPerson.Phone}')",
                connection);

            int result = command.ExecuteNonQuery();

            connection.Close();

            if (result is 0)
            {
                // error
            }
        }

        /// <summary>
        /// Vytažení všech DbModelu pojistných osob z databáze a vložení je do List<>
        /// </summary>
        /// <returns>Seznam DbModelů pojistných osob</returns>
        public List<InsuredPersonDbModel> GetInsuredPersonsDbModels()
        {
            using SqlConnection connection =
                _database.CreateConnection();

            connection.Open();

            using SqlCommand command = new SqlCommand(
                "SELECT * " +
                "FROM [InsuredPersons]", connection);

            using SqlDataReader reader = command.ExecuteReader();

            List<InsuredPersonDbModel> data = new List<InsuredPersonDbModel>();

            while (reader.Read())
            {
                InsuredPersonDbModel model = new InsuredPersonDbModel();

                model.Id = reader.GetInt32(0);
                model.FirstName = reader.GetString(1);
                model.LastName = reader.GetString(2);
                model.Age = reader.GetInt32(3);
                model.Phone = reader.GetString(4);

                data.Add(model);
            }

            connection.Close();

            return data;
        }

        /// <summary>
        /// Vytažení DbModelu pojistných osob jejiž jméno a příjmení se shodují s parametry a vložení do List<>
        /// </summary>
        /// <param name="FirstName">Jméno pojistního</param>
        /// <param name="LastName">příjmení pojistného</param>
        /// <returns>Seznam DbModelu pojistných osob/osoby</returns>
        public List<InsuredPersonDbModel> GetInsuredPersonDbmodel(string FirstName, string LastName)
        {
            using SqlConnection connection =
                _database.CreateConnection();


            connection.Open();

            using SqlCommand command = new SqlCommand(
                "SELECT * " +
                "FROM [InsuredPersons]" +
                "WHERE [FirstName] = @FirstName AND [LastName] = @LastName", connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);

            using SqlDataReader reader = command.ExecuteReader();

            List<InsuredPersonDbModel> singleData = new List<InsuredPersonDbModel>();

            while (reader.Read())
            {
                InsuredPersonDbModel model = new InsuredPersonDbModel();

                model.Id = reader.GetInt32(0);
                model.FirstName = reader.GetString(1);
                model.LastName = reader.GetString(2);
                model.Age = reader.GetInt32(3);
                model.Phone = reader.GetString(4);

                singleData.Add(model);
            }

            connection.Close();

            return singleData;
        }

        /// <summary>
        /// Vytažení DbModelu pojistného z databaze na zaklade Id
        /// </summary>
        /// <param name="id">Id pojistného</param>
        /// <returns>DbModel pojistného</returns>
        public InsuredPersonDbModel GetInsuredPersonById(int id)
        {
            using SqlConnection connection =
                _database.CreateConnection();

            connection.Open();

            using SqlCommand command = new SqlCommand(
                "SELECT * " +
                "FROM [InsuredPersons]" +
                "WHERE [Id] = @Id", connection);

            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = command.ExecuteReader();



            if (reader.Read())
            {
                InsuredPersonDbModel model = new InsuredPersonDbModel();

                model.Id = reader.GetInt32(0);
                model.FirstName = reader.GetString(1);
                model.LastName = reader.GetString(2);
                model.Age = reader.GetInt32(3);
                model.Phone = reader.GetString(4);

                return model;
            }

            return null;
        }

        /// <summary>
        /// Odstranění DbModelu pojistného z databáze na zakladě vloženého Id
        /// </summary>
        /// <param name="id">Id pojistného</param>
        /// <returns>Bool zda se příkaz provedl</returns>
        public bool DeleteInsuredPerson(int id)
        {
            using SqlConnection connection =
                _database.CreateConnection();

            connection.Open();

            using SqlCommand command = new SqlCommand(
                "DELETE FROM [InsuredPersons]" +
                " WHERE [Id] = @Id", connection);

            command.Parameters.AddWithValue("@Id", id);

            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowsAffected > 0;
        }
    }
}
