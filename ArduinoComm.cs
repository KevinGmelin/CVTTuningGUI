using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace RPM_SAE_Project1
{
    class ArduinoComm : SerialPort
    {
        public void CommInit()
        {
            // Allow the user to set the appropriate properties.  
            this.PortName = "COM1";
            this.BaudRate = 9600;
            this.Parity = Parity.None;
            this.DataBits = 8;
            this.StopBits = StopBits.One;
            this.Handshake = Handshake.None;
            this.Open();
        }

        public void test()
        {
            this.WriteLine("hello");
        }





    }
}
