namespace GardropAI.Models
{
    public class ClothingItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örnek: "Mavi Kot Pantolon"
        public string Type { get; set; } // Örnek: "Pantolon", "Tişört"
        public string Color { get; set; }
        public string Season { get; set; } // Örnek: "Yaz", "Kış"
        public string Material { get; set; } // Örnek: "Kot", "Pamuk"
        public string Style { get; set; } // Örnek: "Spor", "Klasik"
    }

}
