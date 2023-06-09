using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace C_5_Api_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private IAllRepositories<Size> _Sizerepo;
        private NHOM5_C5Context _context = new NHOM5_C5Context();
        private DbSet<Size> _Size;
        public SizeController()
        {
            _Size = _context.Sizes;
            AllRepositories<Size> all = new AllRepositories<Size>(_context, _Size);
            _Sizerepo = all;
            
        }
        // GET: api/<SaleController>
        [HttpGet("[action]")]
        public IEnumerable<Size> Getall()
        {
            return _Sizerepo.GetAll().OrderBy(c => c.Ma);
        }

        // GET api/<SaleController>/5
        [HttpGet("[action]")]
        public Size Get(Guid id)
        {
            return _Sizerepo.GetAll().First(c => c.Id == id);
        }

        // POST api/<SaleController>
        [HttpPost("[action]")]
        public bool CreteSize(string Ma, int Size1)
        {
            Size Size = new Size();
            Size.Ma = Ma;
            Size.Size1 = Size1;
            return _Sizerepo.AddItem(Size);
        }

        // PUT api/<SaleController>/5
        [HttpPut("[action]")]
        public bool EditSale(Guid id, string Ma, int Size1)
        {
            Size size = _Sizerepo.GetAll().First(c => c.Id == id);
            size.Ma = Ma;
            size.Size1 = Size1;
            return _Sizerepo.EditItem(size);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("[action]")]
        public bool DeleteSize(Guid id)
        {
            Size size = _Sizerepo.GetAll().First(c => c.Id == id);
            return _Sizerepo.RemoveItem(size);
        }
    }
}
