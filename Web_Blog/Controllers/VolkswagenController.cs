using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Blog.Models;

public class VolkswagenController : Controller
{
    private readonly ApplicationDbContext _context;

    public VolkswagenController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var volkswagenList = await _context.Volkswagen.Include(v => v.LoaiVolkswagen).ToListAsync();
        var loaiVolkswagenList = await _context.LoaiVolkswagen.ToListAsync();

        foreach (var volkswagen in volkswagenList)
        {
            var imageName = volkswagen.Image?.Trim().ToLower();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Volkswagen", volkswagen.LoaiVolkswagen.TenLoai, imageName + ".png");

            // Kiểm tra sự tồn tại của file ảnh
            volkswagen.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
        }

        var viewModel = new VolkswagenViewModel
        {
            VolkswagenList = volkswagenList,
            Brands = loaiVolkswagenList
        };

        return View(viewModel);
    }
}
