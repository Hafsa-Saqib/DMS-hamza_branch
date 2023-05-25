namespace DMS.Models.DomainModels
{
    public class Booker
    {
        public Guid BookerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public string Area { get; set; }
        public string JoinDate { get; set; }
        public string LeaveDate { get; set; }
        public bool IsActive { get; set; }
    }
}
