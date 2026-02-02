using System;

namespace ConsoleApp1
{
    public class Example
    {
        public static void Run()
        {
            int number = 300;

            unchecked
            {
                byte b = (byte)number;
                Console.WriteLine("Byte overflow result: " + b);
            }
        }
    }
}
