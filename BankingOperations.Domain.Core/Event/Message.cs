using MediatR;
using System;
using System.Net;

public abstract class Message:IRequest<bool>
{
    public string MessageType { get; protected set; }
    public Message()
    {
        this.MessageType = GetType().Name;
    }
}
