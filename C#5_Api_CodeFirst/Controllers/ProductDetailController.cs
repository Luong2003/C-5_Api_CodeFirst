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



        //POST
       [HttpPost("create-ProductDetail")]
        public bool CreateProductDetail(Guid idsp, Guid idcolor, Guid idsize, Guid idsale ,string congnghemanhinh, DateTime baohanh, int series, string dophangiai, string mota, int soluongton, float giasale, float giaban, string nhasanxuat, string theloai, DateTime ngaysanxuat, string trangthaikhuyenmai)
        {
            ProductDetail productDetail = new ProductDetail();
            productDetail.Id = Guid.NewGuid();
            productDetail.Idproduct = idsp;
            productDetail.Idcolor = idcolor;
            productDetail.Idsize = idsize;
            productDetail.IdSale = idsale;
            productDetail.CongNgheManHinh = congnghemanhinh;
            productDetail.BaoHanh = baohanh;
            productDetail.Series = series;
            productDetail.DoPhanGiai = dophangiai;
            productDetail.MoTa = mota;
            productDetail.SoLuongTon = soluongton;
            productDetail.GiaBan = giaban;
            productDetail.GiaSale = giasale;
            productDetail.NhaSanXuat = nhasanxuat;
            productDetail.TheLoai = theloai;
            productDetail.NgaySanXuat = ngaysanxuat;
            productDetail.TrangThaiKhuyenMai = trangthaikhuyenmai;
            //if (productDetail.GiaSale > 0)
            //{
            //    productDetail.TrangThaiKhuyenMai = "Có";
            //}
            //else
            //{
            //    productDetail.TrangThaiKhuyenMai = "không";
            //}
            return ProductDetailRepo.AddItem(productDetail);
        }

        // PUT 
        [HttpPut("{id}")]
        public bool PutProductDetail(Guid id, string congnghemanhinh, DateTime baohanh, int series, string dophangiai, string mota, int soluongton, float giasale, float giaban, string nhasanxuat, string theloai, DateTime ngaysanxuat, string trangthaikhuyenmai)
        {
            ProductDetail productDetail = ProductDetailRepo.GetAll().FirstOrDefault(p => p.Id == id);
            productDetail.CongNgheManHinh = congnghemanhinh;
            productDetail.BaoHanh = baohanh;
            productDetail.Series = series;
            productDetail.DoPhanGiai = dophangiai;
            productDetail.MoTa = mota;
            productDetail.SoLuongTon = soluongton;
            productDetail.GiaBan = giaban;
            productDetail.GiaSale = giasale;
            productDetail.NhaSanXuat = nhasanxuat;
            productDetail.TheLoai = theloai;
            productDetail.NgaySanXuat = ngaysanxuat;
            productDetail.TrangThaiKhuyenMai = trangthaikhuyenmai;
            return ProductDetailRepo.EditItem(productDetail);

        }

        // DELETE 
        [HttpDelete("{id}")]
        public bool DeleteCart(Guid id)
        {
            var productDetail = ProductDetailRepo.GetAll().First(p => p.Id == id);
            return ProductDetailRepo.RemoveItem(productDetail);
        }
    }
}
