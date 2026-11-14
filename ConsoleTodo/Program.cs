using ConsoleTodo.Models;
using ConsoleTodo.Services;

namespace ConsoleTodo
{
    internal class Program
    {
        static BoardService board = new BoardService();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nLutfen yapmak istediginiz islemi seciniz");
                Console.WriteLine("******************************");
                Console.WriteLine("(1) Board Listelemek");
                Console.WriteLine("(2) Board'a Kart Eklemek");
                Console.WriteLine("(3) Board'dan Kart Silmek");
                Console.WriteLine("(4) Kart Tasimak");
                Console.WriteLine("(5) Kart Guncellemek");
                Console.WriteLine("(0) Cikis");
                Console.WriteLine("******************************");

                Console.Write("Seciminiz: ");

                string? secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        BoardListele();
                        break;

                    case "2":
                        KartEkle();
                        break;

                    case "3":
                        KartSil();
                        break;

                    case "4":
                        KartTasi();
                        break;

                    case "5":
                        KartGuncelle();
                        break;

                    case "0":
                        Console.WriteLine("Programdan cikiliyor...");
                        return;

                    default:
                        Console.WriteLine("Hatali secim yaptiniz!");
                        break;
                }
            }
        }

        // Board listeleme
        static void BoardListele()
        {
            board.BoardListele();
        }

        // Kart ekleme
        static void KartEkle()
        {
            Console.Write("\nBaslik Giriniz: ");
            string baslik = GerekliBilgiAl();

            Console.Write("Icerik Giriniz: ");
            string icerik = GerekliBilgiAl();

            Console.WriteLine("\nBuyukluk Seciniz");
            Console.WriteLine("XS (1), S (2), M (3), L (4), XL (5)");

            if (!int.TryParse(Console.ReadLine(), out int buyuklukSecim) ||
                !Enum.IsDefined(typeof(Buyukluk), buyuklukSecim))
            {
                Console.WriteLine("Hatali buyukluk secimi!");
                return;
            }

            board.TakimUyeleriniListele();

            Console.Write("\nKisi ID Giriniz: ");

            if (!int.TryParse(Console.ReadLine(), out int kisiId))
            {
                Console.WriteLine("Hatali girisler yaptiniz!");
                return;
            }

            TakimUyesi? atananKisi = board.TakimUyeleri
                .FirstOrDefault(x => x.Id == kisiId);

            if (atananKisi == null)
            {
                Console.WriteLine("Hatali girisler yaptiniz!");
                return;
            }

            Kart yeniKart = new Kart(
                baslik,
                icerik,
                atananKisi,
                (Buyukluk)buyuklukSecim,
                BoardLine.TODO
            );

            board.KartEkle(yeniKart);

            Console.WriteLine("\nKart basariyla eklendi!");
        }

        // Kart silme
        static void KartSil()
        {
            while (true)
            {
                Console.Write("\nSilmek istediginiz kartin basligini yaziniz: ");
                string baslik = GerekliBilgiAl();

                List<Kart> bulunanKartlar = board.KartBul(baslik);

                if (bulunanKartlar.Count == 0)
                {
                    Console.WriteLine(
                        "\nAradiginiz kriterlere uygun kart board'da bulunamadi."
                    );

                    Console.WriteLine("(1) Silmeyi sonlandir");
                    Console.WriteLine("(2) Yeniden dene");

                    string? secim = Console.ReadLine();

                    if (secim == "1")
                        return;

                    if (secim == "2")
                        continue;

                    Console.WriteLine("Hatali secim!");
                    return;
                }

                board.KartSil(baslik);

                Console.WriteLine(
                    $"{bulunanKartlar.Count} adet kart basariyla silindi!"
                );

                return;
            }
        }

        // Kart tasima
        static void KartTasi()
        {
            while (true)
            {
                Console.Write("\nTasımak istediginiz kartin basligini yaziniz: ");
                string baslik = GerekliBilgiAl();

                List<Kart> bulunanKartlar = board.KartBul(baslik);

                if (bulunanKartlar.Count == 0)
                {
                    Console.WriteLine(
                        "\nAradiginiz kriterlere uygun kart board'da bulunamadi."
                    );

                    Console.WriteLine("(1) Islemi sonlandir");
                    Console.WriteLine("(2) Yeniden dene");

                    string? secim = Console.ReadLine();

                    if (secim == "1")
                        return;

                    if (secim == "2")
                        continue;

                    Console.WriteLine("Hatali secim!");
                    return;
                }

                Kart? secilenKart = KartSec(bulunanKartlar);

                if (secilenKart == null)
                    return;

                KartBilgileriniGoster(secilenKart);

                Console.WriteLine("\nTasımak istediginiz Line'i seciniz:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");

                if (!int.TryParse(Console.ReadLine(), out int lineSecim) ||
                    !Enum.IsDefined(typeof(BoardLine), lineSecim))
                {
                    Console.WriteLine("Hatali Line secimi!");
                    return;
                }

                board.KartTasi(secilenKart, (BoardLine)lineSecim);

                Console.WriteLine("\nKart basariyla tasindi!");

                return;
            }
        }

        // Kart guncelleme
        static void KartGuncelle()
        {
            Console.Write("\nGuncellemek istediginiz kartin basligini yaziniz: ");

            string baslik = GerekliBilgiAl();

            List<Kart> bulunanKartlar = board.KartBul(baslik);

            if (bulunanKartlar.Count == 0)
            {
                Console.WriteLine("Kart bulunamadi!");
                return;
            }

            Kart? secilenKart = KartSec(bulunanKartlar);

            if (secilenKart == null)
                return;

            KartBilgileriniGoster(secilenKart);

            Console.Write("\nYeni Baslik: ");
            string yeniBaslik = GerekliBilgiAl();

            Console.Write("Yeni Icerik: ");
            string yeniIcerik = GerekliBilgiAl();

            Console.WriteLine("\nYeni Buyukluk Seciniz");
            Console.WriteLine("XS (1), S (2), M (3), L (4), XL (5)");

            if (!int.TryParse(Console.ReadLine(), out int buyuklukSecim) ||
                !Enum.IsDefined(typeof(Buyukluk), buyuklukSecim))
            {
                Console.WriteLine("Hatali buyukluk secimi!");
                return;
            }

            board.TakimUyeleriniListele();

            Console.Write("\nYeni Atanan Kisi ID: ");

            if (!int.TryParse(Console.ReadLine(), out int kisiId))
            {
                Console.WriteLine("Hatali girisler yaptiniz!");
                return;
            }

            TakimUyesi? atananKisi = board.TakimUyeleri
                .FirstOrDefault(x => x.Id == kisiId);

            if (atananKisi == null)
            {
                Console.WriteLine("Hatali girisler yaptiniz!");
                return;
            }

            board.KartGuncelle(
                secilenKart,
                yeniBaslik,
                yeniIcerik,
                atananKisi,
                (Buyukluk)buyuklukSecim
            );

            Console.WriteLine("\nKart basariyla guncellendi!");
        }

        // Birden fazla kart bulunursa kullanicinin secim yapmasi
        static Kart? KartSec(List<Kart> kartlar)
        {
            if (kartlar.Count == 1)
                return kartlar[0];

            Console.WriteLine("\nBirden fazla kart bulundu.");

            for (int i = 0; i < kartlar.Count; i++)
            {
                Console.WriteLine(
                    $"({i + 1}) {kartlar[i].Baslik} - {kartlar[i].Line}"
                );
            }

            Console.Write("Islem yapmak istediginiz kartin numarasi: ");

            if (!int.TryParse(Console.ReadLine(), out int secim) ||
                secim < 1 ||
                secim > kartlar.Count)
            {
                Console.WriteLine("Hatali secim!");
                return null;
            }

            return kartlar[secim - 1];
        }

        // Kart bilgilerini gosterme
        static void KartBilgileriniGoster(Kart kart)
        {
            Console.WriteLine("\nBulunan Kart Bilgileri");
            Console.WriteLine("******************************");
            Console.WriteLine($"Baslik      : {kart.Baslik}");
            Console.WriteLine($"Icerik      : {kart.Icerik}");
            Console.WriteLine($"Atanan Kisi : {kart.AtananKisi.AdSoyad}");
            Console.WriteLine($"Buyukluk    : {kart.Buyukluk}");
            Console.WriteLine($"Line        : {kart.Line}");
            Console.WriteLine("******************************");
        }

        // Bos girisleri engelleme
        static string GerekliBilgiAl()
        {
            string? bilgi = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(bilgi))
            {
                Console.Write("Bu alan bos birakilamaz. Tekrar giriniz: ");
                bilgi = Console.ReadLine();
            }

            return bilgi.Trim();
        }
    }
}
