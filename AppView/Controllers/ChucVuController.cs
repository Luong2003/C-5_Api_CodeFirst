using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
	public class ChucVuController : Controller
	{
		private readonly IAllRepositories<ChucVu> _chucvurepo;
		private NHOM5_C5Context _C5context = new NHOM5_C5Context();
		private DbSet<ChucVu> _chucvu;

		public ChucVuController()
		{
			_chucvu = _C5context.ChucVus;
			AllRepositories<ChucVu> all = new AllRepositories<ChucVu>(_C5context, _chucvu);
			_chucvurepo = all;
		}

		[HttpGet]
		public async Task<IActionResult> ShowListChucVu()
		{
			string apiUrl = "https://localhost:7023/api/ChucVu/GetBill";
			var httpClient = new HttpClient();
			var respose = await httpClient.GetAsync(apiUrl);
			string apiData = await respose.Content.ReadAsStringAsync();
			var chucvu = JsonConvert.DeserializeObject<List<ChucVu>>(apiData);
			return View(chucvu);
		}

		[HttpGet]
		public async Task<IActionResult> CreateChucVu()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateChucVu(ChucVu c)
		{
			string data = JsonConvert.SerializeObject(c);
			string url = $"https://localhost:7023/api/ChucVu/CreteColor?machucvu={c.MaChucVu}&tenchucvu={c.TenChucVu}";

			var client = new HttpClient();
			StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
			HttpResponseMessage repons = client.PostAsync(url, content).Result;
			return RedirectToAction("ShowListChucVu");
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
