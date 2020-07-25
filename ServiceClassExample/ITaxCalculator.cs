using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassExample
{
    public interface ITaxCalculator
    {
        Task<HttpResponseMessage> Calculate(Address customer, Address supplier, OrderDetail order);

        Task<HttpResponseMessage> RatesForLocation(Address address);
    }
}
