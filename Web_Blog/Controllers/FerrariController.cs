using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Blog.Models;

public class FerrariController : Controller
{
    private readonly ApplicationDbContext _context;

    public FerrariController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var ferrariList = await _context.Ferrari.Include(f => f.LoaiFerrari).ToListAsync();
        var loaiFerrariList = await _context.LoaiFerrari.ToListAsync();

        foreach (var ferrari in ferrariList)
        {
            var imageName = ferrari.Image?.Trim().ToLower();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Ferrari", ferrari.LoaiFerrari.TenLoai, imageName + ".png");

            // Kiểm tra sự tồn tại của file ảnh
            ferrari.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
        }

        var viewModel = new FerrariViewModel
        {
            FerrariList = ferrariList,
            Brands = loaiFerrariList
        };

        return View(viewModel);
    }
}
