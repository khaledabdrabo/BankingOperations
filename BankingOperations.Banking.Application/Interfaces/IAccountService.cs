using BankingOperations.Banking.Application.Models;
using BankingOperations.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Banking.Application.Interfaces
{
   public interface IAccountService
    {
        IEnumerable<Account> Accounts();
        void TransferFund(AccountTransfer accountTransfer);
    }
}
