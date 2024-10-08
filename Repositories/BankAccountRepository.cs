using System.Resources;
using BankingApplicationExercise.Entities;
using BankingApplicationExercise.Enums;
using BankingApplicationExercise.Resources;
using BankingApplicationExercise.Services;

namespace BankingApplicationExercise.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private List<BankAccount> Accounts { get; set; }
        public BankAccountRepository() 
        {
            Accounts = new List<BankAccount>()
            {
                new BankAccount()
                {
                    CustomerId = 5,
                    AccountId = 17,
                    AccountTypeId = AccountType.Checking,
                    Balance = 1000m,
                    IsActive = true
                }
            };
        }

        public BankAccount Deposit(DepositResource resource)
        {
            BankAccount account = Accounts.FirstOrDefault(a => a.AccountId == resource.AccountId);

            if (account == null)
            {
                throw new Exception("Account does not exist");
            }
            else if (account.CustomerId != resource.CustomerId)
            {
                throw new Exception("Account does not belong to this customer");
            }

            account.Balance += resource.Amount;

            return account;
        }

        public BankAccount Withdrawal(WithdrawalResource resource)
        {
            BankAccount account = Accounts.FirstOrDefault(a => a.AccountId == resource.AccountId);

            if (account == null)
            {
                throw new Exception("Account does not exist");
            }
            else if (account.CustomerId != resource.CustomerId)
            {
                throw new Exception("Account does not belong to this customer");
            }

            if (account.Balance - resource.Amount < 0)
            {
                throw new Exception("Withdrawal would bring account balance below 0");
            }

            account.Balance -= resource.Amount;

            return account;
        }
    }
}
