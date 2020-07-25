using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClassExample;

namespace ServiceClassTests
{
    [TestClass]
    public class TaxRateLocationTests
    {
        private HttpClient client;

        private TaxJarCalculator taxJarCalculator;
        private TaxService taxService;


        [TestInitialize]
        public void TestInitialize()
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
        public async Task RatesByZipOK()
        {
            var getResult = await taxService.GetRatesByLocation(new Address(zip: 33498));

            Assert.AreEqual(getResult.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task RatesOutsideUSOK()
        {
            var getResult = await taxService.GetRatesByLocation(new Address(country: "CA", zip: 98607));

            Assert.AreEqual(getResult.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
