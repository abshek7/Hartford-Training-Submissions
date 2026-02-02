 
namespace ConsoleApp1
{
    public class Checked
    { public static void Run()
        {

            // here it switches on overflow checking
            // throwing exception
            checked
            {
                int x = int.MaxValue;
                x = x + 1;   // overflow detected
            }

        }

    }
}
