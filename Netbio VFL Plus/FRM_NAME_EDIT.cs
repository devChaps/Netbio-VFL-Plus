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
    public partial class FRM_NAME_EDIT : Form
    {
        public FRM_NAME_EDIT()
        {
            InitializeComponent();
        }

        private void FRM_NAME_EDIT_Load(object sender, EventArgs e)
        {

            LV_NAMES.Items.Clear(); // prevent dupes

                List<string> fList = new List<string>();


                string[] names = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\NPC_V2.txt");


            try
            {
                if (FRM_MAIN.NAME_OBJ.name != null)
                {

                    for (int i = 0; i < FRM_MAIN.NAME_OBJ.name.Length; i++)
                    {
                        // add shit to listview

                        if (FRM_MAIN.NAME_OBJ.name[i] == null) { i++; }

                        LV_NAMES.Items.Add(i.ToString());
                        LV_NAMES.Items[i].SubItems.Add(FRM_MAIN.NAME_OBJ.offsets[i].ToString());



                        LV_NAMES.Items[i].SubItems.Add(FRM_MAIN.NAME_OBJ.name[i]);
                        LV_NAMES.Items[i].SubItems.Add(names[i]);


                    }
                }
                else 
                {
                    MessageBox.Show("No Disc loaded to read Character Name Table", "!", MessageBoxButtons.OK);
                }
            }
            catch 
            {
                throw;
            }

        }

        private void BTN_UPDATE_Click(object sender, EventArgs e)
        {
            int i = LV_NAMES.SelectedIndices[0];
            int offset = int.Parse(LV_NAMES.Items[i].SubItems[1].Text);
            string new_text = TB_TEXT.Text; // store the newly entered text

            // update listview
            LV_NAMES.Items[i].SubItems[2].Text = new_text;


            // WRITE ENTERED DATA TO OFFSET
             using(FileStream fs = new FileStream(Image_Data.IMG_FP, FileMode.Open)) 
            {
                using (BinaryWriter bw = new BinaryWriter(fs)) 
                {
                    fs.Seek(offset - 1, SeekOrigin.Begin);
                    bw.Write(new_text);


                
                }


            }
        }

        private void LV_NAMES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_NAMES.SelectedItems != null && LV_NAMES.SelectedItems.Count > 0)
            {
                int sel_idx = LV_NAMES.FocusedItem.Index;
                int sel_offset = int.Parse(LV_NAMES.Items[sel_idx].SubItems[1].Text);
                TB_TEXT.Text = LV_NAMES.Items[sel_idx].SubItems[2].Text;



                //....your code here
            }

            

        }

        private void TB_TEXT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
