using DAY_6;

namespace DAY_6
{
    class Program
    {
        static void Main()
        {
            Reactor nuclearReactor = new Reactor();
            ReactorControlRoom controlRoom =
                new ReactorControlRoom(nuclearReactor);

            Console.WriteLine("Setting pressure to 300");
            nuclearReactor.Pressure = 300;

            Console.WriteLine("Setting pressure to 600");
            nuclearReactor.Pressure = 600;

            Console.ReadLine();
        }
    }
}
