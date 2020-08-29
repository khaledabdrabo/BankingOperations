using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Domain.Core.Event
{
    public abstract class Event
    {
        public DateTime Timestamp { get; set; }
        public Event()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
