using OrderService.Models;

namespace OrderService.Services
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetOrders();
        void AddOrder(OrderRequest request);

    }
}
