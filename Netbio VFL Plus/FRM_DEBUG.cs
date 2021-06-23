using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Netbio_VFL_Plus
{
    public partial class FRM_DEBUG : Form
    {
        public FRM_DEBUG()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void BTN_CLEAR_Click(object sender, EventArgs e)
        {
            DEBUG_LOG.Clear();
        }

        private void FRM_DEBUG_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true; //hides the form, cancels closing event
        }

        private void BTN_EXPORT_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\DEBUG_LOG.txt"))
            {
                //write debug log to file..
                sw.Write(DEBUG_LOG.Text);
            }
        }
    }
}
