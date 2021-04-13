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
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualBasic;
using DiscUtils.Common;


namespace Netbio_VFL_Plus
{
   
	public struct dat_header_obj
	{
		public Int32 offset; // resize based on afs count
		public Int32 size; // resize based on afs count
        public string Name;
        
	}

	public struct afs_header_obj 
	{
		public Int32 offset;
		public Int32 size;
        public string Name;
	}    
    
	public struct date_time_obj 
	{
		public Int16 Year;
		public Int16 Month;
		public Int16 Day;
		public Int16 Hour;
		public Int16 Minute;
		public Int16 Second;
		public DateTime DT;
		public Int32 f_size;
	}

    public class AFS_IO
    {

        public int cur_archive_offset = 0; // this will be used to hold the selected archive offset so that way i can grab each file from within an afs archive from a .dat relative layer
        public string export_file_path = string.Empty;
        public string import_file_path = string.Empty;



        /// <summary>
        /// assign formats to a group
        /// </summary>
        public Dictionary<string, int> LUT_GROUPING = new Dictionary<string, int>()
        {

            {"SLD", 0},
            {"RDT", 1},
            {"NBD", 2},
            {"TBL", 3},
            {"DAT", 3},
            {"MAT", 4},
            {"FOG", 5},
            {"LIG", 5},
            {"SFD", 6},
            {"EVB", 8},
            {"EMD", 8},
            {"SGL", 8},
            {"NPC", 8},
            {"ITT", 0},
            {"WMD", 9},
            {"IMG", 10},
            {"TM2", 10},
            {"SND", 13},
            {"ADX", 13},
            {"SNP", 13}



        };




        /// <summary>
        /// Formaat, return full description
        /// </summary>
        public Dictionary<string, string> LUT_FORMATS = new Dictionary<string, string>()
        {
            {"RDT", "ROOM DESCRIPTION"},
            {"AFS", "FILE ARCHIVE"},
            {"NBD", "3D Container"},
            {"SND", "SOUND CONTAINER"},
            {"TM2", "PS2 TEXTURE"},
            {"SLD", "COMPRESSED TIM2 (ROOM)" },
            {"EMD", "ENEMY DATA" },
            {"ITT", "KEY ITEM ICONS" },
            {"SGL", "EVENT SCRIPT" },
            {"EVB", "EVENT SCRIPT" },
            {"TBL", "ITEM TABLE"},
            {"NPC", "NPC SCRIPT"},
            {"LIG", "LIGHT DATA"},
            {"FOG", "FOG DATA"},
            {"MAT", "Autodesk Material?" },
            {"WMD", "Weapon Model Data" },
            {"ADX", "Sound Clip" },
            {"SNP", "Enemy Sound Bank" },
            {"HTM", "HTML PAGE(ONLINE)"},
            {"SFD", "Softdec MPEG" },
            {"DAT", "Data.."},


        };


        /// <summary>
        /// Will have to change the colors to use a var from config later..
        /// </summary>
        public Dictionary<string, Color> LUT_EXTCOLOR = new Dictionary<string, Color>()
        {
            {"RDT", Color.LightSteelBlue},
            {"NBD", Color.LightCoral},
            {"SND", Color.DarkOrange},
            {"TM2", Color.LightSeaGreen},
            {"SLD", Color.LightGreen},
            {"EMD", Color.OrangeRed},
            {"ITT", Color.LightSalmon},
            {"SGL", Color.CornflowerBlue },
            {"EVB", Color.LightYellow},
            {"TBL", Color.LightCyan},
            {"NPC", Color.LightSkyBlue},
            {"LIG", Color.Coral},
            {"FOG", Color.CadetBlue},
            {"MAT", Color.Fuchsia },
            {"WMD", Color.BlueViolet},
            {"ADX", Color.MintCream},
            {"SNP", Color.MistyRose},
            {"HTM", Color.LightGreen },
            {"SFD", Color.AliceBlue},
            {"DAT", Color.Crimson},
            {"AFS", Color.White}

        };




        /// <summary>
        /// Look up for File 1 player extensions
        /// </summary>
        //public Dictionary<string, string> LUT_PlayerExtensionF1 = new Dictionary<string, string>
        //{

        //    {"00", "00"}

        //};


