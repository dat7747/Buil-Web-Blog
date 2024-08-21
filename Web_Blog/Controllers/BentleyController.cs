using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Blog.Models;

public class BentleyController : Controller
{
    private readonly ApplicationDbContext _context;

    public BentleyController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var bentleyList = await _context.Bentley.Include(b => b.LoaiBentley).ToListAsync();
        var loaiBentleyList = await _context.LoaiBentley.ToListAsync();

        foreach (var bentley in bentleyList)
        {
            var imageName = bentley.Image?.Trim().ToLower();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Bentley", bentley.LoaiBentley.TenLoai, imageName + ".png");

            // Kiểm tra sự tồn tại của file ảnh
            bentley.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
        }

        var viewModel = new BentleyViewModel
        {
            BentleyList = bentleyList,
            Brands = loaiBentleyList
        };

        return View(viewModel);
    }
}
