using System;

namespace OopsPrac
{
    public class Student
    {
        private int _rollNo;
        private string _name;
        private string _course;
        private double _marks;

        public int RollNo
        {
            get { return _rollNo; }
            set { _rollNo = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }

        public double Marks
        {
            get { return _marks; }
            set { _marks = value; }
        }

        public Student()
        {
            _rollNo = 0;
            _name = "";
            _course = "";
            _marks = 0;
        }

        public Student(int rollNo, string name)
        {
            _rollNo = rollNo;
            _name = name;
        }

        public Student(int rollNo, string name, string course, double marks)
        {
            _rollNo = rollNo;
            _name = name;
            _course = course;
            _marks = marks;
        }

        public bool HasPassed()
        {
            return _marks > 40;
        }

        public void CheckResult()
        {
            if (!HasPassed())
            {
                throw new ApplicationException("Student has not passed the examination");
            }
        }

        public string GetStudentInfo()
        {
            return _rollNo + "-" + _name;
        }

        public override string ToString()
        {
            return "RollNo: " + _rollNo +
                   ", Name: " + _name +
                   ", Course: " + _course +
                   ", Marks: " + _marks;
        }
    }
}
