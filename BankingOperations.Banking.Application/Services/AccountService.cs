using BankingOperations.Banking.Application.Interfaces;
using BankingOperations.Banking.Application.Models;
using BankingOperations.Banking.Domain.Commands;
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
        private readonly IEventBus _bus;
        public AccountService(IEventBus bus,IAccountRepository accountRepository)
        {
            this._bus = bus; 
            this.accountRepository = accountRepository;
        }
        public IEnumerable<Account> Accounts()
        {
            return accountRepository.GetAccounts();
        }

        public void TransferFund(AccountTransfer accountTransfer)
        {
            //create transfer command
            var createTransferCommad = new CreateTransferCommand(accountTransfer.FromAccount, accountTransfer.ToAccount, accountTransfer.TransferAmount);
            _bus.SendCommand(createTransferCommad );
        }
    }
}
