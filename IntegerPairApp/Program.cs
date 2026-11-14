using IntegerPairApp.Services;

namespace IntegerPairApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PairCalculationService calculationService =
                new PairCalculationService();

            Console.Write("Kac adet sayi cifti gireceksiniz: ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Lutfen gecerli bir adet giriniz!");
                return;
            }

            List<int> sonuclar = new List<int>();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}. ciftin sayilarini giriniz: ");

                string? giris = Console.ReadLine();

                string[] sayilar = giris?.Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries
                ) ?? Array.Empty<string>();

                if (sayilar.Length != 2 ||
                    !int.TryParse(sayilar[0], out int sayi1) ||
                    !int.TryParse(sayilar[1], out int sayi2))
                {
                    Console.WriteLine(
                        "Lutfen iki adet gecerli integer giriniz!"
                    );

                    i--;
                    continue;
                }

                int sonuc = calculationService.Hesapla(sayi1, sayi2);

                sonuclar.Add(sonuc);
            }

            Console.WriteLine("\nSonuclar:");

            Console.WriteLine(string.Join(" ", sonuclar));
        }
    }
}