using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_Blog.Models;

public class HondaController : Controller
{
    private readonly ApplicationDbContext _context;

    public HondaController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var hondaList = await _context.Honda.Include(h => h.LoaiHonda).ToListAsync();
        var loaiHondaList = await _context.LoaiHonda.ToListAsync();

        foreach (var honda in hondaList)
        {
            var imageName = honda.Image?.Trim().ToLower();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Honda", honda.LoaiHonda.TenLoai, imageName + ".png");

            // Kiểm tra sự tồn tại của file ảnh
            honda.ImageExists = !string.IsNullOrEmpty(imageName) && System.IO.File.Exists(imagePath);
        }

        var viewModel = new HondaViewModel
        {
            HondaList = hondaList,
            Brands = loaiHondaList
        };

        return View(viewModel);
    }
}
