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
    public class NhanVienController : Controller
    {
		private readonly IAllRepositories<NhanVien> _nhanvienrepo;
		private readonly IAllRepositories<ChucVu> _chucvurepo;
		private NHOM5_C5Context _C5context = new NHOM5_C5Context();
		private DbSet<NhanVien> _nhanvien;

		public NhanVienController()
		{
			
			_nhanvien = _C5context.NhanViens;
			AllRepositories<NhanVien> all = new AllRepositories<NhanVien>(_C5context, _nhanvien);
			_nhanvienrepo = all;
		}
		[HttpGet]
		public async Task<IActionResult> ShowListNhanVien()
		{
			//Response.Headers.Add("Refresh", "1");
			//using (NHOM5_C5Context context = new NHOM5_C5Context())
			//{
			//	var chucvu = context.ChucVus.ToList();
			//	SelectList selectListChucVu = new SelectList(chucvu, "Id", "TenChucVu");
			//	ViewBag.ChucVuList = selectListChucVu;
			//}
			string apiUrl = "https://localhost:7023/api/NhanVien";
			var httpClient = new HttpClient();
			var respose = await httpClient.GetAsync(apiUrl);
			string apiData = await respose.Content.ReadAsStringAsync();
			var nhanvien = JsonConvert.DeserializeObject<List<NhanVien>>(apiData);
			return View(nhanvien);
		}

		[HttpGet]
		public async Task<IActionResult> CreateNv()
		{
			using (NHOM5_C5Context context = new NHOM5_C5Context())
			{
				var chucvu = context.ChucVus.ToList();
				SelectList selectListChucVu = new SelectList(chucvu, "Id", "TenChucVu");
				ViewBag.ChucVuList = selectListChucVu;
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateNv(NhanVien n)
		{


            var client = new HttpClient();
            string url = $"https://localhost:7023/api/NhanVien/create-NhanVien?idchucvu={n.IdchucVu}&ma={n.Ma}&hoTen={n.HoTen}&sDT={n.Sdt}&matKhau={n.MatKhau}&diaChi={n.DiaChi}&gioiTinh={n.GioiTinh}&ngaySinh={n.Ngaysinh}";

			var repons = client.PostAsync(url, null);

            return RedirectToAction("ShowListNhanVien");
		}
		public IActionResult Index()
        {
            return View();
        }
    }
}
