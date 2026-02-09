using System;

namespace DAY_6
{
    public class ReactorAlertEventArgs : EventArgs
    {
        public string AlertMessage { get; }
        public int CurrentPressure { get; }

        public ReactorAlertEventArgs(string message, int pressure)
        {
            AlertMessage = message;
            CurrentPressure = pressure;
        }
    }
}
