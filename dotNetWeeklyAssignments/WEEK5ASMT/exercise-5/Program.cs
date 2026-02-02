namespace exercise_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("John's wt Classification\n");
            Console.Write("Enter John's wt: ");
            string s = Console.ReadLine();
            int.TryParse(s, out int wt);

            if (wt < 0 || wt > 120)
            {
                Console.WriteLine("Invalid Input");
            }
            else if (wt <= 48)
            {
                Console.WriteLine("Light Fly");
            }
            else if (wt <= 51)
            {
                Console.WriteLine("Fly");
            }
            else if (wt <= 54)
            {
                Console.WriteLine("Bantam");
            }
            else if (wt <= 57)
            {
                Console.WriteLine("Feather");
            }
            else if (wt <= 60)
            {
                Console.WriteLine("Light");
            }
            else if (wt <= 64)
            {
                Console.WriteLine("Light Welter");
            }
            else if (wt <= 69)
            {
                Console.WriteLine("Welter");
            }
            else if (wt <= 75)
            {
                Console.WriteLine("Light Middle");
            }
            else if (wt <= 81)
            {
                Console.WriteLine("Middle");
            }
            else if (wt <= 91)
            {
                Console.WriteLine("Light Heavy");
            }
            else
            {
                Console.WriteLine("Heavy");
            }
        }
    }
}