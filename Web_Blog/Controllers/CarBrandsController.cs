using Microsoft.AspNetCore.Mvc;
using Web_Blog.Models;
using System.Collections.Generic;

namespace Web_Blog.Controllers
{
    public class CarBrandsController : Controller
    {
        public IActionResult Index()
        {
            var model = new CarBrandsViewModel
            {
                Brands = new List<string>
                {
                    "Mercedes-Benz", "BMW", "Volkswagen", "Audi", "Porsche", "Ferrari", 
                    "Lamborghini", "Renault", "Fiat", "Toyota", "Honda", "Nissan", 
                    "Mazda", "Hyundai", "Kia", "Lexus", "Infiniti", "Ford", "Chevrolet", 
                    "Cadillac", "Volvo", "Subaru", "Tesla", "Rivian"
                }
            };
            return View(model);
        }

    }
}
