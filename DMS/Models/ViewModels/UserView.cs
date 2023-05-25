namespace DMS.Models.ViewModels
{
    public class UserView
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public bool Vendor { get; set; }
        public bool PurchaseRequistion { get; set; }
        public bool PurchaseOrder { get; set; }
        public bool GoodsReceipt { get; set; }
        public bool Category { get; set; }
        public bool Warehouse { get; set; }
        public bool AccountPayableInvoice { get; set; }
        public bool SalesOrder { get; set; }
        public bool Customer { get; set; }
        public bool Delivery { get; set; }
        public bool Booker { get; set; }
        public bool SalesMan { get; set; }
    }
}
