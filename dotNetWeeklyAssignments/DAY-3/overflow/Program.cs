namespace overflow
{
    public class Program
    {
        static void Main(string[] args)
        {   // without checked here x value is logged as -2147483648
            unchecked
            {   // here we are telling ignore overflow ,we are going to handle
                int x = int.MaxValue;
                x++;

                Console.WriteLine(x);
            }
            //int x = int.MaxValue;

            //x = x + 1;
            //Console.WriteLine(x);
            Example.Run();
            Checked.Run();

           
        }
    }
}
