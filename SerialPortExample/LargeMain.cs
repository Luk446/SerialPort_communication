using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortExample
{
    public partial class LargeMain : Form

    {
        //private SerialPort serialPort;

        public LargeMain()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM3";
            serialPort.BaudRate = 9600;

            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            UpdateProgressBar(data);
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

        private void MediumMain_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeScreen userInformation = new HomeScreen();
            userInformation.Show();
            this.Hide();
            serialPort.Close();
        }
    }
}
