namespace ContractService.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public required int CustomerId {  get; set; }
        public required double Discount { get; set; }
    }
}
