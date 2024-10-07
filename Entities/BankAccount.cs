using BankingApplicationExercise.Enums;

namespace BankingApplicationExercise.Entities
{
    public class BankAccount
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public AccountType AccountTypeId { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}