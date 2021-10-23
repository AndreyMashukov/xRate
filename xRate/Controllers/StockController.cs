using Microsoft.AspNetCore.Mvc;
using xRate.Services;

namespace xRate.Controllers
{
    [ApiController]
    [Route("stock")]
    public class StockController : ControllerBase
    {
        private readonly IRateRepository _repository;
        
        public StockController(IRateRepository rateRepository)
        {
            this._repository = rateRepository;
        }

        [HttpGet]
        [Route("rates")]
        public Rate[] Get()
        {
            return this._repository.GetList();
        }
    }
}
