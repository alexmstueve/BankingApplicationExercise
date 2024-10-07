using BankingApplicationExercise.Dtos;
using BankingApplicationExercise.Entities;
using BankingApplicationExercise.Interfaces;
using BankingApplicationExercise.Resources;

namespace BankingApplicationExercise.Services
{
    public class BankAccountService : IBankAccountService
    {
        private IBankAccountRepository BankAccountRepository { get; set; }

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            BankAccountRepository = bankAccountRepository;
        }

        public AccountBalanceDto Deposit(DepositResource depositResource)
        {
            if (depositResource.Amount <= 0)
            {
                throw new Exception("Deposit amount must be greater than 0");
            }

            var account = BankAccountRepository.Deposit(depositResource);
            var result = AccountBalanceMapper(account);

            return result;
        }

        private AccountBalanceDto AccountBalanceMapper(BankAccount account)
        {
            var accountBalanceDto = new AccountBalanceDto()
            {
                CustomerId = account.CustomerId,
                Balance = account.Balance,
                AccountId = account.AccountId,
                Succeeded = true
            };

            return accountBalanceDto;
        }
    }
}
