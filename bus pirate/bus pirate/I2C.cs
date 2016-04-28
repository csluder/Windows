using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace bus_pirate
{
    class I2C
    {

        private const byte BitBangMode             = 0x00;
        private const byte Enter_I2C_Mode          = 0x02;
        private const byte RESET                   = 0x0F;
           

        // I2C mode commands
        private const byte DisplayModeVersionString = 0x01;
        private const byte I2C_startBit             = 0x02;
        private const byte I2C_stopBit              = 0x03;
        private const byte I2C_readByte             = 0x04;
        private const byte I2C_ackBit               = 0x06;
        private const byte I2C_nackBit              = 0x07;
        private const byte StartBusSniffer          = 0x0F;
        private const byte I2C_bulkWrite            = 0x10;
        private const byte ConfigPeripherals        = 0x40;
       
        // I2C bus speed
        public enum busSpeed : byte
        {
            I2C_5kHz   = 0x60,
            I2C_50kHz  = 0x61,
            I2C_100kHz = 0x62,
            I2C_400kHz = 0x63
        }
        
        // Bus pirate peripheral configuration bits
        public enum configBits : byte
        {
            POWER  = 0x08,
            PULLUP = 0x04,
            AUX    = 0x02,
            CS     = 0x01
        }

        SerialPort serialPort;

    
        public I2C(ref SerialPort Port)
        {
            
            byte[] BBIO1 = Encoding.ASCII.GetBytes("BBIO1");
            byte[] BBIO1Buffer = new byte[BBIO1.Length];
            byte[] I2C1 = Encoding.ASCII.GetBytes("I2C1");
            byte[] I2C1Buffer = new byte[I2C1.Length];
            bool goodToGo = false;

            // Stash a copy of the serial port object
            serialPort = Port;

            // Put the BP into binary mode by first entering bit bang mode
            for ( int i = 0; i < 20; i++ ) {
                writeByte( BitBangMode ); 

                System.Threading.Thread.Sleep(50);

                if ( serialPort.BytesToRead >= BBIO1.Length ) {
                    serialPort.Read( BBIO1Buffer, 0, BBIO1Buffer.Length );
                    if ( BBIO1.SequenceEqual( BBIO1Buffer) ) {
                        goodToGo = true;
                        break;
                    }
                }
 
            }

            if ( !goodToGo ) return;
            goodToGo = false;

            for (int i = 0; i < 10; i++)
            {
                serialPort.DiscardInBuffer();

                writeByte( Enter_I2C_Mode );

                System.Threading.Thread.Sleep(500);

                if (serialPort.BytesToRead >= I2C1.Length)
                {
                    serialPort.Read(I2C1Buffer, 0, I2C1Buffer.Length);
                    if (I2C1.SequenceEqual(I2C1Buffer))
                    {
                        goodToGo = true;
                        break;
                    }
                }
            }
            if (!goodToGo) return;
        }
        
        public void writeByte(byte b)
        {
            serialPort.Write(new byte[] { b }, 0, 1);
        }

        public int peripheralConfig( configBits flag )
        {
            int ret = -1;
            byte cmd = ConfigPeripherals;
            cmd |= (byte)flag;

            writeByte(cmd);

            try
            {
                byte[] buffer = new byte[1];
                serialPort.Read(buffer, 0, buffer.Length);

                // Check for ACK
                if ( buffer[0] == 1 ) {
                    ret = 0;
                }
            }
            catch
            {
                ret = -1;
            }

            return ret;
        }

        // Debug probe routine. Insert to verivy still in I2C mode.
        private bool probe()
        {
            byte[] I2C1 = Encoding.ASCII.GetBytes("I2C1");
            byte[] I2C1Buffer = new byte[I2C1.Length];
            writeByte(DisplayModeVersionString);
            System.Threading.Thread.Sleep(500);

            serialPort.Read(I2C1Buffer, 0, I2C1Buffer.Length);
            if (I2C1.SequenceEqual(I2C1Buffer))
            {
                return true;
            }

            return false;
        }

        public int sendByte(byte addr, byte data)
        {
            byte[] buffer = new byte[1];
            int ret = 0;

            // I2C Addresses have to be shifted by one for direction bit.
            addr <<= 1;

            byte[] cmdArray = { 0x02, I2C_bulkWrite | 0x01, addr, data, 0x03};
            serialPort.Write(cmdArray, 0, cmdArray.Length);

            // Read the ACKs
            for (int i = 0; i < cmdArray.Length; i++)
            {
                try
                {
                    serialPort.Read(buffer, 0, buffer.Length);
                    // Check for NACK
                    if (buffer[0] == 0)
                    {
                        ret = -1;
                        break;
                    }
                }
                catch
                {
                    ret = -1;
                    break;

                }
            }
            
            return ret;
        }

        public int sendByteArray( byte addr, byte[] data )
        {
            byte[] buffer = new byte[1];
            int ret = 0;
            byte dataLength = (byte)data.Length;
            byte writeCmd = I2C_bulkWrite;
            
            // I2C Addresses have to be shifted by one for direction bit.
            addr <<= 1;

            byte[] cmdArray = new byte[4 + dataLength];
            cmdArray[0] = I2C_startBit;
            writeCmd |= dataLength;
            cmdArray[1] = writeCmd;
            cmdArray[2] = addr;
            Array.Copy( data, 0, cmdArray, 3, (int)dataLength );
            cmdArray[dataLength + 3] = I2C_stopBit;
            serialPort.Write(cmdArray, 0, cmdArray.Length);

            // Read the ACKs
            for (int i = 0; i < cmdArray.Length; i++)
            {
                try
                {
                    serialPort.Read(buffer, 0, buffer.Length);

                    // Check for NACK
                    if (buffer[0] == 0)
                    {
                        ret = -1;
                        break;
                    }
                }
                catch
                {
                    ret = -1;
                    break;

                }
            }

            return ret;
        }

        public int setBusSpeed(busSpeed flag)
        {
            int ret = -1;

            writeByte( (byte)flag );
            try
            {
                byte[] buffer = new byte[1];
                serialPort.Read(buffer, 0, buffer.Length);

                // Look for the ACK
                if (buffer[0] == 1)
                {
                    ret = 0;
                }
            }
            catch
            {
                ret = -1;
            }

            return ret;
        }


    }
}

