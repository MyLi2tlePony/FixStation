using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class Car
    {
        public event EventHandler<ShowEventsArgs> ShowMessage;

        public int StateOfCar { get; private set; }

        public static int MaxStateOfCar { get; } = 100;
        public static int MinStateOfCar { get; } = 0;

        public void ImproveTheStateOfCar(int improve, out int excessImprove)
        {
            Show("Машина:");
            Show($"начальное состояние: {StateOfCar}");

            if (improve + StateOfCar <= MaxStateOfCar)
            {
                excessImprove = 0;
            }
            else
            {
                excessImprove = StateOfCar + improve - MaxStateOfCar;
            }

            StateOfCar += improve - excessImprove;

            Show($"конечное состояние: {StateOfCar}");
            Show(StateOfCar, MaxStateOfCar);
        }

        public Car()
            : this(null)
        {

        }
        public Car(EventHandler<ShowEventsArgs> showMessage)
        {
            ShowMessage += showMessage;

            SetStateOfCar();
        }

        private void SetStateOfCar()
        {
            Random random = new Random();

            StateOfCar = random.Next(MinStateOfCar, MaxStateOfCar);
        }

        private void Show(string message)
        {
            if (ShowMessage != null)
            {
                ShowMessage(this, new ShowEventsArgs(message));
            }
        }
        private void Show(int currentState, int maxState)
        {
            if (ShowMessage != null)
            {
                ShowMessage(this, new ShowEventsArgs(currentState, maxState));
            }
        }
    }
}
