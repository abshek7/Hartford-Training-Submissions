using System;
using System.Collections.Generic;

namespace GenericComparisions
{
    class Program
    {
        static void Main()
        {
            Employee e1 = new Employee { Id = 1, Name = "Abhi", Department = "IT", Salary = 60000 };
            List<Employee> emp = new List<Employee>
            {
                new Employee { Id = 3, Name = "Santhu",  Department = "HR",      Salary = 45000 },
                e1,
                new Employee { Id = 2, Name = "Bantu", Department = "Finance", Salary = 52000 }
            };

            Console.WriteLine("Choose sorting option:");
            Console.WriteLine("1. Sort by Id (Default)");
            Console.WriteLine("2. Sort by Name");
            Console.WriteLine("3. Sort by Department");
            Console.WriteLine("4. Sort by Salary");
            Console.WriteLine("5. Sort by Salary in descending");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }

            switch (choice)
            {
                case 1:
                    emp.Sort();
                    break;

                case 2:
                    emp.Sort(new EmployeeNameComparer());
                    break;

                case 3:
                    emp.Sort(new EmployeeDepartmentComparer());
                    break;

                case 4:
                    emp.Sort(new EmployeeSalaryComparer());
                    break;
                case 5:
                    emp.Sort(new EmployeeSalaryDescComparer());
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            Console.WriteLine("\nSorted Employee List:");
            //foreach (Employee e in emp)
            //{
            //    Console.WriteLine($"{e.Name} || {e.Id} || {e.Department}");   
            //}
            foreach (Employee e in emp)
            {
                Console.WriteLine(e);   
            }

        }
    }
}
