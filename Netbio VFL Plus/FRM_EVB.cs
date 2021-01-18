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
    public partial class FRM_EVB : Form
    {
        public FRM_EVB()
        {
            InitializeComponent();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) { switch (keyData) { case (Keys.F5): {TSB_TOGGLE.PerformClick(); break; } } return base.ProcessCmdKey(ref msg, keyData); }

        public void Toggle_Display() // Toggle EVB Display MOde
        {
            if (LV_INTCODE.Visible)
            {
                LV_INTCODE.Visible = false;
                LV_BYTECODE.Visible = true;
            }
            else
            {
                LV_INTCODE.Visible = true;
                LV_BYTECODE.Visible = false;
            }

        }
        private void BTN_TOGGLE_ButtonClick(object sender, EventArgs e)
        {
            Toggle_Display();
        }

        private void LV_BYTECODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = LV_BYTECODE.FocusedItem.Index; // GET RELATIVE INDEX
                EVB_DEBUG.AppendText(LV_BYTECODE.Items[idx].SubItems[1].Text + "\n"); // DUMP SELECTED BYTE CODE TO LOG
            }
            catch (System.IO.IOException IOX)
            {


            }

            catch (System.NullReferenceException NRE) { 
            
            }
        }

        private void LV_INTCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = LV_INTCODE.FocusedItem.Index;

            LV_BYTECODE.SelectedItems.Clear();

            LV_BYTECODE.Items[idx].Selected = true;


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Toggle_Display();
        }

        private void TSB_SCRIPT_DUMP_Click(object sender, EventArgs e)
        {
            int total = LV_INTCODE.Items.Count;

            EVB_DEBUG.Clear();

            try
            {
                for (int i = 0; i < total; i++)
                {
                    EVB_DEBUG.AppendText(LV_INTCODE.Items[i].SubItems[1].Text + "\n");
                }
            }

            catch (System.ArgumentOutOfRangeException OOR) {

                MessageBox.Show("DONE");
            }


        }
    }
}
