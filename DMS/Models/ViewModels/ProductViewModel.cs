namespace DMS.Models.ViewModels
{
    public class ProductViewModel
    {
        public string CompanyID = "1";
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public double PurchaseRate { get; set; }
        public double SalesRate { get; set; }
        public int OnHandQty { get; set; }
        public string StockInDate { get; set; }
        public string SKU { get; set; }
        public string Unit { get; set; }
        public string TradeOffer { get; set; }
        public string WarehouseId { get; set; }
        public double Quantity { get; set; }
        public int RefDoc { get; set; }
        public string DocType { get; set; }
        public bool IsActive { get; set; }
    }
}
