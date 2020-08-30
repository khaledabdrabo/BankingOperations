using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Domain.Core.Event
{
    public abstract class Event:INotification
    {
        public DateTime Timestamp { get; set; }
        public Event()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
