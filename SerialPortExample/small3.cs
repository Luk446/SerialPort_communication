﻿using BlueMystic;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace SerialPortExample
{
    public partial class Small3 : Form
    {
        private DarkModeCS DM = null;
        //private SerialPort serialPort;
        private Timer updateTimer;
        private string latestSerialData = string.Empty;

        public Small3()
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
            latestSerialData = serialPort.ReadLine();
            UpdateProgressBar(latestSerialData);
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
                    int normalizedMagnitude = Math.Min(1023, Math.Max(0, magnitude));
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeSerialPort();
            InitializeTimer();
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
    }
}
