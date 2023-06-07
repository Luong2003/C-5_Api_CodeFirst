using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using App_Data.IRepositories;
using App_Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_5_Api_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IAllRepositories<Bill> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<Bill> bills;
        Guid layid;
        public BillController()
        {
            bills = context.Bills;
            AllRepositories<Bill> all = new AllRepositories<Bill>(context, bills);
            repos = all;
        }

        // GET
        [HttpGet("GetBill")]
        public IEnumerable<Bill> Get()
        {
            return repos.GetAll();
        }



        // POST 
        [HttpPost("create-Bill")]
        public bool CreateBill(string giamGia, string moTa, string diachiShop, string diachikhachhang, float tienship, float freeship, float tongtien, float sotiengiam, float tienkhachdua, int trangthai)
        {
            Bill bill = new Bill();
            bill.Id = Guid.NewGuid();
            bill.IduuDaiTichDiem = Guid.NewGuid();
            bill.IdkhachHang = Guid.NewGuid();  // Chưa ghép View nên chưa có data nên phải fix cứng;
            bill.IdnhanVien = Guid.NewGuid();  // Chưa ghép View nên chưa có data nên phải fix cứng;
            bill.Idvoucher = Guid.NewGuid();
            bill.NgayThanhToan = DateTime.Now;
            bill.GiamGia = giamGia;
            bill.MoTa = moTa;
            bill.DiaChiShop = diachiShop;
            bill.DiaChiKhachHang = diachikhachhang;
            bill.TienShip = tienship;
            bill.FreeShip = freeship;
            bill.TongTien = tongtien;
            bill.SoTienGiam = sotiengiam;
            bill.TienKhachDua = tienkhachdua;
            bill.TrangThai = trangthai;
            return repos.AddItem(bill);
        }

        // PUT 
        [HttpPut("{id}")]
        public bool PutBill(Guid id, DateTime ngaythanhtoan, string giamGia, string moTa, string trangThai, string diachiShop, string diachikhachhang, float tienship, float freeship, float tongtien, float sotiengiam, float tienkhachdua)
        {
            var bill = repos.GetAll().First(p => p.Id == id);
            bill.NgayThanhToan = DateTime.Now;
            bill.GiamGia = giamGia;
            bill.MoTa = moTa;
            bill.DiaChiShop = diachiShop;
            bill.DiaChiKhachHang = diachikhachhang;
            bill.TienShip = tienship;
            bill.FreeShip = freeship;
            bill.TongTien = tongtien;
            bill.SoTienGiam = sotiengiam;
            bill.TienKhachDua = tienkhachdua;
            return repos.EditItem(bill);
        }

        // DELETE 
        [HttpDelete("{id}")]
        public bool DeleteBill(Guid id)
        {
            var bill = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(bill);
        }
    }
}
