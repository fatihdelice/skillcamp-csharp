using ConsonantCheckApp.Services;

namespace ConsonantCheckApp
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

            bool[] sonuclar = stringService.MetinKontrol(metin);

            Console.WriteLine("\nSonuclar:");

            Console.WriteLine(
                string.Join(" ", sonuclar)
            );
        }
    }
}