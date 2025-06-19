using Microsoft.AspNetCore.Mvc;
using GardropAI.Models;
using System.Text.Json;

namespace GardropAI.Controllers
{
    public class WardrobeController : Controller
    {
        public IActionResult Index(string type, string color, string season, string style)
        {
            var json = System.IO.File.ReadAllText("Data/clothes.json");
            var clothes = JsonSerializer.Deserialize<List<ClothingItemModel>>(json);

            if (!string.IsNullOrEmpty(type))
                clothes = clothes.Where(c => c.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!string.IsNullOrEmpty(color))
                clothes = clothes.Where(c => c.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!string.IsNullOrEmpty(season))
                clothes = clothes.Where(c => c.Season.Equals(season, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!string.IsNullOrEmpty(style))
                clothes = clothes.Where(c => c.Style.Equals(style, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(clothes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddAjax([FromBody] ClothingItemModel item)
        {
            var filePath = "Data/clothes.json";
            var json = System.IO.File.ReadAllText(filePath);
            var clothes = JsonSerializer.Deserialize<List<ClothingItemModel>>(json);

            item.Id = clothes.Max(c => c.Id) + 1;
            clothes.Add(item);

            var updatedJson = JsonSerializer.Serialize(clothes, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, updatedJson);

            return Json(new { success = true, message = "Kıyafet başarıyla eklendi!" });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var filePath = "Data/clothes.json";
            var json = System.IO.File.ReadAllText(filePath);
            var clothes = JsonSerializer.Deserialize<List<ClothingItemModel>>(json);

            var item = clothes.FirstOrDefault(c => c.Id == id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(ClothingItemModel updatedItem)
        {
            var filePath = "Data/clothes.json";
            var json = System.IO.File.ReadAllText(filePath);
            var clothes = JsonSerializer.Deserialize<List<ClothingItemModel>>(json);

            var index = clothes.FindIndex(c => c.Id == updatedItem.Id);
            if (index == -1)
                return NotFound();

            clothes[index] = updatedItem;

            var updatedJson = JsonSerializer.Serialize(clothes, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, updatedJson);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult DeleteConfirmed([FromBody] int id)
        {
            var filePath = "Data/clothes.json";
            var json = System.IO.File.ReadAllText(filePath);
            var clothes = System.Text.Json.JsonSerializer.Deserialize<List<ClothingItemModel>>(json);

            var item = clothes.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                clothes.Remove(item);
                var updatedJson = System.Text.Json.JsonSerializer.Serialize(clothes, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(filePath, updatedJson);
                return Json(new { success = true, message = "Kıyafet silindi." });
            }

            return Json(new { success = false, message = "Kıyafet bulunamadı." });
        }


    }
}
