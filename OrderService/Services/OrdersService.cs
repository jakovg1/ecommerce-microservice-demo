﻿using OrderService.Models;

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

        private readonly HttpClient _httpClient;

        private List<Order> _orders = new () {};
        public OrdersService(HttpClient httpClient)
        {
            _httpClient = httpClient;  
        }

        void IOrdersService.AddOrder(OrderRequest request)
        {
            Product? p = _products.Find(p => p.Id == request.ProductId);

            // get customer via API call and get customerEmail??  ????????????????''
            //var email = await _httpClient.GetFromJsonAsync<String>($"http://customerservice/api/email/{customerId}"); 


            var productPrice = p?.Price ?? 10;
            var maxId = _orders.MaxBy(o => o.Id)?.Id ?? 0;
            var orderId = maxId + 1; 

            Order newOrder = new() { Id = orderId, CustomerId = request.CustomerId, 
                ProductId = request.ProductId, ProductPrice = productPrice, CustomerEmail = "foo" };
            _orders.Add(newOrder);

        }

        IEnumerable<Order> IOrdersService.GetOrders()
        {
            return _orders;
        }
    }
}
