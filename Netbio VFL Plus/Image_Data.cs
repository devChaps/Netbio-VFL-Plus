using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DiscUtils;
using DiscUtils.Iso9660;
using System.Windows.Forms;

namespace Netbio_VFL_Plus
{

    /// <summary>
    /// Structures related to image info
    /// </summary>
   public static class Image_Data
    {
        public static string IMG_FP;
        /// <summary>
        /// structure for general image data extending mostly Disc/Utils/CDReader
        /// </summary>
        public struct Image_Data_Obj
        {
            public DiscUtils.DiscDirectoryInfo[] RootDirectory_Info;
            
            public string[] Directory_Info;
            public DiscUtils.DiscFileInfo[] Root_FInfo;
            public DiscUtils.LogicalVolumeInfo[] Logical_VolumeInfo;
            public DiscUtils.PhysicalVolumeInfo[] Physical_VolumeInfo;
            public DiscUtils.VolumeManager VolumeManager;
            public CDReader Read_Image;
            public CDBuilder Write_Image;
            
            
            public DiscUtils.VolumeInfo Vol_info;
            public DiscUtils.DiscFileSystemInfo[] Root_FSys_Info;           
            public DiscUtils.DiscFileSystemOptions Root_FSystem_Opts;
            public TreeNode[] Root_Nodes;
            public TreeNode[] Dir_Nodes;
            public List<TreeNode> Node_List;
            public ListView AFS_LIST;
            public TreeView Folder_View;
            public System.Windows.Forms.ToolStripTextBox lbl_mainForm;
            public System.Windows.Forms.ToolStripComboBox Volume_Box;

            public string Image_Path; // iso image itself
            public string Selected_Volume; // Selected Root file (netbio00 etc)
            public int Volume_Index;
            public string Volume_Label;
            public string Active_Variant; // format standard
            public string Root_Dir;
            public string FriendlyName;
            public long Cluster_Count;
            public bool IsThreadSafe;
            public bool HasBootIMage;
            public long Physical_Size; // total size of image

        };


        public struct NetBioData
        {
            public string name;
            public Int32 offset;
            public Int32 size;
            
        }

        /// <summary>
        /// Basic File Structure
        /// </summary>
        public struct File_Obj
        {
            public string name;
            public byte[] buffer;
            public long length;
            public DiscUtils.DiscFileInfo[] DiscFileInfo;

        }


        /// <summary>
        /// structure for primary volume descriptor
        /// </summary>
        public struct PrimaryVolume_Obj
        {
            public byte type_flag;
            public string STD_ID;
            public Int32 offset;
       
            public Int32 Volume_Space;
            public Int32 LogicalBlockSz;
            public Int32 PathTableSize;
            public Int32 DirectoryRecord;

        }


       
     


    }



    /// <summary>
    ///  HELPER CLASS FOR DISK MANAGMENT FUNCTIONS
    /// </summary>
    public static class DISKMGM 
    {
    
        public static void ListDirectories(DiscUtils.Iso9660.CDReader Image, RichTextBox DebugLog)
        {

            DiscDirectoryInfo[] Dirs = Image.Root.GetDirectories();

            foreach (DiscDirectoryInfo dir in Dirs)
            {
                DebugLog.AppendText("\n" + dir.FullName);
            }


        }



        public static void DirectoryInfo(CDReader Image, string dirpath, RichTextBox DebugLog)
        {

            DiscDirectoryInfo fi = Image.GetDirectoryInfo(dirpath);
            //Assert.IsNotNull(fi);
            DiscFileInfo[] files = fi.GetFiles();

            foreach (DiscFileInfo file in files) {
                DebugLog.AppendText(file.Name);
            }
        }


        public static void DumpFile(Stream fileStream, string targetFile) 
        {
            
            //tream fileStreams = Image.OpenFile(targetFile, FileMode.Open);

            // create output stream
            var fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\" + targetFile);

            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.CopyTo(fs);

            fileStream.Close();
            fs.Close();




        }



    }

}
