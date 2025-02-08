using Microsoft.AspNetCore.Mvc;
using PriceService.Services;
namespace PriceService.Controllers
{
    [ApiController]
    [Route("api/prices")]
    public class PricesController : ControllerBase
    {
        private readonly ILogger<PricesController> _logger;
        private readonly IPricesService _pricesService;

        public PricesController(ILogger<PricesController> logger, IPricesService pricesService)
        {
            _logger = logger;
            _pricesService = pricesService;
        }

        [HttpGet("api/prices/{productId}/{orderDate}")]
        public ActionResult<String> GetProductPrice(int productId, DateOnly orderDate)
        {
            string price = _pricesService.getProductPrice(productId, orderDate);
            if (price == null) return NotFound();
            return Ok(price);
        }
    }
}
