namespace DMS.Models.ViewModels
{
    public class SalesReturnViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerID { get; set; }
        public string Reason { get; set; }
        public string EntryDate { get; set; }
        public string Date { get; set; }
        public Guid WarehouseId { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        //public List<Guid> Salesreturn { get; set; }
        //public List<Guid> ProductId { get; set; }
        //public List<double> QuantityReturn { get; set; }
        //public List<double> Rate { get; set; }
        //public List<double> TotalAmount { get; set; }
    }
}
