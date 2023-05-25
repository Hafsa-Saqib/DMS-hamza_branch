namespace DMS.Models.DomainModels
{
    public class CustomerCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ReceivableAccountId { get; set; }
        public Guid RevenueaccountId { get; set; }
        public bool IsActive { get; set; }
    }
}
