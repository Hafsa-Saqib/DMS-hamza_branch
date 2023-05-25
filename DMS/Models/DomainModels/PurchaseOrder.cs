namespace DMS.Models.DomainModels
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid VendorId { get; set; }
        public string Description { get; set; }
        public string OrderDate { get; set; }
        public string EntryDate { get; set; }
        public double TotalPrice { get; set; }
        public bool IsActive { get; set; }

    }
}
