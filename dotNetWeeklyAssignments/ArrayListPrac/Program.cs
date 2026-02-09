using System.Collections;

namespace ArrayListPrac
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a Collection using Array List
            ArrayList numberArray = new ArrayList();
            numberArray.Add(10);
            numberArray.Add(200);
            //No CompileTime Error
            numberArray.Add("Pranaya");
            //We Get Runtime Error, when we access the 3rd Element
            //foreach (var no in numberArray)
            //{
            //    Console.WriteLine(no);
            //}
            foreach (object item in numberArray)
            {
                if (item is int)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
        }
    }
}
