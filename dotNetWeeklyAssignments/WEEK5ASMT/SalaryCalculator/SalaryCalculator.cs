namespace SalaryCalculator
{
    public class SalaryCalculation
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            double HRA = 0.20 * basicSalary;
            double DA = 0.10 * basicSalary;
            double PF = basicSalary < 15000 ? 0 : 0.12 * basicSalary;

            return basicSalary + HRA + DA - PF;
        }
    }
}