using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpromProgrammer
{
    /**
    * This exception is thrown if the file we are trying to create exists already
    */
    class FileAlreadyExistsException : Exception
    {
        public FileAlreadyExistsException(string path) : base("File already exists: " + path) { }
    }
}
