using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Blog.Models; 
using System.Threading.Tasks;
using System.Linq;

namespace Web_Blog.Controllers
{
    public class PoscherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoscherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var poschers = await _context.Poscher.Include(p => p.LoaiPoscher).ToListAsync();
            var loaiPoschers = await _context.LoaiPoscher.ToListAsync(); // Truy vấn dữ liệu từ LoaiPoscher

            foreach (var poscher in poschers)
            {
                var imageName = poscher.Image?.Trim().ToLower(); // Xử lý tên hình ảnh
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "poscher", poscher.LoaiPoscher.TenLoai, imageName + ".png");

                // Kiểm tra sự tồn tại của file ảnh
                poscher.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
            }

            // Tạo đối tượng dữ liệu để gửi tới View
            var data = new
            {
                Brands = loaiPoschers.Select(l => new { Id = l.LoaiID, Name = l.TenLoai }).ToList(),
                Poschers = poschers
            };

            return View(data);
        }
    }

}