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

namespace Netbio_VFL_Plus
{
    public partial class FRM_RDT : Form
    {

        public EVB_PARSER EVBIO = new EVB_PARSER();
        public FRM_EVB EVB_FORM = new FRM_EVB();
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
            RDT_MEMORY_FORM.ShowDialog();
        }

        private void BTN_SGL_Click(object sender, EventArgs e)
        {

            EVB_FORM.LV_BYTECODE.Items.Clear();
            EVB_FORM.LV_INTCODE.Items.Clear();

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
    }
}
