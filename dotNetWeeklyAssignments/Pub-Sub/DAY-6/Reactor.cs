using System;

namespace DAY_6
{
    public class Reactor
    {
        private int pressure;

        public delegate void ReactorAlertHandler(
            object sender,
            ReactorAlertEventArgs e);

        public event ReactorAlertHandler ReactorAlert;

        public int Pressure
        {
            get { return pressure; }
            set
            {
                pressure = value;
                if (pressure > 500)
                {
                    OnReactorAlert(pressure);
                }
            }
        }

        protected virtual void OnReactorAlert(int pressure)
        {
            ReactorAlertEventArgs args =
                new ReactorAlertEventArgs(
                    " Reactor pressure critical!",
                    pressure);

            ReactorAlert?.Invoke(this, args);
        }
    }
}
