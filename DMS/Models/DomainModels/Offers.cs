namespace DMS.Models.DomainModels
{
    public class Offers
    {
        public Guid Id { get; set; }
        public double TradeOffer { get; set; }
        public Guid ProductId { get; set; }
        public string ToDatefrom { get; set; }
        public string TODateTo { get; set; }
        public double Discount { get; set; }
        public string DiscountDateFrom { get; set; }
        public string DiscountDateTo { get;set; }

    }
}
