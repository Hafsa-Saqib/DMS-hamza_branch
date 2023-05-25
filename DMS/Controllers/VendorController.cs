using DMS.Data;
using DMS.Migrations;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace DMS.Controllers
{
    public class VendorController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public VendorController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var Vendor = this.dmsDbContext.Vendor.Where(x => x.IsActive == true).ToList();
            return View(Vendor);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(VendorViewModel vendorview)
        {
            var Ven = new Vendor()
            {
                Id = Guid.NewGuid(),
                Name = vendorview.Name,
                Email = vendorview.Email,
                Phone = vendorview.Phone,
                Address = vendorview.Address,
                VendorCategory = vendorview.VendorCategory,
                NTN = vendorview.NTN,
                CompNo = vendorview.CompNo,
                IsActive = true
            };
            dmsDbContext.Vendor.Add(Ven);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var Vendor = dmsDbContext.Vendor.FirstOrDefault(x => x.Id == id);
            var vendorview = new VendorViewModel()
            {
                Id = Vendor.Id,
                Name = Vendor.Name,
                Email = Vendor.Email,
                Phone = Vendor.Phone,
                Address = Vendor.Address,
                VendorCategory = Vendor.VendorCategory,
                NTN = Vendor.NTN,
                CompNo= Vendor.CompNo,
                IsActive = Vendor.IsActive
            };
            return View(vendorview);
        }
        [HttpPost]
        public IActionResult Edit(VendorViewModel vendorView)
        {
            var Vendor = dmsDbContext.Vendor.Find(vendorView.Id);
            Vendor.Id = vendorView.Id;
            Vendor.Name = vendorView.Name;
            Vendor.Email = vendorView.Email;
            Vendor.Phone = vendorView.Phone;
            Vendor.Address = vendorView.Address;
            Vendor.VendorCategory = vendorView.VendorCategory;
            Vendor.NTN = vendorView.NTN;
            Vendor.CompNo = vendorView.CompNo;
            Vendor.IsActive = vendorView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(VendorViewModel vendorView)
        {
            var Vendor = dmsDbContext.Vendor.Find(vendorView.Id);
            Vendor.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
   
