using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;



namespace EpromProgrammer
{
    public class SerialComm
    {
        /**
         * Define the required constants
         */
        const byte CONNECT_REQUEST    = 0xDA;
        const byte DISCONNECT_REQUEST = 0xFF;
        const byte CONNECT_ACCEPT     = 0xAD;
        const byte READ_REQUEST       = 0xAA;
        const byte WRITE_REQUEST      = 0xBB;
        const byte OK                 = 0xDD;
        const byte DATA_SIZE_ERROR    = 0x01;
        const byte INCORRECT_VCC      = 0x02;
        const byte INCORRECT_VPP      = 0x03;
        const byte DEVICE_FAILED      = 0x04;

        /**
         * Define the required objects and variables
         */
        private SerialPort serialPort;
        public bool isProgrammerConnected { private set; get; } = false;

        /**
         * The constructor
         */ 
        public SerialComm()
        {
            serialPort = new SerialPort();

            serialPort.BaudRate = 500000;
            serialPort.ReadTimeout = 3000;
            serialPort.WriteTimeout = 3000;
        }

        /**
         * Find available serial ports
         */
        public string[] FindPorts()
        { 
            return SerialPort.GetPortNames();
        }

        /**
         * Connects to the selected port
         */
        public Exception Connect(string portName)
        {
            Exception retVal = new ExOK();

            // Open the port
            try
            {
                serialPort.PortName = portName;
                serialPort.Open();
            }
            catch (UnauthorizedAccessException e)
            {
                retVal = new Exception("Unauthorized access exception while connecting to " + serialPort.PortName
                    + ".\r\n" + e.Message);
                
                serialPort.Close();
            }
            catch (Exception e)
            {
                retVal = new Exception("Failed to connect to " + serialPort.PortName + ". " + e.Message);
                serialPort.Close();
            }

            if(!(retVal is ExOK))
            {
                return retVal;
            }

            // Identify device
            try
            {
                byte[] message = { CONNECT_REQUEST };
                serialPort.Write(message, 0, 1);
                byte response = (byte)serialPort.ReadByte();

                if(response != CONNECT_ACCEPT)
                {
                    throw new Exception("Incorrect response from the device!");
                }
            }
            catch (TimeoutException e)
            {
                retVal = new Exception("Failed to connect " + serialPort.PortName + 
                    " due to timeout! Check if proper port is selected or reset Arduino.\r\n" + e.Message);
                serialPort.Close();
            }
            catch (Exception e)
            {
                retVal = new Exception("Failed to connect " + serialPort.PortName + ".\r\n" + e.Message);
                serialPort.Close();
            }

            if((retVal is ExOK))
            {
                isProgrammerConnected = true;
            }

            return retVal;
        }

        /**
         * Disconnects from the open port
         */
        public Exception Disconnect()
        {
            Exception retVal = new ExOK();

            try
            {
                byte[] message = { DISCONNECT_REQUEST };
                serialPort.Write(message, 0, 1);
                byte response = (byte)serialPort.ReadByte();

                if (response != OK)
                {
                    throw new Exception("Incorrect response from the device!");
                }
            }
            catch (Exception e)
            {
                retVal = new Exception("Error while disconnecting from port " + serialPort.PortName + ". " + e.Message
                    + "Restart the device before trying to connect to it again.");
            }


            serialPort.Close();
            isProgrammerConnected = false;

            return retVal;
        }

        public Exception ReadByte(ref byte data)
        {
            Exception retVal = new ExOK();

            try
            {
                data = (byte)serialPort.ReadByte();
            }
            catch (Exception ex)
            {
                retVal = ex;
            }

            return retVal;
        }

        public Exception ExpectOK()
        {
            Exception retVal = new Exception("Something went wrong in ExpectOK()...");
            byte data = 0;

            try
            {
                data = (byte)serialPort.ReadByte();

                if(data == OK)
                {
                    throw new ExOK();
                }
                else if (data == DEVICE_FAILED)
                {
                    throw new Exception("Device has failed during programming procedure!");
                }
                else
                {
                    throw new Exception("Unexpected response: 0x" + data.ToString("X"));
                }
            }
            catch (Exception ex)
            {
                retVal = ex;
            }

            return retVal;
        }

        public Exception SendByte(byte data)
        {
            Exception retVal = new ExOK();
            byte[] buffer = { data };

            try
            {
                serialPort.Write(buffer, 0, 1);
            }
            catch (Exception ex)
            {
                retVal = ex;
            }

            return retVal;
        }

