namespace CustomerService.Models
{
    public class Customers
    {
        public static readonly List<Customer> customers = new()
        {
            new Customer { Id = 1, Name = "Andy", Email = "andy@gmail.com" },
            new Customer { Id = 2, Name = "Welsh", Email = "welsh@gmail.com" },
            new Customer { Id = 3, Name = "Joe", Email = "joe@gmail.com" }
        };
    }
}
