using FibonacciAverage.Services;

namespace FibonacciAverage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FibonacciService fibonacciService = new FibonacciService();

            Console.Write("Fibonacci serisinin derinligini giriniz: ");

            if (!int.TryParse(Console.ReadLine(), out int derinlik) ||
                derinlik <= 0)
            {
                Console.WriteLine("Lutfen pozitif bir tam sayi giriniz!");
                return;
            }

            // Fibonacci serisini olustur
            List<int> fibonacciSayilari =
                fibonacciService.FibonacciSerisiOlustur(derinlik);

            // Ortalamayi hesapla
            double ortalama =
                fibonacciService.OrtalamaHesapla(fibonacciSayilari);

            // Sonuclari ekrana yazdir
            Console.WriteLine("\nFibonacci Serisi:");
            Console.WriteLine(string.Join(", ", fibonacciSayilari));

            Console.WriteLine($"Fibonacci Serisinin Ortalamasi: {ortalama:F2}");
        }
    }
}
