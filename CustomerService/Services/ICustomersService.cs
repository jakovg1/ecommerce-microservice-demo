using CustomerService.Models;

namespace CustomerService.Services
{
    public interface ICustomersService
    {
        public void AddCustomer(Customer c);

        public void RemoveCustomer(Customer c);

        public Customer? GetCustomer(int customerId);

        public String? GetCustomerEmail(int customerId);
    }
}
