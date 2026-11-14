using ATMApp.Models;
using ATMApp.Services;

namespace ATMApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();

            ATMService atmService = new ATMService(userService);

            EODService eodService = new EODService();

            Console.WriteLine("========== ATM UYGULAMASI ==========");

            User? aktifKullanici = KullaniciGirisi(
                userService,
                eodService
            );

            if (aktifKullanici == null)
            {
                Console.WriteLine("Giris hakkiniz doldu. Uygulama kapatiliyor.");
                return;
            }

            Console.WriteLine(
                $"\nHos geldiniz, {aktifKullanici.Username}!"
            );

            bool devam = true;

            while (devam)
            {
                MenuGoster();

                Console.Write("\nYapmak istediginiz islemi seciniz: ");

                if (!int.TryParse(Console.ReadLine(), out int secim))
                {
                    Console.WriteLine("Gecersiz secim!");
                    continue;
                }

                switch (secim)
                {
                    case 1:
                        ParaYatir(aktifKullanici, atmService);
                        break;

                    case 2:
                        ParaCek(aktifKullanici, atmService);
                        break;

                    case 3:
                        OdemeYap(aktifKullanici, atmService);
                        break;

                    case 4:
                        BakiyeSorgula(aktifKullanici, atmService);
                        break;

                    case 5:
                        devam = false;
                        break;

                    case 6:
                        string dosyaYolu =
                            eodService.GunSonuRaporuOlustur(
                                atmService.Transactions
                            );

                        Console.WriteLine(
                            $"\nGun sonu raporu olusturuldu:\n{dosyaYolu}"
                        );

                        devam = false;
                        break;

                    default:
                        Console.WriteLine("Gecersiz islem secimi!");
                        break;
                }
            }

            Console.WriteLine("\nATM uygulamasi sonlandirildi.");
        }

        static User? KullaniciGirisi(
            UserService userService,
            EODService eodService)
        {
            const int maksimumDeneme = 3;

            for (int i = 0; i < maksimumDeneme; i++)
            {
                Console.Write("\nUsername: ");
                string username = Console.ReadLine() ?? "";

                Console.Write("PIN: ");
                string pin = Console.ReadLine() ?? "";

                User? user = userService.KullaniciDogrula(
                    username,
                    pin
                );

                if (user != null)
                {
                    return user;
                }

                Console.WriteLine("Hatali username veya PIN!");

                eodService.FraudLogEkle(username);

                Console.WriteLine(
                    $"Kalan giris hakki: {maksimumDeneme - i - 1}"
                );
            }

            return null;
        }

        static void MenuGoster()
        {
            Console.WriteLine("\n========== ATM MENU ==========");
            Console.WriteLine("1 - Para Yatirma");
            Console.WriteLine("2 - Para Cekme");
            Console.WriteLine("3 - Odeme Yapma");
            Console.WriteLine("4 - Bakiye Sorgulama");
            Console.WriteLine("5 - Cikis");
            Console.WriteLine("6 - Gun Sonu");
        }

        static void ParaYatir(User user, ATMService atmService)
        {
            decimal amount = TutarAl("Yatirmak istediginiz tutar: ");

            if (atmService.ParaYatir(user, amount))
            {
                Console.WriteLine("Para yatirma islemi basarili.");
                Console.WriteLine($"Yeni bakiye: {user.Balance:F2} TL");
            }
            else
            {
                Console.WriteLine("Gecersiz tutar!");
            }
        }

        static void ParaCek(User user, ATMService atmService)
        {
            decimal amount = TutarAl("Cekmek istediginiz tutar: ");

            if (atmService.ParaCek(user, amount))
            {
                Console.WriteLine("Para cekme islemi basarili.");
                Console.WriteLine($"Yeni bakiye: {user.Balance:F2} TL");
            }
            else
            {
                Console.WriteLine(
                    "Islem basarisiz. Yetersiz bakiye veya gecersiz tutar!"
                );
            }
        }

        static void OdemeYap(User user, ATMService atmService)
        {
            decimal amount = TutarAl("Odeme tutarini giriniz: ");

            if (atmService.OdemeYap(user, amount))
            {
                Console.WriteLine("Odeme islemi basarili.");
                Console.WriteLine($"Yeni bakiye: {user.Balance:F2} TL");
            }
            else
            {
                Console.WriteLine(
                    "Odeme basarisiz. Yetersiz bakiye veya gecersiz tutar!"
                );
            }
        }

        static void BakiyeSorgula(User user, ATMService atmService)
        {
            decimal balance = atmService.BakiyeSorgula(user);

            Console.WriteLine($"Mevcut bakiyeniz: {balance:F2} TL");
        }

        static decimal TutarAl(string mesaj)
        {
            decimal amount;

            while (true)
            {
                Console.Write(mesaj);

                if (decimal.TryParse(
                    Console.ReadLine(),
                    out amount) && amount > 0)
                {
                    return amount;
                }

                Console.WriteLine(
                    "Lutfen sifirdan buyuk gecerli bir tutar giriniz!"
                );
            }
        }
    }
}