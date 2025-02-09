using ContractService.Models;

namespace ContractService.Services
{
    public class ContractsService : IContractsService
    {
        private readonly List<Contract> _contracts = Contracts.contracts;
        private readonly double _discountFallback = 1.0;

        bool IContractsService.CustomerHasContract(int customerId)
        {
            //return _contracts.FirstOrDefault(c => c.CustomerId == customerId) != null;
            return _contracts.Exists(c => c.CustomerId == customerId);
        }

        double? IContractsService.GetDiscountForCustomer(int customerId)
        {
            var contract = _contracts.FirstOrDefault(c => c.CustomerId == customerId);
            if (contract == null) return _discountFallback;
            return contract.Discount;
        }
    }
}
