using System;
using System.Windows;
using System.IO.Ports;

namespace Pikachu_1_0
{
    public partial class Form1 : Form
    {
        //creating com port
        string comName;
        SerialPort port = new SerialPort("COM0", 9600, Parity.None, 8, StopBits.One)
        {
            NewLine = "\r",
            Handshake = Handshake.XOnXOff,
        };

        //variable for time to stop in center
        int UserTime = 2000;

        //variable for motor steps
        string MotorSteps = "";

        //Brain's functions
        private const float StepsPerMM = 96.00176743f;
        private float? beltLength = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PortNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Brain's Functions
        private void DoTrajectory() => Request("GOSUB(2)", "TRAJECTORY_DONE");

        private void Request(string request, string expectedResponse)
        {
            port.WriteLine($"TALK {request}");
            WaitForResponse(expectedResponse);
            port.WriteLine("SILENT");
        }

        public void Calibrate()
        {
            port.WriteLine("TALK GOSUB(1)");
            port.ReadTo("CALIBRATION_DONE:");

            // The motor outputs the difference between the positive limit and
            // the negative limit, in encoder steps. Save it, but in millimeters.
            if (float.TryParse(port.ReadLine(), out float steps))
            {
                beltLength = steps / StepsPerMM;
            }
        }

        private void WaitForResponse(string line)
        {
            string response;
            do
            {
                response = port.ReadLine();
            }
            while (response != line);
        }

        /// <summary>
        /// Sets belt drive port number on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetBD_Click(object sender, EventArgs e)
        {
            try
            {
                //sets com port to whatever user enters
                comName = PortNum.Text;
                port.PortName = comName;

                port.Open();

                //calibrates leftmost side to range zero
                if (port.IsOpen)
                {
                    port.WriteLine("EIGN(2)");
                    port.WriteLine("EIGN(3)");
                    port.WriteLine("ZS");
                    port.WriteLine("VT=100000");
                    port.WriteLine("ADT=100");
                    port.WriteLine("PT=-20000");
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    port.WriteLine("O=0");

                    Calibrate();
                    HIDText.Text = beltLength.ToString();
                }
                else
                {
                    PortNum.Text = "ERROR";
                }
            }
            catch 
            {
                PortNum.Text = "ERROR";
            }
        }

        /// <summary>
        /// Sets belt drive speen on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetBeltSpeed_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                try
                {
                    //conversion from motor steps to ips
                    double x = Convert.ToDouble(BeltSpeed.Text);
                    double y = x * (96 * 254);
                    MotorSteps = y.ToString();
                }
                catch 
                {
                    BeltSpeed.Text = "ERROR";
                }
            }
            else
            {
                BeltSpeed.Text = "ERROR";
            }
        }

        private void BeltSpeed_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Moves belt drive to the left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftButton_Click(object sender, EventArgs e)
        {
            if (StopInMiddleFirstButton.Checked)
            {
                port.WriteLine("ZS");
                port.WriteLine("MP");
                port.WriteLine("VT=" + MotorSteps);
                port.WriteLine("PT=" + (beltLength / 2) * 96);
                DoTrajectory(); //pause
                Thread.Sleep(UserTime); //pause
                port.WriteLine("ZS");
                port.WriteLine("MP");
                port.WriteLine("VT=" + MotorSteps);
                port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                port.WriteLine("G");
            }
            else
            {
                if (port.IsOpen)
                {
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                }
                else
                {
                    PortNum.Text = "ERROR";
                }
            }
        }

        /// <summary>
        /// Moves belt drive to the right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_Click(object sender, EventArgs e)
        {
            if (StopInMiddleFirstButton.Checked)
            {
                port.WriteLine("ZS");
                port.WriteLine("MP");
                port.WriteLine("VT=" + MotorSteps);
                port.WriteLine("PT=" + (beltLength / 2) * 96);
                DoTrajectory(); //pause
                Thread.Sleep(UserTime); //pause
                port.WriteLine("PT=" + ((beltLength * 96) -1000)); //set to - 1000 so belt doesnt slam into the ends
                port.WriteLine("G");
            }
            else
            {
                if (port.IsOpen)
                {
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");

                }
                else
                {
                    PortNum.Text = "ERROR";
                }
            }
        }

        /// <summary>
        /// Moves belt drive to the center
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CenterButton_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine("ZS");
                port.WriteLine("MP");
                port.WriteLine("VT=" + MotorSteps);
                port.WriteLine("PT=" + (beltLength / 2) * 96);
            }
            else
            {
                PortNum.Text = "ERROR";            
            }
        }

        /// <summary>
        /// Lets the bet drive stop in the cneter before continuing movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopInMiddleFirstButton_CheckedChanged(object sender, EventArgs e)
        {
            //todo check button
        }

        private void SetTimeToStopButton_Click(object sender, EventArgs e)
        {
            UserTime = Int16.Parse(TimeToStop.Text);
        }
    }
}