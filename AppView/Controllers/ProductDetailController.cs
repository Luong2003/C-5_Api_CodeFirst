using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using App_Data.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

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
            string apiUrl = "https://localhost:7023/api/ProductDetail/GetAllSanPhamChiTiet";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var ProductDetail = JsonConvert.DeserializeObject<List<ProductDetailViewModel>>(apiData);
            return View(ProductDetail);
        }
        [HttpGet]
        public async Task<IActionResult> ShowListProductSale()
        {
            string apiUrl = "https://localhost:7023/api/ProductDetail/GetAllProductSale";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var ProductSalel = JsonConvert.DeserializeObject<List<ProductDetailViewModel>>(apiData);
            return View(ProductSalel);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSpDetail()
        {
            ViewBag.Color = new SelectList(_C5Context.Colors.ToList().OrderBy(c => c.Ten), "Id", "Ten");
            ViewBag.Size = new SelectList(_C5Context.Sizes.ToList().OrderBy(c => c.Size1), "Id", "Size1");
            ViewBag.Sale = new SelectList(_C5Context.Sales.ToList().OrderBy(c => c.MaSale), "IDSale", "GiaTriSale");
            ViewBag.Product = new SelectList(_C5Context.Products.ToList().OrderBy(c => c.TenSp), "Id", "TenSp");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpDetail(ProductDetail p)
        {
            var spct1 = JsonConvert.SerializeObject(p);
            string url = $"https://localhost:7023/api/ProductDetail/create-ProductDetail?idsp={p.Idproduct}&idcolor={p.Idcolor}&idsize={p.Idsize}&idsale={p.IdSale}&congnghemanhinh={p.CongNgheManHinh}&baohanh={p.BaoHanh}&series={p.Series}&dophangiai={p.DoPhanGiai}&mota={p.MoTa}&soluongton={p.SoLuongTon}&giasale={p.GiaSale}&giaban={p.GiaBan}&nhasanxuat={p.NhaSanXuat}&theloai={p.TheLoai}&ngaysanxuat={p.NgaySanXuat}&trangthaikhuyenmai={p.TrangThaiKhuyenMai}";
            var client = new HttpClient();
            StringContent content = new StringContent(spct1, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;
            return RedirectToAction("ShowListProductDetail");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
