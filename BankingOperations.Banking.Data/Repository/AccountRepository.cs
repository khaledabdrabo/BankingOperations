using BankingOperations.Banking.Data.Context;
using BankingOperations.Banking.Domain.Interfaces;
using BankingOperations.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Banking1DbContext bankingDbContext;
        public AccountRepository(Banking1DbContext bankingDbContext)
        {
            this.bankingDbContext = bankingDbContext;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return bankingDbContext.Accounts;
        }
    }
}
