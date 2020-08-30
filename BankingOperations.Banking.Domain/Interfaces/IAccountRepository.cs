using BankingOperations.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Banking.Domain.Interfaces
{
  public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
