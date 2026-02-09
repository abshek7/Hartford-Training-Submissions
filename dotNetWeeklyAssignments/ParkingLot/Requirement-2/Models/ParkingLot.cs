using System;
using System.Collections.Generic;

namespace Requirement_2.Models
{
    public class ParkingLot
    {
        private string _name;
        private List<Vehicle> _vehicleList;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public ParkingLot()
        {
            _vehicleList = new List<Vehicle>();
        }

        public ParkingLot(string name)
        {
            _name = name;
            _vehicleList = new List<Vehicle>();
        }

        //This method accepts a vehicle object and adds vehicle to the vehicle list of the current ParkingLot
        public void AddVehicleToParkingLot(Vehicle vehicle)
        {
            try
            {
                if (vehicle == null)
                {
                    Console.WriteLine("Invalid vehicle.");
                    return;
                }

                _vehicleList.Add(vehicle);
                Console.WriteLine("Vehicle added successfully.");
            }
            catch
            {
                Console.WriteLine("Error while adding vehicle.");
            }
        }

        public bool RemoveVehicleFromParkingLot(string registrationNo)
        {
            for (int i = 0; i < _vehicleList.Count; i++)
            {
                // Search for the vehicle with the given registration number
                if (_vehicleList[i].RegistrationNo == registrationNo)
                {
                    // If vehicle is found, remove it from the list
                    _vehicleList.RemoveAt(i);
                    return true;
                }
            }
            // Return false if no matching vehicle is found
            return false;
        }

        // This method displays all the vehicles present in the current parking lot.
        // If no vehicles are available, it prints "No vehicles to show".
        // Otherwise, it displays the parking lot name followed by the vehicle details
        // in the specified tabular format.
        public void DisplayVehicles()
        {
            try
            {
                if (_vehicleList.Count == 0)
                {
                    Console.WriteLine("No vehicles to show");
                    return;
                }

                Console.WriteLine($"Vehicles in {_name}");
                Console.Write(
                    "{0,-15} {1,-10} {2,-12} {3,-7} {4}\n",
                    "Registration No",
                    "Name",
                    "Type",
                    "Weight",
                    "Ticket No"
                );

                foreach (Vehicle vehicle in _vehicleList)
                {
                    Console.Write(
                        "{0,-15} {1,-10} {2,-12} {3,-7:F1} {4}\n",
                        vehicle.RegistrationNo,
                        vehicle.Name,
                        vehicle.Type,
                        vehicle.Weight,
                        vehicle.Ticket.TicketNo
                    );
                }
            }
            catch
            {
                Console.WriteLine("Error while displaying vehicles.");
            }
        }
    }
}
