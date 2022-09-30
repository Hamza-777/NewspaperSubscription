using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewspaperSubscription.Models;

namespace NewspaperSubscription.Controllers
{
    public class AdminController : Controller
    {
        private readonly NewsSubDBContext db;

        public AdminController(NewsSubDBContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("LoggedInPersonnel") == null) {
                return RedirectToAction("Index", "Auth");
            } else
            {
                return View();
            }
        }

        public IActionResult GetAllVendors()
        {
            var result = db.Vendors.Include(x => x.VendorcityNavigation).ToList();
            if (HttpContext.Session.GetString("LoggedInPersonnel") == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View(result);
            }
        }

        public IActionResult GetAllCustomers()
        {
            var result = db.Customers.Include(x => x.CustomercityNavigation).ToList();
            if (HttpContext.Session.GetString("LoggedInPersonnel") == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View(result);
            }
        }

        public IActionResult AddNewNewspaper()
        {
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
        public IActionResult AddNewNewspaper(NewsPaper newspaper)
        {
            if (ModelState.IsValid)
            {
                db.NewsPapers.Add(newspaper);
                db.SaveChanges();
            }

            return View();
        }

        public IActionResult VendorDetails(int id)
        {
            var result = db.Vendors.Include(x => x.VendorcityNavigation).Where(x => x.Vendorid == id).SingleOrDefault();
            if (HttpContext.Session.GetString("LoggedInPersonnel") == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View(result);
            }
        }

        public IActionResult CustomerDetails(int id)
        {
            var result = db.Customers.Include(x => x.CustomercityNavigation).Where(x => x.Customerid == id).SingleOrDefault();
            if (HttpContext.Session.GetString("LoggedInPersonnel") == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View(result);
            }
        }
    }
}
