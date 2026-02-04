using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericComparisions
{
    public class Employee:IComparable<Employee> 
    {
        private int _id;
        private string _name;
        private string _department;
        private double _salary;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        { 
            get { return _name; } 
            set {_name = value; } 
        }

        public string Department
        {
            get { return _department; }
            set {_department = value; }
        }
        public double Salary
        { get { return _salary; }
        set {_salary = value; } }

        public int CompareTo(Employee? other)
        {
            if(other is null)
                return 1;

            return this._id.CompareTo(other._id);
        }
        //public override string ToString()
        //{
        //    return string.Format(
        //        "Id: {0,-3} | Name: {1,-10} | Dept: {2,-10} | Salary: {3,10:C}",
        //        Id,
        //        Name,
        //        Department,
        //        Salary
        //    );
        //}
        public override string ToString()
        {
            return string.Format(
                "{0} | {1} | {2} | {3}",
                Name,
                Id,
                Department,
                Salary
            );
        }

    }
}
