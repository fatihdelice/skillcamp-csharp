using CircleApp.Services;

namespace CircleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CircleService circleService = new CircleService();

            Console.Write("Dairenin yaricapini giriniz: ");

            if (!int.TryParse(Console.ReadLine(), out int yaricap) ||
                yaricap <= 0)
            {
                Console.WriteLine("Lutfen pozitif bir tam sayi giriniz!");
                return;
            }

            circleService.DaireCiz(yaricap);
        }
    }
}
