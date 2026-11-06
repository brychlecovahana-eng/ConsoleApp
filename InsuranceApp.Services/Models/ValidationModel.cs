namespace InsuranceApp.Services.Models
{
    public class ValidationModel
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public ValidationModel()
        {
        }

        /// <summary>
        /// Model pro validaci
        /// </summary>
        /// <param name="isValid">Bool vystup z podmínek</param>
        /// <param name="messege">Zpráva neuspěšné validace podmínky</param>
        public ValidationModel(bool isValid, string messege)
        {
            this.IsValid = isValid;
            this.Message = messege;
        }
    }
}
