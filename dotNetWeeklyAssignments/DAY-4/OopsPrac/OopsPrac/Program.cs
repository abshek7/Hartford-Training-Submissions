//namespace OopsPrac
//{
//    public class Program
//    {


//        static void Main(string[] args)
//        {
          
//            Emp e=new Emp();
//            e.EmpId = 7;
//            Console.WriteLine(e.EmpId);
//        }
//    }
//}

using System;


namespace OopsPrac
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            

            Console.Write("Enter Roll No: ");
            student.RollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Course: ");
            student.Course = Console.ReadLine();

            Console.Write("Enter Marks: ");
            student.Marks = Convert.ToDouble(Console.ReadLine());


            //Console.WriteLine(student);
            //Console.WriteLine(student.ToString());
            Console.WriteLine(student.ToString());


            try
            {
                student.HasPassed();
                Console.WriteLine("Student Passed");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }
    }
}
