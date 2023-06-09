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
        private readonly IAllRepositories<ProductDetail> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<ProductDetail> productDetails;
        Guid layid;
        public ProductDetailController()
        {
            productDetails = context.ProductDetails;
            AllRepositories<ProductDetail> all = new AllRepositories<ProductDetail>(context, productDetails);
            repos = all;
        }

        [HttpGet]
        public IEnumerable<ProductDetail> Get()
        {
            return repos.GetAll();
        }

        // POST 
        [HttpPost("create-ProductDetail")]
        public bool CreateProductDetail(string congnghemanhinh, DateTime baohanh, int series, string dophangiai, string mota, int soluongton, float gianhap, float giaban, string nhasanxuat, string theloai, DateTime ngaysanxuat, string trangthaikhuyenmai)
        {
            ProductDetail productDetail = new ProductDetail();
            productDetail.Id = Guid.NewGuid();
            productDetail.Idproduct = Guid.Parse("0e984725-c51c-4bf4-9960-e1c89e27aba0"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            productDetail.Idcolor = Guid.Parse("73dbd8dd-6043-40b5-8a0a-47ed45e6744e"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            productDetail.Idsize = Guid.Parse("73dbd8dd-6043-40b5-8a0a-47ed45e6744e"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            productDetail.CongNgheManHinh = congnghemanhinh;
            productDetail.BaoHanh = baohanh;
            productDetail.Series = series;
            productDetail.DoPhanGiai = dophangiai;
            productDetail.MoTa = mota;
            productDetail.SoLuongTon = soluongton;
            productDetail.GiaBan = giaban;
            productDetail.NhaSanXuat = nhasanxuat;
            productDetail.TheLoai = theloai;
            productDetail.NgaySanXuat = ngaysanxuat;
            productDetail.TrangThaiKhuyenMai = trangthaikhuyenmai;
            return repos.AddItem(productDetail);
        }

        // PUT 
        [HttpPut("{id}")]
        public bool PutProductDetail(Guid id, string congnghemanhinh, DateTime baohanh, int series, string dophangiai, string mota, int soluongton, float gianhap, float giaban, string nhasanxuat, string theloai, DateTime ngaysanxuat, string trangthaikhuyenmai)
        {
            var productDetail = repos.GetAll().First(p => p.Id == id);
            productDetail.CongNgheManHinh = congnghemanhinh;
            productDetail.BaoHanh = baohanh;
            productDetail.Series = series;
            productDetail.DoPhanGiai = dophangiai;
            productDetail.MoTa = mota;
            productDetail.SoLuongTon = soluongton;
            productDetail.GiaBan = giaban;
            productDetail.NhaSanXuat = nhasanxuat;
            productDetail.TheLoai = theloai;
            productDetail.NgaySanXuat = ngaysanxuat;
            productDetail.TrangThaiKhuyenMai = trangthaikhuyenmai;
            return repos.EditItem(productDetail);

        }

        // DELETE 
        [HttpDelete("{id}")]
        public bool DeleteCart(Guid id)
        {
            var productDetail = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(productDetail);
        }
    }
}
