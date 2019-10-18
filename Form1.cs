using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPM_SAE_Project1
{
    public partial class Form1 : Form
    {
        #region Fields & Constants
        private AGauge mSpeedGauge;
        private AGauge mEngRPMGauge;
        private bool mbLoggingData = false;
        private long mlLastTimeStamp; //tracks the last time stamp sent by the arduino
        private string msDataLog;

        private const int BASE_ARC_START_ANGLE_SPEED = 135;
        private const int BASE_ARC_SWEEP_ANGLE_SPEED = 270;
        private const uint DEFAULT_MAX_DIAL_SPEED = 500;

        #endregion

        #region Form Initialization & Closing
        public Form1()
        {
            InitializeComponent();
            InitializeSpeedGauge();
            InitializeERPMGauge();
            Program.arduinoComm.CommInit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Create the gauge and fit it to the backing panel.
        /// The Y-value is offset 5% to overcome a tendency of the
        /// gauge to sit a bit higher than expected when centered.
        /// </summary>
        private void InitializeSpeedGauge()
        {
            mSpeedGauge = new AGauge
            {
                MinValue = 0,
                MaxValue = DEFAULT_MAX_DIAL_SPEED,
                Parent = panel_mSpeedGauge,
                Height = panel_mSpeedGauge.Height,
                Width = panel_mSpeedGauge.Width,
                BaseArcStart = BASE_ARC_START_ANGLE_SPEED,
                BaseArcSweep = BASE_ARC_SWEEP_ANGLE_SPEED,
                Center = new Point(panel_mSpeedGauge.Width / 2, (int)(panel_mSpeedGauge.Height * 0.55))
            };

            //for (int i = 0; i < mSpeedGauge.RangesEnabled.Length; i++)
            //{
            //    mSpeedGauge.RangesEnabled[i] = false;
            //}
        }

        /// <summary>
        /// Create the gauge and fit it to the backing panel.
        /// The Y-value is offset 5% to overcome a tendency of the
        /// gauge to sit a bit higher than expected when centered.
        /// </summary>
        private void InitializeERPMGauge()
        {
            mEngRPMGauge = new AGauge
            {
                MinValue = 0,
                MaxValue = DEFAULT_MAX_DIAL_SPEED,
                Parent = panel_mERPMGauge,
                Height = panel_mERPMGauge.Height,
                Width = panel_mERPMGauge.Width,
                BaseArcStart = BASE_ARC_START_ANGLE_SPEED,
                BaseArcSweep = BASE_ARC_SWEEP_ANGLE_SPEED,
                Center = new Point(panel_mERPMGauge.Width / 2, (int)(panel_mERPMGauge.Height * 0.55))
            };

            //for (int i = 0; i < mERPMGauge.RangesEnabled.Length; i++)
            //{
            //    mERPMGauge.RangesEnabled[i] = false;
            //}
        }
        private void Button_LogData_Click(object sender, EventArgs e)
        {
            if (mbLoggingData == false)
            {
                msDataLog = "";
                mbLoggingData = true;
                button_LogData.Text = "Stop Logging Data";
            }
            else
            {
                mbLoggingData = false;
                button_LogData.Text = "Start Logging Data";
                string fileBaseName = "DataLog";
                int i = 1;
                string fileName;
                bool found = false;
                //while (!found)
                //{
                //    fileName = fileBaseName + i.ToString() + ".txt";
                //    if (System.IO.File.Exists(fileName))
                //    {
                //        founn = true;
                //    }
                //    i++;
                //}
                System.IO.File.WriteAllText("DataLog.csv", msDataLog);
            }
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            mSpeedGauge.Value = Program.arduinoComm.velocity;
            mEngRPMGauge.Value = Program.arduinoComm.engineRPM;
            if (mbLoggingData == true)
            {
                if (Program.arduinoComm.timeStamp != mlLastTimeStamp)
                {
                    msDataLog += Program.arduinoComm.timeStamp.ToString() + ", " +
                    Program.arduinoComm.wheelCount.ToString() + ", " +
                    Program.arduinoComm.engineCount.ToString() + Environment.NewLine; //creates new line after data
                    mlLastTimeStamp = Program.arduinoComm.timeStamp;
                }
            }
        }
    }
}

#endregion