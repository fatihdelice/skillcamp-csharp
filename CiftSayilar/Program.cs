using System;

class Program
{
    static void Main()
    {
        Console.Write("Kac adet sayi gireceksiniz: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write($"{i}. sayiyi girin: ");
            int sayi = int.Parse(Console.ReadLine());

            if (sayi % 2 == 0)
            {
                Console.WriteLine("Cift sayi: " + sayi);
            }
        }
    }
}
