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

    /*
    [HttpGet("{customerId}")]
    public IActionResult GetCustomer(int customerId)
    {
        var customer = _customersService.GetCustomer(customerId);
        if(customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }
    */

    [HttpGet("emails/{customerId}")]
    public IActionResult GetCustomerEmail(int customerId)
    {
        var customer = _customersService.GetCustomer(customerId);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer.Email);
    }

}
