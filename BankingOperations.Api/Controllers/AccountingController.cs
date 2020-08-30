using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingOperations.Banking.Application.Interfaces;
using BankingOperations.Banking.Application.Models;
using BankingOperations.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingOperations.Api.Controllers
{
    
    public class AccountingController : Controller
    {
        
        
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
