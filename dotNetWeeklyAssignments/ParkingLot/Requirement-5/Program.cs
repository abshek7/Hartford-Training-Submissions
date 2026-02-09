using System;
using System.Collections.Generic;

namespace Requirement_5.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Vehicle> vehicleList = new List<Vehicle>();

                // Read number of vehicles
                Console.Write("Enter the number of vehicles: ");
                int.TryParse(Console.ReadLine(), out int n);

                // Read vehicle details
                Console.WriteLine("\nEnter Vehicle Details:");
                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    Vehicle v = Vehicle.CreateVehicle(input);
                    vehicleList.Add(v);
                }

                // Sort menu
                Console.WriteLine("\nEnter a type to sort:");
                Console.WriteLine("1.Sort by weight");
                Console.WriteLine("2.Sort by parked time");

                int.TryParse(Console.ReadLine(), out int choice);

                // Sort by weight
                if (choice == 1)
                {
                    vehicleList.Sort();
                }
                // Sort by parked time
                else if (choice == 2)
                {
                    vehicleList.Sort(new parkedTimeComparer());
                }

                // Display result
                Console.WriteLine(
                    "\n{0,-20} {1,-10} {2,-12} {3,-7} {4}",
                    "Registration No", "Name", "Type", "Weight", "Ticket No"
                );

                foreach (Vehicle v in vehicleList)
                {
                    Console.WriteLine(
                        "{0,-20} {1,-10} {2,-12} {3,-7:F1} {4}",
                        v.RegistrationNo,
                        v.Name,
                        v.Type,
                        v.Weight,
                        v.Ticket.TicketNo
                    );
                }
            }
            // Invalid inputs
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please check numeric and date values.");
            }
            // Null or empty arguments
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Some other Exceptions
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occurred.");
            }
        }
    }
}
