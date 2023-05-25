namespace DMS.Models.DomainModels
{
    public class Warehouse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public bool Sale { get; set; }
    }   
}
