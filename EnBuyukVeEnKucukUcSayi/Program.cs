using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[20];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write((i + 1) + ". number: ");

            while (!int.TryParse(Console.ReadLine(), out numbers[i]))
            {
                Console.Write("Invalid input. Enter a number: ");
            }
        }

        Array.Sort(numbers);

        int smallestSum = 0;
        int largestSum = 0;

        Console.WriteLine("\nSmallest 3 numbers:");

        for (int i = 0; i < 3; i++)
        {
            Console.Write(numbers[i] + " ");
            smallestSum += numbers[i];
        }

        Console.WriteLine("\n\nLargest 3 numbers:");

        for (int i = numbers.Length - 3; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
            largestSum += numbers[i];
        }

        double smallestAverage = smallestSum / 3.0;
        double largestAverage = largestSum / 3.0;

        double totalAverage = smallestAverage + largestAverage;

        Console.WriteLine("\n\nSmallest 3 average: " + smallestAverage);
        Console.WriteLine("Largest 3 average: " + largestAverage);
        Console.WriteLine("Average total: " + totalAverage);
    }
}
