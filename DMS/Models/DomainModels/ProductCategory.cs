namespace DMS.Models.DomainModels
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid RevenueAccountId { get; set; }
        public Guid SalesReturnAccountId { get; set; }
        public Guid InventoryAccountId { get; set; }

    }
}
