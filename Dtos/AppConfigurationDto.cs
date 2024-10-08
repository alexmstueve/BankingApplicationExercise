namespace BankingApplicationExercise.Dtos
{
    public class AppConfigurationDto
    {
        public decimal MinimumInitialDeposit { get; set; }
        public string AllowedFirstAccountTypes { get; set; }
        public string AllowedAccountTypes { get; set; }
    }
}