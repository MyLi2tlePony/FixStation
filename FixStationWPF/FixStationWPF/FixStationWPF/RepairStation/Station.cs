using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class Station
    {
        private List<Car> QueueOfCarsUnderTheRoof;
        private List<Car> QueueOfCarsNearTheStation;
        private List<Workshop> Workshops;

        public event EventHandler<ShowEventsArgs> ShowMessage;

        public int MaxNumberOfCarsUnderTheRoof { get; private set; }
        public int ImproveStateOfCar { get; private set; }
        public int NumberOfWorkshop { get; private set; }

        public Station(int numberOfWorkshop, int daysToFixTheCar, int maxNumberOfCarsUnderTheRoof)
            : this(numberOfWorkshop, daysToFixTheCar, maxNumberOfCarsUnderTheRoof, null)
        {

        }
        public Station(int numberOfWorkshop, int daysToFixTheCar, int maxNumberOfCarsUnderTheRoof, EventHandler<ShowEventsArgs> showMessage)
        {
            QueueOfCarsUnderTheRoof = new List<Car>();
            QueueOfCarsNearTheStation = new List<Car>();
            Workshops = new List<Workshop>();

            ShowMessage += showMessage;
            NumberOfWorkshop = numberOfWorkshop;
            MaxNumberOfCarsUnderTheRoof = maxNumberOfCarsUnderTheRoof;
            ImproveStateOfCar = (Car.MaxStateOfCar - Car.MinStateOfCar) / daysToFixTheCar;

            BuildWorkshops(numberOfWorkshop);
        }

        private void BuildWorkshops(int numberOfWorkshop)
        {
            for (int currentWorkshops = 0; currentWorkshops < numberOfWorkshop; currentWorkshops++)
            {
                Workshops.Add(new Workshop(ImproveStateOfCar, ShowMessage));
            }
        }

        public void AddCar(Car car)
        {
            if (car != null)
            {
                if (QueueOfCarsUnderTheRoof.Count < MaxNumberOfCarsUnderTheRoof)
                {
                    QueueOfCarsUnderTheRoof.Add(car);
                }
                else
                {
                    QueueOfCarsNearTheStation.Add(car);
                }
            }
        }

        private Car GetCarFromQueueUnderTheRoof()
        {
            if (QueueOfCarsUnderTheRoof.Count > 0 && MaxNumberOfCarsUnderTheRoof > 0)
            {
                Car car = QueueOfCarsUnderTheRoof[0];

                QueueOfCarsUnderTheRoof.RemoveAt(0);

                if (QueueOfCarsNearTheStation.Count > 0)
                {
                    QueueOfCarsUnderTheRoof.Add(QueueOfCarsNearTheStation[0]);

                    QueueOfCarsNearTheStation.RemoveAt(0);
                }

                return car;
            }
            else if (QueueOfCarsNearTheStation.Count > 0)
            {
                Car car = QueueOfCarsNearTheStation[0];

                QueueOfCarsNearTheStation.RemoveAt(0);

                return car;
            }
            else
            {
                return null;
            }
        }

        public void WorkDays()
        {
            ShowAllQueue();

            for (int currentWorkshop = 0; currentWorkshop < Workshops.Count; currentWorkshop++)
            {
                Show($"Mастерская {currentWorkshop}:");

                WorkOfWorkshop(Workshops[currentWorkshop]);
            }
        }

        private void WorkOfWorkshop(Workshop workshop)
        {
            TryFillWorkshop(workshop);

            workshop.UpdateImprove();

            while (workshop.TodayImprove > 0 && workshop.Car != null)
            {
                workshop.ImproveCar();

                TryFillWorkshop(workshop);
            }
        }

        private void TryFillWorkshop(Workshop workshop)
        {
            if (workshop.Car == null)
            {
                workshop.Car = GetCarFromQueueUnderTheRoof();

                if (workshop.Car != null)
                {
                    Show("машина заехала");
                    ShowAllQueue();
                }
                else
                {
                    Show("мастерская простаивает");
                }
            }
        }

        private void ShowAllQueue()
        {
            Show($"машин в очереди под крышей {QueueOfCarsUnderTheRoof.Count}");
            Show(QueueOfCarsUnderTheRoof.Count);
            Show($"машин в очереди рядом со станцией {QueueOfCarsNearTheStation.Count}");
            Show(QueueOfCarsNearTheStation.Count);
        }

        private void Show(string message)
        {
            if (ShowMessage != null)
            {
                ShowMessage(this, new ShowEventsArgs(message));
            }
        }
        private void Show(int numberOfElement)
        {
            if (ShowMessage != null)
            {
                ShowMessage(this, new ShowEventsArgs(numberOfElement));
            }
        }
    }
}
