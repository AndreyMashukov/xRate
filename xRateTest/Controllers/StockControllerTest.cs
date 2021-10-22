using System;
using NUnit.Framework;
using xRate;
using xRate.Controllers;
using Moq;
using xRate.Services;

namespace xRateTest.Controllers
{
    public class StockControllerTest
    {
        private StockController _controller;

        private Mock<IRateRepository> _repository;
        
        [SetUp]
        public void Setup()
        {
            this._repository = new Mock<IRateRepository>();
            this._controller = new StockController(this._repository.Object);
        }

        [Test]
        public void TestShouldAllowToGetRateList()
        {
            var date = new DateTime();
            var rate = new Mock<Rate>("USD-RUB", 75.99, date);

            this._repository
                .Setup(repo=> repo.GetList())
                .Returns(new Rate[] { rate.Object });
            
            Rate[] rates = this._controller.Get();

            Assert.IsInstanceOf<Rate[]>(rates);
            Assert.AreEqual("USD-RUB", rates[0].Ticker);
            Assert.AreEqual(75.99, rates[0].Value);
            Assert.AreEqual(rates[0].Date, date);
        }
    }
}
