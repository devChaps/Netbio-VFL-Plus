using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscUtils.Iso9660;
using System.IO;

namespace Netbio_VFL_Plus
{
    public partial class Root_Form : Form
    {
        public Root_Form()
        {
            InitializeComponent();
        }

        public List<long> File_Sizes = new List<long>();
        public List<string> File_Names = new List<string>();
        public List<string> DateTime = new List<string>();


        public Image_Data.File_Obj[] File_Data = new Image_Data.File_Obj[0];
        public AFS_IO AFSIO = new AFS_IO();

        private void Root_Form_Load(object sender, EventArgs e)
        {


       
            RootForm_Dbg.Clear();

            TextBox_PhysicalSz.Text = FRM_MAIN.PrimaryVolObj.Volume_Space.ToString() + " (" + FRM_MAIN.Img.Physical_Size.ToString() + " bytes)";
            TextBox_Sector_Sz.Text = FRM_MAIN.PrimaryVolObj.LogicalBlockSz.ToString();



            /// add node heirarchy..
            foreach (var node in FRM_MAIN.Img.Root_Nodes)
            {
                TV_Root.Nodes.Add(node);

            }

        }

        private void BTN_AFSCHECK_Click(object sender, EventArgs e)
        {
            RootForm_Dbg.Clear();
            int index = TV_Root.SelectedNode.Index;
            int afs_sig = 5457473;
            int afs_count = 0;

            TV_Root.SelectedNode = null;

            try
            {
                // if file exists..
                if (File.Exists(FRM_MAIN.Img.Image_Path))
                {

                    // open file stream
                    using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open))
                    {
                        // if valid iso..
                        if (CDReader.Detect(fs))
                        {
                            FRM_MAIN.Img.Read_Image = new CDReader(fs, true, true);
                            FRM_MAIN.Img.Root_FSys_Info = FRM_MAIN.Img.Read_Image.Root.GetFileSystemInfos();


                            FRM_MAIN.Img.Selected_Volume = FRM_MAIN.Img.Root_FSys_Info[index].FullName;
                            MessageBox.Show(FRM_MAIN.Img.Selected_Volume.ToString());
                            // open selected File for further parsing..
                            Stream memStream = FRM_MAIN.Img.Read_Image.OpenFile(FRM_MAIN.Img.Root_FSys_Info[index].FullName, FileMode.Open);
                            BinaryReader br = new BinaryReader(memStream);

                            memStream.Seek(0, SeekOrigin.Begin);

                            // if valid afs sig
                            if (br.ReadInt32() == afs_sig && FRM_MAIN.Img.Root_FSys_Info[index].Extension == "DAT")
                            {
                                afs_count = br.ReadInt32() + 1;

                                AFSIO.dat_parse(memStream, br, FRM_MAIN.Img.AFS_LIST, FRM_MAIN.Img.Folder_View);


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

        private void BTN_RCANCEL_Click(object sender, EventArgs e)
        {
            Root_Form.ActiveForm.Close();
        }

        private void TV_Root_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            int idx = e.Node.Index;

            foreach (var file in FRM_MAIN.Img.Root_FSys_Info)
            {
                File_Names.Add(file.Name);
                DateTime.Add(file.CreationTime.ToShortDateString());
            }


            

            e.Node.ToolTipText = File_Names[idx] + " " + DateTime[idx];
            TT_NodeInfo.ToolTipIcon = ToolTipIcon.Warning;


            TT_NodeInfo.Show(e.Node.ToolTipText, TV_Root);
        }

        private void TV_Root_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RootForm_Dbg.Clear();
            int index = e.Node.Index;
            int afs_sig = 5457473;
            int afs_count = 0;

            TV_Root.SelectedNode = null;

            Root_Form.ActiveForm.Close();
            try
            {

                // if file exists..
                if (File.Exists(FRM_MAIN.Img.Image_Path))
                {

                    // open file stream
                    using (FileStream fs = new FileStream(FRM_MAIN.Img.Image_Path, FileMode.Open))
                    {
                        // if valid iso..
                        if (CDReader.Detect(fs))
                        {


                            FRM_MAIN.Img.Read_Image = new CDReader(fs, true, true);
                            FRM_MAIN.Img.Root_FSys_Info = FRM_MAIN.Img.Read_Image.Root.GetFileSystemInfos();



                            FRM_MAIN.Img.Selected_Volume = FRM_MAIN.Img.Root_FSys_Info[index].FullName; // this
                            FRM_MAIN.Img.Volume_Index = FRM_MAIN.Img.Volume_Box.FindStringExact(FRM_MAIN.Img.Selected_Volume);


                            FRM_MAIN.Img.Volume_Box.SelectedIndex = FRM_MAIN.Img.Volume_Index;

                           // FRM_MAIN.Img.Root_FSys_Info[index].Attributes = FileAttributes.Normal;
                            //   MessageBox.Show(MainForm.Img.Selected_Volume.ToString());
                            // open selected File for further parsing..
                            Stream memStream = FRM_MAIN.Img.Read_Image.OpenFile(FRM_MAIN.Img.Root_FSys_Info[index].FullName, FileMode.Open);
                            BinaryReader br = new BinaryReader(memStream);

                        



                            memStream.Seek(0, SeekOrigin.Begin);

                            // if dat extension
                            if (br.ReadInt32() == afs_sig && FRM_MAIN.Img.Root_FSys_Info[index].Extension == "DAT")
                            {
                                //  MessageBox.Show(fs.Position.ToString());

                                FRM_MAIN.NETBIO00_OFFSET = int.Parse(fs.Position.ToString()) - 4;
                                

                                afs_count = br.ReadInt32() + 1;
                               

                                AFSIO.dat_parse(memStream, br, FRM_MAIN.Img.AFS_LIST, FRM_MAIN.Img.Folder_View);


                            }
                            else if (br.ReadInt32() != afs_sig)
                            {
                                MessageBox.Show("FOUND JACK SHIT SON");
                            }

                            //     MainForm.Img.lbl_mainForm.Text = "Selected Volume: " + MainForm.Img.Selected_Volume;


                         //   FRM_MAIN.Img.Read_Image.Dispose();

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
    }
}
