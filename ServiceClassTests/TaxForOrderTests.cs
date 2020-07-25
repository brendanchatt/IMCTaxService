using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClassExample;

namespace ServiceClassTests
{
    [TestClass]
    public class TaxForOrderTests
    {
        private HttpClient client;

        private TaxJarCalculator taxJarCalculator;
        private TaxService taxService;

        private Address customer;
        private Address seller;
        private OrderDetail order;

        [TestInitialize]
        public void InitializeClass()
        {
            client = new HttpClient();
            taxJarCalculator = new TaxJarCalculator(client);
            taxService = new TaxService(taxJarCalculator);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            client.Dispose();
        }

        [TestMethod]
        public async Task USToUSOK()
        {
            seller = new Address(country: "US", zip: 92093, state: "CA", city: "La Jolla", street: "9500 Gilman Drive");
            customer = new Address(country: "US", zip: 90002, state: "CA", city: "Los Angeles", street: "1335 E 103rd St");
            order = new OrderDetail();
            order.Amount = 15;
            order.Shipping = 1.5f;

            var result = await taxService.Calculate(customer, seller, order);
            
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task USToCAOK()
        {
            seller = new Address(country: "US", zip: 92093, state: "CA", city: "La Jolla", street: "9500 Gilman Drive");
            customer = new Address(country: "CA", state: "BC", city: "Vancouver", street: "3333 University Way");
            order = new OrderDetail();
            order.Amount = 35;
            order.Shipping = 4.3f;

            var result = await taxService.Calculate(customer, seller, order);

            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
