using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_4
{
    public class Ticket
    {
        // Private fields
        private string _ticketNo;
        private DateTime _parkedTime;
        private double _cost;

        // Properties (arrow functions)
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

        // Default constructor
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
    }
}
