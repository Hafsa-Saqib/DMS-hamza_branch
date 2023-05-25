using System.ComponentModel.DataAnnotations;

namespace DMS.Models.ViewModels
{
    public class PurchaseCategoryViewModel
    {
        public Guid Id { get; set; }
        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Desc { get; set; }

        [Display(Name = "Payable Account")]
        public int PayableAccount { get; set; }

        [Display(Name = "GRIR Account")]
        public int GRIRAccount { get; set; }
        public bool IsActive { get; set; }

    }
}
