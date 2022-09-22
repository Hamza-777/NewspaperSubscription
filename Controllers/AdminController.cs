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
            return View();
        }

        public IActionResult GetAllVendors()
        {
            var result = db.Vendors.Include(x => x.VendorcityNavigation).ToList();
            return View(result);
        }

        public IActionResult GetAllCustomers()
        {
            var result = db.Customers.Include(x => x.CustomercityNavigation).ToList();
            return View(result);
        }

        public IActionResult AddNewNewspaper()
        {
            return View();
        }

        public IActionResult VendorDetails(int id)
        {
            var result = db.Vendors.Include(x => x.VendorcityNavigation).Where(x => x.Vendorid == id).SingleOrDefault();
            return View(result);
        }

        public IActionResult CustomerDetails(int id)
        {
            var result = db.Customers.Include(x => x.CustomercityNavigation).Where(x => x.Customerid == id).SingleOrDefault();
            return View(result);
        }
    }
}
