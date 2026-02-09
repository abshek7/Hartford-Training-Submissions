using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    public class Vehicle
    {
        // Private fields
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        // Properties
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

        public Ticket Ticket
        {
            get => _ticket;
            set => _ticket = value;
        }

        // Default constructor
        public Vehicle()
        {
        }

        // Parameterized constructor
        public Vehicle(string registrationNo, string name, string type, double weight, Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        // Static method to create Vehicle object from CSV input
        public static Vehicle CreateVehicle(string detail)
        {
            try
            {
                string[] values = detail.Split(',');

                DateTime parkedTime = DateTime.ParseExact(
                    values[5],
                    "dd-MM-yyyy HH:mm:ss",
                    null
                );

                Ticket ticket = new Ticket(
                    values[4],
                    parkedTime,
                    double.Parse(values[6])
                );

                return new Vehicle(
                    values[0],
                    values[1],
                    values[2],
                    double.Parse(values[3]),
                    ticket
                );
            }
            catch (Exception)
            {
                // Return null if input format is invalid
                return null;
            }
        }
    }
}
