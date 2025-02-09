using ContractService.Models;
using ContractService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContractService.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractsController : ControllerBase
    {
        private readonly ILogger<ContractsController> _logger;
        private readonly IContractsService _contractsService;

        private readonly double _discountFallback = 1.0;

        public ContractsController(ILogger<ContractsController> logger, IContractsService contractsService)
        {
            _logger = logger;
            _contractsService = contractsService;
        }

        [HttpGet("{customerId}")]
        public IActionResult GetDiscountForCustomer(int customerId)
        {
            var customerDiscount = _contractsService.GetDiscountForCustomer(customerId) ?? _discountFallback;
            return Ok(customerDiscount);
        }
    }
}
