using OrderService.Models;
using CustomerService.Models;

namespace OrderService.Services
{
    public class OrdersService : IOrdersService
    {

        private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "FlowerPot", Price = 20 },
        new Product { Id = 2, Name = "Table" , Price = 400 },
        new Product { Id = 3, Name = "Book" , Price = 50 }
    };

        private List<Order> _orders = new () {};
        public OrdersService() { }

        void IOrdersService.AddOrder(OrderRequest request)
        {

            Customer customer = _customers.FirstOrDefault(c => c.Id == request.CustomerId);
            Product product = _products.FirstOrDefault(p => p.Id == productId);

            var maxId = _orders.MaxBy(o => o.Id)?.Id ?? 0;
            var orderId = maxId + 1;

            Order newOrder = new Order() { Id = orderId, CustomerId = customerId, ProductId = productId };
            _orders.Add(newOrder);

        }

        IEnumerable<Order> IOrdersService.GetOrders()
        {
            return _orders;
        }
    }
}
