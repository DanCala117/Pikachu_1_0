using System;
using System.IO.Ports;

namespace Pikachu_1_0
{
    /// <summary>
    /// Represents a Parker-brand belt drive driven by a Moog Animatics
    /// class 5 D-style SmartMotor.
    /// </summary>
    public class ParkerBeltDrive : IDisposable
    {
        /// <summary>
        /// The number of motor encoder steps per millimeter (mm) of carriage travel.
        /// </summary>
        private const float StepsPerMM = 96.00176743f;

        /// <summary>
        /// The serial port communicating with the SmartMotor.
        /// </summary>
        private readonly SerialPort serial;

        /// <summary>
        /// The measured length of the belt drive during the last <see cref="Calibrate"/>,
        /// in millimeters (mm). <see langword="null"/> indicates no calibration has
        /// taken place.
        /// </summary>
        private float? beltLength = null;

        public ParkerBeltDrive(string portName, int baudRate = 9600)
        {
            serial = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One)
            {
                NewLine = "\r",
                Handshake = Handshake.XOnXOff,
            };
            serial.Open();
        }

        /// <inheritdoc/>
        public void Dispose() => serial?.Dispose();

        /// <summary>
        /// Detect the physical limits of the carriage in the positive and
        /// negative directions, then set the motor's origin (i.e., zero position)
        /// to the detected negative limit.
        /// </summary>
        public bool Calibrate()
        {
            serial.WriteLine("TALK GOSUB(1)");
            serial.ReadTo("CALIBRATION_DONE:");

            // The motor outputs the difference between the positive limit and
            // the negative limit, in encoder steps. Save it, but in millimeters.
            if (float.TryParse(serial.ReadLine(), out float steps))
            {
                beltLength = steps / StepsPerMM;
            }

            return true;
        }

        /// <summary>
        /// Move the belt drive to the specified position.
        /// </summary>
        /// <param name="pos">The destination, in millimeters (mm) from the origin.</param>
        public void MoveAbsolute(float pos)
        {
            serial.WriteLine($"MP PT={pos * StepsPerMM:0}");
            DoTrajectory();
        }

        /// <summary>
        /// Move the belt drive by the specified amount.
        /// </summary>
        /// <param name="deltaPos">The displacement, in millimeters (mm) from the current position.</param>
        public void MoveIncremental(float deltaPos)
        {
            serial.WriteLine($"MP PRT={deltaPos * StepsPerMM:0}");
            DoTrajectory();
        }

        /// <summary>
        /// Set the target velocity of the SmartMotor.
        /// </summary>
        /// <param name="speed">The desired speed, in millimeters per second (mm/s).</param>
        public bool SetSpeed(float speed)
        {
            serial.WriteLine($"VT={speed * StepsPerMM:0}");
            return true;
        }

        public void MoveToLimit(bool isPositiveLimit) => Request(isPositiveLimit ? "GOSUB(3)" : "GOSUB(4)", "LIMIT_DONE");

        public bool GetPosition(out float position)
        {
            serial.WriteLine("TALK PRINT(\"POSITION:\") RPA");
            serial.ReadTo("POSITION:");

            if (float.TryParse(serial.ReadLine(), out float steps))
            {
                position = steps / StepsPerMM;
                return true;
            }

            position = default;
            return false;
        }

        public bool GetLength(out float length)
        {
            // Has this instance of the belt drive been calibrated?
            if (!beltLength.HasValue)
            {
                Calibrate();

                // Did Calibrate() fail to find the belt length?
                if (!beltLength.HasValue)
                {
                    throw new Exception("Failed to get belt length from calibration");
                }
            }

            length = beltLength.Value;
            return true;
        }

        private void DoTrajectory() => Request("GOSUB(2)", "TRAJECTORY_DONE");

        private void Request(string request, string expectedResponse)
        {
            serial.WriteLine($"TALK {request}");
            WaitForResponse(expectedResponse);
            serial.WriteLine("SILENT");
        }

        private void WaitForResponse(string line)
        {
            string response;

            do
            {
                response = serial.ReadLine();
            }
            while (response != line);
        }
    }
}
