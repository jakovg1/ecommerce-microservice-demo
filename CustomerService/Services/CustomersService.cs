using CustomerService.Models;

namespace CustomerService.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly List<Customer> _customers = new()
        {
            new Customer { Id = 1, Name = "Andy", Email = "andy@gmail.com" },
            new Customer { Id = 2, Name = "Welsh", Email = "welsh@gmail.com" },
            new Customer { Id = 3, Name = "Joe", Email = "joe@gmail.com" }
        };
        void ICustomersService.AddCustomer(Customer c)
        {
            _customers.Add(c);
        }

        Customer? ICustomersService.GetCustomer(int customerId)
        {
            var customer = _customers.Find(x => x.Id == customerId);
            return customer;
        }

        void ICustomersService.RemoveCustomer(Customer c)
        {
             _customers.Remove(c);
        }

        string? ICustomersService.GetCustomerEmail(int customerId)
        {
            var customer = _customers.Find(x => x.Id == customerId);
            if (customer == null) return null;
            return customer.Email;
        }
    }
}