        /// <summary>
        /// LUT for Returning description of said extensions, both high/low poly versions/NPCS FOr File 2...
        /// </summary>
        public Dictionary<string, string> LUT_PlayerExtensionF2 = new Dictionary<string, string>()
        {
            {"P00_00.NBD", "Kevin A"},
            {"EP00_00.NBD", "Kevin A "},
            {"P00_01.NBD", "Kevin B (CowBoy)"},
            {"EP00_01.NBD", "Kevin B (CowBoy)"},
            {"P00_02.NBD", "Kevin C (CollegeBoy)"},
            {"EP00_02.NBD", "Kevin C (CollegeBoy)"},
            {"P01_00.NBD", "Mark A (Security)"},
            {"EP01_00.NBD", "Mark A (Security)"},

            {"P01_01.NBD", "Mark B (Causal)"},
            {"EP01_01.NBD", "Mark B (Causal)"},
            {"P01_02.NBD", "Mark C (Military)"},
            {"EP01_02.NBD", "Mark C (Military)"},
            {"P02_00.NBD", "Jim A (Subway)" },
            {"EP02_00.NBD", "Jim A (Subway)" },
            {"P02_01.NBD", "Jim B (B-Baller) "},
            {"EP02_01.NBD", "Jim B (B-Baller)" },
            {"P02_02.NBD", "Jim C (FannyPack)"},
            {"EP02_02.NBD", "Jim C (FannyPack)"},
            {"P03_00.NBD", "George A (Casual Suit)"},
            {"EP03_00.NBD", "George A (Casual Suit)"},
            {"P03_01.NBD", "George B (John Lenon)"},
            {"EP03_01.NBD", "George B (John Lenon)"},
            {"P03_02.NBD", "George C (Doctor)"},
            {"EP03_02.NBD", "George C (Doctor)"},
            {"P04_00.NBD", "David A (Plumber)"},
            {"EP04_00.NBD", "David A (Plumber)"},
            {"P04_01.NBD", "David B (Mafia)"},
            {"EP04_01.NBD", "David B (Mafia)"},
            {"P04_02.NBD", "David C (Half-Naked)"},
            {"EP04_02.NBD", "David C (Half-Naked)"},
            {"P05_00.NBD", "Alyssa A (Reporter)"},
            {"EP05_00.NBD", "Alyssa A (Reporter)"},
            {"P05_01.NBD", "Alyssa B (Athlete)"},
            {"EP05_01.NBD", "Alyssa B (Athlete)"},
            {"P05_02.NBD", "Alyssa C (Skimpy Dress)"},
            {"EP05_02.NBD", "Alyssa C (Skimpy Dress)"},
            {"P05_03.NBD", "Alyssa D (Black Belt)"},
            {"EP05_03.NBD", "Alyssa D (Black Belt)"},
            {"P05_04.NBD", "Alyssa E (Beach Outfit)"},
            {"EP05_04.NBD", "Alyssa E (Beach OutFit)"},
            {"P06_00.NBD", "Yoko A (Student)"},
            {"EP06_00.NBD", "Yoko A (Student)"},
            {"P06_01.NBD", "Yoko B (Gown)"},
            {"EP06_01.NBD", "Yoko B (Gown)"},
            {"P06_02.NBD", "Yoko C (Casual-Shorts)"},
            {"EP06_02.NBD", "Yoko C (Casual-Shorts"},
            {"P06_03.NBD", "Yoko D (DPRK)"},
            {"EP06_03.NBD", "Yoko D (DPRK)"},
            {"P06_04.NBD", "Yoko E (Swim Suit)"},
            {"EP06_04.NBD", "Yoko E (Swim Suit)"},
            {"P07_00.NBD", "Cindy A (Waitress"},
            {"EP07_00.NBD", "Cindy A (Waitress)"},
            {"P07_01.NBD", "Cindy B (Casual)"},
            {"EP07_01.NBD", "Cindy B (Casual)"},
            {"P07_02.NBD", "Cindy C (Bunny)"},
            {"EP07_02.NBD", "Cindy C (Bunny)"},
            {"P07_03.NBD", "Cindy D (Black Leather)"},
            {"EP07_03.NBD", "Cindy D (Black Leather)"},
            {"P07_04.NBD", "Cindy E (Skimpy)"},
            {"EP07_04.NBD", "Cindy E (Skimpy)"},
            {"N00.NBD", "MAC"},
            {"N01.NBD", "RODRIGEZ"},
            {"N02.NBD", "CONRAD"},
            {"N03.NBD", "HUNK: B"},
            {"N04.NBD", "HUNK: A"},
            {"N05.NBD", "MIGUEL"},
            {"N06.NBD", "MIGUEL?"},
            {"N07.NBD", "LUKE"},
            {"N08.NBD", "??"},
            {"N09.NBD", "ARNOLD"},
            {"N10.NBD", "MATT"},
            {"N11.NBD", "BILLY"},
            {"N12.NBD", "HURSH"},
            {"N13.NBD", "HURSH(Injured)" },
            {"N14.NBD", "HURSH(Dead)"},
            {"N15.NBD", "SKINNY DUDE?" },
           // {"N16" }













        };


        /// <summary>
        /// return image index based on format?
        /// </summary>
        public Dictionary<string, int> LUT_IMAGEINDEX = new Dictionary<string, int>()
        {
            {"RDT", 3},
            {"NBD", 4}
        };


