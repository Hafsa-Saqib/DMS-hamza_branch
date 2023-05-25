namespace DMS.Models.ViewModels
{
    public class ChartsOfAccountsView
    {
        public string AccountTitle { get; set; }
        public Guid ParentId { get; set; }
        public Guid AccountType { get; set; }
        public Guid AccountCategory { get; set; }
        public Guid AccountId { get; set; }
        public string Description { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Date { get; set; }
        public Guid ReferenceNumber { get; set; }
        public string Group { get; set; }
        public string EntryFrom { get; set; }
    }
}
