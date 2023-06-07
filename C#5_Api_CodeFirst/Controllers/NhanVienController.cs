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
    public class NhanVienController : ControllerBase
    {
        private readonly IAllRepositories<NhanVien> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<NhanVien> nhanviens;
        Guid layid;
        public NhanVienController()
        {
            nhanviens = context.NhanViens;
            AllRepositories<NhanVien> all = new AllRepositories<NhanVien>(context, nhanviens);
            repos = all;
        }

        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            return repos.GetAll();
        }

        // POST 
        [HttpPost("create-NhanVien")]
        public bool CreateNhanVien(string ma, string hoTen, string sDT, string matKhau, string diaChi, string gioiTinh, DateTime ngaySinh)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.Id = Guid.NewGuid();
            nhanVien.IdchucVu = Guid.Parse("0C64EEF3-69C7-478E-80D1-58BCD8444E4C"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            nhanVien.Ma = ma;
            nhanVien.HoTen = hoTen;
            nhanVien.Sdt = sDT;
            nhanVien.MatKhau = matKhau;
            nhanVien.DiaChi = diaChi;
            nhanVien.GioiTinh = gioiTinh;
            nhanVien.Ngaysinh = ngaySinh;
            return repos.AddItem(nhanVien);
        }

        // PUT 
        [HttpPut("{id}")]
        public bool PutProductDetail(Guid id, string ma, string hoTen, string sDT, string matKhau, string diaChi, string gioiTinh, DateTime ngaySinh)
        {
            var nhanVien = repos.GetAll().First(p => p.Id == id);
            nhanVien.Ma = ma;
            nhanVien.HoTen = hoTen;
            nhanVien.Sdt = sDT;
            nhanVien.MatKhau = matKhau;
            nhanVien.DiaChi = diaChi;
            nhanVien.GioiTinh = gioiTinh;
            nhanVien.Ngaysinh = ngaySinh;
            return repos.EditItem(nhanVien);

        }

        // DELETE 
        [HttpDelete("{id}")]
        public bool DeleteCart(Guid id)
        {
            var nhanVien = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(nhanVien);
        }
    }
}
