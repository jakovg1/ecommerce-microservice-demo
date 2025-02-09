namespace ContractService.Services
{
    public interface IContractsService
    {
        public bool CustomerHasContract(int customerId);

        public double? GetDiscountForCustomer(int customerId);
        // the whole point of contracts is that users have discounts defined by contracts (for all products)
    }
}
