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
    public class KhachHangController : ControllerBase
    {
        private readonly IAllRepositories<KhachHang> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<KhachHang> khachHang;// = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context().SanPhams;
        public KhachHangController()
        {
            khachHang = context.KhachHangs;
            AllRepositories<KhachHang> all = new AllRepositories<KhachHang>(context, khachHang);
            repos = all;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<KhachHang> Get()
        {
            return repos.GetAll();
        }

        // GET api/<ValuesController>/5
        //[HttpGet("{name}")]
        //public IEnumerable<KhachHang> Get(string name) // Tìm theo tên
        //{
        //    return repos.GetAll().Where(p => p.Ten.Contains(name));
        //}

        // POST api/<ValuesController>
        [HttpPost("action")]
        public bool AddCustomers(string ten, string sdt, string matkhau, string diachi)
        {
            KhachHang kh = new KhachHang();
            kh.Ten = ten;
            kh.Sdt = sdt;
            kh.MatKhau = matkhau;
            kh.DiaChi = diachi;
            kh.Id = Guid.NewGuid();
            kh.IdtichDiem = Guid.NewGuid();
            return repos.AddItem(kh);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string ten, string sdt, string matkhau, string diachi)
        {
            var kh = repos.GetAll().First(p => p.Id == id);
            kh.Ten = ten; kh.Sdt = sdt;
            kh.MatKhau = matkhau; kh.DiaChi = diachi;
            return repos.EditItem(kh);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var kh = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(kh);
        }
    }
}
