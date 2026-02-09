using Requirement_1.Models;

namespace Requirement_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Handle runtime errors to prevent the program from crashing
            try
            {
                // take input details for v1
                Console.Write("Enter Vechile 1 details : ");
                string v1 = Console.ReadLine();

                // take input details for the v2
                Console.Write("Enter Vechile 2 details : ");
                string v2 = Console.ReadLine();

                // Break the comma-separated input into individual values
                string[] v1Array = v1.Split(",");
                string[] v2Array = v2.Split(",");

                // Validate that all required data fields are provided
                if (v1Array.Length != 7 || v2Array.Length != 7)
                {
                    throw new Exception();
                }

                // Create Ticket objects using input values
                Ticket ticket1 = new Ticket(
                    v1Array[4],
                    Convert.ToDateTime(v1Array[5]),
                    Convert.ToDouble(v1Array[6])
                );

                Ticket ticket2 = new Ticket(
                    v2Array[4],
                    Convert.ToDateTime(v2Array[5]),
                    Convert.ToDouble(v2Array[6])
                );

                // Display details of the first vehicle
                Console.WriteLine("\nVehicle 1\n");
                Vehicle vehicle1 = new Vehicle(
                    v1Array[0],
                    v1Array[1],
                    v1Array[2],
                    Convert.ToDouble(v1Array[3]),
                    ticket1
                );
                Console.WriteLine(vehicle1);

                // Display details of the second vehicle
                Console.WriteLine("\nVehicle 2\n");
                Vehicle vehicle2 = new Vehicle(
                    v2Array[0],
                    v2Array[1],
                    v2Array[2],
                    Convert.ToDouble(v2Array[3]),
                    ticket2
                );
                Console.WriteLine(vehicle2);

                // Check whether both vehicle objects represent the same vehicle
                if (vehicle1.Equals(vehicle2))
                {
                    Console.WriteLine("\nVehicle 1 is same as Vehicle 2");
                }
                else
                {
                    Console.WriteLine("\nVehicle 1 and Vehicle 2 are different");
                }
            }
            catch (FormatException)
            {
                // Executes when numeric or date values are entered incorrectly
                Console.WriteLine("Invalid input format. Please enter the details in the correct format.");
            }
            catch (Exception ex)
            {
                // Handles missing data or any unexpected error
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
