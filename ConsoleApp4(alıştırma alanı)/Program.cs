using System;
using System.Linq;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Ürün Adı Kontrolü
            Console.Write("Ürün adını giriniz: ");
            string ua = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(ua) || ua.Any(char.IsDigit))
            {
                Console.WriteLine("⚠️ Lütfen geçerli bir ürün adı giriniz (boş veya sayı olamaz)!");
                ua = Console.ReadLine();
            }

            // 2. Fiyat Kontrolü
            Console.Write("Fiyatını giriniz: ");
            decimal fg;
            while (!decimal.TryParse(Console.ReadLine(), out fg))
            {
                Console.WriteLine("⚠️ Lütfen geçerli bir fiyat giriniz!");
            }

            // 3. Adet Kontrolü (Güvenli int.TryParse)
            Console.Write("Adet giriniz: ");
            int ag;
            while (!int.TryParse(Console.ReadLine(), out ag))
            {
                Console.WriteLine("⚠️ Lütfen geçerli bir adet giriniz!");
            }

            // Tutar Hesaplamaları
            decimal vergisiz_fiyat = fg * ag;
            decimal kdv_dahil = vergisiz_fiyat + (vergisiz_fiyat * 0.2m);

            Console.WriteLine("\nKDV Dahil Ham Tutar: {0} TL", kdv_dahil);
            Console.WriteLine("Lütfen kategoriyi giriniz... 1: Elektronik, 2: Giyim, 3: Diğer");

            ConsoleKeyInfo tus = Console.ReadKey();
            Console.WriteLine(); // Alt satıra geçmek için

            decimal sonTutar = kdv_dahil;

            // Kategori İndirimleri
            if (tus.KeyChar == '1')
            {
                Console.WriteLine("Elektronik kategorisinde kategori indirimi bulunmamaktadır.");
            }
            else if (tus.KeyChar == '2')
            {
                sonTutar = kdv_dahil - (kdv_dahil * 0.10m);
                Console.WriteLine("Tebrikler! Giyim kategorisine özel %10 indirim kazandınız.");
                Console.WriteLine("İndirimli Tutar: {0} TL", sonTutar);
            }
            else if (tus.KeyChar == '3')
            {
                Console.WriteLine("Diğer kategorisi seçildi.");
            }

            // Genel Tutar/Kupon İndirimleri
            if (sonTutar >= 1000m)
            {
                sonTutar -= 150m; // sonTutar = sonTutar - 150m ile aynıdır
                Console.WriteLine("Tebrikler! 1000 TL üzeri alışverişinize 150 TL kupon indirimi uygulandı.");
            }
            else if (sonTutar >= 500m)
            {
                sonTutar -= 50m;
                Console.WriteLine("Tebrikler! 500 TL üzeri alışverişinize 50 TL kupon indirimi uygulandı.");
            }
            else
            {
                Console.WriteLine("Kupon indirimi sınırına ulaşılamadı.");
            }

            // Kargo Hesabı (En Son Adım)
            if (sonTutar >= 750m)
            {
                Console.WriteLine("Sepetiniz 750 TL üzeri olduğu için KARGO ÜCRETSİZ!");
            }
            else
            {
                sonTutar += 60m;
                Console.WriteLine("Sepetiniz 750 TL altı olduğu için 60 TL kargo ücreti eklendi.");
            }

            Console.WriteLine("\n===================================");
            Console.WriteLine("ÖDENECEK TOPLAM TUTAR: {0} TL", sonTutar);
            Console.WriteLine("===================================");
            Console.ReadLine(); // Programın hemen kapanmaması için kullanıcıdan bir tuşa basmasını bekler
        }
    }
}