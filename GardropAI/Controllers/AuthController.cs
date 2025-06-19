using Microsoft.AspNetCore.Mvc;
using GardropAI.Models;
using System.Text.Json;

namespace GardropAI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            var usersJson = System.IO.File.ReadAllText("Data/users.json");
            var users = JsonSerializer.Deserialize<List<UserModel>>(usersJson);

            var match = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (match != null)
            {
                HttpContext.Session.SetString("username", user.Username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }
    }
}
