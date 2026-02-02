using System;
using System.Text;
using System.Diagnostics;

namespace Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string msg = "Abhishek";
            String username = "Tracker";
            Console.WriteLine(msg);
            Console.WriteLine($"username is:'{username}'");
            Console.WriteLine();

            Console.WriteLine("length");
            Console.WriteLine(username.Length);
            Console.WriteLine();

            Console.WriteLine("indexing");
            Console.WriteLine($"username[0]:{username[0]}");
            Console.WriteLine($"username[1]:{username[1]}");
            Console.WriteLine($"username[6]:{username[6]}");
            Console.WriteLine();

            Console.WriteLine("all chars");
            for (int i = 0; i < username.Length; i++)
            {
                Console.WriteLine($"index{i}->{username[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("immutability");
            string org = "Hartford";
            string lorg = org.ToLower();
            string mod = lorg.Replace('h', 'Y');
            Console.WriteLine($"original string:{org}");
            Console.WriteLine($"modified string:{mod}");
            Console.WriteLine("no changes occured");
            Console.WriteLine();

            Console.WriteLine("STRING REPORT (WRONG WAY)");
            Console.WriteLine();

            string report = "";

            for (int i = 1; i <= 5; i++)
            {
                report += $"User logged in at step {i}\n";
            }

            Console.WriteLine(report);

            Console.WriteLine();
            Console.WriteLine("STRINGBUILDER REPORT (CORRECT WAY)");
            Console.WriteLine();

            StringBuilder sbReport = new StringBuilder();

            for (int i = 1; i <= 5; i++)
            {
                sbReport.Append($"User logged in at step {i}");
                sbReport.AppendLine();
            }

            string finalReport = sbReport.ToString();
            Console.WriteLine(finalReport);

            Console.WriteLine("PERFORMANCE COMPARISON");
            Console.WriteLine();

            int iterations = 100000;

            Stopwatch swString = new Stopwatch();
            swString.Start();

            string stringResult = "";
            for (int i = 0; i < iterations; i++)
            {
                stringResult += "A";
            }

            swString.Stop();
            Console.WriteLine($"String time      : {swString.ElapsedMilliseconds} ms");

            Stopwatch swBuilder = new Stopwatch();
            swBuilder.Start();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                sb.Append("A");
            }

            string builderResult = sb.ToString();

            swBuilder.Stop();
            Console.WriteLine($"StringBuilder time: {swBuilder.ElapsedMilliseconds} ms");
        }
    }
}
