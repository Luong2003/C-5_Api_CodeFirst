using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Security.Policy;
using C_5_Api_CodeFirst.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppView.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IAllRepositories<ProductDetail> _ProductDetailRepo;
        private readonly IAllRepositories<Color> _ColorRepo;
        private readonly IAllRepositories<Size> _SizeRepo;
        private readonly IAllRepositories<Sale> _SaleRepo;
        private readonly IAllRepositories<Product> _ProductRepo;

        private NHOM5_C5Context _C5Context = new NHOM5_C5Context(); 
        private DbSet<ProductDetail> _ProductsDetail;
        private DbSet<Color> _Color;
        private DbSet<Size> _Size;
        private DbSet<Sale> _Sale;


        public ProductDetailController()
        {
            _ProductsDetail = _C5Context.ProductDetails;
            AllRepositories<ProductDetail> all = new AllRepositories<ProductDetail>(_C5Context, _ProductsDetail);
            AllRepositories<Color> color = new AllRepositories<Color>(_C5Context, _Color);
            AllRepositories<Size> size = new AllRepositories<Size>(_C5Context, _Size);
            AllRepositories<Sale> sale = new AllRepositories<Sale>(_C5Context, _Sale);
            _ProductDetailRepo = all;
            _ColorRepo = color;
            _SizeRepo = size;
            _SaleRepo = sale;
        }
          
		[HttpGet]
        public async Task<IActionResult> ShowListProductDetail()
        {
			using (NHOM5_C5Context context = new NHOM5_C5Context())
			{
				var color = context.Colors.ToList();
				SelectList selectListsColor = new SelectList(color, "Id", "Ten");
				ViewBag.ColorList = selectListsColor;

				var product = context.Products.ToList();
				SelectList selectListsproduct = new SelectList(product, "Id", "TenSp");
				ViewBag.ProductList = selectListsproduct;

				var sale = context.Sales.ToList();
				SelectList selectListSale = new SelectList(sale, "IDSale", "GiaTriSale");
				ViewBag.SaleList = selectListSale;

				var size = context.Sizes.ToList();
				SelectList selectListSize = new SelectList(size, "Id", "Size1");
				ViewBag.SizeList = selectListSize;


				
			}

			string apiUrl = "https://localhost:7023/api/ProductDetail";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var ProductDetail = JsonConvert.DeserializeObject<List<ProductDetail>>(apiData);
            return View(ProductDetail);
        }


        
        [HttpGet]
        public async Task<IActionResult> CreateSpDetail()
        {
            using(NHOM5_C5Context context = new NHOM5_C5Context())
            {
				var color = context.Colors.ToList();
				SelectList selectListsColor = new SelectList(color, "Id", "Ten");
				ViewBag.ColorList = selectListsColor;

				var product = context.Products.ToList();
				SelectList selectListsproduct = new SelectList(product, "Id", "TenSp");
				ViewBag.ProductList = selectListsproduct;

				var sale = context.Sales.ToList();
				SelectList selectListSale = new SelectList(sale, "IDSale", "GiaTriSale");
				ViewBag.SaleList = selectListSale;

				var size = context.Sizes.ToList();
				SelectList selectListSize = new SelectList(size, "Id", "Size1");
				ViewBag.SizeList = selectListSize;


				//ViewBag.Color = new SelectList(_C5Context.Colors.ToList().OrderBy(c => c.Ten), "Id", "Ten");
				//ViewBag.Size = new SelectList(_C5Context.Sizes.ToList().OrderBy(c => c.Size1), "Id", "Size1");
				//ViewBag.Sale = new SelectList(_C5Context.Sales.ToList().OrderBy(c => c.MaSale), "IDSale", "GiaTriSale");
				//ViewBag.Product = new SelectList(_C5Context.Products.ToList().OrderBy(c => c.TenSp), "Id", "TenSp");
				//var product = _C5Context.Products.ToList();
				//List<Product> lstproduct = new List<Product>();
				//ViewData["TenSp"] = new SelectList(lstproduct, "Id", "TenSp");
				//ViewBag.Products = new Product();
				
			}
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> CreateSpDetail(ProductDetail p)
        {
            //HttpClient client = new HttpClient();
            //string apiUrl = $"https://localhost:7023/api/ProductDetail/create-ProductDetail?idsp={p.Idproduct}&idcolor={p.Idcolor}&idsize={p.Idsize}&idsale={p.IdSale}&congnghemanhinh={p.CongNgheManHinh}&baohanh={p.BaoHanh}&series={p.Series}&dophangiai={p.DoPhanGiai}&mota={p.MoTa}&soluongton={p.SoLuongTon}&giasale={p.GiaSale}&giaban={p.GiaBan}&nhasanxuat={p.NhaSanXuat}&theloai={p.TheLoai}&ngaysanxuat={p.NgaySanXuat}&trangthaikhuyenmai={p.TrangThaiKhuyenMai}";
            //var response = await client.PostAsync(apiUrl, null);
            //var spct1 = JsonConvert.SerializeObject(p);
            //var client = new HttpClient();
            //StringContent content = new StringContent(spct1, Encoding.UTF8, "application/json");
            //HttpResponseMessage repons = client.PostAsync(apiUrl, content).Result;
            _ProductDetailRepo.AddItem(p);

            return RedirectToAction("ShowListProductDetail");
        }
        [HttpPost]
        public IActionResult DeleteSpDetail(ProductDetail p)
        {
            _ProductDetailRepo.RemoveItem(p);
            return RedirectToAction("ShowListProductDetail");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
