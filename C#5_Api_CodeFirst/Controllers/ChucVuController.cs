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
	public class ChucVuController : ControllerBase
	{
		private readonly IAllRepositories<ChucVu> _chucvurepos;
		NHOM5_C5Context context = new NHOM5_C5Context();
		DbSet<ChucVu> chucVus;
		Guid layid;
		public ChucVuController()
		{
			chucVus = context.ChucVus;
			AllRepositories<ChucVu> all = new AllRepositories<ChucVu>(context, chucVus);
			_chucvurepos = all;
		}

		// GET
		[HttpGet("GetBill")]
		public IEnumerable<ChucVu> Get()
		{
			return _chucvurepos.GetAll();
		}

		[HttpPost("[action]")]
		public bool CreteColor(string machucvu, string tenchucvu)
		{
			ChucVu cv = new ChucVu();
			cv.Id = Guid.NewGuid();
			cv.MaChucVu = machucvu;
			cv.TenChucVu = tenchucvu;
			return _chucvurepos.AddItem(cv);
		}
	}
}
