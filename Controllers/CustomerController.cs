using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewspaperSubscription.Models;

namespace NewspaperSubscription.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NewsSubDBContext db;

        public CustomerController(NewsSubDBContext _db)
        {
            db = _db;
        }

        public IActionResult GetAllNewspapers()
        {
            var result = db.NewsPapers.ToList();
            if (HttpContext.Session.GetString("LoggedInPersonnel") == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View(result);
            }
        }

        public IActionResult SubscribeToANewspaper(int id)
        {
            var customers = db.Customers.ToList().Where(x => x.Customerid == (int)HttpContext.Session.GetInt32("CustomerId"));
            ViewBag.Customer = new SelectList(customers, "Customerid", "Customername");
            var newspapers = db.NewsPapers.ToList().Where(x => x.Newspaperid == id);
            ViewBag.Newspaper = new SelectList(newspapers, "Newspaperid", "Newspapername");
            var vendors = db.Vendors.ToList();
            ViewBag.Vendor = new SelectList(vendors, "Vendorid", "Vendorname");
            if (HttpContext.Session.GetString("LoggedInPersonnel") == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult SubscribeToANewspaper(Subscription subscription)
        {
            if(ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("GetAllNewspapers");
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult UnSubscribeToANewspaper()
        {
            return View();
        }
    }
}
