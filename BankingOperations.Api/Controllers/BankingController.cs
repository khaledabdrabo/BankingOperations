using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingOperations.Banking.Application.Interfaces;
using BankingOperations.Banking.Application.Models;
using BankingOperations.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BankingOperations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        public readonly IAccountService accountService;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        private readonly ILogger<BankingController> _logger;

        public BankingController(IAccountService accountService,ILogger<BankingController> logger)
        {
            this.accountService = accountService;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return accountService.Accounts();
        }
        [HttpPost]
        public IActionResult Post(AccountTransfer accountTransfer)
        {
            accountService.TransferFund(accountTransfer);
            return Ok();
        }
        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
