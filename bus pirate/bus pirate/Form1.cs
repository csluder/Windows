using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace bus_pirate
{       

    public partial class busPirate : Form
    {
        private ClockDemo clockDemo;
        private Thread clockDemoThread;

        private void populatePortComboBox()
        {
            // Use serial Io class to retrieve list of active ports
            String[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                portNames = new String[] { "No Ports Detected" };
            }

            Array.Sort(portNames);

            // Add the ports to the combo box
            comPort.Items.AddRange(portNames);
            comPort.SelectedIndex = 0;
        }

        public busPirate()
        {
            InitializeComponent();

            populatePortComboBox(); 

            // The bus pirate default configuration is 115200n81.
            // The values in the box are set in the properties using
            // a string collection for the Item member.
            baudRate.SelectedIndex = 8;
            baudRate.SelectedItem = "115200";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void baudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rescan_Click(object sender, EventArgs e)
        {
            populatePortComboBox();
        }

        private void connect_Click(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                clockDemo.loopStop();
                serialPort1.Close();
                connect.Text = "Connect";
                return;
            }
            serialPort1.PortName = comPort.Text;
            serialPort1.BaudRate = Convert.ToInt32(baudRate.SelectedItem);
            serialPort1.Parity = System.IO.Ports.Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = System.IO.Ports.StopBits.One;
            serialPort1.Handshake = System.IO.Ports.Handshake.None;
            serialPort1.RtsEnable = false;
            serialPort1.ReceivedBytesThreshold = 1;
            serialPort1.ReadTimeout = 50;

            try
            {

                serialPort1.Open();
                connect.Text = "Disconnect";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in open" + ex.Message);
                connect.Text = "Connect";
            } 
        }

        private void clock_Click(object sender, EventArgs e)
        {
            clockDemo = new ClockDemo( serialPort1 );
            clockDemoThread = new Thread( new ThreadStart(clockDemo.timeLoop) );
            clockDemoThread.Start();
        }

    }
}
