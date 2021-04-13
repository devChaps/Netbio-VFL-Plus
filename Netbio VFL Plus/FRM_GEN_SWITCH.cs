using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Netbio_VFL_Plus
{
    public partial class FRM_GEN_SWITCH : Form
    {
        public FRM_GEN_SWITCH()
        {
            InitializeComponent();
        }

        private void RB_SNP00_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_SNP00.Checked) 
            {
                RDT_IO.SNP_FLAG = 1; // FOOTSTEP SWITCH
            }

        }
        private void RB_SNP01_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_SNP01.Checked) 
            {
                RDT_IO.SNP_FLAG = 2; // GENERIC ROOM AUDIO             
            }
        }

        private void BTN_CONFIRM_Click(object sender, EventArgs e)
        {
            // close form
            this.Close();
        }
    }
}
