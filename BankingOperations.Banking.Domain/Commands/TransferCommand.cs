using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Banking.Domain.Commands
{
   public class TransferCommand:Command
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
    }
}
