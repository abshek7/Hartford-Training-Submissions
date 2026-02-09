using Requirement_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement_5
{
    public class parkedTimeComparer:IComparer<Vehicle>
    {
        //sort the Vehicle list based on parkingTime
        public int Compare(Vehicle ?v1, Vehicle ?v2)
        {
            return v1.Ticket.ParkedTime.CompareTo(v2.Ticket.ParkedTime);
        }
    }
}
