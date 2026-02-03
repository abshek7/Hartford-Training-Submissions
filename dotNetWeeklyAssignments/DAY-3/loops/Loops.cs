namespace loops
{
    public class Loops
    {
        static void Main(string[] args)
        {   //------------for loop:
            for (int i = 2; i <= 20; i += 2)
            {
                Console.WriteLine(i);
            }

            int[] numbers = { 10, 20, 30, 40 };
            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            for (int i = 0, j = 10; i < j; i++, j--)
            {
                Console.WriteLine($"i = {i}, j = {j}");
            }

            int j;

            for (int i = 0, j = 5; i < j; i++)
            {
                Console.WriteLine(i);
            }
            // this snippet gives error as 
            //A local or parameter named 'j' cannot be declared in this scope
            //because that name is used in an enclosing local scope to define a local or parameter


            int i = 0;

            for (; i < 5; i++)
            {
                Console.WriteLine(i);
            }
            //this works as fine

            int i = 1;

            for (; i <= 10;)
            {
                Console.WriteLine(i);
                i++;
            }
            //mimicking while


            for (int i = 0; ; i++)
            {
                if (i == 5)
                    break;

                Console.WriteLine(i);
            }
            //infinite loop if cond is removed

            int[] arr = { 10, 20, 30, 40 };

            for (int i = 0, len = arr.Length; i < len; i++)
            {
                Console.WriteLine(arr[i]);
            }


            //--------- while loop

            int sum = 0;
            int num;

            Console.Write("Enter number (0 to stop): ");
            num = int.Parse(Console.ReadLine());

            while (num != 0)
            {
                sum += num;
                Console.Write("Enter number (0 to stop): ");
                num = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Sum = " + sum);


            int attempts = 0;
            string pin = "";

            while (pin != "1234" && attempts < 3)
            {
                Console.Write("Enter PIN: ");
                pin = Console.ReadLine();
                attempts++;

                if (pin != "1234" && attempts < 3)
                {
                    Console.WriteLine("Incorrect PIN, try again.");
                }
            }

            if (pin == "1234")
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Too many incorrect attempts.");
            }


            int choice;

            do
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Exit");
                choice = int.Parse(Console.ReadLine());
            } while (choice != 2);





            //----foreach loop
            int[] marks = { 80, 90, 75 };

            foreach (int m in marks)
            {
                Console.WriteLine(m >= 50 ? "Pass" : "Fail");
            }


            int students = 3;
            int total = 0;

            for (int i = 1; i <= students; i++)
            {
                Console.Write("Enter marks: ");
                int marks = int.Parse(Console.ReadLine());

                while (marks < 0 || marks > 100)
                {
                    Console.Write("Invalid. Enter again: ");
                    marks = int.Parse(Console.ReadLine());
                }

                total += marks;
            }

            do
            {
                Console.WriteLine("Processing completed...");
            } while (false);

            int[] summary = { total };

            foreach (int s in summary)
            {
                Console.WriteLine("Total Marks = " + s);
            }



        }
    }
}
