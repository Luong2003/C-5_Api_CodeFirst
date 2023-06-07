using App_Data.Model;
using App_Data.IRepositories;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class ProductController : Controller
    {   
        private readonly IAllRepositories<Product> _ProductRepo;
        private NHOM5_C5Context _C5Context = new NHOM5_C5Context();
        private DbSet<Product> _Products;

        public ProductController()
        {
            _Products = _C5Context.Products;
            AllRepositories<Product> all = new AllRepositories<Product> (_C5Context ,_Products );
            _ProductRepo = all;
        }
        [HttpGet]
        public async Task<IActionResult> ShowListProduct()
        {
            string apiUrl = "https://localhost:7023/api/Product";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync( apiUrl );
            string apiData = await respose.Content.ReadAsStringAsync();
            var Product = JsonConvert.DeserializeObject<List<Product>>( apiData );
            return View( Product );
        }

        public async Task<IActionResult> CreateSp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSp(Product p)
        {
            _ProductRepo.AddItem( p );
            return RedirectToAction("ShowListProduct");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateSp(Guid id)
        {
            _ProductRepo.GetProductById(id );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSp(Product p)
        {
            _ProductRepo.EditItem(p);
            return RedirectToAction("ShowListProduct");
        }

        public IActionResult DeleteSp(Product p)
        {
            _ProductRepo.RemoveItem(p);
            return RedirectToAction("ShowListProduct");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
