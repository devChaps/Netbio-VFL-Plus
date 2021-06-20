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
    public partial class NPC_FORM : Form
    {
        public NPC_FORM()
        {
            InitializeComponent();
        }

        private void NPC_Imagebox_Click(object sender, EventArgs e)
        {

        }

        private void Lst_Entries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lst_Entries.Items.Count > 0)
            {
                int CurIDX = Lst_Header.FocusedItem.Index;
                int secIDX = Lst_Entries.SelectedIndex;

                Num_RID.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].Room_ID;
                Num_NID.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].N_ID;
                Num_CoordY.Value = Decimal.Parse(NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].coord00.ToString()); // y
                Num_CoordX.Value = Decimal.Parse(NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].coord01.ToString());
                Num_Rotation.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].rotation;
                Num_AnimID.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].Anim_ID;
                Num_Animflg.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].Anim_Flag;
                Num_AnimID2.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].Anim_ID2;
                Num_Animflg2.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].Anim_Flag2;
                Num_alive.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].Alive_flag;
                Num_bounds.Value = NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].boundary;

                // PASS NPC ID TO PICTURE SET ROUTINE
                SET_NPC_PIC(NPC_IO.NPC_DATA[CurIDX].NPC[secIDX].N_ID);

                // SET IMAGE TO CURRENT ROOM ID
          


            }
        }

        public void SET_NPC_PIC(int NPC_ID) 
        {
            try
            {
                string envo = AppDomain.CurrentDomain.BaseDirectory + "\\NPC_IMAGE\\IMG\\";
               // MessageBox.Show(envo + "N" + NPC_ID + ".jpg");
                NPC_Imagebox.Image = Image.FromFile(envo + "N" + NPC_ID + ".jpg");
            }

            catch (Exception ex)
            {
                // 
            }

        }

        private void Lst_Header_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (Lst_Header.Items.Count > 0)
                {
                    int curIDX = Lst_Header.FocusedItem.Index;
                    //  Lst_Header.Items[curIDX].Selected = true;

                    Lst_Entries.Items.Clear();

                    for (int i = 0; i < NPC_IO.SUB_HEADER[curIDX].Entries; i++)
                    {
                        Lst_Entries.Items.Add(i.ToString());
                    }

                    Lst_Entries.SetSelected(0, true);

                    NPC_IO.Set_ROOM(NPC_IO.SCE_VALUE, int.Parse(Lst_Header.Items[curIDX].SubItems[3].Text), PB_CURRENT_ROOM);

                   
                  
                   

                }
            }
            catch 
            {
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Write Functionality not yet implemented... coming soon");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PB_CURROOM_Load(object sender, EventArgs e)
        {
            if (Lst_Header.Items.Count != 0)
            {

                //Lst_Header.Items[0].Selected = true;
                //Lst_Header.Items[0].Focused = true;
          
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
