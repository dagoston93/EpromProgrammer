using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpromProgrammer
{
    /**
     * List the supported chips
     */
    public partial class Form1 : Form
    {
        private List<Chip> supportedChips = new List<Chip> {
            new Chip(0, "TMS 27C0A10-12", 128),
            new Chip(1, "Non-existing Test chip", 256)
        };
    }

    /**
     * This class represents a supported chip
     */
    public struct Chip
    {
        public Chip(uint pId, string pName, uint pMemorySizeKb)
        {
            this.id = pId;
            this.name = pName;
            this.memorySizeKb = pMemorySizeKb;
        }

        public uint id { private set; get; }
        public string name { private set; get; }
        public uint memorySizeKb { private set; get; }
    }
}
