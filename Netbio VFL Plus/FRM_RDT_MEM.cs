using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Netbio_VFL_Plus
{
    public partial class FRM_RDT_MEM : Form
    {


        public byte _totalCams = 0;

        private void FIND_PROCESS()
        {
            Process[] processlist = Process.GetProcesses();
            List<string> tmp_list = new List<string>();

            foreach (Process theprocess in processlist)
            {
                tmp_list.Add(theprocess.ProcessName);
            }

            for (int i = 0; i < tmp_list.Count; i++)
            {
                if (tmp_list[i].Length > 4 && tmp_list[i].Substring(0, 5) == "pcsx2")
                {
                    g_PROCESS_NAME = tmp_list[i];




                }
            }

            if (g_PROCESS_NAME.Length != 0)
            {

                LBL_STATUS.Text = "PCSX2 DETECTED : " + g_PROCESS_NAME.ToString();
            }
            else if (g_PROCESS_NAME.Length == null || g_PROCESS_NAME.Length == 0)
            {
                LBL_STATUS.Text = "PCSX2 IS NOT RUNNING";
            }


        } // just for finding the right process string


        public FRM_RDT_MEM()
        {
            InitializeComponent();



        }



        RDT_IO RDT_OBJ = new RDT_IO();
        public RDT_HEADER_OBJ[] RDT_HEADER = new RDT_HEADER_OBJ[0];
        CAMERA_HEADER_OBJ[] CAM_HEADER_OBJZ = new CAMERA_HEADER_OBJ[0];
        RDT_IO.Camera_Properties cam_props = new RDT_IO.Camera_Properties();
        RDT_IO.LGS_Properties LGSP = new RDT_IO.LGS_Properties();
        LGS_DATA_OBJ LIGHT_DATA = new LGS_DATA_OBJ();
        LGS_HEADER_OBJ LIGHT_HEADER = new LGS_HEADER_OBJ();

        public int cam_num;
        public string fmt;
        public bool _CAMVIEW;
        public bool _FOGVIEW;



        public string g_PROCESS_NAME = "";
        public string Current_RDT;





        public void MI_TIMER_Tick(object sender, EventArgs e) // ms based refresh for basic info
        {

        }


        public void Cam_Scan(Process pcsx2_proc)
        {


            // CLEAR LB ITEMS TO PREVENT DUPES N SHIT...
            LB_TCAM.Items.Clear();


            //var proc = Process.GetProcessesByName(LIB_MEMORY.g_PROCESS_NAME);
            //if (proc.Length == 0 || proc == null)
            //    return;

            //var pcsx2_proc = proc[0];


            byte total_cams = 0;
            Int32 s_off = 0;


            if (LIB_MEMORY.g_GAME_ID == 1)
            {
                total_cams = Memory.Read<byte>(pcsx2_proc, new IntPtr(0x203AEF51));
                s_off = 0x203AEF84;

            }

            if (LIB_MEMORY.g_GAME_ID == 2)
            {
                total_cams = Memory.Read<byte>(pcsx2_proc, new IntPtr(0x203B31D1));
                s_off = 0x203B3200; // starting offset to main memory struct

            }




            int cur_idx = LB_TCAM.SelectedIndex;
            Int32[] cam_off = new Int32[total_cams];




            // add camera indexs to listbox..
            for (int i = 0; i < total_cams; i++)
            {
                LB_TCAM.Items.Add(i.ToString());
            }


            if (LB_TCAM.SelectedIndex != null)
            {
                cam_num = total_cams;

                for (int j = 0; j < total_cams; j++)  // only position atm...
                {
                    cam_off[j] = s_off + 0x198 * j;




                    cam_props.cam_type = Memory.Read<byte>(pcsx2_proc, new IntPtr(cam_off[j] + 1));
                    cam_props.rotation_clock = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j] + 12));
                    cam_props.rotation_counterclock = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j] + 16));
                    cam_props.FOV00 = Memory.Read<Single>(pcsx2_proc, new IntPtr(cam_off[j] + 22));
                    cam_props.FOV01 = Memory.Read<Single>(pcsx2_proc, new IntPtr(cam_off[j] + 26));
                    cam_props.cam_posx00 = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 160);
                    cam_props.cam_height00 = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j] + 164));
                    cam_props.cam_posy00 = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 168);
                    cam_props.cam_posx01 = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 172);
                    cam_props.cam_height01 = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 176);
                    cam_props.cam_posy01 = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 180);
                    cam_props.cam_targetx = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 184);
                    cam_props.cam_targetz = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 188);
                    cam_props.cam_targety = Memory.Read<Int32>(pcsx2_proc, new IntPtr(cam_off[j]) + 192);


                    //  MessageBox.Show(cam_off[j].ToString("X"), "title", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Memory_Grid.SelectedObject = cam_props;
                //  LB_TCAM.SetSelected(0, true); // force listbox index to avoid exception
            }

        }  // scan camera block pass class obj to memory module


        /// <summary>
        /// COPY FOG/LIG DATA ACROSS ALL INDEX
        /// </summary>
        /// <param name="proc"></param>
        public void FOG_COPY(Process proc)
        {


            Int32 light_off = 0; // store main light data object offset
            Int32[] light_offsets = new Int32[cam_num];
            int cur_idx = LB_TCAM.SelectedIndex;






            if (LIB_MEMORY.g_GAME_ID == 1)
            {

                light_off = 0x203ACD80;
            }

            if (LIB_MEMORY.g_GAME_ID == 2)
            {

                light_off = 0x203B11B0;
            }



            for (int i = 0; i < cam_num; i++)
            {

                light_offsets[i] = light_off + 96 * i;



                Memory.Write<Int32>(proc, new IntPtr(light_offsets[i]), LGSP.tag);
                Memory.Write<Single>(proc, new IntPtr(light_offsets[i]) + 4, LGSP.Fade00);
                Memory.Write<Single>(proc, new IntPtr(light_offsets[i]) + 8, LGSP.Ulong01);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 12, LGSP.fogB);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 13, LGSP.fogG);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 14, LGSP.fogR);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 15, LGSP.fogA);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 16, LGSP.CAM_B);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i] + 17), LGSP.CAM_G);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i] + 18), LGSP.CAM_R);
                Memory.Write<byte>(proc, new IntPtr(light_offsets[i] + 19), LGSP.CAM_ALPHA);
                Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 20), LGSP.Ulong04);
                Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 24), LGSP.SDW00);
                Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 28), LGSP.SDW01);
                Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 32), LGSP.SDW02);
                Memory.Write<float>(proc, new IntPtr(light_offsets[i] + 36), LGSP.R);
                Memory.Write<float>(proc, new IntPtr(light_offsets[i] + 40), LGSP.G);
                Memory.Write<float>(proc, new IntPtr(light_offsets[i] + 44), LGSP.B);
            }



        }


        /// <summary>
        /// Merge this function with resync cam off to clean things up abit at a later time..
        /// </summary>
        /// <param name="fp"></param>
        public void READ_RDT_HEADER(string fp) // also re read .FOG HEADERS
        {
            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);



            Int32 _off = br.ReadInt32();

            fs.Seek(-4, SeekOrigin.Current);

            Array.Resize(ref RDT_HEADER, _off / 8);

            for (int i = 0; i < RDT_HEADER.Length; i++)
            {
                RDT_HEADER[i]._offset = br.ReadInt32();
                RDT_HEADER[i]._size = br.ReadInt32();
            }



            fs.Seek(RDT_HEADER[13]._offset, SeekOrigin.Begin);

            LIGHT_HEADER.roomID = br.ReadInt32();
            LIGHT_HEADER.total_cams = br.ReadInt32();

            // Int32[] loff = new Int32[LIGHT_HEADER.total_cams];

            Array.Resize(ref LIGHT_HEADER.offset, LIGHT_HEADER.total_cams);


            for (int i = 0; i < LIGHT_HEADER.total_cams; i++)
            {
                LIGHT_HEADER.offset[i] = br.ReadInt32();
            }


            fs.Close();
            br.Close();





        }

        public void resync_camoff(string fp) // WHY AM I RE READING THIS
        {
            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            fs.Seek(256, SeekOrigin.Begin);

            int tag = br.ReadInt32();
            int cam_count = br.ReadInt32();


            Array.Resize(ref CAM_HEADER_OBJZ, cam_count);


            for (int i = 0; i < cam_count; i++)
            {
                CAM_HEADER_OBJZ[i]._offset = br.ReadInt32();
                CAM_HEADER_OBJZ[i].new_off = CAM_HEADER_OBJZ[i]._offset + 256;

            }


            fs.Close();
            br.Close();

        }





        public void CAM_MEM_TO_RDT(string fp, PropertyGrid PG, ListBox LB) // for writing the updated memory block from property grid to RDT...
        {
            FileStream fs2 = new FileStream(fp, FileMode.Open);
            BinaryWriter bw = new BinaryWriter(fs2);

            fs2.Seek(CAM_HEADER_OBJZ[LB.SelectedIndex].new_off, SeekOrigin.Begin); // skip past camera header to actual chunk data

            bw.Write(cam_props.cam_type);

            fs2.Seek(CAM_HEADER_OBJZ[LB.SelectedIndex].new_off + 20, SeekOrigin.Begin); // skip to rotation and FOV, because i dont have the unknown longs stored in this form.......

            bw.Write(cam_props.rotation_clock);
            bw.Write(cam_props.rotation_counterclock);
            bw.Write(cam_props.FOV00);
            bw.Write(cam_props.FOV01);



            fs2.Seek(CAM_HEADER_OBJZ[LB.SelectedIndex].new_off + 156, SeekOrigin.Begin); // skip to actual positions.. no way to visaulize camera switch primitives in 2d..


            // keep things in x y z order...
            bw.Write(cam_props.cam_posx00);
            bw.Write(cam_props.cam_height00);
            bw.Write(cam_props.cam_posy00);

            bw.Write(cam_props.cam_posx01);
            bw.Write(cam_props.cam_height01);
            bw.Write(cam_props.cam_posy01);

            bw.Write(cam_props.cam_targetx);
            bw.Write(cam_props.cam_targetz);
            bw.Write(cam_props.cam_targety);



            fs2.Close();
            bw.Close();

        }


        /// <summary>
        /// Re write updated memory heap to .RDT .FOG chunk, based on current cam selection
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="PG"></param>
        /// <param name="LB"></param>
        public void FOG_MEM_TO_RDT(string fp, PropertyGrid PG, ListBox LB)
        {

            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryWriter bw = new BinaryWriter(fs);



            fs.Seek(RDT_HEADER[13]._offset + LIGHT_HEADER.offset[LB.SelectedIndex], SeekOrigin.Begin);

            bw.Write(LGSP.tag);
            bw.Write(LGSP.Fade00);
            bw.Write(LGSP.Ulong01);
            bw.Write(LGSP.fogB);
            bw.Write(LGSP.fogG);
            bw.Write(LGSP.fogR);
            bw.Write(LGSP.fogA);

            bw.Write(LGSP.CAM_B);
            bw.Write(LGSP.CAM_G);
            bw.Write(LGSP.CAM_R);
            bw.Write(LGSP.CAM_ALPHA);
            bw.Write(LGSP.Ulong04);
            bw.Write(LGSP.SDW00);
            bw.Write(LGSP.SDW01);
            bw.Write(LGSP.SDW02);
            bw.Write(LGSP.R);
            bw.Write(LGSP.G);
            bw.Write(LGSP.B);


            fs.Close();
            bw.Close();

        }




        public void Light_Scan(Process pcsx2)
        {

            // PREVENT DUPES N SHIT...


            //var proc = Process.GetProcessesByName(g_PROCESS_NAME); // pass process pcsx2.exe
            //if (proc.Length == 0 || proc == null)
            //   return;


            //    var pcsx2 = proc[0];

            LB_TCAM.Items.Clear();

            Int32 s_off = 0; // light data alawys starts here in memory
            byte total_cams = 0;
            int cur_idx = LB_TCAM.SelectedIndex;


            MessageBox.Show(LIB_MEMORY.g_GAME_ID.ToString());

            if (LIB_MEMORY.g_GAME_ID == 1)
            {
                total_cams = Memory.Read<byte>(pcsx2, new IntPtr(0x203AEF51));

                s_off = 0x203ACD80;

            }

            if (LIB_MEMORY.g_GAME_ID == 2)
            {


                total_cams = Memory.Read<byte>(pcsx2, new IntPtr(0x203B31D1));
                s_off = 0x203B11B0; // starting offset to main memory struct

            }

            Int32[] light_offsets = new Int32[total_cams]; // craete an array of integers to hold all possible light offsets re size to t cams

            for (int j = 0; j < total_cams; j++)
            {
                LB_TCAM.Items.Add(j.ToString());
            }


            if (LB_TCAM.SelectedIndex != null)
            {
                cam_num = total_cams;

                for (int i = 0; i < total_cams; i++) // change to actual cam count , pass from RDT somehow
                {

                    light_offsets[i] = s_off + 96 * i; // seek to the start of each 96 byte chunk

                    //MessageBox.Show(light_offsets[i].ToString("X"));

                    // offset adjustment is needed to read the right spots in each chunk
                    LGSP.tag = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[i]));
                    LGSP.Fade00 = Memory.Read<Single>(pcsx2, new IntPtr(light_offsets[i]) + 4);
                    LGSP.Ulong01 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[i]) + 8);
                    LGSP.fogB = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 12);
                    LGSP.fogG = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 13);
                    LGSP.fogR = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 14);
                    LGSP.fogA = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 15);
                    LGSP.CAM_B = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 16);
                    LGSP.CAM_G = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 17);
                    LGSP.CAM_R = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 18);
                    LGSP.CAM_ALPHA = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[i]) + 19);
                    LGSP.Ulong04 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[i]) + 20);
                    LGSP.SDW00 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[i]) + 24);
                    LGSP.SDW01 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[i]) + 28);
                    LGSP.SDW02 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[i]) + 32);
                    LGSP.R = Memory.Read<float>(pcsx2, new IntPtr(light_offsets[i]) + 36);
                    LGSP.G = Memory.Read<float>(pcsx2, new IntPtr(light_offsets[i]) + 40);
                    LGSP.B = Memory.Read<float>(pcsx2, new IntPtr(light_offsets[i] + 44));
                }


            }
            Memory_Grid.SelectedObject = LGSP;

            //  LB_TCAM.SetSelected(0, true); // force listbox index to avoid exception


        } // scan light data pass class obj to memory module




        private void button1_Click(object sender, EventArgs e) // write all index   //needs to be changed to differentiate between cam/light data why would you use it for cam? dumb ass
        {

            Int32 off = 0x203B11B0; // store main light data object offset
            Int32[] light_offsets = new Int32[cam_num];
            int cur_idx = LB_TCAM.SelectedIndex;

            var pcsx2_proc = Process.GetProcessesByName(g_PROCESS_NAME);

            if (pcsx2_proc == null || pcsx2_proc.Length == 0)
                return;

            var proc = pcsx2_proc[0];


            switch (fmt)
            {
                case "_CAM": break;
                case "_FOG":

                    for (int i = 0; i < cam_num; i++)
                    {

                        light_offsets[i] = off + 96 * i;



                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[i]), LGSP.tag);
                        Memory.Write<Single>(proc, new IntPtr(light_offsets[i]) + 4, LGSP.Fade00);
                        Memory.Write<Single>(proc, new IntPtr(light_offsets[i]) + 8, LGSP.Ulong01);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 12, LGSP.fogB);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 13, LGSP.fogG);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 14, LGSP.fogR);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 15, LGSP.fogA);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i]) + 16, LGSP.CAM_B);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i] + 17), LGSP.CAM_G);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i] + 18), LGSP.CAM_R);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[i] + 19), LGSP.CAM_ALPHA);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 20), LGSP.Ulong04);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 24), LGSP.SDW00);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 28), LGSP.SDW01);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[i] + 32), LGSP.SDW02);
                        Memory.Write<float>(proc, new IntPtr(light_offsets[i] + 36), LGSP.R);
                        Memory.Write<float>(proc, new IntPtr(light_offsets[i] + 40), LGSP.G);
                        Memory.Write<float>(proc, new IntPtr(light_offsets[i] + 44), LGSP.B);
                    }

                    break;
            }

        }

        private void BTN_UPDATE_Click(object sender, EventArgs e)
        {
            DialogResult YesNo = MessageBox.Show("This will take all camera indices and re write your updated change to change to the currently opened RDT!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (YesNo == DialogResult.Yes)
            {


                READ_RDT_HEADER(Current_RDT); // this is to re store RDT header info in this scope.. cuz other ways result in stack overflow with the memory grid

                if (_CAMVIEW == true && _FOGVIEW == false)
                {
                    MessageBox.Show("Target RDT will now be updated with updated Camera Heap!", "FUCKIN EH", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resync_camoff(Current_RDT); // re sync chunk relative offsets
                    CAM_MEM_TO_RDT(Current_RDT, Memory_Grid, LB_TCAM);

                }
                else if (_FOGVIEW == true && _CAMVIEW == false)
                {
                    MessageBox.Show("Target RDT will now be updated with updated with adjusted memory heap (.FOG)!", "FUCKIN EH", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FOG_MEM_TO_RDT(Current_RDT, Memory_Grid, LB_TCAM);
                }


            }
            else if (YesNo == DialogResult.No)
            {
                MessageBox.Show("Saul good man!", "Abort!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




        }



        private void LB_TCAM_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            var proc = Process.GetProcessesByName(LIB_MEMORY.g_PROCESS_NAME); // pass process pcsx2.exe

            if (proc.Length == 0 && proc == null)
                return;

            var pcsx2 = proc[0]; // set match       


            //Int32 light_off = 0x203B11B0; // light data alawys starts here in memory
            Int32 cam_off = 0;
            Int32 light_off = 0;


            if (LIB_MEMORY.g_GAME_ID == 1)
            {
                cam_off = 0x203AEF84;
                light_off = 0x203ACD80;
            }

            if (LIB_MEMORY.g_GAME_ID == 2)
            {
                cam_off = 0x203B3200; // this is only the start of the positions, not the start of the actual object
                light_off = 0x203B11B0;
            }







            int cur_idx = LB_TCAM.SelectedIndex;
            Int32[] light_offsets = new Int32[cam_num];
            Int32[] cam_offsets = new Int32[cam_num];


            switch (LIB_MEMORY.SEL_FMT) // need to switch between selected format so the other object isnt overwritten
            {
                case "_CAM":



                    cam_offsets[cur_idx] = cam_off + 0x198 * cur_idx;


                    LBL_MEMOFF.Text = "Current Memory Offset: 0x" + cam_offsets[cur_idx].ToString("X");

                    cam_props.cam_type = Memory.Read<byte>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 1);
                    cam_props.rotation_clock = Memory.Read<Int32>(pcsx2, new IntPtr(cur_idx + 12));
                    cam_props.rotation_counterclock = Memory.Read<Int32>(pcsx2, new IntPtr(cur_idx + 16));
                    cam_props.FOV00 = Memory.Read<Single>(pcsx2, new IntPtr(cam_offsets[cur_idx] + 20));
                    cam_props.FOV01 = Memory.Read<Single>(pcsx2, new IntPtr(cam_offsets[cur_idx] + 24));
                    cam_props.cam_posx00 = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 160);
                    cam_props.cam_height00 = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 164);
                    cam_props.cam_posy00 = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 168);
                    cam_props.cam_posx01 = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 172);
                    cam_props.cam_height01 = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 176);
                    cam_props.cam_posy01 = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 180);
                    cam_props.cam_targetx = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 184);
                    cam_props.cam_targetz = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 188);
                    cam_props.cam_targety = Memory.Read<Int32>(pcsx2, new IntPtr(cam_offsets[cur_idx]) + 192);



                    Memory_Grid.SelectedObject = cam_props;

                    break;

                case "_FOG":
                    light_offsets[cur_idx] = light_off + 96 * cur_idx; // seek to the start of each 96 byte chunk
                    LBL_MEMOFF.Text = "Current Memory Offset: 0x" + light_offsets[cur_idx].ToString("X");
                    //MessageBox.Show(light_offsets[i].ToString("X"));

                    // offset adjustment is needed to read the right spots in each chunk
                    LGSP.tag = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[cur_idx]));
                    LGSP.Fade00 = Memory.Read<Single>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 4);
                    LGSP.Ulong01 = Memory.Read<Single>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 8);
                    LGSP.fogB = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 12);
                    LGSP.fogG = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 13);
                    LGSP.fogR = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 14);
                    LGSP.fogA = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 15);
                    LGSP.CAM_B = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 16);
                    LGSP.CAM_G = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 17);
                    LGSP.CAM_R = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 18);
                    LGSP.CAM_ALPHA = Memory.Read<byte>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 19);
                    LGSP.Ulong04 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 20);
                    LGSP.SDW00 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 24);
                    LGSP.SDW01 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 28);
                    LGSP.SDW02 = Memory.Read<Int32>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 32);
                    LGSP.R = Memory.Read<float>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 36);
                    LGSP.G = Memory.Read<float>(pcsx2, new IntPtr(light_offsets[cur_idx]) + 40);
                    LGSP.B = Memory.Read<float>(pcsx2, new IntPtr(light_offsets[cur_idx] + 44));

                    Memory_Grid.SelectedObject = LGSP;
                    break;
            }



        }

        private void FRM_RDT_MEM_Load(object sender, EventArgs e)
        {
            LIB_MEMORY.GET_PCSX2_PROC();
            LIB_MEMORY.VERIFY_GAME_REGION();


            var proc = Process.GetProcessesByName(LIB_MEMORY.g_PROCESS_NAME);
            if (proc.Length == 0 || proc == null)
                return;

            var pcsx2_proc = proc[0];


            if (LIB_MEMORY.SEL_FMT == "_CAM")
            {
                BTN_IDX.Hide();
                Cam_Scan(pcsx2_proc);

            }

            if (LIB_MEMORY.SEL_FMT == "_FOG")
            {
                BTN_IDX.Show();
                Light_Scan(pcsx2_proc);

            }


        }

        private void Memory_Grid_Click(object sender, EventArgs e)
        {

        }

        private void LBL_MEMOFF_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Write all index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_IDX_Click(object sender, EventArgs e)
        {
            var proc = Process.GetProcessesByName(LIB_MEMORY.g_PROCESS_NAME);
            if (proc.Length == 0 || proc == null)
                return;

            var pcsx2_proc = proc[0];

            FOG_COPY(pcsx2_proc);

        }


        // write to memory on field update
        private void Memory_Grid_PropertyValueChanged_1(object s, PropertyValueChangedEventArgs e)
        {

            if (LB_TCAM.SelectedItems.Count > 0)
            {

                var old_val = e.OldValue; // store old val
                var new_val = Memory_Grid.SelectedGridItem.Value; // store new val
                string prop_name = Memory_Grid.SelectedGridItem.Label; // store name of changed property
                int cur_idx = LB_TCAM.SelectedIndex;


                Int32 light_off = 0; // store main light data object offset
                Int32 cam_off = 0; // start of each camera enttry
                Int32[] light_offsets = new Int32[cam_num];
                Int32[] cam_offsets = new Int32[cam_num];


                if (LIB_MEMORY.g_GAME_ID == 1)
                {
                    light_off = 0x203ACD80;
                    cam_off = 0x203AEF84;
                }

                if (LIB_MEMORY.g_GAME_ID == 2)
                {
                    cam_off = 0x203B3200; // this is only the start of the positions, not the start of the actual object
                    light_off = 0x203B11B0;
                }




                var pcsx2_proc = Process.GetProcessesByName(LIB_MEMORY.g_PROCESS_NAME);

                if (pcsx2_proc == null || pcsx2_proc.Length == 0)
                    return;

                var proc = pcsx2_proc[0];



                switch (LIB_MEMORY.SEL_FMT)
                {
                    case "_CAM":


                        cam_offsets[cur_idx] = cam_off + 0x198 * cur_idx;

                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx] + 1), cam_props.cam_type);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx] + 12), cam_props.rotation_clock);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx] + 16), cam_props.rotation_counterclock);
                        Memory.Write<Single>(proc, new IntPtr(cam_offsets[cur_idx] + 20), cam_props.FOV00);
                        Memory.Write<Single>(proc, new IntPtr(cam_offsets[cur_idx] + 24), cam_props.FOV01);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx] + 160), cam_props.cam_posx00);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx] + 164), cam_props.cam_height00);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx] + 168), cam_props.cam_posy00);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx]) + 172, cam_props.cam_posx01);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx]) + 176, cam_props.cam_height01);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx]) + 180, cam_props.cam_posy01);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx]) + 184, cam_props.cam_targetx);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx]) + 188, cam_props.cam_targetz);
                        Memory.Write<Int32>(proc, new IntPtr(cam_offsets[cur_idx]) + 192, cam_props.cam_targety);

                        break;
                    case "_FOG":

                        light_offsets[cur_idx] = light_off + 96 * cur_idx;

                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[cur_idx]), LGSP.tag);
                        Memory.Write<Single>(proc, new IntPtr(light_offsets[cur_idx]) + 4, LGSP.Fade00);
                        Memory.Write<Single>(proc, new IntPtr(light_offsets[cur_idx]) + 8, LGSP.Ulong01);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx]) + 12, LGSP.fogB);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx]) + 13, LGSP.fogG);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx]) + 14, LGSP.fogR);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx]) + 15, LGSP.fogA);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx]) + 16, LGSP.CAM_B);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx] + 17), LGSP.CAM_G);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx] + 18), LGSP.CAM_R);
                        Memory.Write<byte>(proc, new IntPtr(light_offsets[cur_idx] + 19), LGSP.CAM_ALPHA);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[cur_idx] + 20), LGSP.Ulong04);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[cur_idx] + 24), LGSP.SDW00);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[cur_idx] + 28), LGSP.SDW01);
                        Memory.Write<Int32>(proc, new IntPtr(light_offsets[cur_idx] + 32), LGSP.SDW02);
                        Memory.Write<float>(proc, new IntPtr(light_offsets[cur_idx] + 36), LGSP.R);
                        Memory.Write<float>(proc, new IntPtr(light_offsets[cur_idx] + 40), LGSP.G);
                        Memory.Write<float>(proc, new IntPtr(light_offsets[cur_idx] + 44), LGSP.B);
                        break;

                }
            }
            else 
            {
                MessageBox.Show("Please Select Current Camera", "Select current Camera ");
            }
        }

        // ENABLE TIMER
        private void BTN_STAT_HOOK_ButtonClick(object sender, EventArgs e)
        {
            Interval_Timer.Enabled = true;
        }

        // ON INTERVAL READ/UPDATE STATS
        private void Interval_Timer_Tick(object sender, EventArgs e)
        {

            int g_region = LIB_MEMORY.g_GAME_REGION;
            int g_id = LIB_MEMORY.g_GAME_ID;

            LIB_MEMORY.GET_PCSX2_PROC();
            LBL_VERSION.Text = LIB_MEMORY.VERIFY_GAME_REGION();

            LIB_MEMORY.GET_MEM_STATS(LIB_MEMORY.GET_OFFSET_BASE(g_region, g_id));


            // SET LABLELS USING LOADED MEMORY DATA
            LBL_POS_X.Text = LIB_MEMORY.G_PLAYER.X.ToString();


            LBL_POS_Y.Text = LIB_MEMORY.G_PLAYER.Y.ToString();
            LBL_POS_Z.Text = LIB_MEMORY.G_PLAYER.Z.ToString();

            LBL_ROOM.Text = "ROOM ID: " + LIB_MEMORY.G_ROOM_DATA.ROOM_ID.ToString();
            LBL_CID.Text = "CAM ID: " + LIB_MEMORY.G_ROOM_DATA.CAM_ID.ToString();



        }

        /// <summary>
        /// SAVE DATA TO DISK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTN_UPDATE_Click_1(object sender, EventArgs e)
        {
            // Used as a multiplier to reach the right offset
            int sel_cam_idx = LB_TCAM.SelectedIndex;
            int fog_hdr_skip = 0;

            using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryReader br = new BinaryReader(fs)) 
                {

                    if (LIB_MEMORY.SEL_FMT == "_FOG") 
                    {

                        int offset = RDT_IO.FOG_OFFSET + RDT_IO.RDT_SELECTED.File_Offset + FRM_MAIN.NETBIO00_OFFSET + 8;
                        fs.Seek(offset, SeekOrigin.Begin);
                        fog_hdr_skip = br.ReadInt32();


                    }

                }

            }


                using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    

                    // CAM
                    if (LIB_MEMORY.SEL_FMT == "_CAM") 
                    {
                        
                        int offset = RDT_IO.CAM_OFFSET + RDT_IO.RDT_SELECTED.File_Offset + FRM_MAIN.NETBIO00_OFFSET + 8;
                        int entry_offset = offset + LB_TCAM.Items.Count * 4 + 320 * sel_cam_idx;
                        fs.Seek(entry_offset + LB_TCAM.Items.Count * 4 + 320 * sel_cam_idx, SeekOrigin.Begin);




                        bw.Write(cam_props.cam_type);

                        fs.Seek(+20, SeekOrigin.Current);

                    //    fs.Seek(CAM_HEADER_OBJZ[LB.SelectedIndex].new_off + 20, SeekOrigin.Begin); // skip to rotation and FOV, because i dont have the unknown longs stored in this form.......

                        bw.Write(cam_props.rotation_clock);
                        bw.Write(cam_props.rotation_counterclock);
                        bw.Write(cam_props.FOV00);
                        bw.Write(cam_props.FOV01);

                        fs.Seek(+156, SeekOrigin.Current);


                        // keep things in x y z order...
                        bw.Write(cam_props.cam_posx00);
                        bw.Write(cam_props.cam_height00);
                        bw.Write(cam_props.cam_posy00);

                        bw.Write(cam_props.cam_posx01);
                        bw.Write(cam_props.cam_height01);
                        bw.Write(cam_props.cam_posy01);

                        bw.Write(cam_props.cam_targetx);
                        bw.Write(cam_props.cam_targetz);
                        bw.Write(cam_props.cam_targety);


                        MessageBox.Show("Sucessful Camera Entry Written to : " + entry_offset, "Success!");

                    }


                    // FOG
                    if (LIB_MEMORY.SEL_FMT == "_FOG")
                    {

                        int offset = RDT_IO.FOG_OFFSET + RDT_IO.RDT_SELECTED.File_Offset + FRM_MAIN.NETBIO00_OFFSET + fog_hdr_skip;

                        int entry_offset = offset + 96 * sel_cam_idx;

                        fs.Seek(entry_offset + 96 * sel_cam_idx, SeekOrigin.Begin);



                        bw.Write(LGSP.tag);
                        bw.Write(LGSP.Fade00);
                        bw.Write(LGSP.Ulong01);
                        bw.Write(LGSP.fogB);
                        bw.Write(LGSP.fogG);
                        bw.Write(LGSP.fogR);
                        bw.Write(LGSP.fogA);

                        bw.Write(LGSP.CAM_B);
                        bw.Write(LGSP.CAM_G);
                        bw.Write(LGSP.CAM_R);
                        bw.Write(LGSP.CAM_ALPHA);
                        bw.Write(LGSP.Ulong04);
                        bw.Write(LGSP.SDW00);
                        bw.Write(LGSP.SDW01);
                        bw.Write(LGSP.SDW02);
                        bw.Write(LGSP.R);
                        bw.Write(LGSP.G);
                        bw.Write(LGSP.B);




                        MessageBox.Show("Sucessfull FOG Entry Written to: " + entry_offset.ToString());

                    }

                        }
                    


                }

                //private void Memory_Interface_SizeChanged(object sender, EventArgs e)
                //{
                //    if (Memory_Interface.ActiveForm.WindowState == FormWindowState.Minimized)
                //    {
                //        Memory_Interface.ActiveForm.WindowState = FormWindowState.Normal;
                //    }
                //}
            }



        }
    }




