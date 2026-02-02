using System;

namespace exercise_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the following details:\n");

            Console.Write("Customer ID: ");
            string customerId = Console.ReadLine();

            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Connection Type (Industrial/Business/Domestic/Agricultural): ");
            string connectionType = Console.ReadLine();

            Console.Write("Previous Reading: ");
            int.TryParse(Console.ReadLine(), out int prevReading);

            Console.Write("Current Reading: ");
            int.TryParse(Console.ReadLine(), out int currReading);

            int unitsConsumed = currReading - prevReading;
            double energyCharge = CalculateBill(unitsConsumed);
            double meterRent = GetMeterRent(connectionType);
            double totalAmount = energyCharge + meterRent;

            Console.WriteLine("\nElectricity Bill");
            Console.WriteLine($"Customer ID      : {customerId}");
            Console.WriteLine($"Customer Name    : {customerName}");
            Console.WriteLine($"Address          : {address}");
            Console.WriteLine($"Phone Number     : {phone}");
            Console.WriteLine($"Email ID         : {email}");
            Console.WriteLine($"Connection Type  : {connectionType}");
            Console.WriteLine($"Previous Reading : {prevReading}");
            Console.WriteLine($"Current Reading  : {currReading}");
            Console.WriteLine($"Units Consumed   : {unitsConsumed}");
            Console.WriteLine($"Energy Charges   : Rs. {energyCharge}");
            Console.WriteLine($"Meter Rent       : Rs. {meterRent}");
            Console.WriteLine($"Total Amount     : Rs. {totalAmount}");
        }

        static double CalculateBill(int units)
        {
            if (units <= 100)
                return units * 1.5;
            else if (units <= 250)
                return (100 * 1.5) + ((units - 100) * 2.5);
            else if (units <= 550)
                return (100 * 1.5) + (150 * 2.5) + ((units - 250) * 4.5);
            else
                return (100 * 1.5) + (150 * 2.5) + (300 * 4.5) + ((units - 550) * 7.5);
        }

        static double GetMeterRent(string type)
        {
            switch (type.ToLower())
            {
                case "industrial": return 2500;
                case "business": return 1500;
                case "domestic": return 1000;
                case "agricultural": return 0;
                default: return 0;
            }
        }
    }
}
