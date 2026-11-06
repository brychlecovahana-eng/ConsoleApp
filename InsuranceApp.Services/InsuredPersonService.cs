using InsuranceApp.Data;
using InsuranceApp.Data.Models;
using InsuranceApp.Services.Mappers;
using InsuranceApp.Services.Models;

namespace InsuranceApp.Services
{
    public class InsuredPersonService
    {
        private InsuredPersonRepository InsuredPersonRepository;

        public InsuredPersonService()
        {
            InsuredPersonRepository = new InsuredPersonRepository();
        }

        /// <summary>
        /// Servisní metoda pro přidání pojistné osoby
        /// </summary>
        /// <param name="insuredPerson">Data pojistné osoby</param>
        public void AddInsuredPerson(InsuredPerson insuredPerson)
        {
            InsuredPersonRepository.AddInsuredPersonDB(InsuredPersonMapper.MapToInsuredPersonDbModel(insuredPerson));
        }
        
        /// <summary>
        /// Servisní metoda pro vypsíní seznamu pojištěných
        /// </summary>
        /// <returns>Seznam všech pojištěných</returns>
        public List<InsuredPerson> GetInsuredPersons()
        {
            List<InsuredPersonDbModel> people = InsuredPersonRepository.GetInsuredPersonsDbModels();
            return people.Select(p => InsuredPersonMapper.MapToInsuredPerson(p)).ToList();
        }

        /// <summary>
        /// Servisní metoda pro vypsaní pojistné osoby dele zadaného jména a příjmení
        /// </summary>
        /// <param name="FirstName">Jméno pojištěného</param>
        /// <param name="LastName">Příjmení pojištěného</param>
        /// <returns>Seznam pojištěných osob/osoby</returns>
        public List<InsuredPerson> GetInsuredPerson(string FirstName, string LastName)
        {
            List<InsuredPersonDbModel> people = InsuredPersonRepository.GetInsuredPersonDbmodel(FirstName, LastName);
            return people.Select(p => InsuredPersonMapper.MapToInsuredPerson(p)).ToList();
        }

        /// <summary>
        /// Servisní metoda pro získání Id pojistného
        /// </summary>
        /// <param name="id">Id pojistného</param>
        /// <returns>Pojištěná osoba</returns>
        public InsuredPerson GetInsuredPersonById(int id)
        {
            InsuredPersonDbModel DbModel = InsuredPersonRepository.GetInsuredPersonById(id);
            return InsuredPersonMapper.MapToInsuredPerson(DbModel);
        }

        /// <summary>
        /// Servisní metoda pro odstranění pojištěné osoby
        /// </summary>
        /// <param name="id">Id pojistného</param>
        /// <returns>Bool pro provedení příkazu</returns>
        public bool DeleteInsuredPerson(int id)
        {
            return InsuredPersonRepository.DeleteInsuredPerson(id);
        }
    }
}
