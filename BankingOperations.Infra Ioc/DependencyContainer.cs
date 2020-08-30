using BankingOperations.Banking.Application.Interfaces;
using BankingOperations.Banking.Application.Services;
using BankingOperations.Banking.Data.Repository;
using BankingOperations.Banking.Domain.Interfaces;
using BankingOperations.Infra_Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(RabbitMQBus));
            // domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();
            // domain repository
            services.AddTransient<IAccountRepository, AccountRepository>();
            // application services
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
