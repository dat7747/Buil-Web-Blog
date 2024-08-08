using Microsoft.AspNetCore.Mvc;
using Web_Blog.Models;

namespace Web_Blog.Controllers
{
    public class AccountController : Controller
    {
       [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "Home"); 
            }

            return View(model);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện logic đăng ký, ví dụ lưu thông tin vào database
                // Redirect về trang khác sau khi đăng ký thành công
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
