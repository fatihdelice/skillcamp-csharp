using System;
using System.Collections;

class Program
{
    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    static void PrintList(string title, ArrayList list)
    {
        list.Sort();
        list.Reverse();

        Console.WriteLine("\n" + title);

        foreach (int number in list)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine("\nElement count: " + list.Count);

        if (list.Count > 0)
        {
            double average = 0;

            foreach (int number in list)
            {
                average += number;
            }

            average /= list.Count;

            Console.WriteLine("Average: " + average);
        }
        else
        {
            Console.WriteLine("Average: 0");
        }
    }

    static void Main()
    {
        ArrayList primeNumbers = new ArrayList();
        ArrayList nonPrimeNumbers = new ArrayList();

        int count = 0;

        while (count < 20)
        {
            Console.Write((count + 1) + ". positive integer: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number > 0)
            {
                if (IsPrime(number))
                    primeNumbers.Add(number);
                else
                    nonPrimeNumbers.Add(number);

                count++;
            }
            else
            {
                Console.WriteLine("Please enter a positive integer!");
            }
        }

        PrintList("Prime Numbers:", primeNumbers);
        PrintList("Non-Prime Numbers:", nonPrimeNumbers);
    }
}
