using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllVendors()
        {
            return View();
        }

        public IActionResult SubscribeToANewspaper()
        {
            return View();
        }

        public IActionResult UnSubscribeToANewspaper()
        {
            return View();
        }
    }
}
