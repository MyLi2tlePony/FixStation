using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class Workshop
    {
        public int ImproveStateOfCar { get; private set; }
        public int TodayImprove { get; private set; }

        public Car Car { get; set; } = null;

        public Workshop(int improveStateOfCar)
        {
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
            }
        }
    }
}
