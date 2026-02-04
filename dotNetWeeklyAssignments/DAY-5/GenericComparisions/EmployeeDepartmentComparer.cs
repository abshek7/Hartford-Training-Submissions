using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericComparisions
{
    public class EmployeeDepartmentComparer:IComparer<Employee>
    {

        public int Compare(Employee?x, Employee?y)
        {
            return x.Department.CompareTo(y.Department);
        }
    }
}
