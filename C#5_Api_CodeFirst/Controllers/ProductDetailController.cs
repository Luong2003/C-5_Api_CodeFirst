using App_Data.Model;
using App_Data.IRepositories;
using App_Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_5_Api_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IAllRepositories<ProductDetail> ProductDetailRepo;
		private readonly IAllRepositories<Color> colorrp;
		private readonly IAllRepositories<Product> productrp;
		private readonly IAllRepositories<Size> sizerp;
		private readonly IAllRepositories<Sale> salerp;
		NHOM5_C5Context context = new NHOM5_C5Context();

        DbSet<ProductDetail> productDetails;
        public ProductDetailController()
        {
            productDetails = context.ProductDetails;
            AllRepositories<ProductDetail> productdetail = new AllRepositories<ProductDetail>(context, productDetails);
            ProductDetailRepo = productdetail;
        }

        [HttpGet]
        public IEnumerable<ProductDetail> GetAll()
        {
            return ProductDetailRepo.GetAll();
        }
        [HttpGet("{id}")]
        public ProductDetail GetById(Guid id)
        {
            return ProductDetailRepo.GetAll().First(c => c.Id == id);
        }

        [HttpPost("{Create-product}")]
        public bool CreateProductDetail(Guid idcolor, Guid idproduct, Guid idsize, Guid idsale, string congnghemanhinh, string baohanh, int series, string dophangiai, string mota, int soluongton, float giaban, float giasale, string nhasanxuat, string theloai, string ngaysanxuat, string trangthaikhuyenmai )
        {
            ProductDetail productDetail = new ProductDetail();
            productDetail.Id = Guid.NewGuid();
            productDetail.Idcolor = idcolor;
            productDetail.Idproduct = idproduct;
            productDetail.IdSale = idsale;
            productDetail.Idsize = idsize;
            productDetail.CongNgheManHinh = congnghemanhinh;
            productDetail.BaoHanh = DateTime.Parse(baohanh);
            productDetail.Series = series;
            productDetail.DoPhanGiai = dophangiai;
            productDetail.MoTa = mota;
            productDetail.SoLuongTon = soluongton;
            productDetail.GiaBan = giaban;
            productDetail.GiaSale = giasale;
            productDetail.NhaSanXuat = nhasanxuat;
            productDetail.TheLoai = theloai;
            productDetail.NgaySanXuat = DateTime.Parse(ngaysanxuat); ;
            productDetail.TrangThaiKhuyenMai = trangthaikhuyenmai;
            return ProductDetailRepo.AddItem( productDetail );
        }

        [HttpDelete("[action]")]
        public bool DeleteProductDetail(Guid id)
        {
            var product = ProductDetailRepo.GetAll().First(c => c.Id == id);
            return ProductDetailRepo.RemoveItem(product);
        }
    }
}
