namespace DMS.Models.ViewModels
{
    public class AccountPayableInvoiceViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid VendorId { get; set; }
        public Guid PurchaseOrderDeliveryId { get; set; }
        public string BillReceivedDate { get; set; }
        public string Description { get; set; }
        public string EntryDate { get; set; }
        public double Totalamount { get; set; }
        public bool IsActive { get; set; }
        //public List<Guid> InvoiceId { get; set; }
        //public List<Guid> PurchaseOrderId { get; set; }
        //public List<Guid> PurchaseOrderProductId { get; set; }
        //public List<double> Rate { get; set; }
        //public List<double> QuantityReceived { get; set; }
        //public List<double> TotalAmount { get; set; }
    }
}
