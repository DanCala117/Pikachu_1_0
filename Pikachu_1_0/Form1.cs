using System.Diagnostics;
using System.IO.Ports;

namespace Pikachu_1_0
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Creating com port for belt drive
        /// </summary>
        string comName;
        SerialPort port = new SerialPort("COM0", 9600, Parity.None, 8, StopBits.One)
        {
            NewLine = "\r",
            Handshake = Handshake.XOnXOff,
        };

        /// <summary>
        /// creating come port for debug board
        /// </summary>
        string comName2;
        SerialPort port2 = new SerialPort("COM0", 9600, Parity.None, 8, StopBits.One)
        {
            NewLine = "\r",
            Handshake = Handshake.XOnXOff,
        };

        /// <summary>
        /// Reading in serial data from debug board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            //Debug.WriteLine("Data Received:");
            Debug.Write(indata);
            Console.WriteLine(indata);
        }

        //variable for time to stop in center
        int UserTime = 2000;

        //variable for time to stop at each end
        int UserTimeEnds = 2000;

        //variable for increment to move by
        double UserIncrement = 1;

        //varibale for time to stop between each increment
        int UserTimeIncrement = 30000;

        //variable for end distance for incremental movement
        int EndDistanceIncrement = 0;

        //varibale for exact distance to move to
        double UserExact = 1;

        //variable for motor steps
        string MotorSteps = "";

        //Brain's functions
        private const float StepsPerMM = 96.00176743f;
        private float? beltLength = null;


        //private Control txtConsole;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

        //Brian's Functions
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

        //Brians Functions
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

                    //checks if user input is between 1ips and 50ips and sets accordinglly
                    //anything faster then 25ips casues rattling of the belt drive, but i am unrestricting the limit for a specific test 8/27/24
                    switch (x)
                    {
                        //checks if over 25ips
                        case double n when n >= 50:
                            x = 50;
                            y = x * (96 * 254);
                            MotorSteps = y.ToString();
                            BeltSpeed.Text = "50";
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


        /// <summary>
        /// Moves the belt drive by a user specified incremement in in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    //Get user input
                    UserIncrement = Convert.ToDouble(IncrementToMove.Text);

                    //If user selects to move by increment automatically
                    if (IncrementStopTimeButton.Checked)
                    {
                        //varibales to be used in the loop
                        double x = UserExact; //start distance
                        double y = UserIncrement; //increment distance
                        double z = EndDistanceIncrement; //stop distance

                        //moves until current position = end position
                        while (x < z)
                        {
                            port.WriteLine("ZS");
                            port.WriteLine("MP");
                            port.WriteLine("VT=" + MotorSteps);
                            port.WriteLine("PRT=" + (UserIncrement * 25.4) * 96); //move by incremement
                            port.WriteLine("G");

                            //increases by the amount traveled so far
                            x = x + y;

                            Thread.Sleep(UserTimeIncrement);
                        }

                        //tone plays to signal end of test
                        Console.Beep(2000, 5000);
                    }
                    //if user does not select to move by increment automatically
                    else
                    {
                        //move by user supplied increment
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PRT=" + (UserIncrement * 25.4) * 96); //move by incremement
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
                ERRORText.Text = "ERROR Moving by Increment";
            }
        }

        /// <summary>
        /// Moves the belt to a user specified location on the belt drive in in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExactButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    //get user measurement
                    UserExact = Convert.ToDouble(DistanceToMove.Text);

                    //First, Go Home
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("PT=0");
                    port.WriteLine("G");

                    //Then, move to user specified exact location
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + (UserExact * 25.4) * 96); //go to exact locaation
                    port.WriteLine("G");
                }
                else
                {
                    //throw new Exception();
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Moving To Exact Location";
            }
        }

        /// <summary>
        /// Goes to 0 position on the belt drive, then performs 10 swipes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Swipe10TimesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    //moves left first
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=100000");
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(5000); //pause

                    //start of ten swipes
                    //right
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //left
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //right
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //left
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //right
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //left
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //right
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //left
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //right
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                    //left
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory(); //pause
                    Thread.Sleep(UserTimeEnds); //pause
                }
                else
                {
                    //throws an exception
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Starting Automated Swipes";
            }
        }

        /// <summary>
        /// Opens debug boards com port, then prints out incomming data to a text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBebugBoardButton_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Sets the time for the belt drive to stop inbetween movements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetTimeToStopIncremenetButton_Click(object sender, EventArgs e)
        {
            UserTimeIncrement = Int32.Parse(TimeToStopIncrement.Text);
            //UserTimeIncrement = long.Parse(TimeToStopIncrement.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sets the end distance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetEndDistanceButton_Click(object sender, EventArgs e)
        {
            EndDistanceIncrement = Int32.Parse(EndDistance.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Starts automated Test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartAutoButton_Click(object sender, EventArgs e)
        {
            StartAutoTest();
        }

        /// <summary>
        /// Starts the Automated test
        /// </summary>
        private void StartAutoTest()
        {
            //calibrate belt drive
            try
            {
                //sets com port to whatever user enters
                comName = PortNum.Text;
                port.PortName = comName;

                port.Open();
                port2.Open();

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
                ERRORText.Text = "ERROR Calibrating Belt Drive";
            }

            //move by increment, then pull trigger specified number of times
            while (true)
            {
                //TODO make log File
                try
                {
                    //TODO move increment

                    //TODO pull trigger specified number of times

                    //TODO dd data to log file
                }
                catch
                {
                    break;
                }
            }

        }

        /// <summary>
        /// Test 1 Start Button:
        /// 
        /// this test will move to the start point, then move to the end point, 
        /// then move back to the start point + whatever increment the user gave, then repeat this process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestOneStartButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    //Get user start and stop distance
                    Double TestOneStart = 0;
                    Double TestOneStop = 60;
                    TestOneStart = Convert.ToDouble(TestOneStartDistance.Text);
                    TestOneStop = Convert.ToDouble(TestOneStopDistance.Text);

                    //Get user increment to move by
                    Double TestOneIncrement = 1;
                    TestOneIncrement = Convert.ToDouble(TestOneIncrementToAdvanceBy.Text);

                    Double Count = 1;
                    Double Attempt = 1;

                    //First, Go Home
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                    port.WriteLine("PT=0");
                    port.WriteLine("G");
                    DoTrajectory();
                    Thread.Sleep(1000);
                    //Task.Delay(1000);

                    //Then, move to user specified start distance
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + (TestOneStart * 25.4) * 96); //go to exact locaation
                    port.WriteLine("G");
                    DoTrajectory();
                    Thread.Sleep(1000);
                    //Task.Delay(1000);

                    //Starts the test until the user specified stop distance is reached
                    while (TestOneIncrement < TestOneStop)
                    {
                        //Changing the distance to pause at
                        TestOneIncrement = TestOneStart + (TestOneIncrement * Count);

                        //Then, wait user specified time
                        Thread.Sleep(Int32.Parse(TestOneWaitTime.Text));
                        //Task.Delay(Int32.Parse(TestOneWaitTime.Text));

                        while (Attempt < Convert.ToDouble(TestOneAttempts.Text) && TestOneIncrement < TestOneStop)
                        {
                            //Then, move to the end of the belt
                            port.WriteLine("ZS");
                            port.WriteLine("MP");
                            port.WriteLine("VT=" + MotorSteps);
                            port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                            port.WriteLine("G");
                            DoTrajectory();
                            Thread.Sleep(1000);
                            //Task.Delay(1000);

                            //Then, move to user specified start distance + user specified increment
                            port.WriteLine("ZS");
                            port.WriteLine("MP");
                            port.WriteLine("VT=" + MotorSteps);
                            port.WriteLine("PT=" + (TestOneIncrement * 25.4) * 96); //go to exact locaation
                            port.WriteLine("G");
                            DoTrajectory();
                            Thread.Sleep(1000);
                            //Task.Delay(1000);

                            //Increments the variables to continue the loop
                            Attempt++;
                        }

                        //Reset variables to continue the loop
                        TestOneIncrement = Convert.ToDouble(TestOneIncrementToAdvanceBy.Text);
                        Attempt = 0;
                        Count++;
                    }
                }
            }
            catch
            {
                ERRORText.Text = "ERROR Starting Test 1";
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void StartRepetetiveZoomTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (port.IsOpen)
                {
                    int Count = 0;
                    Count = Int32.Parse(RepetetiveZoomTestCount.Text);

                    int TimeToStop = 0;
                    TimeToStop = Int32.Parse(RepetetiveZoomtestStopTime.Text) * 1000;

                    int ZoomCount = 0;

                    for (int i = Count; i != 0; i--)
                    {
                        RepetetiveZoomTestZoomCount.Text = (ZoomCount + 1).ToString();

                        //move to middle
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=" + (beltLength / 2) * 96);
                        port.WriteLine("G");
                        port.WriteLine("G");
                        DoTrajectory();
                        Thread.Sleep(TimeToStop);
                        //await Task.Delay(TimeToStop);

                        //left
                        port.WriteLine("ZS");
                        port.WriteLine("MP");
                        port.WriteLine("VT=" + MotorSteps);
                        port.WriteLine("PT=1000"); //set to 1000 so belt doesnt slam into the ends
                        port.WriteLine("G");
                        DoTrajectory();
                        Thread.Sleep(TimeToStop);
                        //await Task.Delay(TimeToStop);
                    }

                    ZoomCount = 0;

                    //right
                    port.WriteLine("ZS");
                    port.WriteLine("MP");
                    port.WriteLine("VT=" + MotorSteps);
                    port.WriteLine("PT=" + ((beltLength * 96) - 1000));//set to - 1000 so belt doesnt slam into the ends
                    port.WriteLine("G");
                    DoTrajectory();
                }
                else
                {
                    //throws an exception
                }
            }
            catch (Exception)
            {
                ERRORText.Text = "ERROR Starting Repetetive Zoom Test";
            }
        }
    }
}