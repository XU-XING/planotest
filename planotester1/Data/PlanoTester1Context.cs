using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using planotester1.Models;


namespace planotester1.Data
{
    public class PlanoTester1Context : DbContext
    {
        public PlanoTester1Context(DbContextOptions<PlanoTester1Context> options) : base(options)
        {
        }

        public DbSet<ExchangeRates> ExchangeRates { get; set; }

        public DbSet<CurrencyProps> CurrencyProps { get; set; }
    }
}
