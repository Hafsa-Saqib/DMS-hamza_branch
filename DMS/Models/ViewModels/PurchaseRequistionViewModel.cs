namespace DMS.Models.ViewModels
{
    public class PurchaseRequistionViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Fullfill { get; set; }
        public string EntryDate { get; set; }
        public Guid UserId { get; set; }
        public bool Approved { get; set; }
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
        //public List<Guid> PurchaseRequestId { get; set; }
    }
}
