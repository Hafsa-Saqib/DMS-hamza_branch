using System.ComponentModel.DataAnnotations;

namespace DMS.Models.DomainModels
{
    public class PurchaseCategory
    {
        public Guid Id { get; set; }
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Desc { get; set; }

        [Display(Name = "Payable Account")]
        public int PayableAccount { get; set; }

        [Display(Name = "GRIR Account")]
        public int GRIRAccount { get; set; }
        public bool IsActive { get; set; }
    }
}
