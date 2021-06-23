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
using DiscUtils.Iso9660;
using Microsoft.VisualBasic;



namespace Netbio_VFL_Plus
{
    public partial class FRM_RDT : Form
    {

        public EVB_PARSER EVBIO = new EVB_PARSER();
        public FRM_EVB EVB_FORM = new FRM_EVB();
        public FRM_AUDIO AUDIO_FORM = new FRM_AUDIO();
        public FRM_DEBUG DEBUG_FORM = new FRM_DEBUG();
        public FRM_GEN_SWITCH SNP_SWITCH = new FRM_GEN_SWITCH();
        public static RDT_IO RDT_HANDLER = new RDT_IO();



        public FRM_RDT_MEM RDT_MEMORY_FORM = new FRM_RDT_MEM();

        

        public FRM_RDT()
        {
            InitializeComponent();
        }

        private void LB_RDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            RDT_MEMORY_FORM.ShowDialog();
        }


        // BUTTON RDT CAM
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LIB_MEMORY.SEL_FMT = "_CAM";
            RDT_IO.CAM_OFFSET = int.Parse(LV_RDT.Items[0].SubItems[1].Text);

          



            RDT_MEMORY_FORM.ShowDialog();
        }

        private void BTN_SGL_Click(object sender, EventArgs e)
        {

            EVB_FORM.LV_BYTECODE.Items.Clear();
            EVB_FORM.LV_INTCODE.Items.Clear();
            EVB_FORM.LBL_EVB_FNAME.Text = LBL_RDTSELECT.Text.Substring(0, LBL_RDTSELECT.Text.Length - 3) + "SGL".ToUpper();


            string sceID = LBL_RDTSELECT.Text.Substring(2, 2);
            byte roomID = byte.Parse(LBL_RDTSELECT.Text.Substring(4, 2));


            // SET GLOBAL GAME VALUE BASED OFF SELECTED RDT.. LOAD CORRESPONDING ROOM IMAGE INTO SCRIPT WINDOW
            EMD_IO.GAME_VALUE = ScenarioHandler.GAME_CHECK(LBL_RDTSELECT.Text);
            EMD_IO.Set_ROOM(sceID, roomID, EVB_FORM.PB_ROOM);

            int sgl_len = int.Parse(LV_RDT.FocusedItem.SubItems[2].Text);

            // get afs mounted RDT offset to pass to subsequence functions
            int rdt_afs_off = int.Parse(LBL_RDT_OFF.Text);

            if (File.Exists(FRM_MAIN.Img.Image_Path))
            {
                using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open))
                {
                    if (FRM_MAIN.Valid_Iso(fs))
                    {
                        FRM_MAIN.Img.Read_Image = new CDReader(fs, true, true);
                        FRM_MAIN.Img.Root_FSys_Info = FRM_MAIN.Img.Read_Image.Root.GetFileSystemInfos();

                        Stream memStream = FRM_MAIN.Img.Read_Image.OpenFile(FRM_MAIN.Img.Selected_Volume, FileMode.Open);


                        int sgl_off = int.Parse(LV_RDT.Items[1].SubItems[1].Text);
                        int sgl_sz = int.Parse(LV_RDT.Items[1].SubItems[2].Text);

                        EVBIO.PARSE_RDT_SGL_STREAM(memStream, sgl_off, sgl_sz, rdt_afs_off, LV_RDT, EVB_FORM.LV_BYTECODE, EVB_FORM.LV_INTCODE, EVB_FORM);

                      //  MessageBox.Show(LV_RDT.Items[1].SubItems[1].ToString());

                        //   EVBIO.PARSE_EVB_STREAM(memStream, AFSIO.cur_archive_offset, EVB_SIZE, Obj_debug, LV_AFS, EVB_FORM.LV_BYTECODE, EVB_FORM.LV_INTCODE, EVB_FORM.Progressbar00, EVB_FORM);


                        EVB_FORM.ShowDialog();
                    }

                }

            }


        }

        private void BTN_UNPACK_Click(object sender, EventArgs e)
        {


            if (File.Exists(FRM_MAIN.Img.Image_Path))
            {
                using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open))
                {
                    if (FRM_MAIN.Valid_Iso(fs))
                    {
                        FRM_MAIN.Img.Read_Image = new CDReader(fs, true, true);
                        FRM_MAIN.Img.Root_FSys_Info = FRM_MAIN.Img.Read_Image.Root.GetFileSystemInfos();

                        Stream memStream = FRM_MAIN.Img.Read_Image.OpenFile(FRM_MAIN.Img.Selected_Volume, FileMode.Open);

                        RDT_HANDLER.Unpack_RDT_AFS(memStream, LBL_RDTSELECT, LBL_RDT_OFF);
                    }
                }
            }


                   

              // RDT_HANDLER.Unpack_RDT()  
        }

        private void RDT_ContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void BTN_SOUND_Click(object sender, EventArgs e)
        {

        }

        private void BTN_LIG_Click(object sender, EventArgs e)
        {
            LIB_MEMORY.SEL_FMT = "_FOG";
            RDT_IO.FOG_OFFSET = int.Parse(LV_RDT.Items[13].SubItems[1].Text);
           
            RDT_MEMORY_FORM.ShowDialog();


        }

        private void BTN_MOMO_Click(object sender, EventArgs e)
        {
            SNP_SWITCH.ShowDialog();

            // COLLECT RELATIVE OFFSETS
            RDT_IO.SNP_OFFSET00 = int.Parse(LV_RDT.Items[2].SubItems[1].Text);
            RDT_IO.SNP_OFFSET01 = int.Parse(LV_RDT.Items[3].SubItems[1].Text);

            int sel_snp = 0;

            MessageBox.Show(RDT_IO.SNP_FLAG.ToString());

            if (RDT_IO.SNP_FLAG == 1) { sel_snp = RDT_IO.SNP_OFFSET00; }
            if (RDT_IO.SNP_FLAG == 2) { sel_snp = RDT_IO.SNP_OFFSET01; }


            if (File.Exists(FRM_MAIN.Img.Image_Path))
            {
                using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    if (FRM_MAIN.Valid_Iso(fs))
                    {
                        FRM_MAIN.Img.Read_Image = new CDReader(fs, true, true);
                        FRM_MAIN.Img.Root_FSys_Info = FRM_MAIN.Img.Read_Image.Root.GetFileSystemInfos();

                        Stream memStream = FRM_MAIN.Img.Read_Image.OpenFile(FRM_MAIN.Img.Selected_Volume, FileMode.Open);
                        LIB_AUDIO.SND_RDT_STREAM(memStream, 
                            AUDIO_FORM, 
                            int.Parse(LBL_RDT_OFF.Text),sel_snp, 
                            AUDIO_FORM.LV_AUDIO, 
                            AUDIO_FORM.LBL_TCOUNT, 
                            DEBUG_FORM.DEBUG_LOG);
                         
                        // RDT_HANDLER.Unpack_RDT_AFS(memStream, LBL_RDTSELECT, LBL_RDT_OFF);
                    }
                }
            }


        }
    }
}
