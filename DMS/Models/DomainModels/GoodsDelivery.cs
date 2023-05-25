namespace DMS.Models.DomainModels
{
    public class GoodsDelivery
    {
        public Guid Id { get; set; }
        public int SalesOrderId { get; set; }
        public int UserId { get; set; }
        public int SalesManID { get; set; }
        public int WarehouseId { get; set; }
        public string Description { get; set; }
        public string DeliveryDate { get; set; }
        public  string EntryDate { get; set; }
        public bool IsPosted { get; set; }
        public bool IsActive { get; set; }
        //public List<int> SalesOrderDeliveryID { get; set; }
        //public List<int> SaleOrderItemID { get; set; }
        //public List<double> QuantityDelivered { get; set; }
        //public List<double> QuantityReturn { get; set; }
        //public List<double> TotalAmount { get; set; }

    }
}
