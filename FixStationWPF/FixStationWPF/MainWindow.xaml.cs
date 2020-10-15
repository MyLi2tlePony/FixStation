using System; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using RepairStation;

namespace FixStationWPF
{
    public partial class MainWindow : Window
    {
        private int numberOfWorkShops;
        private int daysToFixTheCar;
        private int numberOfDays;
        private int dayForOneCar;
        private int maxNumberOfCarsUnderTheRoof;

        //private TextBox getAnsver = new TextBox();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBegin_Click(object sender, RoutedEventArgs e)
        {
            MainListBox.Items.Clear();

            try
            {
                SelectionChanged();
            }
            catch
            {
                numberOfWorkShops = 1;
                daysToFixTheCar = 3;
                numberOfDays = 14;
                dayForOneCar = 2;
                maxNumberOfCarsUnderTheRoof = 2;
            }

            GenerateSituation exsersiseOne = new GenerateSituation
                (numberOfWorkShops, daysToFixTheCar, numberOfDays, dayForOneCar, maxNumberOfCarsUnderTheRoof, ShowMessage);
        }

        //Выводит ответ
        private void ShowMessage(object sender, ShowEventsArgs message)
        {
            if (message.Message != "")
            {
                
            }

            if(message.canvas != null)
            {
                MainListBox.Items.Add(message.canvas);

                var getAnsver = new TextBox();
                getAnsver.Background = Brushes.Transparent;
                getAnsver.BorderBrush = Brushes.Transparent;
                getAnsver.FontSize = 24;
                getAnsver.Text += "\n";
                MainListBox.Items.Add(getAnsver);
            }       
            else
            {
                var getAnsver = new TextBox();
                getAnsver.Background = Brushes.Transparent;
                getAnsver.BorderBrush = Brushes.Transparent;
                getAnsver.FontSize = 24;
                getAnsver.Text += message.Message;
                getAnsver.Text += "\n";
                MainListBox.Items.Add(getAnsver);
            }
        }

        //Закрывает окно
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Разворачивает окно
        private void StateChange_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
            }
        }

        //Сворачивает окно
        private void WindowMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Передвигает окно
        private void TopWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Получает значения из настроек
        private void SelectionChanged()
        {
            numberOfWorkShops = Convert.ToInt32(NumberOfWorkShops.Text);
            daysToFixTheCar = Convert.ToInt32(DaysToFixTheCar.Text);
            numberOfDays = Convert.ToInt32(NumberOfDays.Text);
            dayForOneCar = Convert.ToInt32(DayForOneCar.Text);
            maxNumberOfCarsUnderTheRoof = Convert.ToInt32(MaxNumberOfCarsUnderTheRoof.Text);
        }
    }
}
