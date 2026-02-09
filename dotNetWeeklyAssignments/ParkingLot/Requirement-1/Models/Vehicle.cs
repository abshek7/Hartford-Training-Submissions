using System;

namespace Requirement_1.Models
{
    public class Vehicle
    {
        // Private fields
        private string _registrationNo;
        private string _name;
        private string _type;
        private double _weight;
        private Ticket _ticket;

        // Public properties
        public string RegistrationNo
        {
            get => _registrationNo; 
            set => _registrationNo = value ;
        }

        public string Name
        {
            get => _name; 
            set =>_name = value; 
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
        // This overridden Equals method provides custom comparison logic for Vehicle objects.
        // Instead of checking whether two references point to the same object (default behavior),
        // it compares the actual data of the objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Vehicle))
                return false;

            Vehicle other = (Vehicle)obj;


            // Two Vehicle objects are considered equal if their Registration Number and Name
            // are the same, ignoring case differences.
            return _registrationNo.ToLower() == other._registrationNo.ToLower()
                && _name.ToLower() == other._name.ToLower();
        }

        //for hashing things
        public override int GetHashCode()
        {
            return (_registrationNo + _name).ToLower().GetHashCode();
        }
    }
}
