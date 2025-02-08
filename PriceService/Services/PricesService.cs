﻿using PriceService.Models;
namespace PriceService.Services
{
    public class PricesService : IPricesService
    {
        private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "FlowerPot", Price = 20 },
        new Product { Id = 2, Name = "Table" , Price = 400 },
        new Product { Id = 3, Name = "Book" , Price = 50 }
    };
        string IPricesService.getProductPrice(int productId, DateOnly orderDate)
        {
            //order date is not used here
            Product? product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null) return null;
            return product.Price.ToString();
            
        }
    }
}
