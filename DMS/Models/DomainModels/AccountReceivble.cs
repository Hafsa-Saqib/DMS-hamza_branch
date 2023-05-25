namespace DMS.Models.DomainModels
{
    public class AccountReceivble
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid SaleOrderDeliveryDate { get; set; }
        public string BillGivendate { get; set; }
        public string CustomerInvoiceno { get; set; }
        public string EntryDate { get; set; }
        public double TotalAmount { get; }
        //public List<Guid> InvoiceId { get; set; }
        //public List<Guid> SaleOrderId { get; set; }
        //public List<Guid> SaledOrderPRoductId { get; set; }
        //public List<double> Rate { get; set; }  
        //public List<double> QuantityDelivered { get; set; }
        //public List<double> TotalProductAmount { get; set; }

    }
    
}
