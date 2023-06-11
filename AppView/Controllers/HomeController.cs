using App_Data.IRepositories;
using App_Data.Model;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NHOM5_C5Context _context;
        private readonly IAllRepositories<ChucVu> _chucvurepo;
        private readonly IAllRepositories<Cart> _Cartrepo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangNhap(string sdt, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _context.KhachHangs.FirstOrDefault(s => s.Sdt.Equals(sdt) && s.MatKhau.Equals(password));
                //var role = _chucvurepo.GetAll();

                if (user != null)
                {
                    _Cartrepo.AddItem(new Cart()
                    {
                        Id = user.Id,
                        
                    });
                    HttpContext.Session.SetString("username", sdt);
                    HttpContext.Session.SetString("username", user.Ten);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("username", "");
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}