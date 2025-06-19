using System.Diagnostics;
using GardropAI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GardropAI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Auth");

            ViewBag.User = username;
            return View();
        }
    }
}
