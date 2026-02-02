using System;
using SalaryCalculator;
namespace exercise_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Net Salary Calculation\n");
            Console.Write("Enter Basic Salary: ");
            string s = Console.ReadLine();
            double.TryParse(s, out double sal);
            // Use the correct namespace or class reference for SalaryCalculator
            double effective=SalaryCalculation.CalculateNetSalary(sal);
            Console.WriteLine(effective);   
            
             
        }
    }
}
