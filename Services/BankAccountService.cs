﻿using BankingApplicationExercise.Dtos;
using BankingApplicationExercise.Entities;
using BankingApplicationExercise.Enums;
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

        public AccountBalanceDto Withdrawal(WithdrawalResource withdrawalResource)
        {
            if (withdrawalResource.Amount <= 0)
            {
                throw new Exception("Withdrawal amount must be greater than 0");
            }

            var account = BankAccountRepository.Withdrawal(withdrawalResource);
            var result = AccountBalanceMapper(account);

            return result;
        }

        public ClosedAccountDto Close(CloseAccountResource closeResource)
        {
            var account = BankAccountRepository.Close(closeResource);
            var result = ClosedAccountMapper(account);

            return result;
        }

        public AccountDto Create(CreateAccountResource createAccountResource)
        {
            var initialDepositLimit = 100;
            var validAccountTypes = new List<int>() { (int)AccountType.Checking, (int)AccountType.Savings };
            if (createAccountResource.InitialDeposit < initialDepositLimit)
            {
                throw new Exception($"Initial deposit must be at least ${initialDepositLimit}");
            }
            if (!validAccountTypes.Contains(createAccountResource.AccountTypeId))
            {
                throw new Exception("Invalid account type");
            }

            var account = BankAccountRepository.Create(createAccountResource);
            var result = AccountMapper(account);

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

        private ClosedAccountDto ClosedAccountMapper(BankAccount account)
        {
            var closedAccountDto = new ClosedAccountDto()
            {
                CustomerId = account.CustomerId,
                AccountId = account.AccountId,
                Succeeded = true
            };

            return closedAccountDto;
        }

        private AccountDto AccountMapper(BankAccount account)
        {
            var accountDto = new AccountDto()
            {
                AccountId = account.AccountId,
                AccountTypeId = account.AccountTypeId,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                Succeeded = true
            };

            return accountDto;
        }
    }
}
