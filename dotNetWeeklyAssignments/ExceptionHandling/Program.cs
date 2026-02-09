namespace ExceptionHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int x = 10;
            //int y = 0;

            //try
            //{
            //    int result = x / y;
            //    Console.WriteLine(result);
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("Program continues");
            try
            {
                string text = null;
                int length = text.Length;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NullReferenceException caught");
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception caught");
            }

            Console.WriteLine("End of Main");

        }
    }
}
