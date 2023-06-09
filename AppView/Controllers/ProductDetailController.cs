using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IAllRepositories<ProductDetail> _ProductDetailRepo;
        private readonly IAllRepositories<Color> _ColorRepo;
        private readonly IAllRepositories<Size> _SizeRepo;
        private readonly IAllRepositories<Product> _ProductRepo;
        private NHOM5_C5Context _C5Context = new NHOM5_C5Context(); 
        private DbSet<ProductDetail> _ProductsDetail;

        public ProductDetailController()
        {
            _ProductsDetail = _C5Context.ProductDetails;
            AllRepositories<ProductDetail> all = new AllRepositories<ProductDetail>(_C5Context, _ProductsDetail);
            _ProductDetailRepo = all;
        }
        [HttpGet]
        public async Task<IActionResult> ShowListProductDetail()
        {
            string apiUrl = "https://localhost:7023/api/ProductDetail";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var ProductDetail = JsonConvert.DeserializeObject<List<ProductDetail>>(apiData);
            return View(ProductDetail);
        }

        public async Task<IActionResult> CreateSpDetail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpDetail(ProductDetail p)
        {
            _ProductDetailRepo.AddItem(p);
            return RedirectToAction("ShowListProductDetail");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
