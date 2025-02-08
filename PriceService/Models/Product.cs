namespace PriceService.Models
//!!!DUPLICATED IN ORDER SERVICE!!!
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Price { get; set; }
    }
}
