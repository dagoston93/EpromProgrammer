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
        private SerialPort serialPort;

        /**
         * Initializes the serial port
         */
        public void SerialInit()
        {
            serialPort = new SerialPort();
            serialPort.BaudRate = 500000;
            serialPort.ReadTimeout = 3000;
            serialPort.WriteTimeout = 3000;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(ReadSerialData);
        }

        /**
         * Find available serial ports
         */
        public void FindSerialPorts()
        {
            cbPort.Items.Clear();
            string[] availablePorts = SerialPort.GetPortNames();
            cbPort.Items.AddRange(availablePorts);
        }

        /**
         * Connects to the selected port
         */
        public void SerialConnect()
        {
            try
            {
                Log("Connecting to " + cbPort.Text);
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

            cbPort.Enabled = false;
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
