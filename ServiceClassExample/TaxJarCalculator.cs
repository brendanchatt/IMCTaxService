using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServiceClassExample
{
    public class TaxJarCalculator : ITaxCalculator
    {
        private HttpClient _client;

        private const string _urlTaxForOrder = "https://api.taxjar.com/v2/taxes";
        private const string _urlTaxRateLocation = "https://api.taxjar.com/v2/rates";
        private const string _token = "5da2f821eee4035db4771edab942a4cc";

        public TaxJarCalculator(HttpClient httpClient)
        {
            _client = httpClient;
            _client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _token);
        } 

        public async Task<HttpResponseMessage> Calculate(Address customer, Address supplier, OrderDetail order)
        {
            var values = new Dictionary<string, string>()
            {
                //origin
                { "from_country", supplier.Country },
                { "from_zip", supplier.Zip.ToString() },
                { "from_state", supplier.State },
                { "from_city", supplier.City },
                { "from_street", supplier.Street },
                //destination
                { "to_country", customer.Country },
                { "to_zip", customer.Zip.ToString() },
                { "to_state", customer.State },
                { "to_city", customer.City },
                { "to_street", customer.Street },
                //order
                { "amount", order.Amount.ToString() },
                { "shipping", order.Shipping.ToString() },
                { "customer_id", order.CustomerId },
                { "exemption_type", order.ExemptionType }
            }.Where(pair => pair.Value != null);


            var content = new FormUrlEncodedContent(values);

            //HttpResponseMessage response = new HttpResponseMessage();


            var response = await _client.PostAsync(_urlTaxForOrder, content);


            return response;
        }

        public async Task<HttpResponseMessage> RatesForLocation(Address address)
        {
            var values = new Dictionary<string, string>
            {
                { "country", address.Country },
                { "zip", address.Zip.ToString() },
                { "state", address.State },
                { "city", address.City },
                { "street", address.Street }
            }.Where(pair => pair.Value != null);

            var url = _urlTaxRateLocation + "?";

            foreach (var val in values)
            {
                url += ("&" + val.Key + "=" + val.Value);
            }

            var response = await _client.GetAsync(url);


            return response;
        }
    }
}
