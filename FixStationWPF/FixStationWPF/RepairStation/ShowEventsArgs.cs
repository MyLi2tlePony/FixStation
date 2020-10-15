using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RepairStation
{
    class ShowEventsArgs : EventArgs
    {
        public string Message { get; private set; }
        public Canvas canvas;

        public ShowEventsArgs(string message)
        {
            Message = message;
        }
        public ShowEventsArgs(int numberOfElement)
        {
            ShowQueue(numberOfElement);
        }
        public ShowEventsArgs(int currentState, int maxState)
        {
            ShowCanvas(currentState, maxState);
        }

        private void ShowQueue(int numberOfElement)
        {
            canvas = new Canvas();

            for (int currentElement = 0, currentPointOnLeft = 0, currentHeight = 50, currentWidth = 100; 
                currentElement < numberOfElement; 
                currentPointOnLeft += currentWidth + 20, currentElement++)
            {
                Canvas currentCanvas = new Canvas();
                Rectangle myRect = new Rectangle();

                myRect.Stroke = Brushes.Black;
                myRect.Fill = Brushes.Black;
                myRect.VerticalAlignment = VerticalAlignment.Top;

                myRect.Height = currentHeight;
                myRect.Width = currentWidth;

                currentCanvas.Children.Add(myRect);
                Canvas.SetLeft(currentCanvas, currentPointOnLeft);
                canvas.Children.Add(currentCanvas);
            }
        }
        private void ShowCanvas(int currentState, int maxState)
        {
            canvas = new Canvas();
            Rectangle myRect = new Rectangle();
            
            int currentHeight = 50, 
                currentWidth = 100;

            myRect.Height = currentHeight;
            myRect.Width = currentWidth;
            myRect.VerticalAlignment = VerticalAlignment.Top;

            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();

            myLinearGradientBrush.StartPoint = new Point(0, 0.5);
            myLinearGradientBrush.EndPoint = new Point(1, 0.5);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.LimeGreen, (double)currentState/100));

            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.Red, (double)maxState /100));

            myRect.Stroke = Brushes.Black;
            myRect.Fill = myLinearGradientBrush;

            canvas.Children.Add(myRect);
        }
    }
}
