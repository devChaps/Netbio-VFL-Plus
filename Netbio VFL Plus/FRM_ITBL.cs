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
    public partial class FRM_ITBL : Form
    {
        public FRM_ITBL()
        {
            InitializeComponent();
        }

        private void LV_ItemTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(LV_ItemTable.FocusedItem.SubItems[1].Text) != -1)
            {
                Nud_TBL_Index.Value = int.Parse(LV_ItemTable.FocusedItem.SubItems[0].Text);
                NUD_TBL_ItemID.Value = int.Parse(LV_ItemTable.FocusedItem.SubItems[1].Text);
                NUD_TBL_OCCURENCE.Value = int.Parse(LV_ItemTable.FocusedItem.SubItems[3].Text);
                NUD_TBL_QUANTITY.Value = int.Parse(LV_ItemTable.FocusedItem.SubItems[4].Text);
            }


            foreach (string item_name in CMB_ITEMNAME.Items)
            {
                if (item_name == LV_ItemTable.FocusedItem.SubItems[2].Text)
                {
                    CMB_ITEMNAME.SelectedItem = item_name;
                }
            }

        }

        private void Btn_TBL_UPDATE_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Write Feature not yet implemented.. wait for future update");
        }

        private void NUD_TBL_QUANTITY_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
