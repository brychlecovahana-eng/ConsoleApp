using InsuranceApp.Services.Models;
using InsuranceApp.Data.Models;

namespace InsuranceApp.Services.Mappers
{
    public class InsuredPersonMapper
    {
        /// <summary>
        /// Převod z DbModelu pojištěného na model pojistné osoby
        /// </summary>
        /// <param name="dbModel">DbModel pojisté osoby</param>
        /// <returns>Model pojištěného</returns>
        public static InsuredPerson MapToInsuredPerson(InsuredPersonDbModel dbModel)
        {
            return new InsuredPerson
            {
                Id = dbModel.Id,
                FirstName = dbModel.FirstName,
                LastName = dbModel.LastName,
                Age = dbModel.Age,
                Phone = dbModel.Phone
            };
        }

        /// <summary>
        /// Převod z modelu pojistné osoby na DbModel pojištěného
        /// </summary>
        /// <param name="model">Model pojistné osoby</param>
        /// <returns>DbModel pojištěného</returns>
        public static InsuredPersonDbModel MapToInsuredPersonDbModel(InsuredPerson model)
        {
            return new InsuredPersonDbModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Phone = model.Phone
            };
        }
    }
}
