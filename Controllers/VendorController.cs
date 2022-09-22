using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}
