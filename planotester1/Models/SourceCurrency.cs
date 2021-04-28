using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace planotester1.Models
{
    public class SourceCurrency
    {
        public string CurrCode { get; set; }
        public Decimal Amount { get; set; }
        public string TargetCode { get; set; }
    }
}