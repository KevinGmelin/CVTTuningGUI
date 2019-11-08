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
        private long mfEngineRPM;
        private long mfWheelRPM;
        private double mfVelocity;
        private double mfDiameter = 20.5;
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

        public long engineCount
        { //gets engineRPM once engineRPM is unlocked
            get
            {
                lock (mDataLock) //for multiple threads
                {
                    return mfEngineCount;
                }
            }
        }

        public long engineRPM { //gets engineRPM once engineRPM is unlocked
            get 
            {
                lock (mDataLock) //for multiple threads
                {
                    return mfEngineRPM; // count * 60 * 1/250 * 1/nummagnets
                }
            }
        }


        public long wheelCount
        { // gets wheelRPM once wheelRPM is unlocked
            get
            {
                lock (mDataLock)
                {
                    return mfWheelCount;
                }
            }
        }

        public long wheelRPM { // gets wheelRPM once wheelRPM is unlocked
            get
            {
                lock (mDataLock)
                {
                    return mfWheelRPM; // count * 60 * 1/250 * 1/nummagnets
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
                            mfEngineRPM = mfEngineCount * 60 / 250 / 5;
                            mfWheelRPM = mfWheelCount * 60 / 250 / 6;
                            mfVelocity = mfWheelRPM * Math.PI * mfDiameter / 1056;
                            
                        }
                        Console.WriteLine(message);
                    }
                    catch (TimeoutException) { }
                }
            }
        }




    }
}
