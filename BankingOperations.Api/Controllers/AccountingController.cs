using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingOperations.Banking.Application.Interfaces;
using BankingOperations.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingOperations.Api.Controllers
{
    
    public class AccountingController : Controller
    {
        public readonly IAccountService accountService;
        public AccountingController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return accountService.Accounts();
        }
    }
}
