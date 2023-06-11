using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly IAllRepositories<KhachHang> _khachhangRepo;
        private NHOM5_C5Context _C5context = new NHOM5_C5Context();
        private DbSet<KhachHang> _khachhang;

        public KhachHangController()
        {
            _khachhang = _C5context.KhachHangs;
            AllRepositories<KhachHang> all = new AllRepositories<KhachHang>(_C5context, _khachhang);
            _khachhangRepo = all;
        }

        [HttpGet]
        public async Task<IActionResult> ShowListKhachHang()
        {
            using (NHOM5_C5Context context = new NHOM5_C5Context())
            {
                var kh = context.KhachHangs.ToList();
                SelectList selectListsdt = new SelectList(kh, "Id", "Sdt");
                SelectList selectListmk = new SelectList(kh, "Id", "MatKhau");
                ViewBag.Listsdt = selectListsdt;
                ViewBag.Listmk = selectListmk;
            }

            string apiUrl = "https://localhost:7023/api/KhachHang";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var khachhang = JsonConvert.DeserializeObject<List<KhachHang>>(apiData);
            return View(khachhang);
        }

        [HttpGet]
        public async Task<IActionResult> CreateKhachHang()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateKhachHang(KhachHang k)
        {
            //string data = JsonConvert.SerializeObject(c);
            //string url = $"https://localhost:7023/api/Color/CreteColor?Ma={c.Ma}&ten={c.Ten}";

            //var client = new HttpClient();
            //StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //HttpResponseMessage repons = client.PostAsync(url, content).Result;
            _khachhangRepo.AddItem(k);
            return RedirectToAction("ShowListKhachHang");
        }

        [HttpPost]
        public IActionResult DangNhap(KhachHang kh)
        {
            var loggedInUser = _khachhangRepo.GetAll().FirstOrDefault(c => c.Sdt == kh.Sdt && c.MatKhau == kh.MatKhau);
            if (loggedInUser != null)
            {
                HttpContext.Session.SetString("UserId", JsonConvert.SerializeObject(loggedInUser.Ten.ToString()));
                HttpContext.Session.SetString("UserName", JsonConvert.SerializeObject(loggedInUser.TichDiem));

                TempData["SignUpSuccess"] = "Đăng nhập thành công!";
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            else
            {
                return Json(new { success = false, message = "Vui lòng nhập đúng thông tin tài khoản" });
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
