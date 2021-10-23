using System.Net.Http;
using NUnit.Framework;
using xRate;
using xRate.Services;

namespace xRateTest.Services
{
    public class BasicRateRepositoryTest
    {
        private BasicRateRepository _repository;
        
        [SetUp]
        public void Setup()
        {
            this._repository = new BasicRateRepository(new HttpClient());
        }

        [Test]
        public void TestShouldAllowToGetRates()
        {
            Rate[] list = this._repository.GetList();
            Assert.IsInstanceOf<Rate[]>(list);
            
            Assert.AreEqual(list, this._repository.GetList());
        }
    }
}