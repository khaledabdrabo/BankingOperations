using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BankingOperations.Banking.Application.Models
{
   public class AccountTransfer
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
