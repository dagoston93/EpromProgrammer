using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpromProgrammer
{
    public class FileManager : IDisposable
    {
        private FileStream fileStream = null;

        // Track whether Dispose has been called.
        private bool disposed = false;

        /*
         * The constructor
         */
        public FileManager() { }

        /**
         * Creates a file with the given name and given path
         */ 
        public Exception CreateFile(string folder, string fileName, bool overwrite = false)
        {
            Exception retVal = new ExOK();
            string path = folder + @"\" + fileName;

            // Check if file exists
            bool fileExists = File.Exists(path);
            
            try
            {
                // If file exists we throw the proper exception
                if (fileExists && !overwrite)
                {
                    throw new FileAlreadyExistsException(path);
                }

                fileStream = File.Create(path);
            }
            catch (Exception ex)
            {
                retVal = ex;
            }

            return retVal;
        }

        /**
         * Writes a byte to the file if it is open
         */
        public Exception WriteByte(byte data)
        {
            Exception retVal = new ExOK();

            if (fileStream != null)
            {
                fileStream.WriteByte(data);
            }

            return retVal;
        }

        /*
         * Implement the IDisposable interface
         */ 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // If disposing is true, dispose all resources.
                if (disposing)
                {
                    if (fileStream != null)
                    {
                        fileStream.Dispose();
                    }
                }

                // Disposing has been done.
                disposed = true;
            }
        }

        ~FileManager()
        {
            Dispose(false);
        }
    }
}
