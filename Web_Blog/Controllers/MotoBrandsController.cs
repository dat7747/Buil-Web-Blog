using Microsoft.AspNetCore.Mvc;
using Web_Blog.Models; 
using System.Collections.Generic;

namespace Web_Blog.Controllers
{
    public class MotoBrandsController : Controller
    {
        public IActionResult Index()
        {
            var model = new CarBrandsViewModel
            {
                Brands = new List<string>
                {
                    "Honda",
                    "Yamaha",
                    "Suzuki",
                    "BMW",
                    "Ducati",
                    "Harley-Davidson",
                    "KTM",
                    "Vespa",
                    "Piaggio",
                    "Royal Enfield"
                }
            };

            return View(model);
        }
    }
}
