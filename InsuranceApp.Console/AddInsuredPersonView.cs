namespace InsuranceApp.Console
{
    using InsuranceApp.Services.Models;
    using System;

    internal class AddInsuredPersonView
    {            
        public AddInsuredPersonView()
        {
        }

        /// <summary>
        /// Získá data a odkáže na validaci uživatele pro přidání pojistného
        /// </summary>
        /// <returns>Data nové pojistné osoby</returns>
        public InsuredPerson StartAddNewInsuredPerson()
        {
            ValidationModel validationResult = new ValidationModel();
            InsuredPerson newInsuredPerson = new InsuredPerson();
            
            do
            {
                //Konzole vypíše text
                Console.WriteLine("Zadejte jméno pojistného:");
                //Uživatel zadá jméno pojistného
                string firstName = Console.ReadLine() ?? string.Empty;
                //Validace dat
                validationResult = InsuredPerson.ValidateFirstName(firstName);
                //Podmínka pro další postup
                if (validationResult.IsValid)
                {
                    newInsuredPerson.FirstName = firstName;
                }
                //Pokud podmínka neprojde konzole vypíše výsledek neuspěšné validace
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(validationResult.Message);
                    Console.ResetColor();
                }
                //Dokud validace není uspěšná, cyklus se opakuje
            } while (!validationResult.IsValid);

            do
            {
                Console.WriteLine("Zadej příjmení pojistného:");
                string lastName = Console.ReadLine() ?? string.Empty;
                validationResult = InsuredPerson.ValidateLastName(lastName);

                if (validationResult.IsValid)
                {
                    newInsuredPerson.LastName = lastName;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(validationResult.Message);
                    Console.ResetColor();
                }
            } while (!validationResult.IsValid);

            do
            {
                Console.WriteLine("Zadej věk pojistného:");
                string age = Console.ReadLine() ?? string.Empty;
                validationResult = InsuredPerson.ValidateAge(age);

                if (validationResult.IsValid)
                {
                    newInsuredPerson.Age = Int32.Parse(age);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(validationResult.Message);
                    Console.ResetColor();
                }
            } while (!validationResult.IsValid);

            do
            {
                Console.WriteLine("Zadej tel. číslo pojistného:");
                string phone = Console.ReadLine() ?? string.Empty;
                validationResult = InsuredPerson.ValidatePhone(phone);

                if (validationResult.IsValid)
                {
                    newInsuredPerson.Phone = phone;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(validationResult.Message);
                    Console.ResetColor();
                }
            } while (!validationResult.IsValid);
            
            return newInsuredPerson;
        }
    }
}
