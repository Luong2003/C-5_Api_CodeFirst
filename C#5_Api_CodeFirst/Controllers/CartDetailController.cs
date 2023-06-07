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
    public class CartDetailController : ControllerBase
    {
        private readonly IAllRepositories<CartDetail> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<CartDetail> carts;// = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context().SanPhams;
        Guid layid;
        public CartDetailController()
        {
            carts = context.CartDetails;
            AllRepositories<CartDetail> all = new AllRepositories<CartDetail>(context, carts);
            repos = all;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<CartDetail> Get()
        {
            return repos.GetAll();
        }



        // POST api/<ValuesController>
        [HttpPost("create-CartDetails")]
        public bool CreateCartDetail(float dongia, int soluong)
        {
            CartDetail sp = new CartDetail();
            sp.Id = Guid.NewGuid();
            sp.DonGia = dongia;
            sp.SoLuong = soluong;
            sp.IdproductDetails = Guid.Parse("513fb904-f862-4a1c-b125-4e8d4970c73a"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            return repos.AddItem(sp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("EditCartDetails-")]
        public bool PutCartDetails(Guid id, float donGia, int soluong)
        {
            var sp = repos.GetAll().First(p => p.Id == id);
            sp.DonGia = donGia;
            sp.SoLuong = soluong;
            return repos.EditItem(sp);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("DeleteCartDetails")]
        public bool DeleteCartDetails(Guid id)
        {
            var sp = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(sp);
        }
    }
}
