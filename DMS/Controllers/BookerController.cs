using DMS.Data;
using DMS.Models.DomainModels;
using DMS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    public class BookerController : Controller
    {
        private readonly DMSDbContext dmsDbContext;

        public BookerController(DMSDbContext dmsDbContext)
        {
            this.dmsDbContext = dmsDbContext;
        }
        public IActionResult Index()
        {
            var Booker = this.dmsDbContext.Bookers.Where(x => x.IsActive == true) .ToList();
            return View(Booker);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookerViewModel bookerview)
        {
            var Booker = new Booker()
            {
                BookerId = Guid.NewGuid(),
                Name = bookerview.Name,
                Phone = bookerview.Phone,
                Address = bookerview.Address,
                CNIC = bookerview.CNIC,
                Area = bookerview.Area,
                JoinDate = bookerview.JoinDate,
                LeaveDate = bookerview.LeaveDate,
                IsActive = true
            };
            dmsDbContext.Bookers.Add(Booker);
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var booker = dmsDbContext.Bookers.FirstOrDefault(x => x.BookerId == id);
            var bookerview = new BookerViewModel()
            {
                BookerId= booker.BookerId,
                Name = booker.Name,
                Phone = booker.Phone,
                Address = booker.Address,
                CNIC= booker.CNIC,
                Area = booker.Area,
                JoinDate = booker.JoinDate,
                LeaveDate= booker.LeaveDate,
                IsActive = booker.IsActive
            };
            return View(bookerview);
        }
        [HttpPost]
        public IActionResult Edit(BookerViewModel bookerView)
        {
            var Booker = dmsDbContext.Bookers.Find(bookerView.BookerId);
            Booker.BookerId = bookerView.BookerId;
            Booker.Name = bookerView.Name;
            Booker.Phone = bookerView.Phone;
            Booker.Address = bookerView.Address;
            Booker.CNIC = bookerView.CNIC;
            Booker.Area = bookerView.Area;
            Booker.JoinDate = bookerView.JoinDate;
            Booker.LeaveDate = bookerView.LeaveDate;
            Booker.IsActive = bookerView.IsActive;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(BookerViewModel bookerView)
        {
            var Booker = dmsDbContext.Bookers.Find(bookerView.BookerId);
            Booker.IsActive = false;
            dmsDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
