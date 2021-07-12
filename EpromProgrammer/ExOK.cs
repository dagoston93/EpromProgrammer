using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpromProgrammer
{
    /**
     * This exception is returned if the operation was successful.
     */ 
    class ExOK : Exception
    {
        public ExOK() : base("Success!"){}
    }
}
