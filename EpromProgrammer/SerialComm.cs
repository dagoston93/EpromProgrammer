using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;



namespace EpromProgrammer
{
    public partial class Form1 : Form
    {
        /**
         * Define the required constants
         */
        const byte CONNECT_REQUEST = 0xDA;
        const byte DISCONNECT_REQUEST = 0xFF;
        const byte CONNECT_ACCEPT = 0xAD;
        const byte READ_REQUEST = 0xAA;
        const byte OK = 0xDD;
        const byte DATA_SIZE_ERROR = 0x01;

        /**
         * Define the required objects and variables
         */ 
        private SerialPort serialPort;
        private bool isProgrammerConnected = false;

        /**
         * Initializes the serial port
         */
        public void SerialInit()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 500000;
            serialPort.ReadTimeout = 3000;
            serialPort.WriteTimeout = 3000;
            //serialPort.ReadBufferSize = 131072;
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(ReadSerialData);
        }

        /**
         * Find available serial ports
         */
        public void FindSerialPorts()
        {
            string[] availablePorts = SerialPort.GetPortNames();
            ClearComboBox(cbPort);
            AddRangeComboBox(cbPort, availablePorts);
        }

        /**
         * Connects to the selected port
         */
        public void SerialConnect()
        {
            // Open the port
            try
            {
                Log("Connecting to " + cbPort.Text + "...");
                serialPort.PortName = cbPort.Text;
                serialPort.Open();
            }
            catch (UnauthorizedAccessException)
            {
                Log("Unauthorized access exception while connecting: " + serialPort.PortName);
                serialPort.Close();
                return;
            }
            catch (Exception e)
            {
                Log("Failed to connect " + serialPort.PortName + ". " + e.Message);
                serialPort.Close();
                return;
            }

            // Identify device
            try
            {
                byte[] message = { CONNECT_REQUEST };
                serialPort.Write(message, 0, 1);
                byte response = (byte)serialPort.ReadByte();

                if(response != CONNECT_ACCEPT)
                {
                    throw new Exception("Incorrect response from the device connected to " + serialPort.PortName + "!");
                }
            }
            catch (TimeoutException)
            {
                Log("Failed to connect " + serialPort.PortName + " due to timeout! Check if proper port is selected or reset Arduino.");
                serialPort.Close();
                return;
            }
            catch (Exception e)
            {
                Log("Failed to connect " + serialPort.PortName + ". " + e.Message);
                serialPort.Close();
                return;
            }

           
            isProgrammerConnected = true;
            Log("Connected succesfully!");
            SetControlText(lblConnStatus, "Conencted");
            SetControlText(btnConnect, "Disconnect");
            SetControlEnabled(cbPort, false);
            SetControlEnabled(btnRefresh, false);
        }

        /**
         * Disconnects from the open port
         */
        public void SerialDisconnect()
        {
            try
            {
                byte[] message = { DISCONNECT_REQUEST };
                serialPort.Write(message, 0, 1);
                byte response = (byte)serialPort.ReadByte();

                if (response != OK)
                {
                    throw new Exception("Incorrect response from the device connected to " + serialPort.PortName + "!");
                }
            }
            catch (Exception e)
            {
                Log("Error while disconnecting from port " + serialPort.PortName + ". " + e.Message);
            }


            serialPort.Close();
            isProgrammerConnected = false;
            Log("Disconnected from port " + serialPort.PortName + ". ");

            SetControlEnabled(cbPort, true);
            SetControlEnabled(btnRefresh, true);
            SetControlText(btnConnect, "Connect");
            SetControlText(lblConnStatus, "Disconnected");
        }

        /**
         * Request reading from chip
         */
        public void SerialSendReadRequest(uint numOfBytes)
        {
            try
            { 
                byte[] message = { READ_REQUEST, 0, 0, 0, 0 };
                message[1] = (byte)((numOfBytes >> 24) & 0xFF);
                message[2] = (byte)((numOfBytes >> 16) & 0xFF);
                message[3] = (byte)((numOfBytes >>  8) & 0xFF);
                message[4] = (byte)(numOfBytes & 0xFF);

                serialPort.Write(message, 0, 5);
                byte response = (byte)serialPort.ReadByte();

                if(response == DATA_SIZE_ERROR)
                {
                    throw new Exception("The requested data size is greater than the memory of the selected chip!");
                }
                else if (response != OK)
                {
                    throw new Exception("Incorrect response from the device connected to " + serialPort.PortName + ": "+ response.ToString() + "!");
                }
            }
            catch (Exception e)
            {
                Log("Error while reading from port " + serialPort.PortName + ". " + e.Message);
            }
        }

        byte[] buffer = new byte[100];
        byte counter = 0;

        /**
         * Reads data from serial port
         */
        public void ReadSerialData(object sender, SerialDataReceivedEventArgs e)
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
        }
    }
}
