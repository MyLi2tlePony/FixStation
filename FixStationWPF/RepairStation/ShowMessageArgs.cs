using System;
using System.Collections.Generic;
using System.Text;

namespace RepairStation
{
    class ShowMessageArgs : EventArgs
    {
        public string Message { get; private set; }

        public ShowMessageArgs(string message)
        {
            Message = message;
        }
    }
}
