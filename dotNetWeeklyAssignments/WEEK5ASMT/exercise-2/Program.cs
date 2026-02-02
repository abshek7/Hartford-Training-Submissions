using System;

namespace exercise_2
{ 

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("first Circle details");
        Console.Write("Enter radius:");
        string radiusAInput = Console.ReadLine();
        double.TryParse(radiusAInput, out double radiusA);

        Console.Write("x-coord:");
        string xAInput = Console.ReadLine();
        double.TryParse(xAInput, out double centerAX);

        Console.Write("y-coord:");
        string yAInput = Console.ReadLine();
        double.TryParse(yAInput, out double centerAY);

        Console.WriteLine("second Circle details");
        Console.Write("Enter radius:");
        string radiusBInput = Console.ReadLine();
        double.TryParse(radiusBInput, out double radiusB);

        Console.Write("x-coord:");
        string xBInput = Console.ReadLine();
        double.TryParse(xBInput, out double centerBX);

        Console.Write("y-coord:");
        string yBInput = Console.ReadLine();
        double.TryParse(yBInput, out double centerBY);

        double distanceBetweenCenters = Math.Sqrt(
            Math.Pow(centerBX - centerAX, 2) +
            Math.Pow(centerBY - centerAY, 2)
        );

        Console.WriteLine();

        if (distanceBetweenCenters + radiusB <= radiusA)
            Console.WriteLine("B is in A");
        else if (distanceBetweenCenters + radiusA <= radiusB)
            Console.WriteLine("A is in B");
        else if (distanceBetweenCenters <= radiusA + radiusB)
            Console.WriteLine("A and B intersect");
        else
            Console.WriteLine("A and B do not intersect");

        Console.WriteLine();
    }
}
}
