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
            var poschers = await _context.Poscher.ToListAsync();
            var loaiPoschers = await _context.LoaiPoscher.ToListAsync(); // Truy vấn dữ liệu từ LoaiPoscher

            foreach (var poscher in poschers)
            {
                // Loại bỏ khoảng trắng đầu và cuối trong tên file ảnh
                var imageName = poscher.Image?.Trim();
                
                // Thay thế khoảng trắng bằng dấu gạch dưới
                var imageNameWithUnderscores = imageName?.Replace(' ', '_');
                
                // Xây dựng đường dẫn tới file ảnh với thư mục con '911'
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Poscher", "911", imageNameWithUnderscores);

                // Kiểm tra sự tồn tại của file ảnh
                poscher.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);

                // Ghi log tên ảnh và trạng thái tồn tại của ảnh
                Console.WriteLine($"Tên ảnh gốc: '{imageName}', Tên ảnh sau khi thay đổi: '{imageNameWithUnderscores}', Tồn tại: {poscher.ImageExists}");
                Console.WriteLine("Đường dẫn ảnh: " + imagePath);
            }

            // Tạo một đối tượng để chứa dữ liệu
            var data = new
            {
                Brands = loaiPoschers.Select(l => l.TenLoai).Distinct().ToList(),
                Poschers = poschers
            };

            return View(data);
        }

    }
}
