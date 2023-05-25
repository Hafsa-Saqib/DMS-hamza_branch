using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class CustomerCategoryController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public CustomerCategoryController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var CC = this.dmsDbContext.CustomersCategory.Where(x => x.IsActive == true).ToList();
            return View(CC);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CustomerCategoryViewModel customerCategoryView)
        {
            var CC = new CustomerCategory()
            {
                Id = Guid.NewGuid(),
                Name = customerCategoryView.Name,
                Description = customerCategoryView.Description,
                CategoryId = customerCategoryView.CategoryId,
                ReceivableAccountId = customerCategoryView.ReceivableAccountId,
                RevenueaccountId = customerCategoryView.RevenueaccountId,
                IsActive = true
            };
            dmsDbContext.CustomersCategory.Add(CC);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var CC = dmsDbContext.CustomersCategory.FirstOrDefault(x => x.Id == id);
            var customerCategoryview = new CustomerCategoryViewModel()
            {
                Id = CC.Id,
                Name = CC.Name,
                Description = CC.Description,
                CategoryId = CC.CategoryId,
                ReceivableAccountId = CC.ReceivableAccountId,
                RevenueaccountId = CC.RevenueaccountId,
                IsActive = CC.IsActive
            };
            return View(customerCategoryview);
        }
        [HttpPost]
        public IActionResult Edit(CustomerCategoryViewModel customerCategoryView)
        {
            var CC = dmsDbContext.CustomersCategory.Find(customerCategoryView.Id);
            CC.Id = customerCategoryView.Id;
            CC.Name = customerCategoryView.Name;
            CC.Description = customerCategoryView.Description;
            CC.CategoryId = customerCategoryView.CategoryId;
            CC.ReceivableAccountId = customerCategoryView.ReceivableAccountId;
            CC.RevenueaccountId = customerCategoryView.RevenueaccountId;
            CC.IsActive = customerCategoryView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(CustomerCategoryViewModel customerCategoryView)
        {
            var CC = dmsDbContext.CustomersCategory.Find(customerCategoryView.Id);
            CC.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
