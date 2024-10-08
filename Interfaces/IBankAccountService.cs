﻿using BankingApplicationExercise.Dtos;
using BankingApplicationExercise.Resources;

namespace BankingApplicationExercise.Interfaces
{
    public interface IBankAccountService
    {
        public AccountBalanceDto Deposit(DepositResource depositResource);
        public AccountBalanceDto Withdrawal(WithdrawalResource withdrawalResource);
        public ClosedAccountDto Close(CloseAccountResource closeResource);
        public AccountDto Create(CreateAccountResource createAccountResource);
    }
}