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


           for(int i = 0; i < FRM_MAIN.NAME_OBJ.name.Length; i++) 
            {
                // add shit to listview
                LV_NAMES.Items.Add(i.ToString());
                LV_NAMES.Items[i].SubItems.Add(FRM_MAIN.NAME_OBJ.offsets[i].ToString());
                LV_NAMES.Items[i].SubItems.Add(FRM_MAIN.NAME_OBJ.name[i]);
            

            }



        }

        private void BTN_UPDATE_Click(object sender, EventArgs e)
        {

        }

        private void LV_NAMES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_NAMES.SelectedItems != null && LV_NAMES.SelectedItems.Count > 0)
            {
                int sel_idx = LV_NAMES.FocusedItem.Index;

                TB_TEXT.Text = LV_NAMES.Items[sel_idx].SubItems[2].Text;
                //....your code here
            }

            

        }
    }
}
