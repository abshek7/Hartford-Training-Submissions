namespace DAY_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int a = 15;
            //int b = a;
            //b = 30;
            //Console.WriteLine(b);
            //Console.WriteLine(a);
            //int a = 10;
            //int b = 5;

            int[] prices = { 100, 200, 300 };
            int discount = 10; // 10%

            int total = CalculateTotal(prices, discount);
            Console.WriteLine("Final Amount: " + total);


            //int sum = Add(a, b);
            //Console.WriteLine(sum);
            //static int Add(int x, int y)
            //{
            //    int result = x + y;
            //    return result;
            //}
            static int CalculateTotal(int[] prices, int discount)
            {
                int sum = 0;
                for (int i = 0; i < prices.Length; i++)
                {   // to check working of breakpoint written a logical error
                    sum = prices[i];
                }
                int discountedAmt = sum - (sum * discount / 100);
                return discountedAmt;


            }
        }
    }

}