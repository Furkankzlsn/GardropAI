using Microsoft.AspNetCore.Mvc;
using GardropAI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace GardropAI.Controllers;

public class WardrobeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
