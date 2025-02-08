namespace PriceService.Services
{
    public interface IPricesService
    {
        string getProductPrice(int productId, DateOnly orderDate); //this should return a proper response object, not a string to be parsed in ObjectService
    }
}