        public dat_header_obj[] DAT_HEADER = new dat_header_obj[0];
		public date_time_obj[] DATE_TIME = new date_time_obj[0];
		public afs_header_obj[] AFS_HEADER = new afs_header_obj[0];
		public string[] NB00_ARCHIVES = new string[14];
		public string[] NB01_ARCHIVES = new string[3];

        


        public void Parse_AFS(string fp, ListView LV)
        {
            LV.Items.Clear(); // clear listview to prevent dupes n bullshit

            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);


            fs.Seek(0, SeekOrigin.Begin);
         


            Int32 afs_id = br.ReadInt32();
            Int32 f_count = br.ReadInt32();

            Int32 file_off = 0;
            int string_pos = 0;
            byte[] buffer = new byte[21];
            string[] fnames = new string[0];

            Array.Resize(ref AFS_HEADER, f_count);
            Array.Resize(ref fnames, f_count);

            if (afs_id != 5457473) { MessageBox.Show("This is not a supported file type!", "NSF", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            for (int i = 0; i < f_count; i++)
            {
                AFS_HEADER[i].offset = br.ReadInt32();
                AFS_HEADER[i].size = br.ReadInt32();
             

                LV.Items.Add(i.ToString());
            //    LV.Items[i].SubItems.Add(AFS_HEADER[i].new_off.ToString());
                LV.Items[i].SubItems.Add(AFS_HEADER[i].size.ToString());

            }


            fs.Close();
            br.Close();

        }


        /// <summary>
        /// Stream is valid AFS?
        /// </summary>
        /// <param name="stream">The Stream to check</param>
        /// <param name="br">Binary Reader</param>
        /// <returns></returns>
        public bool AfsValid(Stream stream, BinaryReader br)
        {
            int afs_sig = 5457473;

            stream.Seek(0, SeekOrigin.Begin);
            if (br.ReadInt32() == afs_sig)
            {
                return true;
            }
            else
                return false;
            
        }



        /// <summary>
        /// Export Selected Files From Listview..
        /// </summary>
        /// <param name="stream">Current Volume Stream..</param>
        /// <param name="lv">Listview Control were exporting from..</param>
        /// <param name="sel_count">Total Files Selected..</param>
        /// <param name="start_off">Starting offset of volume..</param>
        /// <param name="Sel_Off">List of Selected File Offsets</param>
        /// <param name="Sel_Sz">List of Selected File Sizes</param>
        /// <param name="Sel_File">List of Selected File Names</param>
        public void Export_SelectedFIles(Stream stream,ListView lv, int sel_count, int start_off, List<int> Sel_Off, List<int> Sel_Sz, List<string> Sel_File)
        {
          
            try
            {
                
               // open binary reader
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                FBD.Description = "Select Output Destination for Selected Files..";
                FBD.ShowDialog();

                for (int i = 0; i < sel_count; i++)
                {
                    BinaryReader br = new BinaryReader(stream);

                    string output = FBD.SelectedPath + "\\" + Sel_File[i];
                    byte[] buffer = new byte[Sel_Sz[i]];

                    int file_off = Sel_Off[i] + start_off;

                    stream.Seek(file_off, SeekOrigin.Begin);

                    br.Read(buffer, 0, buffer.Length);

                   
                    br.Close();


                    FileStream OutputStream = new FileStream(output, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(OutputStream);

                    bw.Write(buffer, 0, buffer.Length);


                    OutputStream.Close();
                    bw.Close();


                }


                stream.Close();
                
            }

            catch
            {

            }


        }


        /// <summary>
        /// Export a Single file using the given file stream
        /// </summary>
        /// <param name="stream"> This stream to read from </param>
        /// <param name="LV"> Listview Control</param>
        /// <param name="start_off">The volume relative start offset </param>
        /// <param name="t_sz"> The Total size of selected file </param>
        public string Export_File(Stream stream, ListView LV, int start_off, int t_sz)
        {
            try
            {

                int index = LV.SelectedIndices[0];
                int file_off = 0;

                BinaryReader br = new BinaryReader(stream); // open binary reader
                FolderBrowserDialog FBD = new FolderBrowserDialog(); 
                FBD.Description = "Select Output Destination for Selected Files..";
                FBD.ShowDialog();

             export_file_path = FBD.SelectedPath;
                string selected_file = LV.Items[index].SubItems[3].Text; 

                string output = export_file_path + "\\" + selected_file;

                byte[] buffer = new byte[t_sz];

                
                file_off = int.Parse(LV.Items[index].SubItems[1].Text) + start_off;
                
               
                stream.Seek(file_off, SeekOrigin.Begin);
                
                br.Read(buffer, 0, buffer.Length);


                stream.Close();
                br.Close();

                FileStream OutputStream = new FileStream(output, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(OutputStream);

                bw.Write(buffer, 0, buffer.Length);


                OutputStream.Close();
                bw.Close();

                return output;

            }

            catch(System.UnauthorizedAccessException e)
            {
                MessageBox.Show("\nIgnore\n" + e.Message.ToString());
                return string.Empty;
            }


        }

        public void WriteToMemStream(Stream stream, ListView LV, int start_off)
        {
            try
            {

                int index = LV.SelectedIndices[0];
                int file_off = 0;

                byte[] input_buffer = new byte[0];

                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                // set filter name to selected format eventually..


                // set target file to selected OFD filename
                import_file_path = OFD.FileName;

                using (FileStream fs = new FileStream(import_file_path, FileMode.Open)) 
                {

                    input_buffer = new byte[fs.Length];
                    using (BinaryReader br = new BinaryReader(fs)) 
                    {
                        br.Read(input_buffer, 0, input_buffer.Length);
                        br.Close();
                    }


                    
                    fs.Close();
                }


                MessageBox.Show(stream.CanWrite.ToString());



                // writing to th at offset
                //file_off = int.Parse(LV.Items[index].SubItems[1].Text) + start_off;


                //stream.Seek(file_off, SeekOrigin.Begin);

                //stream.Write(input_buffer, 0, input_buffer.Length);


            }

            catch (System.UnauthorizedAccessException e)
            {
                MessageBox.Show("\nIgnore\n" + e.Message.ToString());
               
            }


        }




        /// <summary>
        ///  import file overtop of selected afs lv index
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="LV"></param>
        /// <param name="start_off"></param>
        /// <param name="t_sz"></param>
        /// <returns></returns>
        public void Import_File(ListView LV, int nb_offset, int afs_offset, int t_sz)
        {

           
                int index = LV.SelectedIndices[0];
                int file_off = 0;

                byte[] input_buffer = new byte[0];

                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                // set filter name to selected format eventually..


                // set target file to selected OFD filename
                import_file_path = OFD.FileName;




            try
            {
                // OPEN SELECTED FILE , RESIZE DATA BUFFER AND STORE DATA 
                using (FileStream InputStream = new FileStream(import_file_path, FileMode.Open))
                {

                    input_buffer = new byte[InputStream.Length];


                    //   MessageBox.Show(input_buffer.Length.ToString());
                    using (BinaryReader br = new BinaryReader(InputStream))
                    {

                        br.Read(input_buffer, 0, input_buffer.Length);

                        br.Close();
                    }


                    // collect offset of selected file 



                }



                FRM_MAIN.Img.Read_Image.Dispose();

                //string fpath = FRM_MAIN.Img.Image_Path;

                //  FRM_MAIN.Img.Read_Image.Dispose();

                string fpath = FRM_MAIN.Img.Image_Path;


                file_off = int.Parse(LV.Items[index].SubItems[1].Text);

                file_off = file_off + afs_offset + nb_offset;




                using (FileStream fs2 = new FileStream(fpath, FileMode.Open))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs2))
                    {
                        bw.Seek(file_off, SeekOrigin.Begin);
                        bw.Write(input_buffer, 0, input_buffer.Length);

                        MessageBox.Show(import_file_path + " Written Succesfully to 0x" + file_off.ToString("X"));
                    }

                }

                //  MessageBox.Show(FRM_MAIN.Img.Image_Path);

                // write buffer to imported disc offset...

            }
            catch (System.ArgumentException AE) 
            {
            
            }

        }

        

