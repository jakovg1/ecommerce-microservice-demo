using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IOrdersService _ordersService;

    public OrdersController(ILogger<OrdersController> logger, IOrdersService ordersService)
    {
        _logger = logger;
        _ordersService = ordersService;
    }

    [HttpGet]
    public IActionResult GetOrders() => Ok(_ordersService.GetOrders());

    [HttpPost]
    public IActionResult AddOrder([FromBody] OrderRequest request)
    {
        _ordersService.AddOrder(request);
        return Ok();
    }
}
