//using System;
//namespace BasicDelegate
//{
//    class Program
//{
//    // STEP 1: Declare delegate
//    delegate void MyDelegate();

//    static void Main()
//    {
//        // STEP 2: Assign method to delegate
//        MyDelegate d = SayHello;

//        // STEP 3: Invoke delegate
//        d();
//    }


//    static void SayHello()
//    {
//        Console.WriteLine("Hello!");
//    }
//}

//}

//using System;

//class Program
//{
//    delegate int Operation(int a, int b);

//    static void Main()
//    {
//        Operation op = Add;      
//        Console.WriteLine(op(4, 5));  

//        op = Multiply;         
//        Console.WriteLine(op(4, 5));
//    }

//    static int Add(int x, int y) => x + y;
//    static int Multiply(int x, int y) => x * y;
//}

//using System;

//class Program
//{
//    delegate void TaskDelegate();

//    static void Main()
//    {
//        ExecuteTask(WorkA);  
//        ExecuteTask(WorkB);
//    }

//    static void ExecuteTask(TaskDelegate task)
//    {
//        task();             
//    }

//    static void WorkA() => Console.WriteLine("Doing Work A");
//    static void WorkB() => Console.WriteLine("Doing Work B");
//}

using System;

class Program
{
    delegate void Notify();

    static void Main()
    {
        Notify n = First;    
        n += Second;
        n += Third;

        n();                 
    }

    static void First() => Console.WriteLine("First");
    static void Second() => Console.WriteLine("Second");
    static void Third() => Console.WriteLine("Third");
}








