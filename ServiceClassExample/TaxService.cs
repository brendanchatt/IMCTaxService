using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassExample
{
    public class TaxService
    {
        ITaxCalculator _calculator;

        public TaxService(ITaxCalculator calc)
        {
            _calculator = calc;
        }

        public async Task<HttpResponseMessage> Calculate(Address customer, Address supplier, OrderDetail order)
        {
            var result = await _calculator.Calculate(customer, supplier, order);
            return result;
        }

        public async Task<HttpResponseMessage> GetRatesByLocation(Address location)
        {
            var result = await _calculator.RatesForLocation(location);

            return result;
        }
    }
}
