using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class AccountPayableInvoiceController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public AccountPayableInvoiceController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var APIC = this.dmsDbContext.AccountPayableInvoice.Where(x => x.IsActive == true).ToList();
            return View(APIC);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AccountPayableInvoiceViewModel accountPayableInvoiceView)
        {
            var APIC = new AccountPayableInvoice()
            {
                Id = Guid.NewGuid(),
                UserId = accountPayableInvoiceView.UserId,
                VendorId = accountPayableInvoiceView.VendorId,
                PurchaseOrderDeliveryId = accountPayableInvoiceView.PurchaseOrderDeliveryId,
                BillReceivedDate = accountPayableInvoiceView.BillReceivedDate,
                Description = accountPayableInvoiceView.Description,
                EntryDate = accountPayableInvoiceView.EntryDate,
                Totalamount = accountPayableInvoiceView.Totalamount,
                IsActive = true
            };
            dmsDbContext.AccountPayableInvoice.Add(APIC);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var APIC = dmsDbContext.AccountPayableInvoice.FirstOrDefault(x => x.Id == id);
            var accountPayableInvoiceView = new AccountPayableInvoiceViewModel()
            {
                Id = APIC.Id,
                UserId = APIC.UserId,
                VendorId = APIC.VendorId,
                PurchaseOrderDeliveryId = APIC.PurchaseOrderDeliveryId,
                BillReceivedDate = APIC.BillReceivedDate,
                Description= APIC.Description,
                EntryDate = APIC.EntryDate,
                Totalamount = APIC.Totalamount,
                IsActive = APIC.IsActive
            };
            return View(accountPayableInvoiceView);
        }
        [HttpPost]
        public IActionResult Edit(AccountPayableInvoiceViewModel accountPayableInvoiceView)
        {
            var APIC = dmsDbContext.AccountPayableInvoice.Find(accountPayableInvoiceView.Id);
            APIC.Id = accountPayableInvoiceView.Id;
            APIC.UserId = accountPayableInvoiceView.UserId;
            APIC.VendorId = accountPayableInvoiceView.VendorId;
            APIC.PurchaseOrderDeliveryId = accountPayableInvoiceView.PurchaseOrderDeliveryId;
            APIC.BillReceivedDate = accountPayableInvoiceView.BillReceivedDate;
            APIC.Description = accountPayableInvoiceView.Description;
            APIC.EntryDate = accountPayableInvoiceView.EntryDate;
            APIC.Totalamount = accountPayableInvoiceView.Totalamount;
            APIC.IsActive = accountPayableInvoiceView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(AccountPayableInvoiceViewModel accountPayableInvoiceView)
        {
            var APIC = dmsDbContext.AccountPayableInvoice.Find(accountPayableInvoiceView.Id);
            APIC.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
