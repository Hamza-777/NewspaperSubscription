using Microsoft.AspNetCore.Mvc;

namespace NewspaperSubscription.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllVendors()
        {
            return View();
        }

        public IActionResult GetAllCustomers()
        {
            return View();
        }

        public IActionResult AddNewNewspaper()
        {
            return View();
        }
    }
}
