using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpromProgrammer
{
    public partial class Form1 : Form
    {
        public Exception createFile(string folder, string fileName, ref FileStream fs)
        {
            string path = folder + @"\" + fileName;
            Exception retVal = new ExOK();

            // Check if file exists
            bool fileExists = File.Exists(path);
            bool overWriteExisting = false;

            // If file exists we ask if user wants overwrite
            if (fileExists)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(path + " already exists.\r\n Do you want to overwrite?", "File exists!", buttons);

                if (result == DialogResult.Yes)
                {
                    overWriteExisting = true;
                }
            }

            // If file doesn't exist or user wants to overwrite we try to create an empty file
            if (!fileExists || overWriteExisting)
            {
                try
                {
                    fs = File.Create(path);
                }
                catch (Exception ex)
                {
                    retVal = ex;
                }
            }

            return retVal;
        }
    }
}
