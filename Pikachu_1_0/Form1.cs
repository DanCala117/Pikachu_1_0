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
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Setting Belt Drive Com Port";
            }
        }

        /// <summary>
        /// Sets belt drive speen on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetBeltSpeed_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    //conversion from motor steps to ips
                    double x = Convert.ToDouble(BeltSpeed.Text);
                    double y = 0;

                    //checks if user input is between 1ips and 25ips and sets accordinglly
                    //anything faster then 25ips casues rattling of the belt drive, so I put a hard cap of 25ips
                    switch (x)
                    {
                        //checks if over 25ips
                        case double n when n >= 25:
                            x = 25;
                            y = x * (96 * 254);
                            MotorSteps = y.ToString();
                            BeltSpeed.Text = "25";
                            break;

                        //checks if under 1ips
                        case double n when n <= 1:
                            x = 1;
                            y = x * (96 * 254);
                            MotorSteps = y.ToString();
                            BeltSpeed.Text = "1";
                            break;
                        //if user input is between the range
                        default:
                            y = x * (96 * 254);
                            MotorSteps = y.ToString();
                            break;
                    }
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Setting Belt Drive Speed";
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
            try
            {
                if (port.IsOpen)
                {
                    //stops in center of belt for one device
                    if (StopInMiddleFirstButton.Checked)
                    {
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + (beltLength / 2) * 96);
                        DoTrajectory(); //pause
                        Thread.Sleep(UserTime); //pause
                        DoTrajectory(); //pause
                        Thread.Sleep(0); //pause
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                        port.WriteLine("G");
                    }
                    //stops in center for two devices
                    else if (StopInMiddleFirstForTwoButton.Checked)
                    {
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + (beltLength * .75) * 96);
                        DoTrajectory(); //pause
                        Thread.Sleep(UserTime); //pause
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + (beltLength * .25) * 96);
                        DoTrajectory(); //pause
                        Thread.Sleep(UserTime); //pause
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                        port.WriteLine("G");
                    }
                    //does not stop in center for any devices
                    else
                    {
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                        port.WriteLine("G");
                    }
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Moving Left";
            }
        }

        /// <summary>
        /// Moves belt drive to the right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    //stops in the center for one device
                    if (StopInMiddleFirstButton.Checked)
                    {
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + (beltLength / 2) * 96);
                        DoTrajectory(); //pause
                        Thread.Sleep(UserTime); //pause
                        DoTrajectory(); //pause
                        Thread.Sleep(0); //pause
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("PT=" + ((beltLength * 96) - 1000)); //set to - 1000 so belt doesnt slam into the ends
                        port.WriteLine("G");
                    }
                    //stops in the center for two devices
                    else if (StopInMiddleFirstForTwoButton.Checked)
                    {
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + (beltLength * .25) * 96);
                        DoTrajectory(); //pause
                        Thread.Sleep(UserTime); //pause
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + (beltLength * .75) * 96);
                        DoTrajectory(); //pause
                        Thread.Sleep(UserTime); //pause
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + ((beltLength * 96) - 1000)); //set to - 1000 so belt doesnt slam into the ends
                        port.WriteLine("G");
                    }
                    //does not stop in center for any devices
                    else
                    {
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                        port.WriteLine("G");
                    }
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Moving Right";
            }
        }

        /// <summary>
        /// Moves belt drive to the center
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CenterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + (beltLength / 2) * 96);
                    port.WriteLine("G");
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Moving Halfway";
            }
        }

        /// <summary>
        /// Lets the bet drive stop in the center for one device before continuing movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopInMiddleFirstButton_CheckedChanged(object sender, EventArgs e)
        {
            //Checks to make sure both radio buttons are not selected at the same time
            if (StopInMiddleFirstForTwoButton.Checked)
            {
                StopInMiddleFirstButton.Checked = false;
            }
        }

        private void SetTimeToStopButton_Click(object sender, EventArgs e)
        {
            UserTime = Int16.Parse(TimeToStop.Text);
        }

        /// <summary>
        /// Lets the bet drive stop in the center for two different devices before continuing movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopInMiddleFirstForTwoButton_CheckedChanged(object sender, EventArgs e)
        {
            //Checks to make sure both radio buttons are not selected at the same time
            if (StopInMiddleFirstButton.Checked)
            {
                StopInMiddleFirstForTwoButton.Checked = false;
            }
        }

        /// <summary>
        /// Moves the belt drive one quarter way
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuarterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + (beltLength * .25) * 96);
                    port.WriteLine("G");
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Moving Quarter Way";
            }
        }

        /// <summary>
        /// Moves the belt drive three quarters way
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreeQuarterButon_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + (beltLength * .75) * 96);
                    port.WriteLine("G");
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Moving Three Quarters Way";
            }
        }

        /// <summary>
        /// clears ERRORText textbox message after 10 seconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ERRORText_TextChanged(object sender, EventArgs e)
        {
            // Declare a timer and set its interval to 10 seconds (10000 milliseconds)
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000;

            // Handle the timer's Tick event
            timer.Tick += (sender, e) =>
            {
                // Clear the text in the text box
                ERRORText.Text = "";

                // Stop the timer
                timer.Stop();
            };

            // Stop the timer
            timer.Stop();

            // Start the timer
            timer.Start();
        }
    }
}