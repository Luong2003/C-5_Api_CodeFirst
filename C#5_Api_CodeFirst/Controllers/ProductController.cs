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
    public class ProductController : ControllerBase
    {
        private readonly IAllRepositories<Product> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<Product> products;// = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context().SanPhams;
        public ProductController()
        {
            products = context.Products;
            AllRepositories<Product> all = new AllRepositories<Product>(context, products);
            repos = all;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return repos.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{name}")]
        public IEnumerable<Product> Get(string name) // Tìm theo tên
        {
            return repos.GetAll().Where(p => p.TenSp.Contains(name));
        }

        // POST api/<ValuesController>
        [HttpPost("create-sanpham")]
        public bool CreateSanpham(string MaSp, string TenSp)
        {
            Product sp = new Product();
            sp.Id = Guid.NewGuid();
            sp.MaSp = MaSp;
            sp.TenSp = TenSp;
            return repos.AddItem(sp);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string MaSp, string TenSp)
        {
            var sp = repos.GetAll().First(p => p.Id == id);
            sp.MaSp = MaSp;
            sp.TenSp = TenSp;
            return repos.EditItem(sp);
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
