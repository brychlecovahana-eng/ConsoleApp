namespace InsuranceApp.Console
{
    using InsuranceApp.Services.Models;
    using System;

    public class InsuredPersonView
    {
        
        public InsuredPersonView()
        {
        }

        /// <summary>
        /// Vypsání seznamu List<InsuredPerson> do konzole
        /// </summary>
        /// <param name="insuredPeople">Seznam pojistních osob</param>
        public void DisplayInsuredPeople(List<InsuredPerson> insuredPeople)
        {
            //Kozole vypíše každého pojistného z seznamu
            Console.WriteLine("Id FirstName LastName Age Phone");
            Console.WriteLine("---------------------------------");
            foreach (InsuredPerson person in insuredPeople)
            {
                Console.WriteLine(person.ToString());
            }
        }

        /// <summary>
        /// Vypsání výsledku odstranění pojistného
        /// </summary>
        /// <param name="isTrue"></param>
        public void DisplayDeleteResult(bool isTrue)
        {
            if (isTrue)
            {
                Console.WriteLine("Pojištěný byl odstraněn.");
            }
            else
            {
                Console.WriteLine("Pojistený s zadaným Id nebyl nalezen.");
            }
        }

        /// <summary>
        /// Získání Id pojistného od uživatele
        /// </summary>
        /// <returns>Id</returns>
        public int ReadInsuredPersonId()
        {
            Console.WriteLine("Zadejte Id pojištěného:");
            int Id = Int32.Parse(Console.ReadLine() ?? string.Empty);
            return Id;
        }

        /// <summary>
        /// Získání jména pojistného od uživatele
        /// </summary>
        /// <returns>jméno</returns>
        public string ReadInsuredPersonFirstName()
        {
            Console.WriteLine("Zadej jméno pojistného:");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Získání příjmení pojistného od uživatele
        /// </summary>
        /// <returns>příjmení</returns>
        public string ReadInsuredPersonLastName()
        {
            Console.WriteLine("Zadej příjmení pojistného:");
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
