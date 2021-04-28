using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using planotester1.Models;
using planotester1.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace planotester1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConvertCurrencyController : Controller
    {
        private readonly PlanoTester1Context _context;

        public ConvertCurrencyController(PlanoTester1Context context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "This is a test result!";
        }

        // POST api/convertcurrency
        [HttpPost]
        public ActionResult<TargetCurrency> PostConvertCurrency([FromBody] Models.SourceCurrency sourceCurrency )
        {

            TargetCurrency targetCurrency = new TargetCurrency();
            if (sourceCurrency == null)
            {
                targetCurrency.Result = "No Valid Currency is Pass!";
            }
            else
            {
                //Console.WriteLine("sourceCurrency.CurrCode:" + sourceCurrency.CurrCode);
                //Console.WriteLine("sourceCurrency.TargetCode:" + sourceCurrency.TargetCode);
                //Console.WriteLine("sourceCurrency.Amount:" + sourceCurrency.Amount);
                var list1 = from g in  _context.ExchangeRates where g.CurrencyCode == sourceCurrency.CurrCode select g;
                var list2 = from g in  _context.ExchangeRates where g.CurrencyCode == sourceCurrency.TargetCode select g;
                Console.WriteLine(list1.Count());

                ExchangeRates exchangeRate1 = list1.FirstOrDefault();
                ExchangeRates exchangeRate2 = list2.FirstOrDefault();

                if (exchangeRate1 == null || exchangeRate2 == null)
                {
                    targetCurrency.Result = "Cant Support Currently By System";
                }
                else
                {
                    var list3 = from g in _context.CurrencyProps where g.CurrencyCode == sourceCurrency.TargetCode select g;
                    CurrencyProps currencyProps = list3.FirstOrDefault();
                    if (currencyProps != null)
                    {
                        var tarAmt = sourceCurrency.Amount / exchangeRate1.exchangeRates * exchangeRate2.exchangeRates;
                        targetCurrency.Result = currencyProps.Symbol + String.Format(currencyProps.DecimalPlace == 0 ?"{0:0}" : "{0:0.00}", tarAmt);
                    }
                }
            }
            
            return targetCurrency;
        }
    }
}
