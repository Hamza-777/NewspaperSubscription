using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewspaperSubscription.Models;

namespace NewspaperSubscription.Controllers
{
    public class VendorController : Controller
    {
        private readonly NewsSubDBContext db;

        public VendorController(NewsSubDBContext _db)
        {
            db = _db;
        }

        public IActionResult GetAllSubscriptions()
        {
            var result = db.Subscriptions.Include(x => x.VendorNavigation).Include(x => x.CustomerNavigation).Include(x => x.NewspaperNavigation).Where(x => x.VendorNavigation.Vendorid == (int)HttpContext.Session.GetInt32("VendorId")).ToList();
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
