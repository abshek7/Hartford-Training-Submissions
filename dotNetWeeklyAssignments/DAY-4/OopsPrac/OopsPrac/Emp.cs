using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsPrac
{
    public class Emp
    {
        private int empId;
        private string empName;
        public int EmpId {
            get {return empId; }
            set {  empId = value; } 
        }
         

       
        public string EmpName { get; set; }
        public Emp()
        {

        }


    }
}
