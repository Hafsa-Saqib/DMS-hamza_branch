using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class GoodsDeliveryController : Controller
    {
        private readonly DMSDbContext dMSDbContext;
        public GoodsDeliveryController(DMSDbContext dMSDbContext)
        {
            this.dMSDbContext = dMSDbContext;
        }
        public IActionResult Index()
        {
            var GD = this.dMSDbContext.GoodsDelivery.Where(x => x.IsActive == true).ToList();
            return View(GD);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(GoodsdeliveryViewModel goodsdeliveryView)
        {
            var gd = new GoodsDelivery()
            {
                Id = Guid.NewGuid(),
                SalesOrderId = goodsdeliveryView.SalesOrderId,
                UserId = goodsdeliveryView.UserId,
                SalesManID = goodsdeliveryView.SalesManID,
                WarehouseId = goodsdeliveryView.WarehouseId,
                Description = goodsdeliveryView.Description,
                DeliveryDate = goodsdeliveryView.DeliveryDate,
                EntryDate = goodsdeliveryView.EntryDate,
                IsPosted = goodsdeliveryView.IsPosted,
                IsActive = true
            };
            dMSDbContext.GoodsDelivery.Add(gd);
            dMSDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var gd = dMSDbContext.GoodsDelivery.FirstOrDefault(x => x.Id == id);
            var gdview = new GoodsdeliveryViewModel()
            {
                Id = gd.Id,
                SalesOrderId = gd.SalesOrderId,
                UserId = gd.UserId,
                SalesManID = gd.SalesManID,
                WarehouseId = gd.WarehouseId,
                Description = gd.Description,
                DeliveryDate = gd.DeliveryDate,
                EntryDate = gd.EntryDate,
                IsPosted = gd.IsPosted,
                IsActive = gd.IsActive,
            };
            return View(gdview);
        }
        [HttpPost]
        public IActionResult Edit(GoodsdeliveryViewModel goodsdeliveryView)
        {
            var Gd = dMSDbContext.GoodsDelivery.Find(goodsdeliveryView.Id);
            Gd.Id = goodsdeliveryView.Id;
            Gd.SalesOrderId= goodsdeliveryView.SalesOrderId;
            Gd.UserId = goodsdeliveryView.UserId;
            Gd.SalesManID = goodsdeliveryView.SalesManID;
            Gd.WarehouseId = goodsdeliveryView.WarehouseId;
            Gd.Description = goodsdeliveryView.Description;
            Gd.DeliveryDate = goodsdeliveryView.DeliveryDate;
            Gd.EntryDate = goodsdeliveryView.EntryDate;
            Gd.IsPosted = goodsdeliveryView.IsPosted;
            Gd.IsActive = goodsdeliveryView.IsActive;
            dMSDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(GoodsdeliveryViewModel goodsdeliveryView)
        {
            var gd = dMSDbContext.GoodsDelivery.Find(goodsdeliveryView.Id);
            gd.IsActive = false;
            dMSDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
