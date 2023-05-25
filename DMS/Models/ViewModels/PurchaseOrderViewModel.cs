namespace DMS.Models.ViewModels
{
    public class PurchaseOrderViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid VendorId { get; set; }
        public string Description { get; set; }
        public string OrderDate { get; set; }
        public string EntryDate { get; set; }
        public double TotalPrice { get; set; }
        public bool IsActive { get; set; }

        //public List<Guid> PurchaseOrderId { get; set; }
        //public List<Guid> ProductId { get; set; }
        //public List<double> ProductQuantity { get; set; }
        //public List<double> QuantityRemaining { get; set; }
        //public List<double> Amount { get; set; }
    }
}
