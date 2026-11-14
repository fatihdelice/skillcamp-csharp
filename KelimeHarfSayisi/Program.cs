using System;

class Program
{
    static void Main()
    {
        Console.Write("Bir cumle girin: ");
        string cumle = Console.ReadLine();

        string[] kelimeler = cumle.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        int kelimeSayisi = kelimeler.Length;
        int harfSayisi = 0;

        foreach (char karakter in cumle)
        {
            if (char.IsLetter(karakter))
            {
                harfSayisi++;
            }
        }

        Console.WriteLine("Kelime sayisi: " + kelimeSayisi);
        Console.WriteLine("Harf sayisi: " + harfSayisi);
    }
}
