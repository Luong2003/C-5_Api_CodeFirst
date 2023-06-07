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
    public class BillDetailController : ControllerBase
    {
        private readonly IAllRepositories<BillDetail> repos;
        NHOM5_C5Context context = new NHOM5_C5Context();
        DbSet<BillDetail> billDetails;// = new FINALASS_FPOLYSHOP_FA22_SOF205__SOF2041Context().SanPhams;
        Guid layid;
        public BillDetailController()
        {
            billDetails = context.BillDetails;
            AllRepositories<BillDetail> all = new AllRepositories<BillDetail>(context, billDetails);
            repos = all;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<BillDetail> Get()
        {
            return repos.GetAll();
        }



        // POST api/<ValuesController>
        [HttpPost("CreateBillDetails")]
        public bool CreateBillDetail(float dongia, int soluong, int trangthai)
        {
            BillDetail bill = new BillDetail();
            bill.Id = Guid.NewGuid();
            bill.DonGia = dongia;
            bill.SoLuong = soluong;
            bill.TrangThai = trangthai;
            bill.Idbill = Guid.Parse("513FB904-F862-4A1C-B125-4E8D4970C73A"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            bill.IdproductDetails = Guid.Parse("513FB904-F862-4A1C-B125-4E8D4970C73A"); // Chưa ghép View nên chưa có data nên phải fix cứng;
            return repos.AddItem(bill);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("EditBillDetails")]
        public bool PutBillDetails(Guid id, int soluong, float dongia, int trangthai)
        {
            var bill = repos.GetAll().First(p => p.Id == id);
            bill.SoLuong = soluong;
            bill.DonGia = dongia;
            bill.TrangThai = trangthai;
            return repos.EditItem(bill);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("DeleteBillDetails")]
        public bool DeleteBillDetails(Guid id)
        {
            var bill = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(bill);
        }
    }
}
