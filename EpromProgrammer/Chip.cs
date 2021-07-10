using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpromProgrammer
{
    /**
     * This class represents a supported chip
     */ 
    public struct Chip
    {
        public Chip(int pId, string pName, int pMemorySizeKb)
        {
            this.id = pId;
            this.name = pName;
            this.memorySizeKb = pMemorySizeKb;
        }

        public int id;
        public string name;
        public int memorySizeKb;
    }
}
