using BlueMystic;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialPortExample
{
    public partial class Small1 : Form
    {
        private DarkModeCS DM = null;
        //private SerialPort serialPort; (commented due to error causing)

        public Small1()
        {
            InitializeComponent();
            InitializeSerialPort();
            this.IsMdiContainer = true;
            DM = new DarkModeCS(this);
        }
        //Serial Port Init
        // establish communication with arduino 
        private void InitializeSerialPort()
        {
            serialPort = new SerialPort(); 
            serialPort.PortName = "COM3"; // choose USB port
            serialPort.BaudRate = 9600; // define serial com rate
            // Subscribed to DataReceived event from serial port object
            // triggers everytime new info comes into serial port
            serialPort.DataReceived += SerialPort_DataReceived; 
            serialPort.Open(); // open port for com
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // event handler for data recieved event of the serial port object 
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine(); // reads and stores serial data 
            UpdateProgressBar(data); // transfer data into progress bar
        }

        // method to update progress bar with reciv data 
        private void UpdateProgressBar(string data)
        {
            if (InvokeRequired) // check if method is called 
            {
                Invoke(new Action<string>(UpdateProgressBar), data);
            }
            else
            {   // we need to convert the data into magnitude for progress bar
                // Parse data to get magnitude (assuming it's an integer value)
                if (int.TryParse(data, out int magnitude))
                {
                    // Normalize magnitude to the range of the progress bar 
                    // from 0->1023 to 0->100
                    int normalizedMagnitude = Math.Min(100, Math.Max(0, magnitude)); // Ensure value is within [0, 100]

                    // Update progress bar value
                    progressBar1.Value = normalizedMagnitude;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen();
            home.Show();
            this.Hide();
            serialPort.Close();
        }
    }
}
