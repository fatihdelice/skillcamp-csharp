using System;

class Program
{
    static void Main()
    {
        Console.Write("Kac adet kelime gireceksiniz: ");
        int n = int.Parse(Console.ReadLine());

        string[] kelimeler = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"{i + 1}. kelimeyi girin: ");
            kelimeler[i] = Console.ReadLine();
        }

        Console.WriteLine("\nKelimelerin ters siralanisi:");

        for (int i = n - 1; i >= 0; i--)
        {
            Console.WriteLine(kelimeler[i]);
        }
    }
}
