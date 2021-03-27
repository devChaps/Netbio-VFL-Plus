using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DiscUtils.Iso9660;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using DiscUtils;

namespace Netbio_VFL_Plus
{
    public partial class FRM_MAIN : Form
    {

        private static bool CONTROL_DOWN = false;
        private static bool I_KEY_DOWN = false;




        [DllImport("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc);

        static void MinimizeFootPrint()
        {
            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }


        public struct NBIO_PLAYER
        {
            public float X;
            public float Y;
            public float Z;
            public float X_Copy0;
            public float Y_Copy0;
            public float Z_Copy0;
            //float
            //int, seems to be 0 always?
            //float
            //int, seems to be 0 always?
            //int, seems to be 0 always?
            //float
            public Int16 RotY;
            public Int16 HP;
            public Int16 Max_HP;

            public int Virus;
        }

        public struct NPC_NAMES 
        {
            public string[] name; // npc_names
            public long[] offsets; // entry offset pos
        
        }



       public static NPC_NAMES NAME_OBJ = new NPC_NAMES();

        public static Image_Data.Image_Data_Obj Img;
        
        public static Image_Data.PrimaryVolume_Obj PrimaryVolObj;

        public Image_Data.File_Obj[] Root_Files = new Image_Data.File_Obj[0];
        //   public Image_Data.PrimaryVolume_Obj PrimaryVolObj = new Image_Data.PrimaryVolume_Obj();
        public AFS_IO AFSIO = new AFS_IO();
        public RDT_IO RDT_IO = new RDT_IO();
        public EVB_PARSER EVBIO = new EVB_PARSER();
        public Items ITEMIO = new Items();
        public EMD_IO EMDIO = new EMD_IO();
        public NPC_IO NPCIO = new NPC_IO();
        public NBD_IO NBDIO = new NBD_IO();


        
        // FORM DEFINITIONS 

        public static FRM_ITBL TBL_FORM = new FRM_ITBL();
        public FRM_RDT RDT_FORM = new FRM_RDT();
        public FRM_EVB EVB_FORM = new FRM_EVB();
        public FRM_EMD EMD_FORM = new FRM_EMD();
        public PB_CURROOM NPC_FORM = new PB_CURROOM();
        public FRM_HEX2DEC CALC_FORM = new FRM_HEX2DEC();
        public FRM_DEBUG DEBUG_FORM = new FRM_DEBUG();
        public FRM_ABOUT ABOUT_FORM = new FRM_ABOUT();
        public FRM_NAME_EDIT FRM_NAMETOOL = new FRM_NAME_EDIT();
        public FRM_ItemMemory FRM_IMEM = new FRM_ItemMemory();

        public static int NETBIO00_OFFSET = 0;


        public string g_PROCESS_NAME = "";
        public bool g_STATE = false;

        NBIO_PLAYER[] g_PLAYER = new NBIO_PLAYER[4];


        public FRM_MAIN()
        {
            InitializeComponent();


            this.MaximizeBox = false;

            Img.AFS_LIST = LV_AFS;
            this.MainMenuStrip.Items.Add(new ToolStripSeparator());
            this.MainToolStrip.ImageScalingSize = new Size(48, 48);

            MAINSTATUS_STRIP.SizingGrip = false;



            LV_AFS.Groups.Add(new ListViewGroup("COMPRESSED TEXTURES")); // 0
            LV_AFS.Groups.Add(new ListViewGroup("ROOM DESCRIPTION"));  // 1
            LV_AFS.Groups.Add(new ListViewGroup("3D CONTAINERS(MESH/TEXTURE/SKELETON)")); // 2
            LV_AFS.Groups.Add(new ListViewGroup("ITEM OCCURENCE TABLES")); // 3
            LV_AFS.Groups.Add(new ListViewGroup("AUTODESK MATERIALS?")); // 4
            LV_AFS.Groups.Add(new ListViewGroup("LIGHTING DATA")); // 5
            LV_AFS.Groups.Add(new ListViewGroup("SOFTDEC MPEG VIDEOS")); //6
            LV_AFS.Groups.Add(new ListViewGroup("ADX SOUND CLIPS")); //7
            LV_AFS.Groups.Add(new ListViewGroup("GAME SCRIPTS"));     //8   
            LV_AFS.Groups.Add(new ListViewGroup("WEAPON MODEL DATA (RELOADING)")); //9
            LV_AFS.Groups.Add(new ListViewGroup("Playstation 2 Texture/Icons")); //10
            LV_AFS.Groups.Add(new ListViewGroup("UNDEFINED")); // 11
            LV_AFS.Groups.Add(new ListViewGroup("Collision Data"));


         // LV_ItemTable.Groups.Add(new ListViewGroup("NULL"));

        }


        public static bool Valid_Iso(Stream fs)
        {
            if (CDReader.Detect(fs))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Invalid ISO!");
                return false;
            }
        }


        private static TreeNode CreateDirNode(DiscUtils.DiscDirectoryInfo directoryInfo)
        {
            // create a new node using the passed dir name
            var directoryNode = new TreeNode(directoryInfo.Name);


            foreach (var directory in directoryInfo.GetDirectories())
            {
                //   MessageBox.Show(directory.Attributes.ToString());

                // recursively add 
                directoryNode.Nodes.Add(CreateDirNode(directory));
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            }




            return directoryNode;
        }

        // ###  DISC MANAGEMENT FUNCTIONS ### //
        public void Read_Image()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            Root_Form RF = new Root_Form();
            Stream sstream;


            List<string> Vol_List = new List<string>();

            OFD.Filter = ".AFS(OBF1/OBF2)|*.afs|.DAT(OBF1/OBF2)|*.DAT|.iso(OBF1/OBF2)|*.iso|All Files (*.*)|*.*"; ;
            OFD.FilterIndex = 3;

            OFD.ShowDialog();


            try
            {
                if (File.Exists(OFD.FileName))
                {
                    using (FileStream fs = new FileStream(OFD.FileName, FileMode.Open))
                    {

                        if (Valid_Iso(fs))
                        {
                            Img.Read_Image = new CDReader(fs, true, true);
                            BinaryReader br = new BinaryReader(fs);
                            Img.VolumeManager = new DiscUtils.VolumeManager();
                            Img.Image_Path = OFD.FileName;
                            RDT_IO.FP_DISC = OFD.FileName;
                            
                            

                            int Dir_Count = 0;
                            int File_Count = 0;

                            Img.VolumeManager.AddDisk(fs);

                            
                            

                            Array.Resize(ref Img.Logical_VolumeInfo, Img.VolumeManager.GetLogicalVolumes().Length);
                            Array.Resize(ref Img.Physical_VolumeInfo, Img.VolumeManager.GetPhysicalVolumes().Length);

                            Img.Logical_VolumeInfo = Img.VolumeManager.GetLogicalVolumes();
                            Img.Physical_VolumeInfo = Img.VolumeManager.GetPhysicalVolumes();

                            Img.RootDirectory_Info = Img.Read_Image.Root.GetDirectories();
                            Img.Root_FInfo = Img.Read_Image.Root.GetFiles();
                            Img.Root_FSystem_Opts = Img.Read_Image.Root.FileSystem.Options;
                            Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();

                           

                            Img.Volume_Label = Img.Read_Image.VolumeLabel;
                            Img.Volume_Box = Volume_List;
                            Img.Active_Variant = Img.Read_Image.ActiveVariant.ToString();
                            Img.HasBootIMage = Img.Read_Image.HasBootImage;
                            Img.IsThreadSafe = Img.Read_Image.IsThreadSafe;
                            Img.Root_Dir = Img.Read_Image.Root.Name;
                            Img.Cluster_Count = Img.Read_Image.TotalClusters;
                            Img.AFS_LIST = LV_AFS;
                            Img.Folder_View = TV_FOLDERS;

//                            LBL_Strip.Text = Img.Image_Path;

                            Array.Resize(ref Img.Root_Nodes, Img.Root_FSys_Info.Length);
                            Array.Resize(ref Root_Files, Img.Root_FSys_Info.Length);



                            byte[] sig_buffer = new byte[5];
                            fs.Seek(0x8000, SeekOrigin.Begin); // seek to PVD

                            PrimaryVolObj.type_flag = br.ReadByte();
                            PrimaryVolObj.STD_ID = System.Text.Encoding.ASCII.GetString(br.ReadBytes(sig_buffer.Length), 0, sig_buffer.Length);

                          //  MessageBox.Show(PrimaryVolObj.offset + "PVD");

                            fs.Seek(0x8050, SeekOrigin.Begin);

                            PrimaryVolObj.Volume_Space = br.ReadInt32();

                            fs.Seek(0x8080, SeekOrigin.Begin);
                            PrimaryVolObj.LogicalBlockSz = br.ReadInt16();


                            

                            for (int t = 0; t < Img.Physical_VolumeInfo.Length; t++)
                            {
                                Img.Physical_Size = Img.Physical_VolumeInfo[t].Length;
                            }

                            for (int i = 0; i < Img.Root_FSys_Info.Length; i++)
                            {


                                DEBUG_FORM.DEBUG_LOG.AppendText("\nFSys: [ " + i.ToString() + "] " + Img.Root_FSys_Info[i].Name + " Attr " + Img.Root_FSys_Info[i].Attributes.ToString() + " Offset: " + fs.Position.ToString());

                                if (Img.Root_FSys_Info[i].Attributes.ToString().Contains("Directory"))
                                {
                                    Dir_Count++;

                                    Vol_List.Add(Img.Root_FSys_Info[i].Name);

                                   
                                    

                                    for (int x = 0; x < Img.RootDirectory_Info.Length; x++)
                                    {
                                        Img.Root_Nodes[i] = new TreeNode(Img.Root_FSys_Info[i].Name);

                                        Img.Root_Nodes[i].Nodes.Add(CreateDirNode(Img.RootDirectory_Info[x]));
                                    }


                                }
                                else if (!Img.Root_FSys_Info[i].Attributes.ToString().Contains("Directory"))
                                {
                                    File_Count++;


                                    sstream = Img.Read_Image.GetFileInfo(Img.Root_FSys_Info[i].FullName).Open(FileMode.Open);
                                 

                                    br = new BinaryReader(sstream);

                                    sstream.Seek(0, SeekOrigin.Begin);


                                    // Set struct nodes to file name
                                    Img.Root_Nodes[i] = new TreeNode(Img.Root_FSys_Info[i].Name);
                                    Vol_List.Add(Img.Root_FSys_Info[i].Name);

                                    // if the files have a valid afs signature color code them..
                                    if (AFSIO.AfsValid(sstream, br))
                                    {
                                  //      Img.Root_Nodes[i].ForeColor = GdiColor.Green;

                                    }
                                    else
                                    {
                                    //    Img.Root_Nodes[i].ForeColor = GdiColor.OrangeRed;
                                    }


                                }

                            }



                            DEBUG_FORM.DEBUG_LOG.AppendText("\b [DEBUG] Total Directories: " + Dir_Count.ToString() + "\n Root_File_Count: " + File_Count.ToString());

                        }
                        else
                            MessageBox.Show("Invalid Signature.. ", "Invalid iso9660", MessageBoxButtons.OK);

                        fs.Close();

                    }


                    // clear list/prevent dupes, add combo items
                    Img.Volume_Box.Items.Clear();
                    foreach (string item in Vol_List)
                    {
                        Volume_List.Items.Add(item);

                    }


                   // Img.Read_Image.Dispose();

                   

                    RF.Show();

                }

            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public void DirectoryInfo()
        {
            CDBuilder builder = new CDBuilder();
            CDReader fs = new CDReader(builder.Build(), false);
            DiscDirectoryInfo fi = fs.GetDirectoryInfo(@"SOMEDIR");
             
        }


        private void isoScanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Read_Image();
        }

        private void LV_AFS_ItemActivate(object sender, EventArgs e)
        {
            int index = LV_AFS.SelectedIndices[0];
            int vol_index = Img.Volume_Index; // u need to pass this

            if (File.Exists(Img.Image_Path))
            {
                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                {
                    if (Valid_Iso(fs))
                    {

                        Img.Read_Image = new CDReader(fs, true, true);
                        Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();
                        Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open); // IMG.selected volume wont update correctly, using the quicker volume browsing..
                        BinaryReader br = new BinaryReader(memStream);

                        int sel_siz = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[1].Text);

                        //    MessageBox.Show("Img.Selected Vol " + Img.Root_FSys_Info[vol_index].FullName);


                        AFSIO.cur_archive_offset = sel_siz;


                        DEBUG_FORM.DEBUG_LOG.AppendText("\n Current Archive Offset: " + AFSIO.cur_archive_offset.ToString());


                        if (LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[3].Text.Contains("afs"))
                        {

                            LBL_SelArchive.Text = ScenarioHandler.ARC2_SCE(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[3].Text);

                            AFSIO.AFS_PARSE(memStream, br, int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[1].Text), LV_AFS, sel_siz, Groups_List, PRG_LOAD);
                        }
                       

                        //FormLabel.Text = "Current Volume: " + Img.Selected_Volume.ToString();

                        br.Close();
                        fs.Close();
                        memStream.Close();

                       // Img.Read_Image.Dispose();

                    }

                }

            }
        }

        private void LV_AFS_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (LV_AFS.SelectedItems.Count > 0)
                {
                    int idx = LV_AFS.SelectedIndices[0];
                    string sel_file = string.Empty;

                    if (LV_AFS.Items[idx].SubItems[2].Text != "TABLE OF CONTENTS")
                    {
                        sel_file = LV_AFS.Items[idx].SubItems[3].Text;
                    }
                    else
                    { sel_file = LV_AFS.Items[idx].SubItems[2].Text; }

                    AFS_MENU.Show(Cursor.Position);
                }


            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int vol_index = Img.Volume_Index; // u need to pass this
            int total_selected = 0;
            List<int> selected_offsets = new List<int>();
            List<int> selected_Sizes = new List<int>();
            List<string> Selected_Files = new List<string>();


            for (int i = 0; i < LV_AFS.SelectedItems.Count; i++)
            {
                selected_offsets.Add(int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[i]].SubItems[1].Text));
                selected_Sizes.Add(int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[i]].SubItems[2].Text));
                Selected_Files.Add(LV_AFS.Items[LV_AFS.SelectedIndices[i]].SubItems[3].Text);

                DEBUG_FORM.DEBUG_LOG.AppendText("\n\nIndex[" + i.ToString() + "]" + " Sel Off: " + selected_offsets[i].ToString() + " Sel File:  " + Selected_Files[i].ToString());

            }


            total_selected = Selected_Files.Count;


            if (File.Exists(Img.Image_Path))
            {
                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                {
                    if (Valid_Iso(fs))
                    {

                        Img.Read_Image = new CDReader(fs, true, true);
                        Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();
                        Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open); // IMG.selected volume wont update correctly, using the quicker volume browsing..
                        BinaryReader br = new BinaryReader(memStream);


                        
                        //    int sel_off = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[1].Text);
                        int sel_sz = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[2].Text);


                        // if total selected files is 1, export single file, else run multi export routine..
                        if (total_selected != 0 && total_selected == 1)
                        {
                            AFSIO.Export_File(memStream, LV_AFS, AFSIO.cur_archive_offset, sel_sz);
                        }
                        else
                        {
                            AFSIO.Export_SelectedFIles(memStream, LV_AFS, total_selected, AFSIO.cur_archive_offset, selected_offsets, selected_Sizes, Selected_Files);
                        }



                        // MessageBox.Show("Tselected: " + total_selected.ToString());


                        //if (LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[3].Text.Contains("afs"))
                        //{
                        //    AFSIO.afs_parse(memStream, br, int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[1].Text), LV_AFS, sel_siz);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Not parsing that shit brah!");
                        //}


                        //FormLabel.Text = "Current Volume: " + Img.Selected_Volume.ToString();

                        br.Close();
                        fs.Close();


                    }

                }

            }
        }

        private void sLDUNPACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selected_file_count = 0;

            List<int> file_sizes = new List<int>();
            List<string> file_names = new List<string>();
            List<int> file_offsets = new List<int>();
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Select Export Location...";
            FBD.ShowDialog();

          //  LBL_Strip.Text = "Decompressing...";


            for (int i = 0; i < LV_AFS.SelectedItems.Count; i++)
            {
                selected_file_count++;
                file_offsets.Add(int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[i]].SubItems[1].Text));
                file_sizes.Add(int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[i]].SubItems[2].Text));

                file_names.Add(LV_AFS.Items[LV_AFS.SelectedIndices[i]].SubItems[3].Text);
            }

          //  ProgressBar00.Maximum = selected_file_count;


            if (File.Exists(Img.Image_Path))
            {
                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                {
                    if (Valid_Iso(fs))
                    {
                        Img.Read_Image = new CDReader(fs, true, true);
                        Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();
                        Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open); // IMG.selected volume wont update correctly, using the quicker volume browsing..


                        if (selected_file_count > 1)
                        {
                            // run multi decompress op
                            for (int x = 0; x < selected_file_count; x++)
                            {
                               // ProgressBar00.Value = x;
                                AFSIO.SLD_UNPACK(memStream, LV_AFS, LV_AFS.SelectedIndices[x], AFSIO.cur_archive_offset, file_sizes[x], FBD.SelectedPath + "\\" + file_names[x].Substring(0, file_names[x].Length - 3) + "tm2", DEBUG_FORM.DEBUG_LOG);

                                if (x == selected_file_count - 1)
                                {
                                    MessageBox.Show("Decompression Complete", "BOO YAH", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                   // ProgressBar00.Value = 0;
                                   // LBL_Strip.Text = Img.Image_Path;
                                }
                            }


                        }
                        // run single decompress op
                        else if (selected_file_count == 1)
                        {
                            int sel_off = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[1].Text);
                            int sel_sz = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[2].Text);

                            AFSIO.SLD_UNPACK(memStream, LV_AFS, LV_AFS.SelectedIndices[0], AFSIO.cur_archive_offset, sel_sz, FBD.SelectedPath + "\\" + LV_AFS.FocusedItem.SubItems[3].Text.Substring(0, LV_AFS.FocusedItem.SubItems[3].Text.Length - 3) + "tm2", DEBUG_FORM.DEBUG_LOG);
                        }



                        memStream.Close();

                    }

                }

            }
        }

        private void BTN_VBACK_Click(object sender, EventArgs e)
        {
            int afs_sig = 5457473;
            int afs_count = 0;
            int index = Img.Volume_Index;
            int Combo_Index = Volume_List.SelectedIndex; // bad idea?

            LBL_SelArchive.Text = "";

            Groups_List.Items.Clear();

            try
            {
                // if file exists..
                if (File.Exists(Img.Image_Path))
                {
                    // open file stream
                    using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                    {
                        // if valid iso..
                        if (CDReader.Detect(fs))
                        {
                            Img.Read_Image = new CDReader(fs, true, true);
                            Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();

                            Img.Selected_Volume = Img.Root_FSys_Info[Combo_Index].FullName; // this
                            Img.Volume_Index = Img.Volume_Box.FindStringExact(Img.Selected_Volume);



                            Stream memStream = FRM_MAIN.Img.Read_Image.OpenFile(Img.Root_FSys_Info[Combo_Index].FullName, FileMode.Open);
                            BinaryReader br = new BinaryReader(memStream);

                            memStream.Seek(0, SeekOrigin.Begin);

                            // if valid afs sig
                            if (br.ReadInt32() == afs_sig)
                            {
                                afs_count = br.ReadInt32() + 1;

                                AFSIO.dat_parse(memStream, br, Img.AFS_LIST, Img.Folder_View);


                            }
                            else if (br.ReadInt32() != afs_sig)
                            {
                                MessageBox.Show("FOUND JACK SHIT SON");
                            }


                            fs.Close();
                            br.Close();
                        }
                    }
                }

            }


            catch
            {

            }
        }

        private void Groups_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Groups_List.SelectedIndex;
            int group_count = LV_AFS.Groups[index].Items.Count;

            //    MessageBox.Show(t);

            if (group_count > 0)
            {
                ListViewItem lvi = LV_AFS.Groups[index].Items[1];
                lvi.EnsureVisible();
               
            }
            else
            {
                MessageBox.Show("No Groups of that type in this archive..");
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Direct File Search", "File Search");
            List<string> fnames = new List<string>();

            for (int i = 0; i < LV_AFS.Items.Count; i++)
            {
                if (LV_AFS.Items[i].SubItems[2].Text != "TABLE OF CONTENTS")
                {
                    if (LV_AFS.Items[i].SubItems[3].Text.Contains(input))
                    {
                        LV_AFS.Items[i].EnsureVisible();
                        LV_AFS.Items[i].Selected = true;
                    }
                }

            }
        }

        private void Volume_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTN_VBACK_Click(sender, e);
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
           // PRG_LOAD.Style = ProgressBarStyle.Blocks;
        }

        private void MainToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void MainMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void iTEMTBLINTToolStripMenuItem_Click(object sender, EventArgs e)
        {

          

            string table_name = LV_AFS.FocusedItem.SubItems[3].Text;
            int f_len = table_name.Length;
            string end_val = table_name.Substring(table_name.Length - 6, 2); // this is just for checking online/offline
            bool tbl_check; // 

            
            

            if (File.Exists(Img.Image_Path))
            {
                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                {
                    if (Valid_Iso(fs))
                    {
                     
                        Img.Read_Image = new CDReader(fs, true, true);
                        Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();
                        Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open);


                        if (f_len > 0)
                        {
                            // ITEMIO.READ_TABLE_STREAM(memStream, AFSIO.cur_archive_offset, LV_AFS, LV_ItemTable, CMB_ITEMNAME, )
                        }

                        if (int.Parse(end_val) <= 15)
                        {
                            tbl_check = true;
                            ITEMIO.READ_TABLE_STREAM(memStream, AFSIO.cur_archive_offset, LV_AFS, TBL_FORM.LV_ItemTable, TBL_FORM.CMB_ITEMNAME, tbl_check, DEBUG_FORM.DEBUG_LOG, ItemIco_List);
                        }
                        else
                        {
                            tbl_check = false;
                            ITEMIO.READ_TABLE_STREAM(memStream, AFSIO.cur_archive_offset, LV_AFS, TBL_FORM.LV_ItemTable, TBL_FORM.CMB_ITEMNAME, tbl_check, DEBUG_FORM.DEBUG_LOG, ItemIco_List);
                        }

                        TBL_FORM.ShowDialog();
                    }

                }

            }
        }

        private void rDTINTToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int index = LV_AFS.SelectedIndices[0];

            if (File.Exists(Img.Image_Path))
            {
                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                {


                    if (Valid_Iso(fs) && LV_AFS.FocusedItem.SubItems[3].Text.Substring(LV_AFS.FocusedItem.SubItems[3].Text.Length - 3, 3).ToUpper() == "RDT")
                    {
                    
                        Img.Read_Image = new CDReader(fs, true, true);
                        Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();
                        Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open); // IMG.selected volume wont update correctly, using the quicker volume browsing..


                        int i = LV_AFS.FocusedItem.Index;
                        int afs_offset = int.Parse(LV_AFS.Items[i].SubItems[1].Text);

                        // transfer archive offset to RDT class
                        RDT_IO.ARCHIVE_OFFSET = AFSIO.cur_archive_offset;

                        RDT_IO.Read_RDT(memStream, AFSIO.cur_archive_offset, index, LV_AFS, RDT_FORM.LV_RDT, DEBUG_FORM.DEBUG_LOG, RDT_FORM.LBL_RDTSELECT, RDT_FORM.LBL_RDTSIZE, RDT_FORM.LBL_RDT_OFF);


                        fs.Close();

                        RDT_FORM.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Cant Run this operation, not a valid RDT selected!", "Wrong File Brah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        public void Toggle_Display() // Toggle EVB Display MOde
        {
            if (EVB_FORM.LV_INTCODE.Visible)
            {
                EVB_FORM.LV_INTCODE.Visible = false;
                EVB_FORM.LV_BYTECODE.Visible = true;


            }
            else
            {
                EVB_FORM.LV_INTCODE.Visible = true;
                EVB_FORM.LV_BYTECODE.Visible = false;
            }

        }


        private void toggleDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void eVBINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EVB_FORM.LV_BYTECODE.Items.Clear();
            EVB_FORM.LV_INTCODE.Items.Clear();

            int EVB_SIZE = int.Parse(LV_AFS.FocusedItem.SubItems[2].Text);

            //FormatController.SelectedIndex = 3;

            if (File.Exists(Img.Image_Path))
            {
                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                {
                    if (Valid_Iso(fs))
                    {
                        Img.Read_Image = new CDReader(fs, true, true);
                        Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();

                        Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open);

                        EVBIO.PARSE_EVB_STREAM(memStream, AFSIO.cur_archive_offset, EVB_SIZE, DEBUG_FORM.DEBUG_LOG, LV_AFS, EVB_FORM.LV_BYTECODE, EVB_FORM.LV_INTCODE, EVB_FORM, PRG_LOAD);
                       
                        EVB_FORM.ShowDialog();
                    }

                }

            }
        }

        private void iTEMDATINTToolStripMenuItem_Click(object sender, EventArgs e)
        {

           

            // PARSE ITEM_DAT FROM WITHIN MOUNTED ARCHIVE
            if (File.Exists(Img.Image_Path)) {
                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open)) {

                    if (Valid_Iso(fs)) {

                        Img.Read_Image = new CDReader(fs, true, true);
                        Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();


                        using (Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open)) {

                          //  ITEMIO.Parse_IDataStream(memStream, AFSIO.cur_archive_offset, LV_AFS, DAT_FORM.LV_IDataHeader, DAT_FORM.LV_ItemData);
                         //   DAT_FORM.ShowDialog();

                        }

                    }
                
                
                }
            
            }


        }

        private void eMDINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                int index = LV_AFS.SelectedIndices[0];
                bool Online; // Online Flag


                // CHECK VALID FILE PATH
                if (File.Exists(Img.Image_Path)) {

                    // OPEN FILE STREAM
                    using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)) 
                    {

                        // ENSURE IT HAS VALID AFS SIG + EMD EXTENSION
                        if (Valid_Iso(fs) && LV_AFS.FocusedItem.SubItems[3].Text.Substring(LV_AFS.FocusedItem.SubItems[3].Text.Length - 3, 3).ToUpper() == "EMD")
                        {
                            // DIFFERENTIATE BETWEEN ONLINE/OFFLINE EMD DATA
                            if (LV_AFS.FocusedItem.SubItems[3].Text.Substring(0, 3).ToUpper() == "SGL")
                            {
                                Online = false;
                            }
                            else 
                            {
                                Online = true;
                            }

                            // 
                            Img.Read_Image = new CDReader(fs, true, true);
                            Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();
                            Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open);
                            


                                EMDIO.Parse_EMDStream(memStream, AFSIO.cur_archive_offset, 
                                    ScenarioHandler.ARC2_VAL(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[3].Text),
                                    ScenarioHandler.GAME_CHECK(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[3].Text),
                                    LV_AFS, EMD_FORM.LB_EMD_OFFSETS, EMD_FORM.PB_EMD_ROOM, EMD_FORM.PB_EMD, EMD_FORM.LBL_OFFSET, EMD_FORM.LBL_FTYPE);

                            SetWindowTheme(EMD_FORM.Handle, "", "");
                                EMD_FORM.ShowDialog();


                                memStream.Close();
                                memStream.Dispose();
                                Img.Read_Image.Dispose();

                            
                          

                        }
                        
                    }
                  
                }
            
            }

            catch (Exception ex) {

                MessageBox.Show(ex.Message);
               

            }

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int vol_index = Img.Volume_Index; // u need to pass this
            int total_selected = 0;
            int sel_sz = 0;
            int sel_off;

            int selected_offset = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[1].Text);

             sel_off = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[1].Text);
             sel_sz = int.Parse(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[2].Text);

            AFSIO.Import_File(LV_AFS, NETBIO00_OFFSET, AFSIO.cur_archive_offset, sel_sz);

        }

        private void checkLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f1 = new FileInfo(Img.Image_Path);
            IsFileLocked(f1);
        }


        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            file.Attributes = FileAttributes.Normal;
            MessageBox.Show(file.FullName + file.Attributes);
            //  File.SetAttributes(file.FullName, ~FileAttributes.ReadOnly);
            // MessageBox.Show(File.GetAttributes(file.FullName).ToString());



            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                MessageBox.Show("Locked");
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            MessageBox.Show("Not locked");
            //file is not locked
            return false;
        }

        private void fontSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog FD = new FontDialog();
            FD.ShowColor = true;
            FD.ShowEffects = true;
            FD.ShowApply = true;
            FD.ShowDialog();

            LV_AFS.Font = FD.Font;

        }

        private void BTN_RAM_ButtonClick(object sender, EventArgs e)
        {
            // FIND_PROCESS();

            TMR_EXE.Enabled = true; 
            
      


            

        }



        private void FIND_PROCESS()
        {
            

            Process[] processlist = Process.GetProcesses();
            List<string> tmp_list = new List<string>();

            g_PROCESS_NAME = string.Empty;
            

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
                LBL_VERSION.Text = "PCSX2 DETECTED : " + g_PROCESS_NAME.ToString();
                LBL_VERSION.BackColor = Color.CornflowerBlue;
                TMR_EXE.Enabled = true;
                //LBL_STATUS.Text = "PCSX2 DETECTED : " + g_PROCESS_NAME.ToString();
            }
            else if (g_PROCESS_NAME.Length == null || g_PROCESS_NAME.Length == 0)
            {
                LBL_VERSION.Text = "PCSX2 NOT FOUND!!!";
                LBL_VERSION.BackColor = Color.Red;
                TMR_EXE.Enabled = false;
                //LBL_STATUS.Text = "PCSX2 IS NOT RUNNING";
            }


        }

        private void GET_PLAYER()
        {
            
                //==============================================================================
                //File 1
                //==============================================================================
                //Biohazard Outbreak            (NTSC-J)    0x202321B3  [STRING*10] = SLPM-65428
                //Resident Evil Outbreak        (NTSC-U)    0x2024FB23  [STRING*10] = SLUS-20765
                //Resident Evil Outbreak        (PAL)       0x202339B2  [STRING*10] = SLES-51589
                //==============================================================================
                //File 2
                //==============================================================================
                //Biohazard Outbreak File 2     (NTSC-J)    0x2023DFD3  [STRING*10] = SLPM-65692
                //Resident Evil Outbreak File 2 (NTSC-U)    0x20255083  [STRING*10] = SLUS-20984
                //Resident Evil Outbreak File 2 (PAL)       0x2024E5A2  [STRING*10] = SLES-53319

                Process[] exe_proc = Process.GetProcessesByName(g_PROCESS_NAME);
                var proc = exe_proc[0];
                IntPtr windowHandle = exe_proc[0].MainWindowHandle;

            int ROOMID_ADDR = 0;
            int CAMID_ADDR = 0;

            //If active window is not the PCSX2 GSdx window... 
            //   if(exe_proc[0].MainWindowTitle.Substring(0,4) != "GSdx") {this.Visible = false;}
            //   else {this.Visible = true;}


            // ShowWindow(windowHandle, 9);
            //  BringToFront(exe_proc[0]);

            int g_Game_ID = 0;
                int g_Region = 0;

                //Biohazard Outbreak (NTSC-J)
                if (Memory.Read<int>(proc, new IntPtr(0x202321B3)) == 0x4D504C53)
                {
                    g_Game_ID = 1;
                    g_Region = 1;
              //   CAMID_ADDR = 0x203B31D3; TO BE DETERMINED
                    ROOMID_ADDR = 0x203065AC;
                LBL_VERSION.Text = "Biohazard Outbreak (NTSC-J)";
                }
                //Resident Evil Outbreak (NTSC-U)
                if (Memory.Read<int>(proc, new IntPtr(0x2024FB23)) == 0x53554C53)
                {
                    g_Game_ID = 1;
                    g_Region = 2;
                    LBL_VERSION.Text = "Resident Evil Outbreak (NTSC-U)";
                }
                //Resident Evil Outbreak (PAL)
                if (Memory.Read<int>(proc, new IntPtr(0x202339B2)) == 0x53454C53)
                {
                    g_Game_ID = 1;
                    g_Region = 3;
                    LBL_VERSION.Text = "Resident Evil Outbreak (PAL)";
                }

                //Biohazard Outbreak File 2 (NTSC-J)
                if (Memory.Read<int>(proc, new IntPtr(0x2023DFD3)) == 0x4D504C53)
                {
                    g_Game_ID = 2;
                    g_Region = 1;
             
                CAMID_ADDR = 0x203B31D3;
                ROOMID_ADDR = 0x203137BC;
                LBL_VERSION.Text = "Biohazard Outbreak File 2 (NTSC-J)";
                }
                //Resident Evil Outbreak File 2 (NTSC-U)
                if (Memory.Read<int>(proc, new IntPtr(0x20255083)) == 0x53554C53)
                {
                    g_Game_ID = 2;
                    g_Region = 2;
                    LBL_VERSION.Text = "Resident Evil Outbreak File 2 (NTSC-U)";
                }
                //Resident Evil Outbreak File 2 (PAL)
                if (Memory.Read<int>(proc, new IntPtr(0x2024E5A2)) == 0x53454C53)
                {
                    g_Game_ID = 2;
                    g_Region = 3;
                    LBL_VERSION.Text = "Resident Evil Outbreak File 2 (PAL)";
                }

                int o_base = 0x2047BD30;
                int g_Time = 0;


                //File 1
                if (g_Game_ID == 1 && g_Region == 1) { o_base = 0; }
                if (g_Game_ID == 1 && g_Region == 2) { o_base = 0x204A5BB4; }           //US >> PAL (SUB) 0x40FB0
                if (g_Game_ID == 1 && g_Region == 3) { o_base = 0x20464C04; }
                //File 2
                if (g_Game_ID == 2 && g_Region == 1) { o_base = 0x2047BD30; }
                if (g_Game_ID == 2 && g_Region == 2) { o_base = 0x2047BD30 + 0x4A0E0; } //Adjust JAP offsets by +0x4A0E0
                if (g_Game_ID == 2 && g_Region == 3) { o_base = 0x2047BD30 + 0x69360; }

                g_Time = Memory.Read<int>(proc, new IntPtr(o_base - 0xF0F48));

                g_PLAYER[0].X = Memory.Read<float>(proc, new IntPtr(o_base + 0x38));
                g_PLAYER[0].Y = Memory.Read<float>(proc, new IntPtr(o_base + 0x3C));
                g_PLAYER[0].Z = Memory.Read<float>(proc, new IntPtr(o_base + 0x40));

                g_PLAYER[0].RotY = Memory.Read<Int16>(proc, new IntPtr(o_base + 0x92));

                g_PLAYER[0].HP = Memory.Read<Int16>(proc, new IntPtr(o_base + 0x540));
                g_PLAYER[0].Max_HP = Memory.Read<Int16>(proc, new IntPtr(o_base + 0x542));

                if (g_Game_ID == 1) { g_PLAYER[0].Virus = Memory.Read<int>(proc, new IntPtr(o_base + 0xBA8)); }
                if (g_Game_ID == 1 && g_Region == 3) { g_PLAYER[0].Virus = Memory.Read<int>(proc, new IntPtr(o_base + 0xBC0)); }
                if (g_Game_ID == 2) { g_PLAYER[0].Virus = Memory.Read<int>(proc, new IntPtr(o_base + 0xBC4)); }



                TimeSpan playtime = TimeSpan.FromSeconds((g_Time * 2) / 60);
             //   LBL_VAL_PLAYTIME.Text = playtime.ToString();

                LBL_POS_X.Text = (g_PLAYER[0].X).ToString().Replace(",", ".");
                LBL_POS_Y.Text = (g_PLAYER[0].Y).ToString().Replace(",", ".");
                LBL_POS_Z.Text = (g_PLAYER[0].Z).ToString().Replace(",", ".");

                byte cam_id = Memory.Read<byte>(proc, new IntPtr(0x203B31D3));

                byte ROOM_ID = Memory.Read<byte>(proc, new IntPtr(ROOMID_ADDR));

                LBL_RID.Text = "Current ROOM ID: " + ROOM_ID.ToString();
                LBL_CID.Text = "Camera ID: " + cam_id.ToString();

            //LBL_.Text = (g_PLAYER[0].RotY).ToString();

            //LBL_H.Text = (g_PLAYER[0].HP).ToString() + " / " + (g_PLAYER[0].Max_HP).ToString();

            //if (g_PLAYER[0].HP > 0)
            //{
            //    BAR_HP.Maximum = g_PLAYER[0].Max_HP;
            //    BAR_HP.Minimum = 0;

            //    BAR_HP.Value = g_PLAYER[0].HP;
            //}
            //else
            //{
            //    BAR_HP.Maximum = 100;
            //    BAR_HP.Minimum = 0;

            //    BAR_HP.Value = 0;
            //}

            //int fakeval = g_PLAYER[0].Virus;


            //float divVal2 = 1512.1875f;
            //float tmp_float = fakeval / divVal2;
            //LBL_VAL_VIRUS.Text = (Convert.ToDecimal(Math.Round(tmp_float, 2))).ToString().Replace(",", ".") + "%";

            //GET POINTER TO PLAYER STRUCT OFFSET...
            //int o_player = Memory.Read<int>(proc, new IntPtr(0x5E002C));

            //g_PLAYER.X = Memory.Read<Int16>(proc, new IntPtr(o_player + 0x40));
            //g_PLAYER.Z = Memory.Read<Int16>(proc, new IntPtr(o_player + 0x42));
            //g_PLAYER.Y = Memory.Read<Int16>(proc, new IntPtr(o_player + 0x44));
            //g_PLAYER.R = Memory.Read<Int16>(proc, new IntPtr(o_player + 0x4A));
            //g_PLAYER.Floor = Memory.Read<byte>(proc, new IntPtr(o_player + 0x5A));
            //g_PLAYER.HP = Memory.Read<Int16>(proc, new IntPtr(o_player + 0x108));

            //g_PLAYER.Playtime = Memory.Read<int>(proc, new IntPtr(0x87EEB8));
            //g_PLAYER.Ext_Points = Memory.Read<int>(proc, new IntPtr(0x87F014));

            //DISPLAY STUFF...
            //LBL_X.Text = g_PLAYER.X.ToString();
            //LBL_Z.Text = g_PLAYER.Z.ToString();
            //LBL_Y.Text = g_PLAYER.Y.ToString();
            //LBL_R.Text = g_PLAYER.R.ToString();
            //LBL_FLOOR.Text = g_PLAYER.Floor.ToString();
            //LBL_HP.Text = g_PLAYER.HP.ToString();

            //LBL_PTS.Text = g_PLAYER.Ext_Points.ToString();

            //if (g_PLAYER.HP >= 0 && g_PLAYER.HP <= 2400)
            //{
            //BAR_HP.Value = g_PLAYER.HP;

            //0-574		Danger
            //575-1149	Caution Red
            //1150-1724	Caution
            //1725-2300	Fine

            //if (g_PLAYER.HP > 600) { BAR_HP.ForeColor = Color.LimeGreen;}
            //if (g_PLAYER.HP > 300 && 
            //g_PLAYER.HP < 601) { BAR_HP.ForeColor = Color.Gold; }
            //if (g_PLAYER.HP < 301) { BAR_HP.ForeColor = Color.Red; }

            //}
            //else
            //{
            //    BAR_HP.Value = 0;
            //}

            //TimeSpan gtime = TimeSpan.FromSeconds(g_PLAYER.Playtime / 60);
            //TXT_TIME.Text = gtime.ToString();



        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABOUT_FORM.ShowDialog();

        }

        private void LV_AFS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if () 
            //{
            //    MessageBox.Show("CONTROL TEST");
            //}
            

        }

        private void LV_AFS_KeyDown(object sender, KeyEventArgs e)
        {
            string sel_fmt = string.Empty;

            CONTROL_DOWN = false;

            if (e.Control && e.KeyCode == Keys.I) 
            {
                CONTROL_DOWN = true;

                if (LV_AFS.SelectedIndices.Count > 0) 
                {
                    sel_fmt = LV_AFS.FocusedItem.SubItems[3].Text.Substring(LV_AFS.FocusedItem.SubItems[3].Text.Length - 3, 3);

                    switch (sel_fmt.ToUpper()) 
                    {
                        case "EMD":
                            eMDINTToolStripMenuItem_Click(sender, e);
                            break;
                        case "RDT":
                            rDTINTToolStripMenuItem_Click(sender, e);
                            break;
                        case "TBL":
                            iTEMTBLINTToolStripMenuItem_Click(sender, e);
                            break;
                        case "EVB":
                            eVBINTToolStripMenuItem_Click(sender, e);
                            break;
                        case "DAT":
                            break;
                        case "NPC":
                            nPCINTToolStripMenuItem_Click(sender, e);
                            break;



                    }

                }



            }

        }

        private void LV_AFS_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.ControlKey)
            {
                CONTROL_DOWN = false;
             //   MessageBox.Show(e.KeyValue.ToString() + e.Modifiers);


            }
        }

        private void TMR_EXE_Tick(object sender, EventArgs e)
        {
             int g_region = LIB_MEMORY.g_GAME_REGION;
            int g_id = LIB_MEMORY.g_GAME_ID;


            LIB_MEMORY.GET_PCSX2_PROC();
            LBL_VERSION.Text = LIB_MEMORY.VERIFY_GAME_REGION();

            LIB_MEMORY.GET_MEM_STATS(LIB_MEMORY.GET_OFFSET_BASE(g_region, g_id));

            LBL_POS_X.Text = LIB_MEMORY.G_PLAYER.X.ToString();


            LBL_POS_Y.Text = LIB_MEMORY.G_PLAYER.Y.ToString();
            LBL_POS_Z.Text = LIB_MEMORY.G_PLAYER.Z.ToString();

            LBL_RID.Text = "ROOM ID: " + LIB_MEMORY.G_ROOM_DATA.ROOM_ID.ToString();
            LBL_CID.Text = "CAM ID: " + LIB_MEMORY.G_ROOM_DATA.CAM_ID.ToString();


            //  GET_PLAYER();
        }

        private void BTN_DNAS_Click(object sender, EventArgs e)
        {
            LIB_DNAS.GAME_CHECK();
        }

        private void BTN_DEBUGLOG_Click(object sender, EventArgs e)
        {
            DEBUG_FORM.Show();

        }

        private void BTN_CALC_Click(object sender, EventArgs e)
        {
            CALC_FORM.ShowDialog();
        }

        private void nPCINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
               int index = LV_AFS.SelectedIndices[0];
               
                // CHECK VALID FILE PATH
                if (File.Exists(Img.Image_Path))
                {

                    // OPEN FILE STREAM
                    using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open))
                    {

                        // ENSURE IT HAS VALID AFS SIG + EMD EXTENSION
                        if (Valid_Iso(fs) && LV_AFS.FocusedItem.SubItems[3].Text.Substring(LV_AFS.FocusedItem.SubItems[3].Text.Length - 3, 3).ToUpper() == "NPC")
                        {
                            
                            Img.Read_Image = new CDReader(fs, true, true);
                            Img.Root_FSys_Info = Img.Read_Image.Root.GetFileSystemInfos();
                            Stream memStream = Img.Read_Image.OpenFile(Img.Selected_Volume, FileMode.Open);

                            
                                   NPCIO.READ_NPC_STREAM(memStream, AFSIO.cur_archive_offset, ScenarioHandler.GAME_CHECK(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[3].Text), ScenarioHandler.ARC2_VAL(LV_AFS.Items[LV_AFS.SelectedIndices[0]].SubItems[3].Text), LV_AFS, NPC_FORM.Lst_Header, NPC_FORM.Lst_Entries);
                                   NPC_FORM.ShowDialog();
                              //  EMD_FORM.ShowDialog();
                            

                        }

                    }

                }

            

            
        }

        private void BTN_IMG_Click(object sender, EventArgs e)
        {

            // just re use the menu button
            isoScanToolStripMenuItem_Click(sender, e);
        }

        private void BTN_PL_NAME_Click(object sender, EventArgs e)
        {

            byte GAME_VERSION = 0;
            Int32 data_check = 0;

            try
            {


            





                // 2065640 FILE 1 OFFSET




                using (FileStream fs = new FileStream(Img.Image_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (BinaryReader br = new BinaryReader(fs, new ASCIIEncoding()))
                    {


                        fs.Seek(33592, SeekOrigin.Begin);
                        data_check = br.ReadInt32();

                        if (data_check == 808924466)
                        {
                            GAME_VERSION = 1;



                        } // FILE 1 
                        if (data_check == 809055544)
                        {


                            GAME_VERSION = 2;



                        } // FILE 2





                        if (GAME_VERSION == 1)
                        {

                            // seek to name data
                            fs.Seek(2065640, SeekOrigin.Begin);

                            // resize string to num of entries + offsets
                            Array.Resize(ref NAME_OBJ.name, 784 / 8);
                            Array.Resize(ref NAME_OBJ.offsets, NAME_OBJ.name.Length);

                            // loop through entries and convert b array to ascii / store in structure for later use
                            for (int i = 0; i < NAME_OBJ.name.Length; i++)
                            {
                                NAME_OBJ.offsets[i] = fs.Position; // store offsets to each entry
                                byte[] buffer = br.ReadBytes(8);
                                NAME_OBJ.name[i] = System.Text.Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                                //   MessageBox.Show(NAME_OBJ.name[i]);

                            }


                        }


                            if (GAME_VERSION == 2)
                        {

                            // seek to name data
                            fs.Seek(2107032, SeekOrigin.Begin);

                            // resize string to num of entries + offsets
                            Array.Resize(ref NAME_OBJ.name, 784 / 8);
                            Array.Resize(ref NAME_OBJ.offsets, NAME_OBJ.name.Length);

                            // loop through entries and convert b array to ascii / store in structure for later use
                            for (int i = 0; i < NAME_OBJ.name.Length; i++)
                            {
                                NAME_OBJ.offsets[i] = fs.Position; // store offsets to each entry
                                byte[] buffer = br.ReadBytes(8);
                                NAME_OBJ.name[i] = System.Text.Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                                //   MessageBox.Show(NAME_OBJ.name[i]);

                            }

                        }
                    }

                }
            }
            catch (Exception ex) 
            {
            

            
            }
            // SHOW FORM
            FRM_NAMETOOL.ShowDialog();
        }

        
        /// <summary>
        /// SHOW ITEM PROPERTIES MEMORY FORM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
             // LOAD ITEM PROPERTIES MEMORY FORM
            FRM_IMEM.ShowDialog();
        }

        private void BTN_SOUND_Click(object sender, EventArgs e)
        {

            
            FRM_AUDIO AUDIO_FORM = new FRM_AUDIO();

            AUDIO_FORM.Show();


        }

        private void MAINSTATUS_STRIP_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
