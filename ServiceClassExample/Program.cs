using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClassExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PostRequest();
            Console.Read();
        }

        async static void PostRequest()
        {
            using (HttpClient client = new HttpClient())
            {
                var tjCalc = new TaxJarCalculator(client);
                var taxService = new TaxService(tjCalc);

                var seller = new Address(country: "US", zip: 92093, state: "CA", city: "La Jolla", street: "9500 Gilman Drive");
                var customer = new Address(country: "US", zip: 90002, state: "CA", city: "Los Angeles", street: "1335 E 103rd St");
                var ord = new OrderDetail();
                ord.Amount = 15;
                ord.Shipping = 1.5f;

                var result = await taxService.Calculate(customer, seller, ord);
                var resultString = await result.Content.ReadAsStringAsync();

                var getResult = await taxService.GetRatesByLocation(seller);
                var getResultString = await getResult.Content.ReadAsStringAsync();

                Console.WriteLine(resultString);
            }
        }
    }
}
