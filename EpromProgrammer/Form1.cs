using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpromProgrammer
{
    public partial class Form1 : Form
    {
        /**
         * Define the supported chips
         */ 
        private List<Chip> supportedChips= new List<Chip> {
            new Chip(0, "TMS 27C0A10-12", 128)
        };

        /**
         * The constructor
         */ 
        public Form1()
        {
            // Initialize the components
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
