using AbsoluteSquareApp.Services;

namespace AbsoluteSquareApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberCalculationService calculationService =
                new NumberCalculationService();

            Console.Write("Kac adet sayi gireceksiniz: ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Lutfen gecerli bir adet giriniz!");
                return;
            }

            int[] sayilar = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}. sayiyi giriniz: ");

                while (!int.TryParse(Console.ReadLine(), out sayilar[i]))
                {
                    Console.Write("Gecersiz sayi! Tekrar giriniz: ");
                }
            }

            var sonuc = calculationService.Hesapla(sayilar);

            Console.WriteLine("\n=== HESAPLAMA SONUCU ===");

            Console.WriteLine(
                $"67'den kucuklerin farklari toplami: {sonuc.KucuklerinToplami}"
            );

            Console.WriteLine(
                $"67'den buyuklerin mutlak kareleri toplami: {sonuc.BuyuklerinToplami}"
            );

            Console.WriteLine(
                $"{sonuc.KucuklerinToplami} {sonuc.BuyuklerinToplami}"
            );
        }
    }
}