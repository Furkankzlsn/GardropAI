using System.ComponentModel.DataAnnotations;

namespace GardropAI.Models
{
    public enum MainCategory
    {
        Giyim,
        Aksesuar,
        Ayakkabı,
        Şapka
    }

    public enum ClothingGroup
    {
        Üst,
        Alt,
        DışGiyim,
        Takım,
        Pijama,
        Plaj
    }

    public enum AccessoryGroup
    {
        Takı,
        Kemer,
        FularAtkı,
        Diğer
    }

    public enum SubCategory
    {
        // Giyim - Üst
        Tişört,
        Gömlek,
        Bluz,
        Sweatshirt,
        Kazak,
        Crop,
        Büstiyer,

        // Giyim - Alt
        Pantolon,
        Şort,
        Etek,
        Tayt,
        Eşofman,

        // Giyim - Dış Giyim
        Ceket,
        Kaban,
        Trençkot,
        Mont,

        // Giyim - Takım
        TakımElbise,
        TakımCeket,
        Yelek,

        // Giyim - Pijama
        PijamaÜst,
        PijamaAlt,

        // Giyim - Plaj
        Bikini,
        Mayo,
        Pareo,

        // Aksesuar - Takı
        Kolye,
        Küpe,
        Bilezik,
        Yüzük,
        Halhal,
        BelZinciri,
        Saat,

        // Aksesuar - Diğer
        Gözlük,
        Broş,

        // Aksesuar - Kemer
        Kemer,

        // Aksesuar - Fular Atkı
        Fular,
        Atkı,

        // Ayakkabı
        Spor,
        Günlük,
        Topuklu,
        Çizme,
        Sandalet,
        Terlik,

        // Şapka
        Şapka,
        Bere,
        Kasket,
        Bandana
    }

    public abstract class WardrobeItemBase
    {
        public Guid Id { get; set; }
        public MainCategory Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string? ImagePath { get; set; }
        public string? ExtraDetail { get; set; }
    }

    // Giyim
    public class ClothingItem : WardrobeItemBase
    {
        public string? Material { get; set; }
        public string? Style { get; set; }
        public string? Fit { get; set; } // Dar, Normal, Oversize, Oversize Fit
        public string? Length { get; set; } // Diz üstü, diz altı, uzun
        public string? Season { get; set; } // Kış, Yaz, Bahar, Hepsi
    }

    // Takı
    public class NecklaceItem : WardrobeItemBase
    {
        public string? ChainType { get; set; }
        public bool IsMultiLayered { get; set; }
        public List<string>? NecklaceLengths { get; set; } // Kısa, Orta, Uzun vs.
    }

    public class WatchItem : WardrobeItemBase
    {
        public string? WatchStrapType { get; set; } // Deri, Metal vs.
    }

    public class RingItem : WardrobeItemBase { }
    public class BraceletItem : WardrobeItemBase { }
    public class EarringItem : WardrobeItemBase { }
    public class AnkleChainItem : WardrobeItemBase { }
    public class BodyChainItem : WardrobeItemBase { }

    // Aksesuar
    public class BeltItem : WardrobeItemBase { }
    public class ScarfItem : WardrobeItemBase { }
    public class GlassesItem : WardrobeItemBase { }
    public class BroochItem : WardrobeItemBase { }

    // Ayakkabı
    public class ShoeItem : WardrobeItemBase
    {
        public string? Material { get; set; }
        public string? Style { get; set; }
        public string? ShoeTypeDetail { get; set; }
        public bool? IsAnkleSupport { get; set; }
    }

    // Şapka
    public class HatItem : WardrobeItemBase
    {
        public string? Material { get; set; }
        public string? Style { get; set; }
        public string? HatShape { get; set; }
    }

}
