using System;
using System.Collections.Generic;

namespace Requirement_6.Models
{
    public class Vehicle
    {
        // Private fields
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;

        // Public properties
        public string RegistrationNo
        {
            get => _registrationNo;
            set => _registrationNo = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public double Weight
        {
            get => _weight;
            set => _weight = value;
        }

        // Parameterless constructor
        public Vehicle()
        {
        }

        // Parameterized constructor
        public Vehicle(string registrationNo, string name, string type, double weight)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
        }

        public override string ToString()
        {
            return string.Format(
                "Registration No: {0}\nName: {1}\nType: {2}\nWeight: {3:F1}",
                _registrationNo,
                _name,
                _type,
                _weight
            );
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vehicle))
                return false;

            Vehicle other = (Vehicle)obj;

            return _registrationNo.ToLower() == other._registrationNo.ToLower()
                && _name.ToLower() == other._name.ToLower();
        }

        public override int GetHashCode()
        {
            return (_registrationNo + _name).ToLower().GetHashCode();
        }

        public static Vehicle CreateVehicle(string detail)
        {
            string[] vehicleDetails = detail.Split(",");

            return new Vehicle(
                vehicleDetails[0],
                vehicleDetails[1],
                vehicleDetails[2],
                double.Parse(vehicleDetails[3])
            );
        }

        // 🔹 IMPROVED: Normalize Type here so categories merge correctly
        public static SortedDictionary<string, int> TypeWiseCount(List<Vehicle> vehicleList)
        {
            SortedDictionary<string, int> typeWiseCount =
                new SortedDictionary<string, int>();

            foreach (Vehicle vehicle in vehicleList)
            {
                // Normalize type (NO Program.cs changes needed)
                string normalizedType = vehicle.Type
                    .Replace(" ", "")
                    .ToLower();

                if (typeWiseCount.ContainsKey(normalizedType))
                {
                    typeWiseCount[normalizedType]++;
                }
                else
                {
                    typeWiseCount.Add(normalizedType, 1);
                }
            }
            return typeWiseCount;
        }
    }
}
