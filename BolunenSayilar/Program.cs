using System;

class Program
{
    static void Main()
    {
        Console.Write("Kac adet sayi gireceksiniz (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Bolunme sayisini girin (m): ");
        int m = int.Parse(Console.ReadLine());

        if (m <= 0)
        {
            Console.WriteLine("m pozitif bir sayi olmalidir.");
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            Console.Write($"{i}. sayiyi girin: ");
            int sayi = int.Parse(Console.ReadLine());

            if (sayi == m || sayi % m == 0)
            {
                Console.WriteLine("Uygun sayi: " + sayi);
            }
        }
    }
}
