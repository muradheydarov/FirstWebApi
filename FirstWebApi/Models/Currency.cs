using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApi.Models
{
    public class Currency
    {
        public List<CurrencyItem> rates { get; set; }
        public string @base { get; set; }
        public DateTime date { get; set; }
    }

    public class CurrencyItem
    {
        public string CurrencyName { get; set; }
        public float CurrencyValue { get; set; }
    }
}
