using System;

namespace Requirement_5.Models
{
    public class Vehicle : IComparable<Vehicle>
    {
        // Private fields
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        // Public properties (arrow functions)
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

        // Parameterless constructor
        public Vehicle()
        {
        }

        // Parameterized constructor
        public Vehicle(
            string registrationNo,
            string name,
            string type,
            double weight,
            Ticket ticket)
        {
            _registrationNo = registrationNo;
            _name = name;
            _type = type;
            _weight = weight;
            _ticket = ticket;
        }

        // Override ToString for formatted output
        public override string ToString()
        {
            return string.Format(
                "Registration No: {0}\nName: {1}\nType: {2}\nWeight: {3:F1}\nTicket No: {4}",
                _registrationNo,
                _name,
                _type,
                _weight,
                _ticket.TicketNo
            );
        }

        // Custom equality logic for Vehicle objects
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vehicle))
                return false;

            Vehicle other = (Vehicle)obj;

            return _registrationNo.ToLower() == other._registrationNo.ToLower()
                && _name.ToLower() == other._name.ToLower();
        }

        // for hashing things
        public override int GetHashCode()
        {
            return (_registrationNo + _name).ToLower().GetHashCode();
        }

        // IComparable interface implementation
        public int CompareTo(Vehicle? other)
        {
            if (other == null)
                return 1;

            return this.Weight.CompareTo(other.Weight);
        }

        // This method accepts a comma-separated string, creates a Vehicle object and returns it
        public static Vehicle CreateVehicle(string detail)
        {
            // Split the input string
            string[] data = detail.Split(',');

            // Vehicle details
            string registrationNo = data[0];
            string name = data[1];
            string type = data[2];
            double weight = double.Parse(data[3]);

            // Ticket details
            string ticketNo = data[4];
            DateTime parkedTime = DateTime.Parse(data[5]);
            double cost = double.Parse(data[6]);

            // Create Ticket object
            Ticket ticket = new Ticket(ticketNo, parkedTime, cost);

            // Create and return Vehicle object
            return new Vehicle(registrationNo, name, type, weight, ticket);
        }
    }
}
