using CharacterSwapApp.Services;

namespace CharacterSwapApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringService stringService = new StringService();

            Console.Write("Bir metin giriniz: ");

            string? metin = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(metin))
            {
                Console.WriteLine("Lutfen gecerli bir metin giriniz!");
                return;
            }

            string sonuc = stringService.KarakterleriDegistir(metin);

            Console.WriteLine($"Sonuc: {sonuc}");
        }
    }
}