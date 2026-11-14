using VotingApp.Models;
using VotingApp.Services;

namespace VotingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();
            VotingService votingService = new VotingService();
            ReportService reportService = new ReportService();

            List<Category> categories = new List<Category>
            {
                new Category(1, "Film"),
                new Category(2, "Tech Stack"),
                new Category(3, "Spor")
            };

            Console.WriteLine("========== VOTING UYGULAMASI ==========");

            Console.WriteLine("\nOylama Kategorileri:");

            KategorileriListele(categories);

            User? aktifKullanici = null;

            while (aktifKullanici == null)
            {
                Console.Write("\nUsername giriniz: ");

                string? username = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Username bos olamaz!");
                    continue;
                }

                aktifKullanici = userService.KullaniciBul(username);

                if (aktifKullanici == null)
                {
                    Console.WriteLine(
                        "Kullanici sistemde kayitli degil."
                    );

                    Console.Write("Kayit olmak ister misiniz? (E/H): ");

                    string? cevap = Console.ReadLine();

                    if (cevap?.Equals(
                        "E",
                        StringComparison.OrdinalIgnoreCase) == true)
                    {
                        aktifKullanici = userService.KayitOl(username);

                        if (aktifKullanici != null)
                        {
                            Console.WriteLine(
                                "Kayit islemi basarili!"
                            );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lutfen kayit olunuz.");
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"Hos geldiniz, {aktifKullanici.Username}!"
                    );
                }
            }

            bool devam = true;

            while (devam)
            {
                Console.WriteLine("\nOylama Kategorileri:");

                KategorileriListele(categories);

                Console.WriteLine("0 - Oylamayi Bitir");

                Console.Write("\nOy vermek istediginiz kategoriyi seciniz: ");

                if (!int.TryParse(Console.ReadLine(), out int secim))
                {
                    Console.WriteLine("Gecersiz secim!");
                    continue;
                }

                if (secim == 0)
                {
                    devam = false;
                    continue;
                }

                Category? secilenKategori = categories.FirstOrDefault(
                    category => category.Id == secim
                );

                if (secilenKategori == null)
                {
                    Console.WriteLine("Boyle bir kategori bulunamadi!");
                    continue;
                }

                bool sonuc = votingService.OyVer(
                    aktifKullanici,
                    secilenKategori
                );

                if (sonuc)
                {
                    Console.WriteLine(
                        $"{secilenKategori.Name} kategorisine oyunuz kaydedildi!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "Bu kategoriye daha once oy kullandiniz!"
                    );
                }
            }

            reportService.RaporGoster(categories);

            Console.WriteLine("\nUygulama sonlandirildi.");
        }

        static void KategorileriListele(List<Category> categories)
        {
            foreach (Category category in categories)
            {
                Console.WriteLine(
                    $"{category.Id} - {category.Name}"
                );
            }
        }
    }
}