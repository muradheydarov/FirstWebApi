using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CurrencyController : Controller
    {
        [HttpGet]
        public Currency GetDefaultCurrency()
        {
            Currency currency = new Currency()
            {
                date = DateTime.Now,
                @base = "USD",
                rates = new List<CurrencyItem>()
                {
                    new CurrencyItem(){CurrencyName="TRY", CurrencyValue=7.1946348481f},
                    new CurrencyItem(){CurrencyName="RUB", CurrencyValue=0.84623847f},
                    new CurrencyItem(){CurrencyName="EUR", CurrencyValue=73.6018447999f},
                }
            };

            return currency;
        }

        [HttpGet("{curr}")]
        public Currency GetSpecCurrency(string curr)
        {
            Currency currency = new Currency()
            {
                date = DateTime.Now,
                @base = curr,
                rates = new List<CurrencyItem>()
                {
                    new CurrencyItem(){CurrencyName="TRY", CurrencyValue=7.1946348481f},
                    new CurrencyItem(){CurrencyName="RUB", CurrencyValue=0.84623847f},
                    new CurrencyItem(){CurrencyName="EUR", CurrencyValue=73.6018447999f},
                }
            };

            return currency;
        }

        [HttpGet]
        public string GetParamCurrency(string sample1, string sample2)
        {   
            return sample1 + sample2;
        }
    }
}