namespace ContractService.Models
{
    public class Contracts
    {
        public static readonly List<Contract> contracts = new()
        {
            new Contract{ Id = 1, CustomerId = 1, Discount = 0.5},
            new Contract{ Id = 2, CustomerId = 2, Discount = 0.1}
        };
    }
}
