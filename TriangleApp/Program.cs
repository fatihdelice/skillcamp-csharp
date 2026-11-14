using TriangleApp.Services;

namespace TriangleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TriangleService triangleService = new TriangleService();

            Console.Write("Ucgen boyutunu giriniz: ");

            if (!int.TryParse(Console.ReadLine(), out int boyut) ||
                boyut <= 0)
            {
                Console.WriteLine("Lutfen pozitif bir tam sayi giriniz!");
                return;
            }

            triangleService.UcgenCiz(boyut);
        }
    }
}
