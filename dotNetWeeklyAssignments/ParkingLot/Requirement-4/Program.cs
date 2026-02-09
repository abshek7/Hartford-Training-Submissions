using System;
using System.Collections.Generic;
using Requirement_4;
namespace Requirement_4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Vehicle> vehicleList = new List<Vehicle>();

                Console.WriteLine("Enter the number of vehicles:");
                int count = int.Parse(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    string input = Console.ReadLine();
                    Vehicle vehicle = Vehicle.CreateVehicle(input);

                    if (vehicle != null)
                    {
                        vehicleList.Add(vehicle);
                    }
                }

                Console.WriteLine("Enter a search type:");
                Console.WriteLine("1.By type");
                Console.WriteLine("2.By parked time");

                int choice = int.Parse(Console.ReadLine());
                VehicleBO vehicleBO = new VehicleBO();
                List<Vehicle> result;

                if (choice == 1)
                {
                    Console.WriteLine("Enter the vehicle type");
                    string type = Console.ReadLine();
                    result = vehicleBO.FindVehicle(vehicleList, type);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the parked time:");
                    DateTime parkedTime = DateTime.ParseExact(
                        Console.ReadLine(),
                        "dd-MM-yyyy HH:mm:ss",
                        null
                    );

                    result = vehicleBO.FindVehicle(vehicleList, parkedTime);
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    return;
                }

                if (result.Count == 0)
                {
                    Console.WriteLine("No such vehicle is present");
                }
                else
                {
                    Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7} {4}",
                        "Registration No", "Name", "Type", "Weight", "Ticket No");

                    foreach (Vehicle vehicle in result)
                    {
                        Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}",
                            vehicle.RegistrationNo,
                            vehicle.Name,
                            vehicle.Type,
                            vehicle.Weight,
                            vehicle.Ticket.TicketNo);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
