using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewspaperSubscription.Models;

namespace NewspaperSubscription.Controllers
{
    public class AuthController : Controller
    {
        private readonly NewsSubDBContext db;

        public AuthController(NewsSubDBContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdminLogin(Admin admin)
        {
            var result = (from i in db.Admins where i.Username == admin.Username && i.Password == admin.Password select i).SingleOrDefault();

            if(result != null)
            {
                HttpContext.Session.SetString("LoggedInPersonnel", "Admin");
                HttpContext.Session.SetString("Username", admin.Username);
                return RedirectToAction("Index", "Admin");
            } else
            {
                return View();
            }
        }

        public IActionResult VendorRegister()
        {
            var result = db.Cities.ToList();
            ViewBag.Vendorcity = new SelectList(result, "Cityid", "Cityname");
            return View();
        }

        [HttpPost]
        public IActionResult VendorRegister(Vendor v)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(v);
                db.SaveChanges();
                return RedirectToAction("VendorCredentialsRegister", "Auth");
            }
            return View();
        }

        public IActionResult VendorCredentialsRegister()
        {
            var result = db.Vendors.ToList().TakeLast(1);
            ViewBag.Vendor = new SelectList(result, "Vendorid", "Vendorname");
            return View();
        }

        [HttpPost]
        public IActionResult VendorCredentialsRegister(VendorCredential vc)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("LoggedInPersonnel", "Vendor");
                HttpContext.Session.SetString("Username", vc.Username);
                db.VendorCredentials.Add(vc);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult VendorLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VendorLogin(VendorCredential ven)
        {
            var result = (from i in db.VendorCredentials where i.Username == ven.Username && i.Password == ven.Password select i).Include(x => x.VendorNavigation).SingleOrDefault();

            if (result != null)
            {
                HttpContext.Session.SetString("LoggedInPersonnel", "Vendor");
                HttpContext.Session.SetString("Username", result.Username);
                HttpContext.Session.SetInt32("VendorId", (int)result.VendorNavigation.Vendorid);
                return RedirectToAction("GetAllSubscriptions", "Vendor");
            }
            else
            {
                return View();
            }
        }

        public IActionResult CustomerRegister()
        {
            var result = db.Cities.ToList();
            ViewBag.Customercity = new SelectList(result, "Cityid", "Cityname");
            return View();
        }

        [HttpPost]
        public IActionResult CustomerRegister(Customer c)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(c);
                db.SaveChanges();
                return RedirectToAction("CustomerCredentialsRegister", "Auth");
            }
            return View();
        }

        public IActionResult CustomerCredentialsRegister()
        {
            var result = db.Customers.ToList().TakeLast(1);
            ViewBag.Customer = new SelectList(result, "Customerid", "Customername");
            return View();
        }

        [HttpPost]
        public IActionResult CustomerCredentialsRegister(CustomerCredential cc)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("LoggedInPersonnel", "Customer");
                HttpContext.Session.SetString("Username", cc.Username);
                db.CustomerCredentials.Add(cc);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomerLogin(CustomerCredential cus)
        {
            var result = (from i in db.CustomerCredentials where i.Username == cus.Username && i.Password == cus.Password select i).Include(x => x.CustomerNavigation).SingleOrDefault();

            if (result != null)
            {
                HttpContext.Session.SetString("LoggedInPersonnel", "Customer");
                HttpContext.Session.SetString("Username", result.Username);
                HttpContext.Session.SetInt32("CustomerId", (int)result.CustomerNavigation.Customerid);
                return RedirectToAction("GetAllNewspapers", "Customer");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Auth");
        }
    }
}
