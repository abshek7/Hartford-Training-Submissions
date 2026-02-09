using System;

namespace Requirement_5.Models
{
    public class Ticket
    {
        // Private fields
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        // Public properties (arrow functions)
        public string TicketNo
        {
            get => _ticketNo;
            set => _ticketNo = value;
        }

        public DateTime ParkedTime
        {
            get => _parkedTime;
            set => _parkedTime = value;
        }

        public double Cost
        {
            get => _cost;
            set => _cost = value;
        }

        // Default (parameterless) constructor
        public Ticket()
        {
        }

        // Parameterized constructor
        public Ticket(string ticketNo, DateTime parkedTime, double cost)
        {
            _ticketNo = ticketNo;
            _parkedTime = parkedTime;
            _cost = cost;
        }

        // Override ToString for formatted output
        public override string ToString()
        {
            return string.Format(
                "Ticket No: {0}\nParked Time: {1}\nCost: {2}",
                TicketNo,
                ParkedTime,
                Cost
            );
        }
    }
}
