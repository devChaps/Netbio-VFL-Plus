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
        public FRM_SP_ITEM SP_ITEM_FORM = new FRM_SP_ITEM();

        public EVB_PARSER.x35010003[] SP_ITEMS = new EVB_PARSER.x35010003[0];

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
                             
                    int idx = LV_BYTECODE.SelectedIndices[0]; // GET RELATIVE INDEX
                    //  LV_INTCODE.SelectedItems.Clear();
                    LV_INTCODE.Items[idx].Selected = true;
                    LV_INTCODE.EnsureVisible(idx);


                // DUMP SELECTED OPCODE TO DEBUG LOG


                EVB_DEBUG.DEBUG_LOG.AppendText(LV_BYTECODE.Items[idx].SubItems[1].Text + "\n");

                LBL_OFFSET.Text = LV_BYTECODE.Items[idx].SubItems[2].Text;
               
           

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
            int int_total = LV_INTCODE.Items.Count;
            int byte_total = LV_BYTECODE.Items.Count;


            try
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + LBL_EVB_FNAME.Text + "_" + "event_INT.txt"))
                {
                    for (int i = 0; i < int_total - 1; i++)
                    {


                        if (LV_INTCODE.Items[i].SubItems[1].Text != string.Empty)
                        {
                            // MessageBox.Show(LV_INTCODE.Items[i].SubItems[1].Text);
                            sw.WriteLine(LV_INTCODE.Items[i].SubItems[1].Text);
                        }
                    }

                }

                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + LBL_EVB_FNAME.Text + "_" + "event_BYTE.txt"))
                {
                    for (int i = 0; i < byte_total - 1; i++)
                    {

                        if (LV_BYTECODE.Items[i].SubItems[1].Text != string.Empty)
                        {
                            // MessageBox.Show(LV_INTCODE.Items[i].SubItems[1].Text);
                            sw.WriteLine(LV_BYTECODE.Items[i].SubItems[1].Text);
                        }


                    }
                }

                MessageBox.Show("Event Script succesfully Written to app directory", "Success!");
            }
            catch 
            {
                MessageBox.Show("Something Went Wrong..", "Oops");
            
            }


        }






        private void propertyGrid1_Click(object sender, EventArgs e)
        {

        }

        private void TSB_OPSCAN_Click(object sender, EventArgs e)
        {

            try
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
                        EVB_DEBUG.DEBUG_LOG.AppendText(bytestr + "\n");
                    }





                }



                if (QueryMatch) { EVB_DEBUG.ShowDialog(); }
                else
                {
                    MessageBox.Show("No match or incorrect query..", "NO MATCH", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (System.ArgumentOutOfRangeException AOE)
            {

            }



            //perform scan

        }

        private void TSB_DEBUG_Click(object sender, EventArgs e)
        {
            EVB_DEBUG.Show();
            
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

        private void BTN_SP_ITEM_Click(object sender, EventArgs e)
        {

            try
            {

                string opcode = "35010003"; // SP.ITEM OPCODE ID
                List<string> sp_opcodes = new List<string>();

                int _spcount = 0;

                for (int i = 0; i < LV_BYTECODE.Items.Count - 1; i++)
                {
                  
                        string bytestr = LV_BYTECODE.Items[i].SubItems[1].Text;

                            if (bytestr.Substring(0, 8) == opcode)
                            {
                                _spcount++; // count every instance
                                sp_opcodes.Add(bytestr);
                                //  EVB_DEBUG.DEBUG_LOG.AppendText(bytestr + "\n"); 

                 
                            }
                      

                }


                Array.Resize(ref SP_ITEMS, _spcount);
               

                // CREATE SP ITEM ARRAY FOR EACH ONE FOUND .. 
              
                

            //    MessageBox.Show(_spcount.ToString());


                // LOOP THROUGH DETECTED SP ITEMS, ADD TO CONTROLS / CONVERT BYTESTR TO BYTE ARRAY
               for (int i = 0; i < SP_ITEMS.Length; i++)
               {
                    SP_ITEMS[i].SpecialItemData = new byte[32];
                    SP_ITEMS[i].SpecialItemData = Encoding.ASCII.GetBytes(sp_opcodes[i]);
                    SP_ITEM_FORM.LB_SP_ITEM.Items.Add(i);
                    SP_ITEM_FORM.CB_SP_ITEM_SEL.Items.Add(sp_opcodes[i]);

                }


                SP_ITEM_FORM.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Sp.Items found in scan");

            }


        }

        private void TSB_DOORSCAN_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
