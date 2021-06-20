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



            if (nbdval0 == "01")
            {
                CB_ZANIM.Show();
            }
            else {
                CB_ZANIM.Hide();
            }
           

            // CHECK IF KEY EXISTS
            if (EMD_IO.ZOMBIE_ANIMATION_LUT.ContainsKey(EMD_IO.EMD_DATA[x].Enemy[i].EMD_STATE))
            {
                CB_ZANIM.SelectedItem = EMD_IO.ZOMBIE_ANIMATION_LUT[EMD_IO.EMD_DATA[x].Enemy[i].EMD_STATE];
            }
            else
            {
                MessageBox.Show("ANIM LUT KEY NOT AVAILABLE");
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

            EMD_SCALEX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SCALEX;
            EMD_SCALEY.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SCALEY;
            EMD_SCALEZ.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SCALEZ;

            EMD_ANIM.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_STATE;
            EMD_SPAWNIDX.Value = EMD_IO.EMD_DATA[x].Enemy[idx].SpawnIDX;
            EMD_KNOCKBACK.Value = EMD_IO.EMD_DATA[x].Enemy[idx].SpawnIDX;

            EMD_SPEED.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_SPEED;
            EMD_HP.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_HP;
            EMD_FOLLOW_FLAG.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_FOLLOW;
            EMD_STR.Value = EMD_IO.EMD_DATA[x].Enemy[idx].EMD_STR;
            EMD_ZREZ.Value = EMD_IO.EMD_DATA[x].Enemy[idx].Zombie_ressurect;
           // STILL NEEDS TO BE FIXED

            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 01) { CB_EASY.Checked = true; CB_NORMAL.Checked = false; CB_HARD.Checked = false; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 03) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = false; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 12) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = true; CB_VH.Checked = false; }
            if (EMD_IO.EMD_DATA[x].Enemy[i].EMD_DFC == 15) { CB_EASY.Checked = true; CB_NORMAL.Checked = true; CB_HARD.Checked = true; CB_VH.Checked = true; }


  


            EMD_IO.Set_ROOM(EMD_IO.SCE_VALUE, EMD_IO.EMD_DATA[x].Enemy[idx].Room_ID, PB_EMD_ROOM);
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

                    //  MessageBox.Show(fs1.Position.ToString());


                    bw.Write((byte)EMD_TAG.Value);
                    bw.Write((byte)EMD_INDEX.Value);
                    bw.Write((byte)EMD_NBDID00.Value);
                    bw.Write((byte)EMD_NBDID01.Value);


                    fs1.Seek(+8, SeekOrigin.Current); // skip writing Ulongs
                    //bw.Write((int)EMD_IO.EMD_DATA[x].Enemy[i].ULong00);

                    //bw.Write((int)EMD_IO.EMD_DATA[x].Enemy[i].ULong01);kk


                    bw.Write((Int16)EMD_POS_DEC_X.Value);

                    fs1.Seek(+2, SeekOrigin.Current);

                    bw.Write((Int16)EMD_POS_DEC_Z.Value);
                    fs1.Seek(+2, SeekOrigin.Current);
                    bw.Write((Int16)EMD_POS_DEC_Y.Value);
                    fs1.Seek(+2, SeekOrigin.Current);
                    bw.Write((Int16)EMD_POS_DEC_R.Value);
                    fs1.Seek(+2, SeekOrigin.Current);

                    bw.Write((byte)EMD_ROOMID.Value);
                    bw.Write((byte)EMD_IO.EMD_DATA[x].Enemy[i].SpawnIDX);

                    //// need convert radio buttons to difficulty bitmask

                    bw.Write((byte)EMD_DFC_CONVERT(CB_EASY, CB_NORMAL, CB_HARD, CB_VH));

                    fs1.Seek(+19, SeekOrigin.Current);


                    //bw.Write((byte)EMD_IO.EMD_DATA[x].Enemy[i].UnkB01);
                    //bw.Write((short)EMD_IO.EMD_DATA[x].Enemy[i].UShort02);
                    //bw.Write((byte)EMD_IO.EMD_DATA[x].Enemy[i].UByte00);
                    //bw.Write((byte)EMD_IO.EMD_DATA[x].Enemy[i].UByte01);
                    //bw.Write((short)EMD_IO.EMD_DATA[x].Enemy[i].UShort03);
                    //bw.Write((short)EMD_IO.EMD_DATA[x].Enemy[i].UShort04);
                    //bw.Write((int)EMD_IO.EMD_DATA[x].Enemy[i].ULong01);
                    //bw.Write((int)EMD_IO.EMD_DATA[x].Enemy[i].ULong02);
                    //bw.Write((int)EMD_IO.EMD_DATA[x].Enemy[i].ULong03);
                    //bw.Write((byte)EMD_IO.EMD_DATA[x].Enemy[i].Ubyte02);
                    //bw.Write((byte)EMD_IO.EMD_DATA[x].Enemy[i].EMD_STATE); // need to switch this to NUD val
                    bw.Write((byte)EMD_STR.Value);
                    bw.Write((byte)EMD_HP.Value);

                    fs1.Seek(+7, SeekOrigin.Current);
                    //bw.Write((short)EMD_IO.EMD_DATA[x].Enemy[i].UShort07);
                    //bw.Write((short)EMD_IO.EMD_DATA[x].Enemy[i].UShort08);
                    //bw.Write((short)EMD_IO.EMD_DATA[x].Enemy[i].UShort09);
                    //bw.Write((short)EMD_IO.EMD_DATA[x].Enemy[i].UShort10);
                    //bw.Write((int)EMD_IO.EMD_DATA[x].Enemy[i].ULong04);
                    bw.Write((byte)EMD_SPEED.Value);
                    //bw.Write((byte)EMD_IO.EMD_DATA[x].Enemy[i].UByte03);
                    //bw.Write((int)EMD_IO.EMD_DATA[x].Enemy[i].ULong05);
                    //bw.Write((short)EMD_SCALE.Value); // could be wrong data type..



                    //EMD_DATA[x].Enemy[j].UByte04 = br.ReadByte();
                    //EMD_DATA[x].Enemy[j].EMD_FOLLOW = br.ReadByte(); // prob wrong
                    //EMD_DATA[x].Enemy[j].UShort14 = br.ReadInt16();
                    //EMD_DATA[x].Enemy[j].ULong06 = br.ReadInt32();
                    //EMD_DATA[x].Enemy[j].ULong07 = br.ReadInt32();
                    //EMD_DATA[x].Enemy[j].ULong08 = br.ReadInt32();
                    //EMD_DATA[x].Enemy[j].ULong09 = br.ReadInt32();



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


        public void EMD_RELOAD() 
        {

            

            try
            {

                int index = afs_index;
                bool Online; // Online Flag


                // CHECK VALID FILE PATH
                if (File.Exists(FRM_MAIN.Img.Image_Path))
                {

                    // OPEN FILE STREAM
                    using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {

                        // ENSURE IT HAS VALID AFS SIG + EMD EXTENSION
                        if (FRM_MAIN.Valid_Iso(fs) && MainForm.LV_AFS.FocusedItem.SubItems[3].Text.Substring(MainForm.LV_AFS.FocusedItem.SubItems[3].Text.Length - 3, 3).ToUpper() == "EMD")
                        {
                            // DIFFERENTIATE BETWEEN ONLINE/OFFLINE EMD DATA
                            if (MainForm.LV_AFS.FocusedItem.SubItems[3].Text.Substring(0, 3).ToUpper() == "SGL")
                            {
                                Online = false;
                            }
                            else
                            {
                                Online = true;
                            }

                            // 
                            FRM_MAIN.Img.Read_Image = new CDReader(fs, true, true);
                            FRM_MAIN.Img.Root_FSys_Info = FRM_MAIN.Img.Read_Image.Root.GetFileSystemInfos();
                            Stream memStream = FRM_MAIN.Img.Read_Image.OpenFile(FRM_MAIN.Img.Selected_Volume, FileMode.Open);

                            FRM_MAIN.EMDIO.Parse_EMDStream(memStream, MainForm.AFSIO.cur_archive_offset,
                            ScenarioHandler.ARC2_VAL(MainForm.LV_AFS.Items[MainForm.LV_AFS.SelectedIndices[0]].SubItems[3].Text),
                                ScenarioHandler.GAME_CHECK(MainForm.LV_AFS.Items[MainForm.LV_AFS.SelectedIndices[0]].SubItems[3].Text),
                                MainForm.LV_AFS, MainForm.EMD_FORM.LB_EMD_OFFSETS, MainForm.EMD_FORM.PB_EMD_ROOM, MainForm.EMD_FORM.PB_EMD, MainForm.EMD_FORM.LBL_OFFSET, MainForm.EMD_FORM.LBL_FTYPE);

                            //   SetWindowTheme(MainForm.EMD_FORM.Handle, "", ""); // enable classic view
                            MainForm.EMD_FORM.ShowDialog();


                            memStream.Close();
                            memStream.Dispose();
                            FRM_MAIN.Img.Read_Image.Dispose();




                        }

                    }

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }

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
            MessageBox.Show("Not Supported Currently", "N/A", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CB_EMD_SEL_SelectedValueChanged(object sender, EventArgs e)
        {


            string sel_val = CB_EMD_SEL.Text;


            string GetKey = EMD_IO.ENEMY_NAME_LUT.FirstOrDefault(x => x.Value == sel_val).Key;



            byte[] nbdArray = Helper.ConvertHexStringToByteArray(GetKey);


            EMD_NBDID00.Value = nbdArray[0];
            EMD_NBDID01.Value = nbdArray[1];




            EMD_IO.Set_pic(nbdArray[0], nbdArray[1], PB_EMD, LBL_NBD_FILE);

            ////EMD_NBDID00.Value = NBDID0;
            ////EMD_NBDID01.Value = NBDIO1;
            //MessageBox.Show(NBDID0.ToString() + "\\" + NBDIO1.ToString());



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void LBL_ZREZ_Click(object sender, EventArgs e)
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
    }
}
