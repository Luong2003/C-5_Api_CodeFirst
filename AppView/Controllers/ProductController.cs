using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing;
using System.Text;

namespace AppView.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAllRepositories<Product> _productRepo;
        private NHOM5_C5Context _C5context = new NHOM5_C5Context();
        private DbSet<Product> _product;

        public ProductController()
        {
            _product = _C5context.Products;
            AllRepositories<Product> all = new AllRepositories<Product>(_C5context, _product);
            _productRepo = all;
        }
        [HttpGet]
        public async Task<IActionResult> ShowListProduct()
        {
            string apiUrl = "https://localhost:7023/api/Product";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<List<Product>>(apiData);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product p)
        {
            //string data = JsonConvert.SerializeObject(c);
            //string url = $"https://localhost:7023/api/Color/CreteColor?Ma={c.Ma}&ten={c.Ten}";

            //var client = new HttpClient();
            //StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //HttpResponseMessage repons = client.PostAsync(url, content).Result;
            _productRepo.AddItem(p);
            return RedirectToAction("ShowListProduct");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
