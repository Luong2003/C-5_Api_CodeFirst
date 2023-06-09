using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class SaleController : Controller
    {
        private readonly IAllRepositories<Sale> _SaleRepo;
        private NHOM5_C5Context _C5context = new NHOM5_C5Context();
        private DbSet<Sale> _sales;

        public SaleController()
        {
            _sales = _C5context.Sales;
            AllRepositories<Sale> all = new AllRepositories<Sale>(_C5context, _sales);
            _SaleRepo = all;
        }
        [HttpGet]
        public async Task<IActionResult> ShowListSale()
        {
            string apiUrl = "https://localhost:7023/api/Sale/Getall";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var Sale = JsonConvert.DeserializeObject<List<Sale>>(apiData);
            return View(Sale);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSale()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSale(Sale s)
        {
            string data = JsonConvert.SerializeObject(s);
            string url = $"https://localhost:7023/api/Sale/CreteSale?masale={s.MaSale}&nbd={s.NgayBatDau}&nkt={s.NgayKetThuc}&giatrisale={s.GiaTriSale}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("ShowListSale");
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
