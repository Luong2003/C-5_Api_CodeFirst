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
    public class ColorController : ControllerBase
    {
        private IAllRepositories<Color> _Colorrepo;
        private NHOM5_C5Context _context = new NHOM5_C5Context();
        private DbSet<Color> _Color;
        public ColorController()
        {
            _Color = _context.Colors;
            AllRepositories<Color> all = new AllRepositories<Color>(_context, _Color);
            _Colorrepo = all;

        }
        // GET: api/<SaleController>
        [HttpGet("[action]")]
        public IEnumerable<Color> Getall()
        {
            return _Colorrepo.GetAll().OrderBy(c => c.Ma);
        }

        // GET api/<SaleController>/5
        [HttpGet("[action]")]
        public Color Get(Guid id)
        {
            return _Colorrepo.GetAll().First(c => c.Id == id);
        }

        // POST api/<SaleController>
        [HttpPost("[action]")]
        public bool CreteColor(string Ma, string ten)
        {
            Color color = new Color();
            color.Ma = Ma;
            color.Ten = ten;
            return _Colorrepo.AddItem(color);
        }

        // PUT api/<SaleController>/5
        [HttpPut("[action]")]
        public bool EditColor(Guid id, string Ma, string ten)
        {
            Color color = _Colorrepo.GetAll().First(c => c.Id == id);
            color.Ma = Ma;
            color.Ten = ten;
            return _Colorrepo.EditItem(color);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete]
        public bool DeleteColor(Guid id)
        {
            Color color = _Colorrepo.GetAll().First(c => c.Id == id);
            return _Colorrepo.RemoveItem(color);
        }
    }
}