        /*
        public Exception ReadByteFromProgrammer(ref byte data)
        {
            Exception retVal = new ExOK();

            try
            {
                
                if (!isProgrammerConnected)
                {
                    throw new Exception("Programmer is not connected!");
                }

                data = (byte)serialPort.ReadByte();
            }
            catch (Exception ex)
            {
                retVal = ex;
            }

            return retVal;
        }*/

        /**
         * Request writing to the chip
         */
        public Exception SerialSendWriteRequest(uint numOfBytes, uint startAddress)
        {
            Exception retVal = new ExOK();

            try
            {
                byte[] message = { WRITE_REQUEST, 0, 0, 0, 0, 0, 0, 0, 0 };
                message[1] = (byte)((numOfBytes >> 24) & 0xFF);
                message[2] = (byte)((numOfBytes >> 16) & 0xFF);
                message[3] = (byte)((numOfBytes >> 8) & 0xFF);
                message[4] = (byte)(numOfBytes & 0xFF);

                message[5] = (byte)((startAddress >> 24) & 0xFF);
                message[6] = (byte)((startAddress >> 16) & 0xFF);
                message[7] = (byte)((startAddress >> 8) & 0xFF);
                message[8] = (byte)(startAddress & 0xFF);

                serialPort.Write(message, 0, 9);
                byte response = (byte)serialPort.ReadByte();

                if (response == DATA_SIZE_ERROR)
                {
                    throw new Exception("The requested data size is greater than the memory of the selected chip!");
                }
                else if (response != OK)
                {
                    throw new Exception("Incorrect response from the device: " + response.ToString() + "!");
                }
            }
            catch (Exception e)
            {
                retVal = new Exception("Error while reading from port " + serialPort.PortName + ". " + e.Message);
            }

            return retVal;
        }

        /**
         * Request reading from chip
         */
        public Exception SerialSendReadRequest(uint numOfBytes, uint startAddress)
        {
            Exception retVal = new ExOK();

            try
            { 
                byte[] message = { READ_REQUEST, 0, 0, 0, 0, 0, 0, 0, 0 };
                message[1] = (byte)((numOfBytes >> 24) & 0xFF);
                message[2] = (byte)((numOfBytes >> 16) & 0xFF);
                message[3] = (byte)((numOfBytes >>  8) & 0xFF);
                message[4] = (byte)(numOfBytes & 0xFF);

                message[5] = (byte)((startAddress >> 24) & 0xFF);
                message[6] = (byte)((startAddress >> 16) & 0xFF);
                message[7] = (byte)((startAddress >> 8) & 0xFF);
                message[8] = (byte)(startAddress & 0xFF);

                //throw new Exception(message[5].ToString() + " " + message[5].ToString() + " " + message[5].ToString() + " " + message[5].ToString() + " " +);

                serialPort.Write(message, 0, 9);
                byte response = (byte)serialPort.ReadByte();

                if(response == DATA_SIZE_ERROR)
                {
                    throw new Exception("The requested data size is greater than the memory of the selected chip!");
                }
                else if (response != OK)
                {
                    throw new Exception("Incorrect response from the device: " + response.ToString() + "!");
                }
            }
            catch (Exception e)
            {
                retVal = new Exception("Error while reading from port " + serialPort.PortName + ". " + e.Message);
            }

            return retVal;
        }

        public void testSendByte(byte msg)
        {
            byte[] message = { msg };
            serialPort.Write(message, 0, 1);
        }

        public byte testReadByte()
        {
            return (byte)serialPort.ReadByte();
        }

        //byte[] buffer = new byte[100];
        // byte counter = 0;

        /**
         * Reads data from serial port
         */
        /*public void ReadSerialData(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                while (serialPort.BytesToRead > 0)
                {
                    byte data = (byte)serialPort.ReadByte();
                    buffer[counter] = data;

                    if (counter == 58){
                        Log(Encoding.ASCII.GetString(buffer), true);
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }
                    
                }
            }
            catch (InvalidOperationException)
            {
                Log("Reading has failed. Port " + serialPort.PortName + " is not open.");
            }
            catch (TimeoutException)
            {
                Log("Reading from port " + serialPort.PortName + " has failed due to timeout.");                
            }
            catch (Exception ex)
            {
                Log("Reading from port " + serialPort.PortName + " has failed: " + ex.Message);              
            }
        }*/
    }
}
