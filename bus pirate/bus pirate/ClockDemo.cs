using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;



namespace bus_pirate
{
    
    class ClockDemo
    {
        private SerialPort serialPort;
        private I2C ledPanel;
        private bool DieYouGravySuckingPig = false;

        // Default address for the LED backpack
        private const byte I2C_ADDR = 0x70;

        public ClockDemo(SerialPort serialPort)
        {
            this.serialPort = serialPort;
            ledPanel = new I2C(ref serialPort);
            ledPanel.peripheralConfig(I2C.configBits.POWER);

            System.Threading.Thread.Sleep(500);
            ledPanel.setBusSpeed(I2C.busSpeed.I2C_400kHz);

            // Turn on the clock oscillator
            System.Threading.Thread.Sleep(50);
            ledPanel.sendByte(I2C_ADDR, 0x21);

            // Turn on power to the seven segment display
            System.Threading.Thread.Sleep(50);
            ledPanel.sendByte(I2C_ADDR, 0x81);
        }

        // Update the : every second and the minutes and hours as they change
        public void timeLoop()
        {
            String curTime;
            char[] cTime = {'0', '0', '0', '0' };
            int cnt = 0;


            while (!DieYouGravySuckingPig)
            {
                curTime = DateTime.Now.ToString("HHmm");
                cTime = curTime.ToCharArray();
                for ( int i = 0; i < cTime.Length; i++ ) {
                    writeLed( cTime[ i ], i );
                }

                // Flash the colon once a second
                if ((++cnt % 2) == 0)
                {
                    // This is on
                    byte[] cmdArray = { 0x04, 0x02, 0x00 };
                    ledPanel.sendByteArray(I2C_ADDR, cmdArray);
                }
                else
                {
                    // This is off
                    byte[] cmdArray = { 0x04, 0x00, 0x00 };
                    ledPanel.sendByteArray(I2C_ADDR, cmdArray);
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        private void writeLed(char digit, int i )
        {
            byte offset = 0;
            byte digitOut = (byte) 0;
            byte[] cmdArray = { 0x00, 0x00, 0x00 };

            // Map the digit to the individual diodes
            switch (digit)
            {
                case '0':
                    digitOut = 0x3F;
                    break;
                case '1':
                    digitOut = 0x06;
                    break;
                case '2':
                    digitOut = 0x5b;
                    break;
                case '3':
                    digitOut = 0x4F;
                    break;
                case '4':
                    digitOut = 0x66;
                    break;
                case '5':
                    digitOut = 0x6D;
                    break;
                case '6':
                    digitOut = 0x7D;
                    break;
                case '7':
                    digitOut = 0x07;
                    break;
                case '8':
                    digitOut = 0x7F;
                    break;
                case '9':
                    digitOut = 0x67;
                    break;
                default:
                    break;
            }

            // The back pack can drive 40 lines. We use every other byte
            // for the seven segment display.
            // Byte 4 is used by the colon and is not here
            switch ( i )
            {
                case 0:
                    offset = 0;
                    break;
                case 1:
                    offset = 2;
                    break;
                case 2:
                    offset = 6;
                    break;
                case 3:
                    offset = 8;
                    break;
            }
            cmdArray[0] = offset;
            cmdArray[1] = digitOut;

            ledPanel.sendByteArray( I2C_ADDR, cmdArray );

        }
        
        public void loopStop()
        {
            DieYouGravySuckingPig = true;
        }
    }
}
