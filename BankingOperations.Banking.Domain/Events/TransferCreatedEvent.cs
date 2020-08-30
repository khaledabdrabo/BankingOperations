using BankingOperations.Domain.Core.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Banking.Domain.Events
{
   public class TransferCreatedEvent:Event
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
        public TransferCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
