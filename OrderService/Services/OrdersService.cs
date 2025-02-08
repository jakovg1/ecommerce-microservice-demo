using OrderService.Models;

namespace OrderService.Services 
{
    public class OrdersService : IOrdersService
    {
        private HttpClient _httpClient;
        private ILogger<OrdersService> _logger;

        /*
        private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "FlowerPot", Price = 20 },
        new Product { Id = 2, Name = "Table" , Price = 400 },
        new Product { Id = 3, Name = "Book" , Price = 50 }
    };
        */
        private readonly int _defaultProductPrice = 10;
        private readonly string _defaultCustomerEmail = "email.fallback@gmail.com";



        private List<Order> _orders = new () {};
        public OrdersService(HttpClient httpClient, ILogger<OrdersService> logger)
        {
            _httpClient = httpClient;  
            _logger = logger;  
        }

        async Task<Order> IOrdersService.AddOrder(OrderRequest request) 
        {
            var orderDate = $"{DateTime.Now:yyyy - MM - dd}";

            var productPriceString = await _httpClient.GetStringAsync($"http://priceservice:8080/api/prices/{request.ProductId}/{orderDate}");
            int productPrice;
            if (productPriceString == null)
            {
                _logger.LogError($"Product with id {request.CustomerId} was not found. Using default product price: {_defaultProductPrice}");
                productPrice = _defaultProductPrice;
            } else
            {
                productPrice = int.Parse(productPriceString);
            }

            var email = await _httpClient.GetStringAsync($"http://customerservice:8080/api/customers/emails/{request.CustomerId}");
            if (email == null)
            {
                _logger.LogError($"Customer with id {request.CustomerId} was not found. Using default customer email: {_defaultCustomerEmail}");
                email = _defaultCustomerEmail;
            };

            var maxId = _orders.MaxBy(o => o.Id)?.Id ?? 0;
            var orderId = maxId + 1; 

            Order newOrder = new() { Id = orderId, CustomerId = request.CustomerId, 
                ProductId = request.ProductId, ProductPrice = productPrice, CustomerEmail = email };
            _orders.Add(newOrder);
            return newOrder;

        }

        //TODO delete order, update order

        IEnumerable<Order> IOrdersService.GetOrders()
        {
            return _orders;
        }
    }
}
