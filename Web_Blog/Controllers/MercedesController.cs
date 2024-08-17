using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Blog.Models;

namespace Web_Blog.Controllers
{
    public class MercedesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MercedesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var mercedesList = await _context.Mercedes.Include(m => m.LoaiMercedes).ToListAsync();
            var loaiMercedesList = await _context.LoaiMercedes.ToListAsync();

            foreach (var mercedes in mercedesList)
            {
                var imageName = mercedes.Image?.Trim().ToLower();
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Mercedes", mercedes.LoaiMercedes.TenLoai, imageName + ".png");

                // Kiểm tra sự tồn tại của file ảnh
                mercedes.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
            }

            var viewModel = new MercedesViewModel
            {
                MercedesList = mercedesList,
                Brands = loaiMercedesList
            };

            return View(viewModel);
        }

    }
}
