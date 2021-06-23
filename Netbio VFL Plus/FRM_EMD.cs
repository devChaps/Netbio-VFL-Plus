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
using DiscUtils;
using DiscUtils.Iso9660;

namespace Netbio_VFL_Plus
{
    public partial class FRM_EMD : Form
    {


       public FRM_MAIN MainForm;
       public int afs_index; // hold the emd selected index for reload..
        public FRM_DEBUG EMD_DEBUG = new FRM_DEBUG();
       

       

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


        // CONVERTS RADIO BUTTON VALUES BACK TO BYTE/BITMASK
        public byte EMD_DFC_CONVERT(CheckBox EASY, CheckBox NORMAL, CheckBox HARD, CheckBox VH) 
        {

            byte total = 0;

            if (EASY.Checked) { total += 1; }
            if (NORMAL.Checked) { total += 2; }
            if (HARD.Checked) { total += 4; }
            if (VH.Checked) { total += 8; }


            total = (byte)(total & 0x0f);

            return total;
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


            LBL_OFFSET.Text = LB_EMD_OFFSETS.SelectedItem.ToString();

            LB_EMD_TOTAL.Items.Clear();

            for (int x = 0; x < EMD_IO.EMD_DATA[LB_EMD_OFFSETS.SelectedIndices[0]].Enemy.Length; x++) 
            {
                LB_EMD_TOTAL.Items.Add(x);
            }

            // load picture using first enemy block, all room ids should the same for each room relative enemy list..
            EMD_IO.Set_ROOM(EMD_IO.SCE_VALUE, EMD_IO.EMD_DATA[i].Enemy[0].MAP, PB_EMD_ROOM);

            // LB_EMD_TOTAL.SetSelected(0, true);

        }

        private void LB_EMD_TOTAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = LB_EMD_TOTAL.SelectedIndices[0];
            int x = LB_EMD_OFFSETS.SelectedIndices[0];

            int idx = LB_EMD_TOTAL.SelectedIndex;
            string nbdstring = string.Empty;

           // MessageBox.Show(x.ToString() + "  : idx: " + idx.ToString());

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



            if (nbdval0 == "01")
            {
                CB_ZANIM.Show();

            }
            else {
                CB_ZANIM.Hide();
                EMD_ANIM.Value = 0;
            }


           

            // CHECK IF KEY EXISTS
            if (EMD_IO.ZOMBIE_ANIMATION_LUT.ContainsKey(EMD_IO.EMD_DATA[x].Enemy[i].Movement_Pattern))
            {
                CB_ZANIM.SelectedItem = EMD_IO.ZOMBIE_ANIMATION_LUT[EMD_IO.EMD_DATA[x].Enemy[i].Movement_Pattern];
            }
            else
            {
                MessageBox.Show("ANIM LUT KEY NOT AVAILABLE");
            }

            //   MessageBox.Show(idx.ToString());


            // Set disable enemy box
            if (EMD_IO.EMD_DATA[x].Enemy[idx].Disable_Enemy == 0) { CB_ATK_SUPRESS.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[idx].Disable_Enemy == 1) { CB_ATK_SUPRESS.Checked = true; }

            // SET REVIVE FLAG
            if (EMD_IO.EMD_DATA[x].Enemy[idx].Respawn == 0) { CB_RESPAWN.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[idx].Respawn == 1) { CB_RESPAWN.Checked = true; }

            EMD_RESPAWN_TIME.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Respawn_Time;

            if (EMD_IO.EMD_DATA[x].Enemy[idx].FOLLOW == 0) { CB_EMD_FOLLOW.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[idx].FOLLOW == 1) { CB_EMD_FOLLOW.Checked = true; }

           

            EMD_POS_DEC_X.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Position_X;
            EMD_POS_DEC_Y.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Position_Y;
            EMD_POS_DEC_Z.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Position_Z;
            EMD_POS_DEC_RX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].RotationX;
            EMD_POS_DEC_RY.Value = EMD_IO.EMD_DATA[x].Enemy[idx].RotationY;


