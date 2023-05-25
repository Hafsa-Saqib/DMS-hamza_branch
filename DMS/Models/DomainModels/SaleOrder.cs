namespace DMS.Models.DomainModels
{
    public class SaleOrder
    {
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public int BookerID { get; internal set; }
        public int WarehouseId  { get; set; }
        public string Description { get; set; }
        public int OrderDate { get; set;}
        public int EntryDate { get; set; }
        public double TotalPrice { get; set; }
        //LineItems
        public Guid Id { get; set; }
     
        public Guid ProductID { get; set; }
        public double ProductQuantity { get; set; }
        public double QuantityRemaining { get; set; }       
        public double Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
