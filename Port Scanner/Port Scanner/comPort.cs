using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class comPort : Form
    {
        public comPort()
        {
            InitializeComponent();	
		
            //Set list of serial ports for the list box
            String[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                portNames = new String[] { "No Ports Detected" };
            }
            Array.Sort( portNames );
            listBox1.Items.AddRange(portNames);
        }

        private void Rescan_Click(object sender, EventArgs e)
        {
            //Set list of serial ports for the list box
            String[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                portNames = new String[] { "No Ports Detected" };
            }
            listBox1.Items.Clear();
            Array.Sort(portNames);
            listBox1.Items.AddRange(portNames);
        }
    }
}
