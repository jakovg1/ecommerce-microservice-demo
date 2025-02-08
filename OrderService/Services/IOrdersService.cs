using OrderService.Models;

namespace OrderService.Services
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetOrders();
        Task<Order> AddOrder(OrderRequest request); 

    }
}
