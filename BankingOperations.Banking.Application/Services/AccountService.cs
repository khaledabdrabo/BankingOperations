using BankingOperations.Banking.Application.Interfaces;
using BankingOperations.Banking.Domain.Interfaces;
using BankingOperations.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public IEnumerable<Account> Accounts()
        {
            return accountRepository.GetAccounts();
        }
    }
}
