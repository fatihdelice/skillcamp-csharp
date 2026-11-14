using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();

        string vowels = "ae\u0131io\u00F6u\u00FC";

        List<char> vowelList = new List<char>();

        foreach (char character in sentence.ToLower(new CultureInfo("tr-TR")))
        {
            if (vowels.Contains(character))
            {
                vowelList.Add(character);
            }
        }

        char[] vowelArray = vowelList.ToArray();

        Array.Sort(vowelArray);

        Console.WriteLine("\nVowel letters:");

        foreach (char vowel in vowelArray)
        {
            Console.Write(vowel + " ");
        }

        Console.WriteLine("\n\nTotal vowel count: " + vowelArray.Length);
    }
}
