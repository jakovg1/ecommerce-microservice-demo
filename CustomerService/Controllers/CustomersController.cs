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
    [HttpGet("{id}")]
    public async Task<String> GetCustomerEmail(int customerId)
    {
        var email = await _customersService.GetCustomerEmail(customerId);
        return email;
        //return _customersService.getCustomer(customerId);
    }
    */

    [HttpGet("{id}")]
    public async Task<Customer> GetCustomer(int customerId)
    {
        var customer = _customersService.GetCustomer(customerId);
        return customer;
    }

}
