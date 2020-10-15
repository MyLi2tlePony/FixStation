using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class GenerateSituation
    {
        public event EventHandler<ShowEventsArgs> ShowMessage;

        public GenerateSituation(int numberOfWorkShops, int daysToFixTheCar, int numberOfDays, int dayForOneCar, int maxNumberOfCarsUnderTheRoof)
            : this(numberOfWorkShops, daysToFixTheCar, numberOfDays, dayForOneCar, maxNumberOfCarsUnderTheRoof, null)
        {

        }
        public GenerateSituation(int numberOfWorkShops, int daysToFixTheCar, int numberOfDays, int dayForOneCar, int maxNumberOfCarsUnderTheRoof, EventHandler<ShowEventsArgs> showMessage)
        {
            ShowMessage = showMessage;

            Station myStation = new Station(numberOfWorkShops, daysToFixTheCar, maxNumberOfCarsUnderTheRoof, ShowMessage);

            GenerateDays(myStation, numberOfDays, dayForOneCar);
        }

        private void GenerateDays(Station station, int numberOfDays, int dayForOneCar)
        {
            for (int currentDay = 1; currentDay <= numberOfDays; currentDay++)
            {
                Random random = new Random();

                Show("");
                Show($"день {currentDay}:");

                if (random.Next(0, 100) >= 100 / dayForOneCar)
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
                ShowMessage(this, new ShowEventsArgs(message));
            }
        }
    }
}
