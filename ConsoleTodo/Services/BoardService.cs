using ConsoleTodo.Models;

namespace ConsoleTodo.Services
{
    public class BoardService
    {
        public List<Kart> Kartlar { get; set; }

        public List<TakimUyesi> TakimUyeleri { get; set; }

        public BoardService()
        {
            Kartlar = new List<Kart>();

            // Takim uyeleri
            TakimUyeleri = new List<TakimUyesi>
            {
                new TakimUyesi(1, "Ahmet Yilmaz"),
                new TakimUyesi(2, "Mehmet Demir"),
                new TakimUyesi(3, "Ayse Kaya"),
                new TakimUyesi(4, "Fatma Yildiz"),
                new TakimUyesi(5, "Ali Can")
            };

            // Ornek kartlar
            Kartlar.Add(new Kart(
                "Login Sayfasi",
                "Kullanici giris ekraninin hazirlanmasi",
                TakimUyeleri[0],
                Buyukluk.M,
                BoardLine.TODO
            ));

            Kartlar.Add(new Kart(
                "Navbar",
                "Navigasyon menusunun yapilmasi",
                TakimUyeleri[1],
                Buyukluk.S,
                BoardLine.IN_PROGRESS
            ));

            Kartlar.Add(new Kart(
                "Footer",
                "Footer tasariminin tamamlanmasi",
                TakimUyeleri[2],
                Buyukluk.XS,
                BoardLine.DONE
            ));
        }

        // Kart ekleme
        public void KartEkle(Kart kart)
        {
            Kartlar.Add(kart);
        }

        // Basliga gore kart bulma
        public List<Kart> KartBul(string baslik)
        {
            return Kartlar
                .Where(x => x.Baslik.Equals(
                    baslik,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Kart silme
        public void KartSil(string baslik)
        {
            var bulunanKartlar = KartBul(baslik);

            foreach (var kart in bulunanKartlar)
            {
                Kartlar.Remove(kart);
            }
        }

        // Kart guncelleme
        public void KartGuncelle(
            Kart kart,
            string baslik,
            string icerik,
            TakimUyesi atananKisi,
            Buyukluk buyukluk)
        {
            kart.Baslik = baslik;
            kart.Icerik = icerik;
            kart.AtananKisi = atananKisi;
            kart.Buyukluk = buyukluk;
        }

        // Kart tasima
        public void KartTasi(Kart kart, BoardLine yeniLine)
        {
            kart.Line = yeniLine;
        }

        // Board listeleme
        public void BoardListele()
        {
            foreach (BoardLine line in Enum.GetValues(typeof(BoardLine)))
            {
                Console.WriteLine();
                Console.WriteLine(line);
                Console.WriteLine("******************************");

                var lineKartlari = Kartlar
                    .Where(x => x.Line == line)
                    .ToList();

                if (lineKartlari.Count == 0)
                {
                    Console.WriteLine("~ BOS ~");
                    continue;
                }

                foreach (var kart in lineKartlari)
                {
                    Console.WriteLine($"Baslik      : {kart.Baslik}");
                    Console.WriteLine($"Icerik      : {kart.Icerik}");
                    Console.WriteLine($"Atanan Kisi : {kart.AtananKisi.AdSoyad}");
                    Console.WriteLine($"Buyukluk    : {kart.Buyukluk}");
                    Console.WriteLine("------------------------------");
                }
            }
        }

        // Takim uyelerini listeleme
        public void TakimUyeleriniListele()
        {
            Console.WriteLine("\nTakim Uyeleri");
            Console.WriteLine("------------------------------");

            foreach (var uye in TakimUyeleri)
            {
                Console.WriteLine(uye);
            }
        }
    }
}
