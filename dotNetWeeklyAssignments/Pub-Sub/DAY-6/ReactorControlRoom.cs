using DAY_6;
using System;

namespace DAY_6
{
    public class ReactorControlRoom
    {
        public ReactorControlRoom(Reactor reactor)
        {
            reactor.ReactorAlert += HandleReactorAlert;
        }

        private void HandleReactorAlert(
            object sender,
            ReactorAlertEventArgs e)
        {
            Console.WriteLine(e.AlertMessage);
            Console.WriteLine("Current Pressure: " + e.CurrentPressure);
            Console.WriteLine("Emergency systems activated!");
        }
    }
}
