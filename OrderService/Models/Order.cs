namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public required string CustomerEmail { get; set; }
        public int ProductId { get; set; }

        public int ProductPrice { get; set; }
    }
}