            EMD_POS_HEX_X.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Position_X;
            EMD_POS_HEX_Y.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Position_Y;
            EMD_POS_HEX_Z.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Position_Z;
            EMD_POS_HEX_RX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].RotationX;
            EMD_POS_HEX_RY.Value = EMD_IO.EMD_DATA[x].Enemy[idx].RotationY;
            EMD_ROOMID.Value = EMD_IO.EMD_DATA[x].Enemy[idx].MAP; 

            EMD_NBDID00.Value = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID0;
            EMD_NBDID01.Value = EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID1;

            EMD_ATTACK_DELAY.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Attack_Delay;

            EMD_TAG.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Tag;
            EMD_INDEX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].No;

            EMD_SCALEX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Scale_X;
            EMD_SCALEY.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Scale_Y;
            EMD_SCALEZ.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Scale_Z;

            EMD_ANIM.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Movement_Pattern; // fix this
            EMD_SPAWNIDX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Spawn_Index;
            EMD_FOLLOW_TIME.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Follow_Time;
            EMD_TRACKING.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Tracking_Distance;
            EMD_KDR.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Knockdown_Rate;
            EMD_KDT.Value = EMD_IO.EMD_DATA[x].Enemy[idx].KnockDown_Time;




            EMD_SPEED.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Enemy_Speed;
            EMD_HP.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Enemy_HP;
           
            EMD_STR.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Enemy_Str;
         
           // STILL NEEDS TO BE FIXED

            if (EMD_IO.EMD_DATA[x].Enemy[i].Difficulty == 01) { CB_EASY.Checked = true; CB_NORMAL.Checked = false; CB_HARD.Checked = false; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].Difficulty == 03) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = false; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].Difficulty == 12) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = true; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].Difficulty == 15) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = true; CB_VH.Checked = true; }

         //   EMD_IO.EMD_DATA[x].Enemy[idx].MAP = (byte)x;


          //  MessageBox.Show(EMD_IO.EMD_DATA[x].Enemy[idx].MAP);

            EMD_IO.Set_ROOM(EMD_IO.SCE_VALUE, EMD_IO.EMD_DATA[x].Enemy[idx].MAP, PB_EMD_ROOM);
            EMD_IO.Set_pic(EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID0, EMD_IO.EMD_DATA[x].Enemy[idx].NBD_ID1, PB_EMD, LBL_NBD_FILE);

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
  

            // OPEN FILE STREAM
            using (FileStream fs1 = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryWriter bw = new BinaryWriter(fs1))
                {
                    // seek to ISO relative offset for selected EMD ENTRY
                    fs1.Seek(total, SeekOrigin.Begin);

                    bw.Write((byte)EMD_TAG.Value); // 0
                    bw.Write((byte)EMD_INDEX.Value); // 1
                    bw.Write((byte)EMD_NBDID00.Value); // 2
                    bw.Write((byte)EMD_NBDID01.Value); // 3
                    bw.Write((byte)EMD_EVENT00.Value); // 4

                    if (CB_ATK_SUPRESS.Checked) { bw.Write((byte)0x01); }  // 5
                    if (!CB_ATK_SUPRESS.Checked) { bw.Write((byte)0x00); }

                    fs1.Seek(total + 12, SeekOrigin.Begin); // skip to Rotation 12

                    bw.Write((byte)EMD_POS_DEC_RX.Value); // 12
                    bw.Write((byte)EMD_POS_DEC_RY.Value); // 13

                    fs1.Seek(+2, SeekOrigin.Current); // skip unused02

                    bw.Write((int)EMD_POS_DEC_X.Value); // 16
                    bw.Write((int)EMD_POS_DEC_X.Value); // 20
                    bw.Write((int)EMD_POS_DEC_X.Value); // 24
                    bw.Write((byte)EMD_ROOMID.Value); // 28

                    if (CB_EMD_FOLLOW.Checked) { bw.Write((byte)0x01); } // 29
                    if (!CB_EMD_FOLLOW.Checked) { bw.Write((byte)0x00); } // 29
                        

                    // skip unused or not using..
                    fs1.Seek(total + 32, SeekOrigin.Begin);

                    bw.Write((byte)EMD_ANIM.Value); // 32

                    fs1.Seek(total + 38, SeekOrigin.Begin);

                    if (CB_RESPAWN.Checked) { bw.Write((byte)0x01); } // 38
                    if (!CB_EMD_FOLLOW.Checked) { bw.Write((byte)0x00); } // 38

                    fs1.Seek(total + 40, SeekOrigin.Begin);

                    bw.Write((byte)EMD_ATTACK_DELAY.Value); // 40

                    fs1.Seek(total + 48, SeekOrigin.Begin);

                    bw.Write((byte)EMD_SPAWNIDX.Value);

                    fs1.Seek(total + 50, SeekOrigin.Begin);
                    bw.Write((byte)EMD_HP.Value); // 50
                    bw.Write((byte)EMD_STR.Value); // 51

                    fs1.Seek(total + 53, SeekOrigin.Begin);
                    bw.Write((byte)EMD_TRACKING.Value); // 53

                    fs1.Seek(total + 59, SeekOrigin.Begin);
                    bw.Write((byte)EMD_KDT.Value); // 59
                    bw.Write((byte)EMD_RESPAWN_TIME.Value); // 60

                    fs1.Seek(total + 64, SeekOrigin.Begin);
                    bw.Write((byte)EMD_SPEED.Value);

                    fs1.Seek(total + 67, SeekOrigin.Begin);
                    bw.Write((byte)EMD_KDR.Value); // 67
                    bw.Write((byte)EMD_FOLLOW_TIME.Value); // 68
                    bw.Write((byte)EMD_SCALEX.Value); // 69
                    bw.Write((byte)EMD_SCALEY.Value); // 70
                    bw.Write((byte)EMD_SCALEZ.Value); // 71
                  //  bw.Write((byte)EMD_FOLLOW_TIME.Value); // 71

                    fs1.Seek(total + 73, SeekOrigin.Begin);  
                    bw.Write((byte)EMD_DFC_CONVERT(CB_EASY, CB_NORMAL, CB_HARD, CB_VH)); // 73 DFC conversion




                    bw.Close();
                }


                fs1.Close();

            }

            MessageBox.Show("Emd Entry updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            // need a way to reload 

            // FRM_MAIN.emd



            //   MainForm.eMDINTToolStripMenuItem_Click(sender, e);

            this.Close();


        }


       

        private void FRM_EMD_Load(object sender, EventArgs e)
        {

            foreach (string em in EMD_IO.ENEMY_NAME_LUT.Values)
            {
                CB_EMD_SEL.Items.Add(em);
            }



            foreach (string zanim in EMD_IO.ZOMBIE_ANIMATION_LUT.Values)
            {
                CB_ZANIM.Items.Add(zanim);
            }

            LB_EMD_OFFSETS.SetSelected(0, true);
            LB_EMD_TOTAL.SetSelected(0, true);


        }

        private void LB_EMD_TOTAL_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Supported Currently", "N/A", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CB_EMD_SEL_SelectedValueChanged(object sender, EventArgs e)
        {


            string sel_val = CB_EMD_SEL.Text;


            string GetKey = EMD_IO.ENEMY_NAME_LUT.FirstOrDefault(x => x.Value == sel_val).Key;



            byte[] nbdArray = Helper.ConvertHexStringToByteArray(GetKey);


            EMD_NBDID00.Value = nbdArray[0];
            EMD_NBDID01.Value = nbdArray[1];


            if (EMD_NBDID00.Value != 1) 
            {
                 EMD_ANIM.Value = 0;              
            }




            EMD_IO.Set_pic(nbdArray[0], nbdArray[1], PB_EMD, LBL_NBD_FILE);

            ////EMD_NBDID00.Value = NBDID0;
            ////EMD_NBDID01.Value = NBDIO1;
            //MessageBox.Show(NBDID0.ToString() + "\\" + NBDIO1.ToString());



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BTN_PASTE_EMD_BC_Click(object sender, EventArgs e)
        {

        }

        private void LBL_NBD_FILE_Click(object sender, EventArgs e)
        {

        }

        private void BTN_EMD_ADD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Supported Currently", "N/A", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BTN_COPY_EMD_BC_Click(object sender, EventArgs e)
        {
            EMD_BYTECODE.SelectAll();
            EMD_BYTECODE.Copy();
        }

        private void CB_ATK_SUPRESS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BTN_EMD_DEBUG_Click(object sender, EventArgs e)
        {
           
           FRM_MAIN.DEBUG_FORM.ShowDialog();
        }

        private void CB_ZANIM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EMD_NBDID00_ValueChanged(object sender, EventArgs e)
        {
           
        }
    }
}
