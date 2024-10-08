using BankingApplicationExercise.Entities;
using BankingApplicationExercise.Resources;

namespace BankingApplicationExercise.Services
{
    public interface IBankAccountRepository
    {
        public BankAccount Deposit(DepositResource resource);
        public BankAccount Withdrawal(WithdrawalResource resource);
        public BankAccount Close(CloseResource resource);
    }
}