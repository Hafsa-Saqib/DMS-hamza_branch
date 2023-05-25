namespace DMS.Models.ViewModels
{
    public class OffersView
    {
        public double TradeOffer { get; set; }
        public Guid ProductId { get; set; }
        public string ToDatefrom { get; set; }
        public string TODateTo { get; set; }
        public double Discount { get; set; }
        public string DiscountDateFrom { get; set; }
        public string DiscountDateTo { get; set; }
    }
}
