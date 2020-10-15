using System;

namespace RepairStation
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateSituation exsersiseOne = new GenerateSituation(1, 3, 14, 2, 2, Show);
        }

        private static void Show(object sender, ShowMessageArgs message)
        {
            Console.WriteLine(message.Message);
        }
    }
}
