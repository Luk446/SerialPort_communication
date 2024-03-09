using BlueMystic;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialPortExample
{
    public partial class Small1 : Form
    {
        private DarkModeCS DM = null;
        //private SerialPort serialPort;
        private Timer updateTimer;
        private string latestSerialData = string.Empty;

        public Small1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM3";
            serialPort.BaudRate = 9600;
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 5000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
                return;

            serialPort.WriteLine("READ");

            if (!string.IsNullOrEmpty(latestSerialData))
            {
                UpdateTextBox(latestSerialData);
                latestSerialData = string.Empty;
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string incomingData = serialPort.ReadLine();

            // Check if the data starts with "PV: "
            if (incomingData.StartsWith("PV: "))
            {
                // Extract the numerical value after "PV: "
                string dataValue = incomingData.Substring(4); // Skip the first 4 characters ("PV: ")

                // Update the latestSerialData if the data is a valid integer
                if (int.TryParse(dataValue, out int potValue))
                {
                    latestSerialData = potValue.ToString();
                    UpdateProgressBar(latestSerialData);
                    UpdateTextBox(latestSerialData);
                }
            }
        }

        private void UpdateProgressBar(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateProgressBar), data);
            }
            else
            {
                if (int.TryParse(data, out int magnitude))
                {
                    int normalizedMagnitude = Math.Min(100, Math.Max(0, magnitude));
                    progressBar1.Value = normalizedMagnitude;
                }
            }
        }

        private void UpdateTextBox(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateTextBox), data);
            }
            else
            {
                textBox2.AppendText(data + Environment.NewLine);
            }
        }

        // Button click event to start serial port communication and timer
        private void button1_Click(object sender, EventArgs e)
        {
            InitializeSerialPort();
            InitializeTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SmallHome smallHome = new SmallHome();
            smallHome.Show();
            this.Hide();
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
