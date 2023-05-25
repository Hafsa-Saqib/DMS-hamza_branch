using DMS.Data;
using DMS.Migrations;
using DMS.Models.ViewModels;
using DMS.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class SaleOrderController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public SaleOrderController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var SO = this.dmsDbContext.SaleOrders.Where(x => x.IsActive == true).ToList();
            return View(SO);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(SaleOrderViewModel saleOrderView)
        {
            var SO = new DMS.Models.DomainModels.SaleOrder()
            {
                UserID = saleOrderView.UserID,
                CustomerID = saleOrderView.CustomerID,
                BookerID = saleOrderView.BookerId,
                WarehouseId = saleOrderView.WarehouseId,
                Description = saleOrderView.Description,
                OrderDate = saleOrderView.OrderDate,
                EntryDate = saleOrderView.EntryDate,
                TotalPrice = saleOrderView.TotalPrice,
                Id = (Guid)saleOrderView.Id,
                ProductID = saleOrderView.ProductID,
                ProductQuantity = saleOrderView.ProductQuantity,
                QuantityRemaining = saleOrderView.QuantityRemaining,
                Amount = saleOrderView.Amount,
                IsActive = true
            };
            dmsDbContext.SaleOrders.Add(SO);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var SaleOrder = dmsDbContext.SaleOrders.FirstOrDefault(x => x.Id == id);
            var saleOrderView = new SaleOrderViewModel()
            {
                UserID = SaleOrder.UserID,
                CustomerID = SaleOrder.CustomerID,
                BookerId = SaleOrder.BookerID,
                WarehouseId= SaleOrder.WarehouseId,
                Description = SaleOrder.Description,
                OrderDate = SaleOrder.OrderDate,
                EntryDate = SaleOrder.EntryDate,
                TotalPrice = SaleOrder.TotalPrice,
                Id = SaleOrder.Id,
                ProductID = SaleOrder.ProductID,
                ProductQuantity = SaleOrder.ProductQuantity,
                QuantityRemaining = SaleOrder.QuantityRemaining,
                Amount = SaleOrder.Amount,
                IsActive = SaleOrder.IsActive
            };
            return View(saleOrderView);
        }
    }
}
