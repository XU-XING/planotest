using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace planotester1.Models
{
    public class CurrencyProps
    {
        [Key]
        public Int64 CPID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string CurrencyCode { get; set; }
        public Int16 DecimalPlace { get; set; }
    }
}
