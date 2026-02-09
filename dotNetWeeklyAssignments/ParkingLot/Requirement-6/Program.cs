using System;
using System.Collections.Generic;
using Requirement_6.Models;

namespace Requirement_6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vehicles:");
            int n = Convert.ToInt32(Console.ReadLine());

            List<Vehicle> vehicleList = new List<Vehicle>();

            try
            {
                // Read vehicle details and create Vehicle objects
                for (int i = 0; i < n; i++)
                {
                    string info = Console.ReadLine();
                    Vehicle vehicle = Vehicle.CreateVehicle(info);
                    vehicleList.Add(vehicle);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid vehicle input.");
                return;
            }

            // Call TypeWiseCount to get count of vehicles by type
            SortedDictionary<string, int> vehicles =
                Vehicle.TypeWiseCount(vehicleList);

            Console.WriteLine("\nType\t\tNo. of Vehicles");

            // Display result
            foreach (KeyValuePair<string, int> vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Key + "\t\t" + vehicle.Value);
            }
        }
    }
}
