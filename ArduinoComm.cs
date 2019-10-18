using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace RPM_SAE_Project1
{
    class ArduinoComm : SerialPort
    {
        bool _continue = true;
        private Thread mReadThread;
        private long mfEngineCount;
        private long mfWheelCount;
        private readonly Object mDataLock = new Object();
        private long mlTimeStamp;

        public void CommInit()
        {
            // Allow the user to set the appropriate properties.  
            this.PortName = "COM3";
            this.BaudRate = 9600;
            this.Parity = Parity.None;
            this.DataBits = 8;
            this.StopBits = StopBits.One;
            this.Handshake = Handshake.None;
            this.Open();
            mReadThread = new Thread(read);
            mReadThread.Start();
        }

        public long engineCount { //gets engineCount once engineCount is unlocked
            get 
            {
                lock (mDataLock) //for multiple threads
                {
                    return mfEngineCount;
                }
            }
        }

        public long wheelCount { // gets wheelCount once wheelCount is unlocked
            get
            {
                lock (mDataLock)
                {
                    return mfWheelCount;
                }
            }
        }

        public long engineRPM
        {
            get
            {
                lock (mDataLock)
                {
                    //Converts engineCount to engineRPM
                    return mfWheelCount * 60 / 250 / 6;
                }
            }
        }

        public long wheelRPM
        {
            get
            {
                lock (mDataLock)
                {
                    return mfEngineCount * 60 / 250 / 5;
                }
            }
        }

        public float velocity //Converts wheelCount to Velocity (mph)
        {
            get
            {
                lock (mDataLock)
                {
                    return (float)Math.PI * (mfEngineCount * 60 / 250 / 5) / 1056;
                }
            }
        }

        public long timeStamp // gets timeStamp once unlocked
        {
            get
            {
                lock (mDataLock)
                {
                    return mlTimeStamp;
                }
            }
        }

         public void read()
        {
            {
                while (_continue)
                {
                    try
                    {
                        string message = this.ReadLine();
                        string[] data = message.Split(',');
                        if (data.Length != 3)
                        {
                            continue;
                        }
                        lock (mDataLock)
                        {
                            mlTimeStamp = long.Parse(data[0]);
                            mfEngineCount = long.Parse(data[1]);
                            mfWheelCount = long.Parse(data[2]);
                            
                        }
                        Console.WriteLine(message);
                    }
                    catch (TimeoutException) { }
                }
            }
        }




    }
}
