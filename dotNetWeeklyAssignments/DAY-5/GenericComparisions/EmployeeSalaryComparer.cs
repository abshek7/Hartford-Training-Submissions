using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GenericComparisions
{
    public class EmployeeSalaryComparer:IComparer<Employee>
    {
        public int Compare(Employee?x, Employee?y) { 
            return x.Salary.CompareTo(y.Salary);
        }
    }
}
