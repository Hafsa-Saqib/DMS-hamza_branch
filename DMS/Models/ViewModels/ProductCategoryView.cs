namespace DMS.Models.ViewModels
{
    public class ProductCategoryView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid RevenueAccountId { get; set; }
        public Guid SalesReturnAccountId { get; set; }
        public Guid InventoryAccountId { get; set; }
    }
}
