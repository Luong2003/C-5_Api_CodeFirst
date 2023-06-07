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
    public class CartController : ControllerBase
    {
        private readonly IAllRepositories<Cart> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<Cart> carts;
        Guid layid;
        public CartController()
        {
            carts = context.Carts;
            AllRepositories<Cart> all = new AllRepositories<Cart>(context, carts);
            repos = all;
        }

        // GET
        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return repos.GetAll();
        }



        // POST 
        [HttpPost("create-Cart")]
        public bool CreateCart(float dongia, int soluong, DateTime ngaytao)
        {
            Cart cart = new Cart();
            cart.Id = Guid.NewGuid();
            cart.IdkhachHang = Guid.Parse("F699C7C2-F3D9-497A-9724-8896E6386EE9"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            cart.IdcartDetails = Guid.Parse("09a86475-692a-413b-bfeb-b7dd27a13ee2"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            cart.DonGia = dongia;
            cart.SoLuong = soluong;
            cart.NgayTao = ngaytao;
            return repos.AddItem(cart);
        }

        // PUT 
        [HttpPut("{id}")]
        public bool PutCart(Guid id, int soluong, float donGia, DateTime ngayTao)
        {
            var sp = repos.GetAll().First(p => p.Id == id);
            sp.SoLuong = soluong;
            sp.DonGia = donGia;
            sp.NgayTao = ngayTao;
            return repos.EditItem(sp);

        }

        // DELETE 
        [HttpDelete("{id}")]
        public bool DeleteCart(Guid id)
        {
            var sp = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(sp);
        }
    }
}
