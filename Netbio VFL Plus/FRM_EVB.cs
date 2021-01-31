using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;


namespace Netbio_VFL_Plus
{
    public partial class FRM_EVB : Form
    {



        public FRM_DEBUG EVB_DEBUG = new FRM_DEBUG();

        public FRM_EVB()
        {
            InitializeComponent();

            EVB_DEBUG.Text = "EVB DEBUG LOG";
            EVB_DEBUG.BackColor = Color.Gray;

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
                // LV_INTCODE.SelectedItems.Clear();

             
                    int idx = LV_BYTECODE.SelectedIndices[0]; // GET RELATIVE INDEX

                    //  LV_INTCODE.SelectedItems.Clear();
                    LV_INTCODE.Items[idx].Selected = true;

                    LV_INTCODE.EnsureVisible(idx);

                

               
           

            }
            catch (System.IO.IOException IOX)
            {

            }

            catch (System.NullReferenceException NRE)
            {

            }
            catch (Exception ex) 
            {
            
            }

        }

        private void LV_INTCODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LV_BYTECODE.SelectedItems.Clear();


            try
            {



                  int idx = LV_INTCODE.SelectedIndices[0];

                    LV_BYTECODE.Items[idx].Selected = true;

                    LV_BYTECODE.EnsureVisible(idx);



                TB_DETAILS.Text = EVB_PARSER.SET_COMMENT(LV_INTCODE, LV_BYTECODE, TB_DETAILS);


            }

            catch (Exception ex) 
            {
            
            
            }
          
     

            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Toggle_Display();
        }

        private void TSB_SCRIPT_DUMP_Click(object sender, EventArgs e)
        {
            int total = LV_INTCODE.Items.Count;

          //  EVB_DEBUG.Clear();

            try
            {
                for (int i = 0; i < total; i++)
                {
                 //   using(StreamWriter sw = new StreamWriter(ScenarioHandler.ARC2_SCE(EVB_PARSER. )))



                //    EVB_DEBUG.AppendText(LV_INTCODE.Items[i].SubItems[1].Text + "\n");
                }
            }

            catch (System.ArgumentOutOfRangeException OOR) {

                MessageBox.Show("DONE");
            }


        }

        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void TSB_OPSCAN_Click(object sender, EventArgs e)
        {
            string opcode = Interaction.InputBox("Enter the 4 byte opcode you want all instances of for example '39000002'", "OP_SCAN");

            bool QueryMatch = false;

            EVB_DEBUG.DEBUG_LOG.Clear();

            for (int i = 0; i < LV_BYTECODE.Items.Count; i++) 
            {

                string bytestr = LV_BYTECODE.Items[i].SubItems[1].Text;


                if (bytestr.Substring(0, 8) == opcode)
                {
                    QueryMatch = true;
                    EVB_DEBUG.DEBUG_LOG.AppendText(bytestr  + "\n");
                }
             




            }

            if (QueryMatch) { EVB_DEBUG.ShowDialog(); }
            else {
                MessageBox.Show("No match or incorrect query..", "NO MATCH", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }





            //perform scan

        }

        private void TSB_DEBUG_Click(object sender, EventArgs e)
        {
            EVB_DEBUG.ShowDialog();
            
        }

        private void TSB_CONFIG_Click(object sender, EventArgs e)
        {
            FontDialog FD = new FontDialog();
            FD.ShowColor = true;
            FD.ShowApply = true;
            FD.ShowEffects = true;
            FD.ShowHelp = true;

            FD.ShowDialog();

            LV_INTCODE.Font = FD.Font;
        }
    }
}
