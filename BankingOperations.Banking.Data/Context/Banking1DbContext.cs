using BankingOperations.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingOperations.Banking.Data.Context
{
    public class Banking1DbContext:DbContext
    {
        public Banking1DbContext(DbContextOptions<Banking1DbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
    }
}
