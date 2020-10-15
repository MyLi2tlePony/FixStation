using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class Car
    {
        public event EventHandler<ShowMessageArgs> ShowMessage;

        public int StateOfCar { get; private set; }

        public static int MaxStateOfCar { get;} = 100;
        public static int MinStateOfCar { get;} = 0;
        
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
        }

        public Car():this(null)
        {
            
        }
        public Car(EventHandler<ShowMessageArgs> showMessage)
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
            if(ShowMessage != null)
            {
                ShowMessage(this, new ShowMessageArgs(message));
            }
        }
    }
}
