using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class SalesReturnController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public SalesReturnController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var SR = this.dmsDbContext.SalesReturn.Where(x => x.IsActive == true).ToList();
            return View(SR);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(SalesReturnViewModel salesReturnView)
        {
            var SR = new SalesReturn()
            {
                Id = Guid.NewGuid(),
                CustomerID = salesReturnView.CustomerID,
                Reason = salesReturnView.Reason,
                EntryDate = salesReturnView.EntryDate,
                Date = salesReturnView.Date,
                WarehouseId = salesReturnView.WarehouseId,
                UserId = salesReturnView.UserId,
                IsActive = true
            };
            dmsDbContext.SalesReturn.Add(SR);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var SR = dmsDbContext.SalesReturn.FirstOrDefault(x => x.Id == id);
            var salesReturnView = new SalesReturnViewModel()
            {
                Id = SR.Id,
                CustomerID = SR.CustomerID,
                Reason = SR.Reason,
                EntryDate = SR.EntryDate,
                Date = SR.Date,
                WarehouseId = SR.WarehouseId,
                UserId = SR.UserId,
                IsActive = SR.IsActive
            };
            return View(salesReturnView);
        }
        [HttpPost]
        public IActionResult Edit(SalesReturnViewModel salesReturnView)
        {
            var SR = dmsDbContext.SalesReturn.Find(salesReturnView.Id);
            SR.Id = salesReturnView.Id;
            SR.CustomerID = salesReturnView.CustomerID;
            SR.Reason = salesReturnView.Reason;
            SR.EntryDate = salesReturnView.EntryDate;
            SR.Date = salesReturnView.Date;
            SR.WarehouseId = salesReturnView.WarehouseId;
            SR.UserId = salesReturnView.UserId;
            SR.IsActive = salesReturnView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(SalesManViewModel salesReturnView)
        {
            var SR = dmsDbContext.SalesReturn.Find(salesReturnView.Id);
            SR.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
