using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialPortExample
{
    public partial class Form1 : Form
    {
        // Declare the class-level serialPort variable here
        //private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeSerialPort()
        {
            // Initialize the SerialPort object within this method
            SerialPort port = new SerialPort();
            port.PortName = "COM3";
            port.BaudRate = 9600;
            port.DataReceived += SerialPort_DataReceived;
            port.Open();

            // Assign the initialized SerialPort object to the class-level variable
            serialPort = port;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            UpdateUI(data);
        }

        private void UpdateUI(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateUI), data);
            }
            else
            {
                textBox1.AppendText(data + Environment.NewLine);
            }
        }
    }
}
