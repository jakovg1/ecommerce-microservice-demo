using OrderService.Models;

namespace OrderService.Services 
{
    public class OrdersService : IOrdersService
    {
        private HttpClient _httpClient;
        private ILogger<OrdersService> _logger;

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
            var orderDate = DateOnly.FromDateTime(DateTime.Now);

            var discountString = await _httpClient.GetStringAsync($"http://contractservice:8080/api/contracts/{request.CustomerId}");
            double discount = double.Parse(discountString);

            //var productPriceString = await _httpClient.GetStringAsync($"http://priceservice:8080/api/prices/{request.ProductId}/{orderDate}");
            var productPriceString = await _httpClient.GetStringAsync($"http://priceservice:8080/api/prices/{request.ProductId}");
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
            productPrice = (int)(productPrice * discount);

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
