using App_Data.IRepositories;
using App_Data.Model;
using App_Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Security.AccessControl;
using System.Text;

namespace AppView.Controllers
{
    public class ColorController : Controller
    {
        private readonly IAllRepositories<Color> _Colorrepo;
        private NHOM5_C5Context _C5context = new NHOM5_C5Context();
        private DbSet<Color> _colors;

        public ColorController()
        {
            _colors = _C5context.Colors;
            AllRepositories<Color> all = new AllRepositories<Color>(_C5context, _colors);
            _Colorrepo = all; 
        }
        
        [HttpGet]
        public async Task<IActionResult> ShowListColor()
        {
            string apiUrl = "https://localhost:7023/api/Color/Getall";
            var httpClient = new HttpClient();
            var respose = await httpClient.GetAsync(apiUrl);
            string apiData = await respose.Content.ReadAsStringAsync();
            var Color = JsonConvert.DeserializeObject<List<Color>>(apiData);
            return View(Color);
        }

        [HttpGet]
        public async Task<IActionResult> CreateColor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateColor(Color c)
        {
            string data = JsonConvert.SerializeObject(c);
            string url = $"https://localhost:7023/api/Color/CreteColor?Ma={c.Ma}&ten={c.Ten}";

            var client = new HttpClient();
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage repons = client.PostAsync(url, content).Result;

            return RedirectToAction("ShowListColor");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateColor(Guid id)
        {
            Color color = _Colorrepo.GetAll().FirstOrDefault(x => x.Id == id);
            return View(color);
        }    
        [HttpPost]
        public async Task<IActionResult> UpdateColor(Color c)
        {
            _Colorrepo.EditItem(c);
            return RedirectToAction("ShowListColor");
        }

        public IActionResult DeleteColor(Color c)
        {
            _Colorrepo.RemoveItem(c);
            return RedirectToAction("ShowListColor");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
