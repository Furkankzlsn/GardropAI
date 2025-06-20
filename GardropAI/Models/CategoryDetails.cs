using System;
using System.Collections.Generic;

namespace GardropAI.Models
{
    // Enumlar
    public enum KolTipi { Kisa, Uzun, Askili }
    public enum YakaTipi { Bisiklet, V, Polo }
    public enum PacaTipi { Dar, Bol, Lastikli }
    public enum BelTipi { Yuksek, Orta, Dusuk }
    public enum ElbiseTipi { Gunluk, Abiye }
    public enum KalinlikTipi { Ince, Orta, Kalin }
    public enum TabanTipi { Duz, Kalin, Disli }
    public enum GozlukTipi { Gunes, Numara, Moda }
    public enum CerceveTipi { Yuvarlak, Dikdortgen }

    // Detay interface'i
    public interface ICategoryDetails
    {
        string? Id { get; set; }
        string? Name { get; set; } // Kullanıcının verdiği benzersiz isim
        string? Renk { get; set; }
        string? Beden { get; set; }
        string? Marka { get; set; }
        string? Mevsim { get; set; }
        string? Aciklama { get; set; }
        List<string>? AnahtarKelimeler { get; set; }
        List<string>? Kategoriler { get; set; }
        string? GorselUrl { get; set; }
        DateTime? CreatedAt { get; set; } // Eklenme tarihi
    }

    // Ortak detaylar
    public class CommonDetails : ICategoryDetails
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Renk { get; set; }
        public string? Desen { get; set; }
        public string? Beden { get; set; }
        public string? Marka { get; set; }
        public string? Mevsim { get; set; }
        public string? Aciklama { get; set; }
        public List<string>? AnahtarKelimeler { get; set; }
        public List<string>? Kategoriler { get; set; }
        public string? GorselUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    // Üst Giyim detayları
    public class ClothingTopDetails : CommonDetails
    {
        public KolTipi? KolTipi { get; set; } // Kısa, Uzun, Askılı
        public YakaTipi? YakaTipi { get; set; } // Bisiklet, V, Polo
        public bool BaskiVarMi { get; set; }
        public string? KumasTuru { get; set; }
    }

    // Alt Giyim detayları
    public class ClothingBottomDetails : CommonDetails
    {
        public PacaTipi PacaTipi { get; set; } // Dar, Bol, Lastikli
        public BelTipi BelTipi { get; set; } // Yüksek, Orta, Düşük
        public bool CepVarMi { get; set; }
        public string? KumasTuru { get; set; }
    }

    // Elbise detayları
    public class ClothingDressDetails : CommonDetails
    {
        public ElbiseTipi ElbiseTipi { get; set; } // Günlük, Abiye
        public bool SirtDekoltesiVarMi { get; set; }
        public bool YirtmacVarMi { get; set; }
        public bool AskiliMi { get; set; }
        public string? KumasTuru { get; set; }
    }

    // Dış Giyim detayları
    public class ClothingOuterwearDetails : CommonDetails
    {
        public KalinlikTipi KalinlikTipi { get; set; } // İnce, Orta, Kalın
        public bool KapusonVarMi { get; set; }
        public bool FermuarliMi { get; set; }
        public bool CepliMi { get; set; }
        public bool SuGecirmezMi { get; set; }
        public string? KumasTuru { get; set; }
    }

    // Takım detayları
    public class ClothingSuitDetails : CommonDetails
    {
        public string? ParcaSayisi { get; set; } // 2'li, 3'lü
        public string? RenkUyumu { get; set; } // Tek renk, Karışık
        public string? Kumas { get; set; }
    }

    // Pijama detayları
    public class ClothingPajamaDetails : CommonDetails
    {
        public string? KumasTuru { get; set; } // Pamuk, Saten, Polar
        public KolTipi KolTipi { get; set; } // Kısa, Uzun
    }

    // Plaj detayları
    public class ClothingBeachDetails : CommonDetails
    {
        public bool UstAltTakimMi { get; set; }
        public string? TransparanlikDurumu { get; set; }
        public string? AskiTipi { get; set; }
    }

    // Takı detayları
    public class AccessoryJewelryDetails : CommonDetails
    {
        public string? MetalTuru { get; set; } // Altın, Gümüş, Çelik, Bijuteri
        public bool TasliMi { get; set; }
        public bool SetMi { get; set; }
        public bool AyarlanabilirMi { get; set; }
        public double? UzunlukCm { get; set; }
    }

    // Kemer detayları
    public class AccessoryBeltDetails : CommonDetails
    {
        public double? GenislikCm { get; set; }
        public string? MalzemeTuru { get; set; } // Deri, Kumaş
        public bool TokaliMi { get; set; }
        public bool AyarlanabilirMi { get; set; }
    }

    // Fular/Atkı detayları
    public class AccessoryScarfDetails : CommonDetails
    {
        public string? Malzeme { get; set; } // İpek, Yün
        public string? Boyut { get; set; } // Kısa, Uzun
    }

    // Şapka detayları
    public class AccessoryHatDetails : CommonDetails
    {
        public string? SapkaTipi { get; set; } // Snapback, Bucket, Bere
        public bool AyarlanabilirMi { get; set; }
        public string? Malzeme { get; set; }
        public bool MevsimlikMi { get; set; }
    }

    // Diğer aksesuar detayları (gözlük)
    public class AccessoryOtherDetails : CommonDetails
    {
        public GozlukTipi GozlukTipi { get; set; } // Güneş, Numara, Moda
        public bool UVKorumaliMi { get; set; }
        public CerceveTipi CerceveTipi { get; set; } // Yuvarlak, Dikdörtgen
    }

    // Ayakkabı detayları
    public class ShoeDetails : CommonDetails
    {
        public string? AyakkabiTipi { get; set; }
        public double? TopukYuksekligiCm { get; set; }
        public bool BagcikliMi { get; set; }
        public bool SuGecirmezMi { get; set; }
        public TabanTipi TabanTipi { get; set; } // Düz, Kalın, Dişli
        public string? Numara { get; set; }
        public string? Malzeme { get; set; }
    }
}
