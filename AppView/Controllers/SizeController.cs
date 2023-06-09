using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class SizeController : Controller
    {
        private readonly IAllRepositories<Size> _Sizerepo;
        private NHOM5_C5Context _C5context = new NHOM5_C5Context();
        private DbSet<Size> _size;

        public SizeController()
        {
            _size = _C5context.Sizes;
            AllRepositories<Size> all = new AllRepositories<Size>(_C5context, _size);
            _Sizerepo = all;
        }
        [HttpGet]
        public async Task<IActionResult> ShowListSize()
        {
            string apiUrl = "https://localhost:7023/api/Size/Getall";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var Size = JsonConvert.DeserializeObject<List<Size>>(apiData);
            return View(Size);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSize()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSize(Size s)
        {
            string data = JsonConvert.SerializeObject(s);
            string url = $"https://localhost:7023/api/Size/CreteSize?Ma={s.Ma}&Size1={s.Size1}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("ShowListSize");
        }

        public IActionResult Index()
        {
            return View();
        }
       
    }
}
