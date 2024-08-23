using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_Blog.Models;

namespace Web_Blog.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Navigating to Login page.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation("Attempting login with model: {@Model}", model);

            if (ModelState.IsValid)
            {
                // Xử lý đăng nhập thông thường ở đây
                _logger.LogInformation("Login successful.");
                return RedirectToAction("Index", "Home");
            }

            _logger.LogWarning("Login failed. Model state is invalid.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogInformation("Navigating to Register page.");
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            _logger.LogInformation("Attempting register with model: {@Model}", model);

            if (ModelState.IsValid)
            {
                // Thực hiện logic đăng ký, ví dụ lưu thông tin vào database
                _logger.LogInformation("Registration successful.");
                return RedirectToAction("Index", "Home");
            }

            _logger.LogWarning("Registration failed. Model state is invalid.");
            return View(model);
        }

        // Đăng nhập với Google
        [HttpGet]
        public IActionResult GoogleLogin()
        {
            _logger.LogInformation("Initiating Google login.");
            var redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

       [HttpGet]
       public IActionResult GoogleResponse()
        {
            _logger.LogInformation("Processing Google login response.");

            var claimsPrincipal = HttpContext.User;
            var userName = claimsPrincipal?.FindFirst(ClaimTypes.Name)?.Value;

            if (!string.IsNullOrEmpty(userName))
            {
                HttpContext.Session.SetString("UserName", userName);
                HttpContext.Session.SetString("IsAuthenticated", "true");
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            _logger.LogInformation("Logout method has been triggered.");

            // Clear the session
            HttpContext.Session.Clear();
            
            _logger.LogInformation("Session has been cleared.");

            // Return a JSON response indicating success
            return Json(new { success = true });
        }

    }
}
