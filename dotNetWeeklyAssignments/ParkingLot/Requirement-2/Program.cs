using System;
using Requirement_2.Models;

namespace Requirement_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the name of the Parking Lot:");
                string name = Console.ReadLine();

                ParkingLot parkingLot = new ParkingLot(name);

                while (true)
                {
                    Console.WriteLine("1.Add Vehicle");
                    Console.WriteLine("2.Delete Vehicle");
                    Console.WriteLine("3.Display Vehicles");
                    Console.WriteLine("4.Exit");
                    Console.WriteLine("Enter your choice:");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            string detail = Console.ReadLine();
                            Vehicle vehicle = Vehicle.CreateVehicle(detail);
                            parkingLot.AddVehicleToParkingLot(vehicle);
                            break;

                        case 2:
                            Console.WriteLine("Enter the registration number of the vehicle to be deleted:");
                            string regNo = Console.ReadLine();

                            bool removed = parkingLot.RemoveVehicleFromParkingLot(regNo);
                            if (removed)
                                Console.WriteLine("Vehicle successfully deleted");
                            else
                                Console.WriteLine("Vehicle not found in parkinglot");
                            break;

                        case 3:
                            parkingLot.DisplayVehicles();
                            break;

                        case 4:
                            return;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occurred.");
            }
        }
    }
}
