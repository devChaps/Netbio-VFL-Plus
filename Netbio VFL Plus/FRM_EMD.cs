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
    public partial class FRM_EMD : Form
    {

        public string ARC2_SCE(string archive_string)
        {
            string SCE_NAME = archive_string.Substring(2, 2);

            switch (SCE_NAME.ToLower())
            {
                case "01": return "Outbreak"; break;
                case "02": return "Hellfire"; break;
                case "28": return "The Hive"; break;
                case "35": return "Below Freezing Point"; break;
                case "41": return "Decisions, Decisions"; break;
                case "06": return "End of the Road"; break;
                case "15": return "Desperate Times"; break;
                case "10": return "Underbelly"; break;
                case "26": return "Flashback"; break;
                case "20": return "Training Ground"; break;
                case "21": return "Showdown 1"; break;
                case "22": return "Showdown 2"; break;
                case "23": return "Showdown 3"; break;
                case "27": return "Elimination 1"; break;
                case "29": return "Elimination 2"; break;
                case "30": return "Elimination 3"; break;
            }


            return string.Empty;

        }


        public FRM_EMD()
        {
          

            InitializeComponent();

          
     
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void LB_EMD_OFFSETS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = LB_EMD_OFFSETS.SelectedIndex;
            

            LB_EMD_TOTAL.Items.Clear();

            for (int x = 0; x < EMD_IO.EMD_DATA[LB_EMD_OFFSETS.SelectedIndices[0]].Enemy.Length; x++) 
            {
                LB_EMD_TOTAL.Items.Add(x);
            }

            // load picture using first enemy block, all room ids should the same for each room relative enemy list..
            EMD_IO.Set_ROOM(EMD_IO.SCE_VALUE, EMD_IO.EMD_DATA[i].Enemy[0].Room_ID, PB_EMD_ROOM);

            // LB_EMD_TOTAL.SetSelected(0, true);

        }

        private void LB_EMD_TOTAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = LB_EMD_TOTAL.SelectedIndices[0];
            int x = LB_EMD_OFFSETS.SelectedIndices[0];

            int idx = LB_EMD_TOTAL.SelectedIndex;
            string nbdstring = string.Empty;

            string nbdval0 = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID0.ToString("X2");
            string nbdval1 = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID1.ToString("X2");
            
            nbdstring = nbdval0 + nbdval1;


            // CHECK IF KEY EXISTS
            if (EMD_IO.ENEMY_NAME_LUT.ContainsKey(nbdstring))
            {
                CB_EMD_SEL.SelectedItem = EMD_IO.ENEMY_NAME_LUT[nbdstring];
            }
            else 
            {
                MessageBox.Show("EMD LUT KEY NOT PRESENT");
            }
            //   MessageBox.Show(idx.ToString());


            EMD_POS_DEC_X.Value = EMD_IO.EMD_DATA[x].Enemy[idx].X;
            EMD_POS_DEC_Y.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Y;
            EMD_POS_DEC_Z.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Z;
            EMD_POS_DEC_R.Value = EMD_IO.EMD_DATA[x].Enemy[idx].R;


            EMD_POS_HEX_X.Value = EMD_IO.EMD_DATA[x].Enemy[idx].X;
            EMD_POS_HEX_Y.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Y;
            EMD_POS_HEX_Z.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Z;
            EMD_POS_HEX_R.Value = EMD_IO.EMD_DATA[x].Enemy[idx].R;
            EMD_ROOMID.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Room_ID;

            EMD_NBDID00.Value = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID0;
            EMD_NBDID01.Value = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID1;

            EMD_TAG.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Tag;
            EMD_INDEX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].No;
       
            EMD_SCALE.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SCALE;
            

            EMD_SPEED.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SPEED;
            EMD_HP.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_HP;
            EMD_FOLLOW_FLAG.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_FOLLOW;
            EMD_STR.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_STR;


           

            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 01) { CB_EASY.Checked = true; CB_NORMAL.Checked = false; CB_HARD.Checked = false; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 03) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = false; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 12) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = true; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 15) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = true; CB_VH.Checked = true; }


  


            EMD_IO.Set_ROOM(EMD_IO.SCE_VALUE, EMD_IO.EMD_DATA[x].Enemy[idx].Room_ID, PB_EMD_ROOM);
            EMD_IO.Set_pic(EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID0, EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID1, PB_EMD);

            EMD_BYTECODE.Clear();
            EMD_BYTECODE.Text = ByteArrayToString(EMD_IO.EMD_DATA[x].Enemy[idx].Emd_block);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        private void LBL_NBD_Click(object sender, EventArgs e)
        {

        }

        private void LBL_TAG_Click(object sender, EventArgs e)
        {

        }

        private void BTN_EMDSAVE_Click(object sender, EventArgs e)
        {

            int i = LB_EMD_OFFSETS.SelectedIndex;
            int sel_off = (int)LB_EMD_OFFSETS.Items[i];

            int x = LB_EMD_TOTAL.SelectedIndex;



            // CUR ARCHIVE OFFSET + NETBIO OFFSET + EMD OFFSET * SELECTED ENTRY + 96
            int total = EMD_IO.ARCHIVE_OFFSET + FRM_MAIN.NETBIO00_OFFSET + sel_off + EMD_IO.EMD_OFFSET;

            total += x * 96;

            MessageBox.Show(total.ToString());




            //    MessageBox.Show(sel_off.ToString());



        }

        private void FRM_EMD_Load(object sender, EventArgs e)
        {

            foreach (string em in EMD_IO.ENEMY_NAME_LUT.Values) 
            {
                CB_EMD_SEL.Items.Add(em);   
            }


            LB_EMD_OFFSETS.SetSelected(0, true);
            LB_EMD_TOTAL.SetSelected(0, true);









        }

        private void LB_EMD_TOTAL_Click(object sender, EventArgs e)
        {


            //int i = LB_EMD_TOTAL.SelectedIndices[0];
            //int x = LB_EMD_OFFSETS.SelectedIndices[0];


            //int idx = LB_EMD_TOTAL.SelectedIndex;


            ////   MessageBox.Show(idx.ToString());



            //EMD_POS_DEC_X.Value = EMD_IO.EMD_DATA[x].Enemy[idx].X;
            //EMD_POS_DEC_Y.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Y;
            //EMD_POS_DEC_Z.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Z;
            //EMD_POS_DEC_R.Value = EMD_IO.EMD_DATA[x].Enemy[idx].R;


            //EMD_POS_HEX_X.Value = EMD_IO.EMD_DATA[x].Enemy[idx].X;
            //EMD_POS_HEX_Y.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Y;
            //EMD_POS_HEX_Z.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Z;
            //EMD_POS_HEX_R.Value = EMD_IO.EMD_DATA[x].Enemy[idx].R;


            //EMD_NBDID00.Value = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID0;
            //EMD_NBDID01.Value = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID1;

            //EMD_TAG.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Tag;
            //EMD_INDEX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].No;
            //EMD_DFC.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_DFC;
            //EMD_SCALE.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SCALE;

            //EMD_SPEED.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SPEED;
            //EMD_HP.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_HP;
            //EMD_FOLLOW_FLAG.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_FOLLOW;
            //EMD_STR.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_STR;
            //// EMD_DFC.Value = EMD_IO.EMD_DATA[x].Enemy[i].EMD





            //EMD_IO.Set_ROOM(EMD_IO.SCE_VALUE, EMD_IO.EMD_DATA[x].Enemy[idx].Room_ID, PB_EMD_ROOM);
            //EMD_IO.Set_pic(EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID0, EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID1, PB_EMD);

            //EMD_BYTECODE.Clear();
            //EMD_BYTECODE.Text = ByteArrayToString(EMD_IO.EMD_DATA[x].Enemy[idx].Emd_block);


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
