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
    public class SaleController : ControllerBase
    {
        private IAllRepositories<Sale> _Salerepo;
        private NHOM5_C5Context _context = new NHOM5_C5Context();
        private DbSet<Sale> _sale;
        public SaleController()
        {
            _sale = _context.Sales;
            AllRepositories<Sale> all = new AllRepositories<Sale>(_context, _sale);
            _Salerepo = all;
        }
        // GET: api/<SaleController>
        [HttpGet("[action]")]
        public IEnumerable<Sale> Getall()
        {
            return _Salerepo.GetAll().OrderBy(c => c.GiaTriSale);
        }

        // GET api/<SaleController>/5
        [HttpGet("[action]")]
        public Sale Get(Guid id)
        {
            return _Salerepo.GetAll().First(c => c.IDSale == id);
        }

        // POST api/<SaleController>
        [HttpPost("[action]")]
        public bool CreteSale(string masale, DateTime nbd, DateTime nkt, int giatrisale)
        {
            Sale sale = new Sale();
            sale.IDSale = Guid.NewGuid();
            sale.MaSale = masale;
            sale.NgayBatDau = nbd;
            sale.NgayKetThuc = nkt;
            sale.GiaTriSale = giatrisale;
            sale.TrangThai = 1;
            return _Salerepo.AddItem(sale);
        }

        // PUT api/<SaleController>/5
        [HttpPut("[action]")]
        public bool EditSale(Guid id, string masale, DateTime nbd, DateTime nkt, int giatrisale, int trangthai)
        {
            Sale sale = _Salerepo.GetAll().First(c => c.IDSale == id);
            sale.MaSale = masale;
            sale.NgayBatDau = nbd;
            sale.NgayKetThuc = nkt;
            sale.GiaTriSale = giatrisale;
            sale.TrangThai = trangthai;

            return _Salerepo.EditItem(sale);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("[action]")]
        public bool Delete(Guid id)
        {
            Sale sale = _Salerepo.GetAll().First(c => c.IDSale == id);
            return _Salerepo.RemoveItem(sale);
        }
    }
}
