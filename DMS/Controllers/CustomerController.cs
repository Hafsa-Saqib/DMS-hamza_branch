using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMS.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public CustomerController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var Customers = this.dmsDbContext.Customers.Where(x => x.IsActive == true).ToList();
            return View(Customers);
        }
        [HttpGet] 
        public IActionResult Add()
        {
            var CC = dmsDbContext.CustomersCategory.Select(x => x.CategoryId).ToList();
            ViewBag.CustomerCategory = new SelectList(CC, "CategoryID");
            return View();
        }
        [HttpPost]
        public IActionResult Add(CustomerViewModel customerView) 
        {
            var Customer = new Customer() 
            {
                Id = Guid.NewGuid(),
                Name = customerView.Name,
                Email = customerView.Email,
                Phone = customerView.Phone,
                Address = customerView.Address,
                CustomerCategory = customerView.CustomerCategory,
                NTN = customerView.NTN,
                CompNo = customerView.CompNo,
                IsActive = true
            }; 
            dmsDbContext.Customers.Add(Customer); 
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");  
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = dmsDbContext.Customers.FirstOrDefault(x => x.Id == id);
            var customerview = new CustomerViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                CustomerCategory = customer.CustomerCategory,
                NTN = customer.NTN,
                CompNo = customer.CompNo,
                IsActive = customer.IsActive
            };
            return View(customerview);
        }
        [HttpPost]
        public IActionResult Edit(CustomerViewModel customerView)
        {
            var Customer = dmsDbContext.Customers.Find(customerView.Id);
            Customer.Id = customerView.Id;
            Customer.Name = customerView.Name;
            Customer.Email = customerView.Email;
            Customer.Phone = customerView.Phone;
            Customer.Address = customerView.Address;
            Customer.CustomerCategory = customerView.CustomerCategory;
            Customer.NTN = customerView.NTN;
            Customer.CompNo = customerView.CompNo;
            Customer.IsActive = customerView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(CustomerViewModel customerView) 
        {
            var Customer = dmsDbContext.Customers.Find(customerView.Id);
            Customer.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
