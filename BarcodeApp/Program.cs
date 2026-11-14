using BarcodeApp.Services;

namespace BarcodeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BarcodeService barcodeService = new BarcodeService();

            bool devam = true;

            while (devam)
            {
                Console.WriteLine("\n========== BARCODE UYGULAMASI ==========");
                Console.WriteLine("1 - Barkod Olustur");
                Console.WriteLine("2 - Barkod Oku");
                Console.WriteLine("3 - Cikis");

                Console.Write("\nSeciminiz: ");

                string? secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        BarkodOlustur(barcodeService);
                        break;

                    case "2":
                        BarkodOku(barcodeService);
                        break;

                    case "3":
                        devam = false;
                        Console.WriteLine("Uygulama kapatildi.");
                        break;

                    default:
                        Console.WriteLine("Gecersiz secim!");
                        break;
                }
            }
        }

        static void BarkodOlustur(BarcodeService barcodeService)
        {
            Console.Write("\nBarkoda donusturulecek metni giriniz: ");

            string? metin = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(metin))
            {
                Console.WriteLine("Metin bos olamaz!");
                return;
            }

            string filePath = barcodeService.BarkodOlustur(metin);

            Console.WriteLine("\nBarkod basariyla olusturuldu!");
            Console.WriteLine($"Dosya yolu: {filePath}");
        }

        static void BarkodOku(BarcodeService barcodeService)
        {
            Console.Write("\nBarkod dosyasinin yolunu giriniz: ");

            string? filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Dosya yolu bos olamaz!");
                return;
            }

            string? sonuc = barcodeService.BarkodOku(filePath);

            if (sonuc == null)
            {
                Console.WriteLine(
                    "Dosya bulunamadi veya barkod okunamadi!"
                );

                return;
            }

            Console.WriteLine("\nBarkod basariyla okundu!");
            Console.WriteLine($"Barkod icerigi: {sonuc}");
        }
    }
}