using System;
using System.Collections;
 

namespace DAY_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            myList.Add(7);
            myList.Add("Abhi");
            myList.Add("101, \"John Doe\"");
            myList.Add(true);

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Generic counterpart");
            List<int> numbers = new List<int>();
            numbers.Add(numbers.Count);
            //numbers.Add("Abhi");
            numbers.Add(143);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

            List<string> countries = new List<string>();
            countries.Add("India");
            countries.Add("Srilanka");
            List<string> newCountries = new List<string>();
            newCountries.Add("USA");
            newCountries.Add("UK");

            countries.AddRange(newCountries);

            foreach (var item in countries)
            {
                Console.WriteLine(item);

            }


            Dictionary<string, int> Marks = new Dictionary<string, int>();
            Marks.Add("A", 50);
            Marks.Add("Abhi", 34);
            Marks.Add("Shek", 35);
            Marks.Add("Ranjan", 2);
            double avg = Marks.Values.Average();
            Console.WriteLine(avg);
            Console.WriteLine();
            //lowest alphabetically
            Console.WriteLine(Marks.Keys.Min());
            Console.WriteLine(Marks.Keys.Contains("abhi"));
            Console.WriteLine(Marks.Keys.ToArray());
            Console.WriteLine(Marks.Count);

            Console.WriteLine();

            Console.WriteLine(Marks.ContainsKey("Abhi"));
            Console.WriteLine(Marks.ContainsValue(35));

            Console.WriteLine(Marks["Shek"]);

            Console.WriteLine();

            int value;
            bool found = Marks.TryGetValue("Ranjan", out value);
            Console.WriteLine(found);
            Console.WriteLine(value);

            foreach (string key in Marks.Keys)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine();

            foreach (int val in Marks.Values)
            {
                Console.WriteLine(val);
            }
            Console.WriteLine();

            foreach (KeyValuePair<string, int> item in Marks)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.WriteLine();

            Marks["Abhi"] = 40;
            Console.WriteLine(Marks["Abhi"]);

            Console.WriteLine();

            Marks.Remove("A");
            Console.WriteLine(Marks.Count);

            Console.WriteLine();

            Marks.Clear();
            Console.WriteLine(Marks.Count);

            Console.WriteLine(Marks.GetType());

            // here it is predefined datatype not user defined so sort function knows and works
            // for case of user defined types ,classes,objects sort doesnot know how to
            // non primitives
            // so we need to use IComparable
            List<int> numbers = new List<int> { 420, 143, 341, 45, 7 };
            foreach (int nums in numbers)
            {
                Console.WriteLine(nums);
            }
            numbers.Sort();
            //public class Emp:IComparable<Emp>






        }

    }
}