using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class PurchaseCategoryController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public PurchaseCategoryController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var purchaseCategory = this.dmsDbContext.PurchaseCategory.Where(x => x.IsActive == true).ToList();
            return View(purchaseCategory);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PurchaseCategoryViewModel categoryViewModel)
        {
            var category = new PurchaseCategory()
            {
                Id = Guid.NewGuid(),
                CategoryID = categoryViewModel.CategoryID,
                Name = categoryViewModel.Name,
                Desc = categoryViewModel.Desc,
                PayableAccount = categoryViewModel.PayableAccount,
                GRIRAccount = categoryViewModel.GRIRAccount,
                IsActive = true
            };
            dmsDbContext.PurchaseCategory.Add(category);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var category = dmsDbContext.PurchaseCategory.FirstOrDefault(x => x.Id == id);
            var categoryView = new PurchaseCategoryViewModel()
            {
                Id = Guid.NewGuid(),
                CategoryID = category.CategoryID,
                Name = category.Name,
                Desc = category.Desc,
                PayableAccount = category.PayableAccount,
                GRIRAccount = category.GRIRAccount,
                IsActive = category.IsActive
            };
            return View(categoryView);
        }
        [HttpPost]
        public IActionResult Edit(PurchaseCategoryViewModel categoryViewModel)
        {
            var category = dmsDbContext.PurchaseCategory.Find(categoryViewModel.Id);
            category.Id = categoryViewModel.Id;
            category.CategoryID = categoryViewModel.CategoryID;
            category.Name = categoryViewModel.Name;
            category.Desc = categoryViewModel.Desc;
            category.PayableAccount = categoryViewModel.PayableAccount;
            category.GRIRAccount = categoryViewModel.GRIRAccount;
            category.IsActive = categoryViewModel.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(PurchaseCategoryViewModel categoryViewModel)
        {
            var category = dmsDbContext.PurchaseCategory.Find(categoryViewModel.Id);
            category.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