        /// <summary>
        /// Parse Selected AFS archive
        /// </summary>
        /// <param name="fs">The Stream to Read from</param>
        /// <param name="br">Binary Reader</param>
        /// <param name="start_off">Volume Start Offset</param>
        /// <param name="LV">The Listview Control</param>
        /// <param name="sel_Siz">Selected AFS size?</param>
        public void AFS_PARSE(Stream fs, BinaryReader br, int start_off, ListView LV, int sel_Siz, ToolStripComboBox TSCOMBO, ToolStripProgressBar ProgressBar)
        {
            Int32 fmt_id = 0;
            Int32 afs_count = 0;
            byte[] buffer = new byte[32];
            string[] fnames = new string[0];
            List<string> File_Names = new List<string>();
            List<Int32> Entry_Offsets = new List<Int32>();
            List<Int32> Entry_Sizes = new List<Int32>();
          
          
            int Table_Index = 0;
            int string_pos = 0;

            

            LV.Items.Clear(); // reset LV
                              //   TSCOMBO.Items.Clear(); // rest combo box .. prevent dupes..


            // add groups


            //LV.Groups.Add(new ListViewGroup("COMPRESSED TEXTURES")); // 0
            //LV.Groups.Add(new ListViewGroup("ROOM DESCRIPTION"));  // 1
            //LV.Groups.Add(new ListViewGroup("3D CONTAINERS(MESH/TEXTURE/SKELETON)")); // 2
            //LV.Groups.Add(new ListViewGroup("ITEM OCCURENCE TABLES")); // 3
            //LV.Groups.Add(new ListViewGroup("AUTODESK MATERIALS?")); // 4
            //LV.Groups.Add(new ListViewGroup("LIGHTING DATA")); // 5
            //LV.Groups.Add(new ListViewGroup("SOFTDEC MPEG VIDEOS")); //6
            //LV.Groups.Add(new ListViewGroup("ADX SOUND CLIPS")); //7
            //LV.Groups.Add(new ListViewGroup("GAME SCRIPTS"));     //8   
            //LV.Groups.Add(new ListViewGroup("WEAPON MODEL DATA (RELOADING)")); //9
            //LV.Groups.Add(new ListViewGroup("Playstation 2 Texture/Icons")); //10
            //LV.Groups.Add(new ListViewGroup("UNDEFINED")); // 11


            for (int t = 0; t < LV.Groups.Count; t++)
            {
                //  MessageBox.Show(LV.Groups[t].Name.ToString());
                LV.Groups[t].HeaderAlignment = HorizontalAlignment.Center;               
                TSCOMBO.Items.Add(LV.Groups[t].ToString());

            }

            
            fs.Seek(start_off, SeekOrigin.Begin); // seek to offset passed thru list view.. bad idea. lol (i think there is a problem here with offsets netbio00/netbio01 relative..
            fmt_id = br.ReadInt32(); // read sig

            afs_count = br.ReadInt32();

           
            Array.Resize(ref AFS_HEADER, afs_count + 1); // + 1 to get file table offset/size, *for Romdata on both f1/f2 you can just add the sector size (2048) to get the file table.. seems direct for scene afs



            ProgressBar.Maximum = AFS_HEADER.Length - 1;

            for (int i = 0; i < AFS_HEADER.Length; i++) // store offsets and size in struct array
            {
                ProgressBar.Value = i;
                AFS_HEADER[i].offset = br.ReadInt32();
                AFS_HEADER[i].size = br.ReadInt32();
                LV.Items.Add(i.ToString());
                LV.Items[i].ImageIndex = 0; // setting all to use image list index 0..
                LV.Items[i].SubItems.Add(AFS_HEADER[i].offset.ToString());
                LV.Items[i].SubItems.Add(AFS_HEADER[i].size.ToString());
                Entry_Offsets.Add(AFS_HEADER[i].offset);
                Entry_Sizes.Add(AFS_HEADER[i].size);
                
            }


       
            foreach (int var in Entry_Sizes) // for every entry size retrieve the index of the last entry
            {
                if (var > 0 && Entry_Sizes.IndexOf(var) == Entry_Sizes.Count - 1) // -1 cuz life sux
                {
                    LV.Items[Entry_Sizes.IndexOf(var)].BackColor = Color.PowderBlue;
                    Table_Index = Entry_Sizes.IndexOf(var); // assign index
                                                            //  MessageBox.Show(Entry_Sizes.IndexOf(var).ToString());
                }
            }
            

            // seek to the location where each archives TOC IS....
            fs.Seek(AFS_HEADER[Table_Index].offset + sel_Siz, SeekOrigin.Begin); // have to pass sel_size beacuse your retreiving by netbio relative offsets...
           

            Array.Resize(ref fnames, afs_count);
            Array.Resize(ref DATE_TIME, afs_count);


            for (int x = 0; x < afs_count; x++) // - 1 because the table doesent include itself in file list..
            {
                br.Read(buffer, 0, 32);

                for (int j = 0; j < buffer.Length; j++)
                {
                    if (buffer[j] == 0x00)
                    {
                        string_pos = j;
                        break; // without the break it just keeps running through all padding..
                    }
                }

                
                string ext = System.Text.Encoding.ASCII.GetString(buffer, 0, string_pos);
            //    MessageBox.Show(ext);

                ext = ext.Substring(ext.Length - 3, 3);
                ext = ext.ToUpper();
                
          //      MessageBox.Show("EXTS " + ext);


                File_Names.Add(System.Text.Encoding.ASCII.GetString(buffer, 0, string_pos).Trim());
                AFS_HEADER[x].Name = File_Names[x];
                
                DATE_TIME[x].Year = br.ReadInt16();
                DATE_TIME[x].Day = br.ReadInt16();
                DATE_TIME[x].Month = br.ReadInt16();
                DATE_TIME[x].Hour = br.ReadInt16();
                DATE_TIME[x].Minute = br.ReadInt16();
                DATE_TIME[x].Second = br.ReadInt16();
                DATE_TIME[x].f_size = br.ReadInt32();
                DATE_TIME[x].DT = new DateTime(DATE_TIME[x].Year, DATE_TIME[x].Day, DATE_TIME[x].Month, DATE_TIME[x].Hour, DATE_TIME[x].Minute, DATE_TIME[x].Second);
                LV.Items[x].SubItems.Add(AFS_HEADER[x].Name.ToString());

                
                if (LUT_FORMATS.ContainsKey(ext))
                {
                    LV.Items[x].ForeColor = LUT_EXTCOLOR[ext];
                    LV.Items[x].SubItems.Add(LUT_FORMATS[ext]);
                   
                }
                else
                {
                    LV.Items[x].ForeColor = Color.DarkRed;
                    LV.Items[x].SubItems.Add("UNDEFINED");
                }
              

               
                LV.Items[x].SubItems.Add(DATE_TIME[x].DT.ToString());

                LV.Items[x].BackColor = Color.Black; // make these customizable through config...
                                                     // LV.Items[x].ForeColor = Color.BlanchedAlmond; //  set in config..
                                                     // LV.Items[x].Font = new System.Drawing.Font("Lucida Console", 8); // set in config..

                if (LUT_IMAGEINDEX.ContainsKey(ext))
                {
                    LV.Items[x].ImageIndex = LUT_IMAGEINDEX[ext];
                }


                // if extension is found in group table, assign LV items group to matching value
                if (LUT_GROUPING.ContainsKey(ext))
                {
                    LV.Items[x].Group = LV.Groups[LUT_GROUPING[ext]];
                }
                else {// set to undefined if unknown file type
                    LV.Items[x].Group = LV.Groups[11];
                }
                
             
            }


            fs.Close();
           
            LV.Items[Table_Index].BackColor = Color.Black;
            LV.Items[Table_Index].ImageIndex = 2;
            LV.Items[Table_Index].SubItems[2].Text = "TABLE OF CONTENTS";
        

        }

        
        /// <summary>
        /// parse afs data into listview/treeview
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="br"></param>
        /// <param name="LV"></param>
		public void dat_parse(Stream fs, BinaryReader br, ListView LV, TreeView TV)
		{
			Int32 fmt_id = 0;
			Int32 afs_count = 0;
			byte[] buffer = new byte[32];
			string[] fnames = new string[0];
            List<string> File_Names = new List<string>();
            List<Int32> Entry_Offsets = new List<Int32>();
            List<Int32> Entry_Sizes = new List<Int32>();
            TreeNode Folder_Node = new TreeNode();
            List<TreeNode> Folder_List = new List<TreeNode>();
            int Table_Index = 0;
            int string_pos = 0;

            
           
            LV.Items.Clear();
            TV.Nodes.Clear();


			fs.Seek(0, SeekOrigin.Begin); // seek
			fmt_id = br.ReadInt32(); // read sig

			afs_count = br.ReadInt32() + 1; // + table file (not sure why its not included in the general acount)

			Array.Resize(ref DAT_HEADER, afs_count); // resize struct array


			for (int i = 0; i < DAT_HEADER.Length; i++) // store offsets and size in struct array
			{			
				DAT_HEADER[i].offset = br.ReadInt32();
				DAT_HEADER[i].size = br.ReadInt32();
				LV.Items.Add(i.ToString());
             //   LV.Items[i].ImageIndex = 1;
				LV.Items[i].SubItems.Add(DAT_HEADER[i].offset.ToString());
				LV.Items[i].SubItems.Add(DAT_HEADER[i].size.ToString());

                Entry_Offsets.Add(DAT_HEADER[i].offset);
                Entry_Sizes.Add(DAT_HEADER[i].size);

            }
            
            foreach (int var in Entry_Sizes) // for every entry size retrieve the index of the last entry
            {
                if (var > 0 && Entry_Sizes.IndexOf(var) == Entry_Sizes.Count - 1) // -1 cuz life sux
                {
                    LV.Items[Entry_Sizes.IndexOf(var)].BackColor = Color.PowderBlue;
                    Table_Index = Entry_Sizes.IndexOf(var); // assign index
                  //  MessageBox.Show(Entry_Sizes.IndexOf(var).ToString());
                }
            }

            // seek to table index retrieve data..
            fs.Seek(DAT_HEADER[Table_Index].offset, SeekOrigin.Begin);
            
            Array.Resize(ref fnames, afs_count);
			Array.Resize(ref DATE_TIME, afs_count); 


            for (int x = 0; x < afs_count - 1; x++) // - 1 because the table doesent include itself..
            {
                br.Read(buffer, 0, 32);

                for(int j = 0; j < buffer.Length; j++)
                {
                    if (buffer[j] == 0x00)
                    {
                        string_pos = j;
                        break;
                    }
                }

                File_Names.Add(System.Text.Encoding.ASCII.GetString(buffer, 0, string_pos));
                DAT_HEADER[x].Name = File_Names[x];
            

             //   fs.Seek(fs.Position, SeekOrigin.Begin);

                DATE_TIME[x].Year = br.ReadInt16();
                DATE_TIME[x].Day = br.ReadInt16();
                DATE_TIME[x].Month = br.ReadInt16();
                DATE_TIME[x].Hour = br.ReadInt16();
                DATE_TIME[x].Minute = br.ReadInt16();
                DATE_TIME[x].Second = br.ReadInt16();
                DATE_TIME[x].f_size = br.ReadInt32();
                DATE_TIME[x].DT = new DateTime(DATE_TIME[x].Year, DATE_TIME[x].Day, DATE_TIME[x].Month, DATE_TIME[x].Hour, DATE_TIME[x].Minute, DATE_TIME[x].Second);
                LV.Items[x].SubItems.Add(DAT_HEADER[x].Name.ToString());

              

                if (DAT_HEADER[x].Name.Contains("afs"))
                {
                    LV.Items[x].SubItems.Add("AFS directory");
                    LV.Items[x].ImageIndex = 1;
                }
                else
                {
                    LV.Items[x].ImageIndex = 0;
                    LV.Items[x].SubItems.Add("Table of contents");
                }


                LV.Items[x].SubItems.Add(DATE_TIME[x].DT.ToString());
            //    LV.Items[x].BackColor = Color.DarkSlateGray;
           //     LV.Items[x].ForeColor = Color.BlanchedAlmond;
          

            }

            

            TreeNode[] NodeArray = new TreeNode[0];

            // for every file in file name list, create a new treenode in treenodelist..
            foreach (string dir in File_Names)
            {
                Folder_List.Add(new TreeNode(dir));               
            }


            Array.Resize(ref NodeArray, Folder_List.Count); // resize the array

            for (int i = 0; i < NodeArray.Length; i++)
            {
                NodeArray[i] = Folder_List[i]; // assign the array to each list index
            }


            TreeNode Final_Node = new TreeNode(FRM_MAIN.Img.Image_Path, NodeArray); // create the final node

            TV.Nodes.Add(Final_Node); // add the final node
            TV.ExpandAll();
            
            // GG
            
			fs.Close();
			br.Close();

            LV.Items[Table_Index].BackColor = Color.Black;
            LV.Items[Table_Index].ImageIndex = 2;
            LV.Items[Table_Index].SubItems[2].Text = "TABLE OF CONTENTS";

        } // for scanning .dat archives on disk

