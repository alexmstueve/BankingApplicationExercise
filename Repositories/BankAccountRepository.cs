﻿using BankingApplicationExercise.Dtos;
using BankingApplicationExercise.Entities;
using BankingApplicationExercise.Enums;
using BankingApplicationExercise.Interfaces;
using BankingApplicationExercise.Resources;
using Microsoft.Extensions.Options;

namespace BankingApplicationExercise.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private List<BankAccount> Accounts { get; set; }
        private readonly AppConfigurationDto AppConfiguration;
        public BankAccountRepository(IOptions<AppConfigurationDto> appConfiguration) 
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

            AppConfiguration = appConfiguration.Value;
        }

        public BankAccount Deposit(DepositResource resource)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountId == resource.AccountId);
            var customer = Accounts.FirstOrDefault(a => a.CustomerId == resource.CustomerId);

            if (account == null)
            {
                throw new Exception("Account does not exist");
            }
            else if (customer == null)
            {
                throw new Exception("Customer does not exist");
            }
            else if (account.CustomerId != resource.CustomerId)
            {
                throw new Exception("Account does not belong to this customer");
            }

            if (!account.IsActive)
            {
                throw new Exception("Cannot deposit into a closed account");
            }

            account.Balance += resource.Amount;

            return account;
        }

        public BankAccount Withdrawal(WithdrawalResource resource)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountId == resource.AccountId);
            var customer = Accounts.FirstOrDefault(a => a.CustomerId == resource.CustomerId);

            if (account == null)
            {
                throw new Exception("Account does not exist");
            }
            else if (customer == null)
            {
                throw new Exception("Customer does not exist");
            }
            else if (account.CustomerId != resource.CustomerId)
            {
                throw new Exception("Account does not belong to this customer");
            }

            if (!account.IsActive)
            {
                throw new Exception("Cannot withrawal from a closed account");
            }

            if (account.Balance - resource.Amount < 0)
            {
                throw new Exception("Withdrawal would bring account balance below 0");
            }

            account.Balance -= resource.Amount;

            return account;
        }

        public BankAccount Close(CloseAccountResource resource)
        {
            var account = Accounts.FirstOrDefault(a => a.AccountId == resource.AccountId);
            var customer = Accounts.FirstOrDefault(a => a.CustomerId == resource.CustomerId);

            if (account == null)
            {
                throw new Exception("Account does not exist");
            }
            else if (customer == null)
            {
                throw new Exception("Customer does not exist");
            }
            else if (account.CustomerId != resource.CustomerId)
            {
                throw new Exception("Account does not belong to this customer");
            }

            if (account.Balance != 0)
            {
                throw new Exception("Account balance must be 0 in order to close");
            }

            if (!account.IsActive)
            {
                throw new Exception("Account is already closed");
            }

            account.IsActive = false;

            return account;
        }

        public BankAccount Create(CreateAccountResource resource)
        {
            var accounts = Accounts.Where(a => a.CustomerId == resource.CustomerId);

            var validFirstAccountTypes = AppConfiguration.AllowedFirstAccountTypes.Split(",").Select(int.Parse);

            if (accounts.Count() == 0 && !validFirstAccountTypes.Contains(resource.AccountTypeId))
            {
                throw new Exception($"Invalid inital account type, must be in type(s): {AppConfiguration.AllowedFirstAccountTypes}");
            }

            var nextAccountId = Accounts.OrderByDescending(a => a.AccountId).First().AccountId;

            nextAccountId++;

            var newAccount = new BankAccount()
            {
                AccountId = nextAccountId,
                AccountTypeId = (AccountType)resource.AccountTypeId,
                Balance = resource.InitialDeposit,
                CustomerId = resource.CustomerId,
                IsActive = true
            };

            Accounts.Add(newAccount);

            return newAccount;
        }
    }
}
