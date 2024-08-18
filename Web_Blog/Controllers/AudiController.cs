using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Blog.Models; 
using System.Threading.Tasks;
using System.Linq;

namespace Web_Blog.Controllers
{
    public class AudiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AudiController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var audiList = await _context.Audi.Include(a => a.LoaiAudi).ToListAsync();
            var loaiAudiList = await _context.LoaiAudi.ToListAsync();

            foreach (var audi in audiList)
            {
                var imageName = audi.Image?.Trim().ToLower();
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Audi", audi.LoaiAudi.Ten, imageName + ".png");

                // Kiểm tra sự tồn tại của file ảnh
                audi.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
            }

            var viewModel = new AudiViewModel
            {
                AudiList = audiList,
                Brands = loaiAudiList
            };

            return View(viewModel);
        }
    }

}