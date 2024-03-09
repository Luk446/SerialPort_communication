﻿using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SerialPortExample
{
    public partial class Diagnostics : Form
    {
        //private SerialPort serialPort;

        public Diagnostics()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM3"; // Adjust as necessary
            serialPort.BaudRate = 9600;
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();

            // Check if data starts with "TV: "
            if (data.StartsWith("TV: "))
            {
                string tempValue = data.Substring(4); // Extract the temperature value
                UpdateTextBox(tempValue);
            }
        }

        private void UpdateTextBox(string data)
        {
            if (label8.InvokeRequired)
            {
                label8.Invoke(new Action<string>(UpdateTextBox), data);
            }
            else
            {
                label8.Text = data;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomeScreen userInformation = new HomeScreen();
            userInformation.Show();
            this.Hide();
            if (serialPort.IsOpen)
            {
                serialPort.Close(); // Close the serial port when the form is closed
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
