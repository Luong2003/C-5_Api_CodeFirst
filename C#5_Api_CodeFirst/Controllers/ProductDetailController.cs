using App_Data.Model;
using App_Data.IRepositories;
using App_Data.Repositories;
using App_Data.ViewModel;
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
        private readonly IAllRepositories<Color> ColorRepo;
        private readonly IAllRepositories<Size> SizeRepo;
        private readonly IAllRepositories<Sale> SaleRepo;
        private readonly IAllRepositories<Product> ProductRepo;

        NHOM5_C5Context context = new NHOM5_C5Context();

        DbSet<ProductDetail> productDetails;
        DbSet<Color> colors;
        DbSet<Size> sizes;
        DbSet<Sale> sales;
        DbSet<Product> products;
        Guid layid;
        public ProductDetailController()
        {
            productDetails = context.ProductDetails;
            colors = context.Colors;
            sizes = context.Sizes;
            sales = context.Sales;
            products = context.Products;
            AllRepositories<ProductDetail> productdetail = new AllRepositories<ProductDetail>(context, productDetails);
            AllRepositories<Color> color = new AllRepositories<Color>(context, colors);
            AllRepositories<Size> size = new AllRepositories<Size>(context, sizes);
            AllRepositories<Sale> sale = new AllRepositories<Sale>(context, sales);
            AllRepositories<Product> product = new AllRepositories<Product>(context, products);


            ProductDetailRepo = productdetail;
            ColorRepo = color;
            SizeRepo = size;
            SaleRepo = sale;
            ProductRepo = product;
        }

        [HttpGet]
        public IEnumerable<ProductDetail> Get()
        {
            return ProductDetailRepo.GetAll();
        }
        [HttpGet("[action]")]
        public IEnumerable<ProductDetailViewModel> GetAllSanPhamChiTiet()
        {
            var spct = from a in context.ProductDetails
                       join b in context.Products on a.Idproduct equals b.Id
                       join c in context.Colors on a.Idcolor equals c.Id
                       join d in context.Sizes on a.Idsize equals d.Id
                       join e in context.Sales on a.IdSale equals e.IDSale
                       select new ProductDetailViewModel
                       {
                           Id = a.Id,
                           TenSp = b.TenSp,
                           Color = c.Ten,
                           Size = d.Size1,
                           GiaTriSale = e.GiaTriSale,
                           CongNgheManHinh = a.CongNgheManHinh,
                           BaoHanh = a.BaoHanh,
                           Series = a.Series,
                           DoPhanGiai = a.DoPhanGiai,
                           MoTa = a.MoTa,
                           SoLuongTon = a.SoLuongTon,
                           GiaBan = a.GiaBan,
                           GiaSale = a.GiaBan - (a.GiaBan * e.GiaTriSale / 100),
                           NhaSanXuat = a.NhaSanXuat,
                           TheLoai = a.TheLoai,
                           NgaySanXuat = a.NgaySanXuat,
                           TrangThaiKhuyenMai = a.TrangThaiKhuyenMai,
                       };
            if(spct.Any(a => a.SoLuongTon > 0))
            {
                return spct.ToList();
            }    
            else
            {
                return new List<ProductDetailViewModel>();
            }
            return spct;
        }
        [HttpGet("[action]")]
        public IEnumerable<ProductDetailViewModel> GetAllProductSale()
        {
            var spct = from a in context.ProductDetails
                       join b in context.Products on a.Idproduct equals b.Id
                       join c in context.Colors on a.Idcolor equals c.Id
                       join d in context.Sizes on a.Idsize equals d.Id
                       join e in context.Sales on a.IdSale equals e.IDSale
                       select new ProductDetailViewModel
                       {
                           Id = a.Id,
                           TenSp = b.TenSp,
                           Color = c.Ten,
                           Size = Convert.ToInt32(d.Size1),
                           GiaTriSale = e.GiaTriSale,
                           CongNgheManHinh = a.CongNgheManHinh,
                           BaoHanh = a.BaoHanh,
                           Series = a.Series,
                           DoPhanGiai = a.DoPhanGiai,
                           MoTa = a.MoTa,
                           SoLuongTon = a.SoLuongTon,
                           GiaBan = a.GiaBan,
                           GiaSale = a.GiaBan - (a.GiaBan * e.GiaTriSale / 100),
                           NhaSanXuat = a.NhaSanXuat,
                           TheLoai = a.TheLoai,
                           NgaySanXuat = a.NgaySanXuat,
                           TrangThaiKhuyenMai = a.TrangThaiKhuyenMai,
                       };
            if (spct.Any(a => a.SoLuongTon > 0 && a.GiaTriSale > 0))
            {
                return spct.ToList();
            }
            else
            {
                return new List<ProductDetailViewModel>();
            }

        }

        [HttpGet("[action]")]
        public ProductDetailViewModel GetIdProductDetail(Guid id)
        {
            var spct = from a in context.ProductDetails
                       join b in context.Products on a.Idproduct equals b.Id
                       join c in context.Colors on a.Idcolor equals c.Id
                       join d in context.Sizes on a.Idsize equals d.Id
                       join e in context.Sales on a.IdSale equals e.IDSale
                       select new ProductDetailViewModel
                       {
                           Id = a.Id,
                           TenSp = b.TenSp,
                           Color = c.Ten,
                           Size = Convert.ToInt32(d.Size1),
                           GiaTriSale = e.GiaTriSale,
                           CongNgheManHinh = a.CongNgheManHinh,
                           BaoHanh = a.BaoHanh,
                           Series = a.Series,
                           DoPhanGiai = a.DoPhanGiai,
                           MoTa = a.MoTa,
                           SoLuongTon = a.SoLuongTon,
                           GiaBan = a.GiaBan,
                           GiaSale = a.GiaBan - (a.GiaBan * e.GiaTriSale / 100),
                           NhaSanXuat = a.NhaSanXuat,
                           TheLoai = a.TheLoai,
                           NgaySanXuat = a.NgaySanXuat,
                           TrangThaiKhuyenMai = a.TrangThaiKhuyenMai,
                       };
            return spct.First(c => c.Id == id);
        }
        [HttpGet("{id}")]
        public ProductDetail GetById(Guid id)
        {
            return ProductDetailRepo.GetAll().First(c => c.Id == id);
        }

        [HttpGet("[action]")]
        
        // POST 
        [HttpPost("create-ProductDetail")]
        public bool CreateProductDetail(Guid idsp, Guid idcolor,Guid idsize, Guid idsale ,string congnghemanhinh, DateTime baohanh, int series, string dophangiai, string mota, int soluongton, float giasale, float giaban, string nhasanxuat, string theloai, DateTime ngaysanxuat, string trangthaikhuyenmai)
        {
            ProductDetail productDetail = new ProductDetail();
            productDetail.Id = Guid.NewGuid();
            productDetail.Idproduct = ProductRepo.GetAll().First(c => c.Id == idsp).Id;
            productDetail.Idcolor = ColorRepo.GetAll().First(c => c.Id == idcolor).Id;
            productDetail.Idsize = SizeRepo.GetAll().First(c => c.Id == idsize).Id;
            productDetail.IdSale = SaleRepo.GetAll().First(c => c.IDSale == idsale).IDSale;
            productDetail.CongNgheManHinh = congnghemanhinh;
            productDetail.BaoHanh = baohanh;
            productDetail.Series = series;
            productDetail.DoPhanGiai = dophangiai;
            productDetail.MoTa = mota;
            productDetail.SoLuongTon = soluongton;
            productDetail.GiaBan = giaban;
            productDetail.GiaSale = giaban - (giaban * SaleRepo.GetAll().First(c => c.IDSale == idsale).GiaTriSale / 100);
            productDetail.NhaSanXuat = nhasanxuat;
            productDetail.TheLoai = theloai;
            productDetail.NgaySanXuat = ngaysanxuat;
            //productDetail.TrangThaiKhuyenMai = trangthaikhuyenmai;
            if (productDetail.GiaSale > 0)
            {
                productDetail.TrangThaiKhuyenMai = "Có";
            }
            else
            {
                productDetail.TrangThaiKhuyenMai = "không";
            }
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
