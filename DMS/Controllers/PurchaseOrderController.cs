using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public PurchaseOrderController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var purchaseOrder = this.dmsDbContext.PurchaseOrder.Where(x => x.IsActive == true).ToList();
            return View(purchaseOrder);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PurchaseOrderViewModel purchaseOrderViewModel)
        {
            var purchaseOrder = new PurchaseOrder()
            {
                Id = Guid.NewGuid(),
                UserId = purchaseOrderViewModel.UserId,
                VendorId = purchaseOrderViewModel.VendorId,
                Description = purchaseOrderViewModel.Description,
                OrderDate = purchaseOrderViewModel.OrderDate,
                EntryDate = purchaseOrderViewModel.EntryDate,
                TotalPrice = purchaseOrderViewModel.TotalPrice,
                IsActive = true
            };
            dmsDbContext.PurchaseOrder.Add(purchaseOrder);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var purchaseOrder = dmsDbContext.PurchaseOrder.FirstOrDefault(x => x.Id == id);
            var purchaseOrderViewModel = new PurchaseOrderViewModel()
            {
                Id = Guid.NewGuid(),
                UserId = purchaseOrder.UserId,
                VendorId = purchaseOrder.VendorId,
                Description = purchaseOrder.Description,
                OrderDate = purchaseOrder.OrderDate,
                EntryDate = purchaseOrder.EntryDate,
                TotalPrice = purchaseOrder.TotalPrice,
                IsActive = purchaseOrder.IsActive
            };
            return View(purchaseOrderViewModel);
        }
        [HttpPost]
        public IActionResult Edit(PurchaseOrderViewModel purchaseOrderViewModel)
        {
            var purchaseOrder = dmsDbContext.PurchaseOrder.Find(purchaseOrderViewModel.Id);
            purchaseOrder.Id = purchaseOrderViewModel.Id;
            purchaseOrder.UserId = purchaseOrderViewModel.UserId;
            purchaseOrder.VendorId = purchaseOrderViewModel.VendorId;
            purchaseOrder.Description = purchaseOrderViewModel.Description;
            purchaseOrder.OrderDate = purchaseOrderViewModel.OrderDate;
            purchaseOrder.EntryDate = purchaseOrderViewModel.EntryDate;
            purchaseOrder.TotalPrice = purchaseOrderViewModel.TotalPrice;
            purchaseOrder.IsActive = purchaseOrderViewModel.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(PurchaseOrderViewModel purchaseOrderViewModel)
        {
            var purchaseOrder = dmsDbContext.PurchaseOrder.Find(purchaseOrderViewModel.Id);
            purchaseOrder.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
