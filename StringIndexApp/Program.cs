using StringIndexApp.Services;

namespace StringIndexApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringService stringService = new StringService();

            Console.Write("Metin ve index giriniz (Ornek: Algoritma,3): ");

            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Hatali giris yaptiniz!");
                return;
            }

            string[] parcalar = input.Split(',');

            if (parcalar.Length != 2 ||
                !int.TryParse(parcalar[1].Trim(), out int index))
            {
                Console.WriteLine("Hatali giris yaptiniz!");
                return;
            }

            string metin = parcalar[0].Trim();

            string sonuc = stringService.KarakterSil(metin, index);

            Console.WriteLine($"Sonuc: {sonuc}");
        }
    }
}
