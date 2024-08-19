using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Blog.Models;

public class LamborghiniController : Controller
{
    private readonly ApplicationDbContext _context;

    public LamborghiniController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var lamborghiniList = await _context.Lamborghini.Include(l => l.LoaiLamborghini).ToListAsync();
        var loaiLamborghiniList = await _context.LoaiLamborghini.ToListAsync();

        foreach (var lamborghini in lamborghiniList)
        {
            var imageName = lamborghini.Image?.Trim().ToLower();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Lamborghini", lamborghini.LoaiLamborghini.TenLoai, imageName + ".png");

            // Kiểm tra sự tồn tại của file ảnh
            lamborghini.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
        }

        var viewModel = new LamborghiniViewModel
        {
            LamborghiniList = lamborghiniList,
            Brands = loaiLamborghiniList
        };

        return View(viewModel);
    }
}
