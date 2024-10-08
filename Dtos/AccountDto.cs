using BankingApplicationExercise.Enums;

namespace BankingApplicationExercise.Dtos
{
    public class AccountDto
    {
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        public AccountType AccountTypeId { get; set; }
        public decimal Balance { get; set; }
        public bool Succeeded { get; set; }
    }
}