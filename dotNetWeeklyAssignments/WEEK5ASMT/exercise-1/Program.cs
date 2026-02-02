using System;

namespace exercise_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Runs scored by Dhoni in N matches");
            Console.Write("Enter number of matches: ");

            string s = Console.ReadLine();

            if (!int.TryParse(s, out int n) || n < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine($"\nRuns scored by Dhoni in {n} matches are:\n");

            for (int i = 0; i < n; i++)
            {
                int runs = i * (i + 1) * (i + 2);
                Console.Write($"{runs} ");
            }

            Console.WriteLine();
        }
    }
}
