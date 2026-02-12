namespace Linq
{
    public class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            string[] names = { "deepu", "abhi" };

            var upper = names.Select(n => n.ToUpper());


            var evens = nums.Where(n => n % 2 == 0);

            foreach (var n in evens)
                Console.WriteLine(n);

            Console.WriteLine();
            var squares = nums.Select(n => n * n);
            foreach (var n in squares)
                Console.WriteLine(n);

            Console.WriteLine();
            var result = nums.Where(n => n > 3).Select(n => n * 10);
            foreach (var ans in result)
                Console.WriteLine(ans);

            Console.WriteLine();
            var sorted = nums.OrderBy(n => n);
            var desc = nums.OrderByDescending(n => n);

            foreach (var ele in sorted)
                Console.WriteLine(ele);
            Console.WriteLine();

            foreach (var ele in desc)
                Console.WriteLine(ele);

            Console.WriteLine();
            var sortedNames = names.OrderBy(n => n.Length);
            foreach (var ele in sortedNames)
            {
                Console.WriteLine(ele);
            }
            Console.WriteLine();


            List<Person> people = new List<Person>
{
    new Person { Name = "John", Age = 25 },
    new Person { Name = "Alex", Age = 30 },
    new Person { Name = "Bob",  Age = 25 },
    new Person { Name = "Chris", Age = 32 }
};
            
            var answer = people
    .OrderBy(p => p.Name).ThenBy(p => p.Age);

            foreach (var p in answer)
            {
                Console.WriteLine($"{p.Name} {p.Age}");
            }

            Console.WriteLine();

            int[] dup = { 1, 2, 2, 3, 3, 3 };

            var unique = dup.Distinct();

            foreach (var d in unique)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine(unique.Count());
            Console.WriteLine(unique.Count(n => n > 3));
            Console.WriteLine(unique.Any(n => n > 5));


        }
    }
}
