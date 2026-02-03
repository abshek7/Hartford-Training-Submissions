*If you do NOT write any constructor, C# automatically creates a default constructor for you.*



*If you write at least one constructor, C# does NOT create the default one.*



*You can have multiple constructors, but the compiler-generated default constructor and your own constructor cannot exist at the same time.*



*Initialization and for poco:*

*fields and properties*

*zero arguments constructor*

*parameterized constructors*

*ToString() override*

*methods but no business logics*











*ToString() in C# – Quick Note*



*Every class in C# inherits from System.Object.*



*Object.ToString() is a virtual method.*



*The default ToString() returns Namespace + ClassName.*



*Example default output: OopsPrac.Student*



*Using override, we replace the default behavior.*



*Overriding ToString() lets us return meaningful object data.*



*Console.WriteLine(object) automatically calls ToString().*



*Method resolution happens at runtime (polymorphism).*



*One line to remember:*



*Override ToString() to control how an object is represented as text.*







*Runtime polymorphism::*



*Where Runtime Polymorphism Comes From Here*



*Even though your Student class does not explicitly inherit from anything, it implicitly inherits from System.Object.*



*So your class is actually:*



*public class Student : Object*

*{*

*}*



*Case 1: ToString() is COMMENTED (your current code)*

*Student s = new Student();*

*Console.WriteLine(s.ToString());*





*or*



*Object obj = new Student();*

*Console.WriteLine(obj.ToString());*



*What happens at runtime?*



*CLR looks for ToString() in Student*



*It does not find an override*



*So it executes Object.ToString()*



*Output:*

*OopsPrac.Student*





*No runtime polymorphism happens inside your class, because there is no overridden method.*



*Case 2: ToString() is OVERRIDDEN (when you uncomment it)*

*public override string ToString()*

*{*

    *return "RollNo: " + \_rollNo +*

           *", Name: " + \_name +*

           *", Course: " + \_course +*

           *", Marks: " + \_marks;*

*}*





*Now run:*



*Object obj = new Student(101, "Amit", "CS", 78);*

*Console.WriteLine(obj.ToString());*



*What happens at runtime?*



*Reference type: Object*



*Actual object type: Student*



*CLR checks method table at runtime*



*Finds Student.ToString() override*



*Calls Student’s version, not Object’s*



*Output:*

*RollNo: 101, Name: Amit, Course: CS, Marks: 78*





*This is runtime polymorphism.






Then Why Override ToString() Specifically?*



*Because .NET automatically uses ToString() in many places.*



*Example 1: Console.WriteLine(object)*

*Console.WriteLine(student);*





*Internally, .NET does:*



*Console.WriteLine(student.ToString());*





*If you don’t override:*



*OopsPrac.Student*





*If you override:*



*RollNo: 1, Name: Amit, Course: CS, Marks: 78*



*Example 2: Debugging \& Logging*

*var student = new Student();*

*Console.WriteLine(student);*

*logger.Log(student);*





*Frameworks, debuggers, and loggers all call ToString() automatically.*



*Example 3: Collections*

*List<Student> students = new List<Student>();*

*Console.WriteLine(students\[0]);*





*Again → ToString() is called.*

