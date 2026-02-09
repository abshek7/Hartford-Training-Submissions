using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    public class VehicleBO
    {
        // method to find vehicles by type
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle vehicle in vehicleList)
            {
                if (vehicle.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(vehicle);
                }
            }

            return result;
        }

        //method to find vehicles by parked time
        //method to find vehicles by parked time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (Vehicle vehicle in vehicleList)
            {
                if (vehicle.Ticket.ParkedTime == parkedTime)
                {
                    result.Add(vehicle);
                }
            }

            return result;
        }
    }
}
