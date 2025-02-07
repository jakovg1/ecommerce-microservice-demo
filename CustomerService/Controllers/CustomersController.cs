using CustomerService.Models;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers;

[ApiController]
[Route("api/orders")]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> _logger;
    private readonly ICustomersService _customersService;

    public CustomersController(ILogger<CustomersController> logger, ICustomersService customersService)
    {
        _logger = logger;
        _customersService = customersService;
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _customersService.GetCustomer(id);
        if(customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

}
