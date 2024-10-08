using BankingApplicationExercise.Enums;

namespace BankingApplicationExercise.Resources
{
    public class CreateAccountResource
    {
        public int CustomerId { get; set; }
        public decimal InitialDeposit { get; set; }
        public int AccountTypeId { get; set; }
    }
}