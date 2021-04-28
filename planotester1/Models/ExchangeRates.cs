using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace planotester1.Models
{
    public class ExchangeRates
    {
        [Key]
        public Int64 ERID { get; set; }
        public string CurrencyCode { get; set; }
        public decimal exchangeRates { get; set; }
        public Boolean IsDefault { get; set; }
    }
}
