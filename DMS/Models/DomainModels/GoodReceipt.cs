namespace DMS.Models.DomainModels
{
    public class GoodReceipt
    {
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public string Description { get; set; }
        public string RecevingDate { get; set; }
        public string EntryDate { get; set; }
        public bool IsPosted { get; set; }
        public Guid WarehouseId { get; set; }
        //public List<Guid> PurchaseOrderDeliveryId { get; set; }
        //public List<Guid> PurchaseOrderproductId { get; set; }
        //public List<double> QuantityRecieved { get; set; }
        //public List<double> TotalAmount { get; set; }
        //public List<double> TotalFee { get; set; }
    }
}
