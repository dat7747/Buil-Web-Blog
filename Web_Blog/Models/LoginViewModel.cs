using System.ComponentModel.DataAnnotations;
using Web_Blog.Models;

namespace Web_Blog.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
