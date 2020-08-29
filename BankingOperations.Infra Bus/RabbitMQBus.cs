using BankingOperations.Domain.Core.Event;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
//using Newtonsoft.Json;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingOperations.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator mediator;
        private readonly Dictionary<string, List<Type>> handlers;
        private readonly List<Type> eventTypes;
        public RabbitMQBus(IMediator mediator)
        {
            this.mediator = mediator;
            handlers = new Dictionary<string, List<Type>>();
            eventTypes = new List<Type>();  
        }
        public void Publish<T>(T @event) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection=factory.CreateConnection
                ())
            using (var channel=connection.CreateModel())
            {
                var eventName = @event.GetType().Name;
                channel.QueueDeclare(eventName, false, false, false, null);
                var message = JsonConvert.SerializeObject(@event) ;
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("",eventName,null,body);


            };

                mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);
            if (!eventTypes.Contains(typeof(T))){
                this.eventTypes.Add(typeof(T));
            }
            if(!handlers.ContainsKey(eventName))
            {
                this.handlers.Add(eventName, new List<Type>());
            }

            if (handlers[eventName].Any(H=>H.GetType()==handlerType))
            {
                throw new ArgumentException($"this handeler od type {handlerType.Name} already registered for {eventName}");
            }
            handlers[eventName].Add(handlerType);
        }
        private void StartBasicConsume<T>()where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var eventName = typeof(T).Name;
            channel.QueueDeclare(eventName, false, false, false, null);
            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume(eventName, true, consumer);


        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            var eventName = @event.RoutingKey;
            var message = Encoding.UTF8.GetString((@event.Body).ToArray());
            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (handlers.ContainsKey(eventName))
            {
                var subscriptions = handlers[eventName];
                foreach (var subscription in subscriptions)
                {
                    var hanadler = Activator.CreateInstance(subscription);
                    if (handlers == null) continue;
                    var eventType = eventTypes.SingleOrDefault(t=>t.Name==eventName);
                    var @event = JsonConvert.DeserializeObject(message
                        , eventType); 
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handlers, new object[] { @event });
                }
            }
        }
    }
}
