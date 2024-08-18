using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Blog.Models; 
using System.Threading.Tasks;
using System.Linq;

namespace Web_Blog.Controllers
{
    public class BMwController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BMwController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bmwiList = await _context.BMW.Include(a => a.LoaiBMW).ToListAsync();
            var loaiBMWList = await _context.LoaiBMW.ToListAsync();

            foreach (var bmw in bmwiList)
            {
                var imageName = bmw.Image?.Trim().ToLower();
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "BMW", bmw.LoaiBMW.TenLoai, imageName + ".png");

                bmw.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
            }

            var viewModel = new BMWViewModel
            {
                BMWList = bmwiList,
                Brands = loaiBMWList
            };

            return View(viewModel);
        }

    }

}