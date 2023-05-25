using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMS.Controllers
{
    public class PurchaseRequisitionController : Controller
    {
        private readonly DMSDbContext dmsDbContext = new DMSDbContext();

        public PurchaseRequisitionController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var PR = this.dmsDbContext.PurchaseRequisition.Where(x => x.Approved == true).ToList();
            return View(PR);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var products = dmsDbContext.Products.Select(x => x.ProductName).ToList();
            ViewBag.Products = new SelectList(products, "ProductID", "ProductName");

            return View();
        }
        [HttpPost]
       // public async Task<IActionResult> PurchaseRequisitionController.Add(Guid ProductID, string ProductName, int ProductQuantity, string Json)

        public IActionResult Add(PurchaseRequistionViewModel purchaseRequistionView)

        {
            var PR = new PurchaseRequisition()
            {
                Id = Guid.NewGuid(),
                Description = purchaseRequistionView.Description,
                Fullfill = purchaseRequistionView.Fullfill,
                EntryDate = purchaseRequistionView.EntryDate,
                UserId = purchaseRequistionView.UserId,
                ProductId = purchaseRequistionView.ProductId,
                ProductQuantity = purchaseRequistionView.ProductQuantity,
                Approved = true
            };
            dmsDbContext.PurchaseRequisition.Add(PR);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var PR = dmsDbContext.PurchaseRequisition.FirstOrDefault(x => x.Id == id);
            var purchaseRequistionView = new PurchaseRequistionViewModel()
            {
                Id = PR.Id,
                Description = PR.Description,
                Fullfill = PR.Fullfill,
                EntryDate = PR.EntryDate,
                UserId = PR.UserId,
                Approved = PR.Approved,
                ProductId = PR.ProductId,
                ProductQuantity = PR.ProductQuantity,
            };
            return View(purchaseRequistionView);
        }
        [HttpPost]
        public IActionResult Edit(PurchaseRequistionViewModel purchaseRequistionView)
        {
            var PR = dmsDbContext.PurchaseRequisition.Find(purchaseRequistionView.Id);
            PR.Id = purchaseRequistionView.Id;
            PR.Description = purchaseRequistionView.Description;
            PR.Fullfill = purchaseRequistionView.Fullfill;
            PR.EntryDate = purchaseRequistionView.EntryDate;
            PR.UserId = purchaseRequistionView.UserId;
            PR.Approved = purchaseRequistionView.Approved;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(PurchaseRequistionViewModel purchaseRequistionView)
        {
            var PR = dmsDbContext.PurchaseRequisition.Find(purchaseRequistionView.Id);
            PR.Approved = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
