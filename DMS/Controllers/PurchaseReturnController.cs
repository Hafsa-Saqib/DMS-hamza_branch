using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class PurchaseReturnController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public PurchaseReturnController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var PR = this.dmsDbContext.PurchaseReturn.Where(x => x.IsActive == true).ToList();
            return View(PR);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(PurchaseReturnViewModel purchaseReturnView)
        {
            var PR = new PurchaseReturn()
            {
                Id = Guid.NewGuid(),
                VendorId = purchaseReturnView.VendorId,
                Reason = purchaseReturnView.Reason,
                EntryDate = purchaseReturnView.EntryDate,
                Date = purchaseReturnView.Date,
                WarehouseId = purchaseReturnView.WarehouseId,
                UserId = purchaseReturnView.UserId,
                IsActive = true
            };
            dmsDbContext.PurchaseReturn.Add(PR);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var PR = dmsDbContext.PurchaseReturn.FirstOrDefault(x => x.Id == id);
            var purchaseReturnView = new PurchaseReturnViewModel()
            {
                Id = PR.Id,
                VendorId = PR.VendorId,
                Reason = PR.Reason,
                EntryDate = PR.EntryDate,
                Date = PR.Date,
                WarehouseId = PR.WarehouseId,
                UserId = PR.UserId,
                IsActive = PR.IsActive
            };
            return View(purchaseReturnView);
        }
        [HttpPost]
        public IActionResult Edit(PurchaseReturnViewModel purchaseReturnView)
        {
            var PR = dmsDbContext.PurchaseReturn.Find(purchaseReturnView.Id);
            PR.Id = purchaseReturnView.Id;
            PR.VendorId = purchaseReturnView.VendorId;
            PR.Reason = purchaseReturnView.Reason;
            PR.EntryDate = purchaseReturnView.EntryDate;
            PR.Date = purchaseReturnView.Date;
            PR.WarehouseId = purchaseReturnView.WarehouseId;
            PR.UserId = purchaseReturnView.UserId;
            PR.IsActive = purchaseReturnView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(PurchaseReturnViewModel purchaseReturnView)
        {
            var PR = dmsDbContext.PurchaseReturn.Find(purchaseReturnView.Id);
            PR.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
