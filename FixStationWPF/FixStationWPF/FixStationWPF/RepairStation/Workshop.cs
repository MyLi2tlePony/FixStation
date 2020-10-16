using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class Workshop
    {
        public int ImproveStateOfCar { get; private set; }
        public int TodayImprove { get; private set; }

        public event EventHandler<ShowEventsArgs> ShowMessage;

        public Car Car { get; set; }

        public Workshop(int improveStateOfCar)
            : this(improveStateOfCar, null)
        {

        }
        public Workshop(int improveStateOfCar, EventHandler<ShowEventsArgs> showMessage)
        {
            Car = null;
            ShowMessage += showMessage;
            ImproveStateOfCar = improveStateOfCar;
            TodayImprove = 0;
        }

        public void UpdateImprove()
        {
            TodayImprove = ImproveStateOfCar;
        }

        public void ImproveCar()
        {
            if (Car != null)
            {
                Car.ImproveTheStateOfCar(TodayImprove, out int todayImprove);

                TodayImprove = todayImprove;

                ClearWorkshop();
            }
        }

        private void ClearWorkshop()
        {
            if (Car.StateOfCar == Car.MaxStateOfCar)
            {
                Car = null;

                Show("машина уехала");
            }
        }

        private void Show(string message)
        {
            if (ShowMessage != null)
            {
                ShowMessage(this, new ShowEventsArgs(message));
            }
        }
    }
}