		public void iso_scan(string FilePath, ListView LV, TreeView TV_AFS)
		{
			
				FileStream fs = new FileStream(FilePath, FileMode.Open);
				BinaryReader br = new BinaryReader(fs);

				fs.Seek(0, SeekOrigin.Begin);

				Int32 byte_check = br.ReadInt32();
				Int32 NB_Offset = 0;
				Int32 fmt_id = 0;
				Int32 afs_count = 0;
				byte[] buffer = new byte[11];
				string[] fnames = new string[0];
				string disc_ID = string.Empty;




				if (byte_check == -437918235)
				{
					disc_ID = "OBF2";
				}
				else if (byte_check != -437918235)
				{
					disc_ID = "OBF1";
				}

                


					fs.Seek(NB_Offset, SeekOrigin.Begin); // seek to either nb1 or nb0
					fmt_id = br.ReadInt32();  // read format ID 
					afs_count = br.ReadInt32();




					Array.Resize(ref DAT_HEADER, afs_count); // resize dat header array to afs count


					for (int i = 0; i < DAT_HEADER.Length; i++) // dump offsets to listview relevant to iso
					{
						DAT_HEADER[i].offset = br.ReadInt32() + 16887808;
						DAT_HEADER[i].size = br.ReadInt32();
						LV.Items.Add(i.ToString());
						LV.Items[i].SubItems.Add(DAT_HEADER[i].offset.ToString());
						LV.Items[i].SubItems.Add(DAT_HEADER[i].size.ToString());
					}

					Array.Resize(ref fnames, afs_count);
					Array.Resize(ref DATE_TIME, afs_count);


					fs.Seek(1183225856, SeekOrigin.Begin); // what fucking offset is this? lmao


					for (int i = 0; i < afs_count; i++) // loop through total afs count, read afs list names convert to asci and dump to listview
					{
						br.Read(buffer, 0, 11);
						fnames[i] = System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, 11);
						fs.Seek(fs.Position + 37, SeekOrigin.Begin);
						LV.Items[i].SubItems.Add(fnames[i]);

						/////////////////////////////////////////////////////////////////////////////////////
						//                        Color the code                                           //
						if (fnames[i].Substring(5, 3) == "afs" || fnames[i].Substring(0, 11) == "romdata.afs")
						{
							LV.Items[i].ForeColor = Color.BlanchedAlmond;
							LV.Items[i].Font = new System.Drawing.Font("Lucida Console", 8);
						}
						else if (fnames[i].Substring(7, 3) == "bin")
						{
							LV.Items[i].ForeColor = Color.DarkCyan;
							LV.Items[i].Font = new System.Drawing.Font("Lucida Console", 8);
						}
						//////////////////////////////////////////////////////////////////////////////////////

					}


