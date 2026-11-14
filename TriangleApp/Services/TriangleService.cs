namespace TriangleApp.Services
{
    public class TriangleService
    {
        // Ucgen cizme metodu
        public void UcgenCiz(int boyut)
        {
            for (int i = 1; i <= boyut; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
