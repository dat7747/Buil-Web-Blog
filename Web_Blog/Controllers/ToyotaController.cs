using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Blog.Models;

public class ToyotaController : Controller
{
    private readonly ApplicationDbContext _context;

    public ToyotaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var toyotaList = await _context.Toyota.Include(t => t.LoaiToyota).ToListAsync();
        var loaiToyotaList = await _context.LoaiToyota.ToListAsync();

        foreach (var toyota in toyotaList)
        {
            var imageName = toyota.Image?.Trim().ToLower();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Toyota", toyota.LoaiToyota.TenLoai, imageName + ".png");

            // Kiểm tra sự tồn tại của file ảnh
            toyota.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
        }

        var viewModel = new ToyotaViewModel
        {
            ToyotaList = toyotaList,
            Brands = loaiToyotaList
        };

        return View(viewModel);
    }
}
