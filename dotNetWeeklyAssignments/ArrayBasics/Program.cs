namespace ArrayBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating and Initializing an Array of Integers
            // Size of the Array is 10
            int[] Numbers = { 17, 23, 4, 59, 27, 36, 96, 9, 1, 3 };

            // Printing the Array Elements using a for loop
            Console.WriteLine("Original Array Elements:");
            for (int i = 0; i < Numbers.Length; i++)
            {
                Console.Write(Numbers[i] + " ");
            }

            Console.WriteLine();

            // Sorting the Array using Array.Sort()
            Array.Sort(Numbers);

            // Printing array after sorting
            Console.WriteLine("\nArray Elements After Sorting:");
            foreach (int i in Numbers)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            // Reversing the array using Array.Reverse()
            Array.Reverse(Numbers);

            // Printing array in reverse order
            Console.WriteLine("\nArray Elements in Reverse Order:");
            foreach (int i in Numbers)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            // Creating a new array of size 10
            int[] NewNumbers = new int[10];

            // Copying first 5 elements from Numbers to NewNumbers
            Array.Copy(Numbers, NewNumbers, 5);

            // Printing new array elements
            Console.WriteLine("\nNew Array Elements:");
            foreach (int i in NewNumbers)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            // Length property
            Console.WriteLine($"\nNew Array Length using Length Property: {NewNumbers.Length}");

            // GetLength method
            Console.WriteLine($"New Array Length using GetLength Method: {NewNumbers.GetLength(0)}");
            Console.WriteLine($"New Array Length using GetLength Method: {NewNumbers.GetLength(0)}");

            // Pause console
            Console.ReadKey();
        }
    }
    }
 