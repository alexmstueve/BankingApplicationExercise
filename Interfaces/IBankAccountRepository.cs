﻿using BankingApplicationExercise.Entities;
using BankingApplicationExercise.Resources;

namespace BankingApplicationExercise.Services
{
    public interface IBankAccountRepository
    {
        public BankAccount Deposit(DepositResource resource);
    }
}