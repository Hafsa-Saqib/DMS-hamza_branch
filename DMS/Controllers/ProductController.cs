using DMS.Models.DomainModels;
using DMS.Data;
using DMS.Migrations;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class ProductController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public ProductController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
            public IActionResult Index()
        {
            var Product = this.dmsDbContext.Products.Where(x => x.IsActive == true).ToList();
            return View(Product);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel productView)
        {
            var Pro = new DMS.Models.DomainModels.Product()
            {
                CompanyID = productView.CompanyID,
                ProductID = productView.ProductID,
                ProductType = productView.ProductType,
                ProductCategory = productView.ProductCategory,
                PurchaseRate = productView.PurchaseRate,
                SalesRate = productView.SalesRate,
                OnHandQty = productView.OnHandQty,
                StockInDate = productView.StockInDate,
                SKU = productView.SKU,
                Unit = productView.Unit,
                TradeOffer = productView.TradeOffer,
                WarehouseId = productView.WarehouseId,
                Quantity = productView.Quantity,
                RefDoc = productView.RefDoc,
                DocType = productView.DocType,
                IsActive = true
            };
            dmsDbContext.Products.Add(Pro);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var Product = dmsDbContext.Products.FirstOrDefault(x => x.ProductID == id);
            var productView = new ProductViewModel()
            {
                CompanyID = Product.CompanyID,
                ProductID = Product.ProductID,
                ProductType = Product.ProductType,
                ProductCategory = Product.ProductCategory,
                PurchaseRate = Product.PurchaseRate,
                SalesRate = Product.SalesRate,
                OnHandQty = Product.OnHandQty,
                StockInDate = Product.StockInDate,
                SKU = Product.SKU,
                Unit = Product.Unit,
                TradeOffer = Product.TradeOffer,
                WarehouseId = Product.WarehouseId,
                Quantity = Product.Quantity,
                RefDoc = Product.RefDoc,
                DocType = Product.DocType,               
                IsActive = Product.IsActive
            };
            return View(productView);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel productView)
        {
            var Product = dmsDbContext.Products.Find(productView.CompanyID);

            Product.CompanyID = productView.CompanyID;
            Product.ProductID = productView.ProductID;
            Product.ProductType = productView.ProductType;
            Product.ProductCategory = productView.ProductCategory;
            Product.PurchaseRate = productView.PurchaseRate; 
            Product.SalesRate = productView.SalesRate;
            Product.OnHandQty = productView.OnHandQty; 
            Product.StockInDate = productView.StockInDate; 
            Product.SKU = productView.SKU;
            Product.Unit = productView.Unit;
            Product.TradeOffer = productView.TradeOffer;
            Product.WarehouseId = productView.WarehouseId;
            Product.Quantity = productView.Quantity;
            Product.RefDoc = productView.RefDoc;
            Product.DocType = productView.DocType;
            Product.IsActive = productView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(ProductViewModel productView) 
        {
            var Product = dmsDbContext.Products.Find(productView.ProductID);
            Product.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
