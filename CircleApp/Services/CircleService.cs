namespace CircleApp.Services
{
    public class CircleService
    {
        // Daire cizme metodu
        public void DaireCiz(int yaricap)
        {
            for (int y = -yaricap; y <= yaricap; y++)
            {
                for (int x = -yaricap; x <= yaricap; x++)
                {
                    if ((x * x) + (y * y) <= yaricap * yaricap)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
