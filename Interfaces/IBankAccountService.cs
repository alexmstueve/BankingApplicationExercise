using BankingApplicationExercise.Dtos;
using BankingApplicationExercise.Resources;

namespace BankingApplicationExercise.Interfaces
{
    public interface IBankAccountService
    {
        public AccountBalanceDto Deposit(DepositResource depositResource);
        public AccountBalanceDto Withdrawal(WithdrawalResource withdrawalResource);
        public ClosedAccountDto Close(CloseResource closeResource);
    }
}