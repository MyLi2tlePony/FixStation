using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class GenerateSituation
    {
        public event EventHandler<ShowMessageArgs> ShowMessage;

        public GenerateSituation(EventHandler<ShowMessageArgs> showMessage) : this(1, 3, 14, 2, 2, showMessage)
        {

        }
        public GenerateSituation() : this(1, 3, 14, 2, 2, null)
        {

        }
        public GenerateSituation(int numberOfWorkShops, int daysToFixTheCar, int numberOfDays, int dayForOneCar, int maxNumberOfCarsUnderTheRoof, EventHandler<ShowMessageArgs> showMessage)
        {
            ShowMessage = showMessage;

            Station myStation = new Station(numberOfWorkShops, daysToFixTheCar, maxNumberOfCarsUnderTheRoof);

            myStation.ShowMessage += ShowMessage;

            GenerateDays(myStation, numberOfDays, dayForOneCar);
        }

        private void GenerateDays(Station station, int numberOfDays, int dayForOneCar)
        {
            for (int currentDay = 1; currentDay <= numberOfDays; currentDay++)
            {
                Random random = new Random();

                Show("");
                Show($"день {currentDay}:");

                if (random.Next(0, 100) >= 100/dayForOneCar)
                {
                    station.AddCar(new Car(ShowMessage));

                    Show("машина приехала");
                }

                station.WorkDays();
            }
        }

        private void Show(string message)
        {
            if (ShowMessage != null)
            {
                ShowMessage(this, new ShowMessageArgs(message));
            }
        }
    }
}