					fs.Seek(1183225888, SeekOrigin.Begin);

					for (int j = 0; j < afs_count; j++)
					{
						DATE_TIME[j].Year = br.ReadInt16();
						DATE_TIME[j].Day = br.ReadInt16();
						DATE_TIME[j].Month = br.ReadInt16();
						DATE_TIME[j].Hour = br.ReadInt16();
						DATE_TIME[j].Minute = br.ReadInt16();
						DATE_TIME[j].Second = br.ReadInt16();
						DATE_TIME[j].DT = new DateTime(DATE_TIME[j].Year, DATE_TIME[j].Day, DATE_TIME[j].Month, DATE_TIME[j].Hour, DATE_TIME[j].Minute, DATE_TIME[j].Second);
						fs.Seek(fs.Position + 36, SeekOrigin.Begin);
						LV.Items[j].SubItems.Add(DATE_TIME[j].DT.ToString());
					}



				}

        public void SLD_UNPACK(Stream fs, ListView LV, int LvIndex, int start_off, int fsz, string outputPath, RichTextBox Debug)
        {
            try
            {
                
                byte[] dest = new byte[1024 * 1024 * 4];
                int file_off = 0;
                int file_sz = 0;
                int index = LV.FocusedItem.Index;
                int total_items = LV.SelectedItems.Count;

                UInt32 mask, tmp, length;
                UInt32 offset;
                UInt16 seq;
                UInt32 dptr, sptr;
                UInt16 l, ct;
                UInt16 t, s;

                BinaryReader br = new BinaryReader(fs);
              
                
                
                file_off = int.Parse(LV.Items[LvIndex].SubItems[1].Text) + start_off;
                file_sz = file_off + fsz;
                
                //  MessageBox.Show("off: " + file_off.ToString());
                fs.Seek(file_off, SeekOrigin.Begin);
                dptr = 0;
                seq = br.ReadUInt16();

             //   Debug.AppendText("\n Sequence: " + seq.ToString());
                sptr = 0;


                while (br.BaseStream.Position != file_sz)
                {
                    mask = seq;

                    for (t = 0; t < 16; t++)
                    {
                        if ((mask & (1 << (15 - t))) != 0)
                        {
                            seq = br.ReadUInt16();

                            sptr = sptr + 2;
                            tmp = seq;

                            offset = (UInt32)(tmp & 0x07ff);
                            length = (UInt16)((tmp >> 11) & 0x1f);

                            offset = (UInt16)(offset * 2);
                            length = (UInt16)(length * 2);


                         //   Debug.AppendText("\n Offset: " + offset.ToString() + "\n Length: " + length.ToString());

                            if (length > 0)
                            {
                                for (l = 0; l < length; l++)
                                {
                                    dest[dptr] = dest[dptr - offset];
                                    dptr++;
                                    // MessageBox.Show(dest.Length.ToString() + "Dptr" + dptr.ToString() + " Offset: " + offset.ToString());

                                }
                            }
                            else
                            {
                                seq = br.ReadUInt16();
                                sptr = sptr + 2;
                                length = (ushort)(seq * 2);


                                for (s = 0; s < length; s++)
                                {
                                    dest[dptr] = dest[dptr - offset];
                                    dptr++;
                                }

                            }


                        }
                        else
                        {
                            if (br.BaseStream.Position != file_sz)
                            {
                                seq = br.ReadUInt16();
                                sptr = sptr + 2;
                                dest[dptr++] = (byte)(seq & 0xff);
                                dest[dptr++] = (byte)((seq >> 8) & 0xff);
                            }
                            
                        }
                    }

                    if (br.BaseStream.Position != file_sz)
                    {
                        seq = br.ReadUInt16();
                    }

                }

                
                br.Close();


                FileStream tm2out = new FileStream(outputPath, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(tm2out);

                tm2out.Seek(0, SeekOrigin.Begin);

                int newPtr = int.Parse(dptr.ToString());

                bw.Write(dest, 0, newPtr);
                Debug.AppendText("\nDecompress Succesful: @ " + outputPath);
                Debug.ScrollToCaret();

                bw.Close();
                tm2out.Close();

                //   MessageBox.Show("DECOMPRESS SUCCESFUL @ " + outputPath);

                Debug.ForeColor = Color.Green;
               
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("YOUR BREAKING MY PROGRAM NIGGA\n" + ex.Message);
            }


        }
        

		}
	


	


		



	}

public class ExtraMath
{
    


}