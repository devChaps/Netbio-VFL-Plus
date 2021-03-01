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



 namespace Netbio_VFL_Plus
{

    public struct RDT_SELECTED_OBJ
    {
        public Int32 File_Offset;
        public Int32 File_Size;
        public string File_Name;

    }


     public struct RDT_HEADER_OBJ
     {
         public Int32 _offset;
         public Int32 _size;
     }

     public struct CAMERA_HEADER_OBJ
     {
         public Int32 _offset;
         public Int32 new_off;
     }

     public struct CAMERA_SUB_OBJ 
     {
         public Int32 count_1;
         public Int32 count_2;
         public Int32 count_3;


        public Int32 Camera_Type; // 00 disabled 01 static, 02 follow cams 
        public Int32 UNK_00;
        public Int32 UNK_01;
        public Int32 UNK_02;
        public Int32 UNK_03;
        public Int32 Horizontal_Rotation;
        public Int32 Verticala_Rotation;
        public float H_FOV; // maybe floats
        public float V_FOV; // maybe floats
        public Int32 x1;
        public Int32 height_1;
        public Int32 y1;
        public Int32 x2;
        public Int32 height_2;
        public Int32 y2;
        public Int32 Target_x;  // target / aim pos
        public Int32 Target_z;
        public Int32 Target_y;

     }

	 public struct LGS_HEADER_OBJ 
	 {
		 public Int32 roomID;
		 public Int32 total_cams;
		 public Int32[] offset;
	 }

	 public struct LGS_DATA_OBJ 
	 {
		 public Int32 tag; // 4
		 public float fade00; // fog fade effect
		 public float Ulong01; // 12
         public byte Fog_B;
         public byte Fog_G;
         public byte Fog_R;
         public byte Fog_A; // 16
		 public byte cam_B; // cam relative blue
		 public byte cam_G; // cam relative green
		 public byte cam_R; // cam relative red
		 public byte cam_alpha;
		 public Int32 Ulong04; // 24
		 public Int32 Shadow01; // 28 player shadow, can turn off, hard/soft, or small circle, need to determine exact values still
		 public Int32 Shadow02; // 32
		 public Int32 Shadow03; // 36
		 public float hue_red; // 40 // player relative
		 public float hue_green; // 44
		 public float hue_blue; // 48
	 }



    public struct GRD_SOUND_HEADER
    {
        public Int32 t_count; // total # of entries
        public Int32 _null; // always seems to be 0x00000
        public Int32[] offsets; // as many as total entries

    
    }


  public class RDT_IO
 
  {
     public RDT_HEADER_OBJ[] RDT_HEADER = new RDT_HEADER_OBJ[0];
     public CAMERA_HEADER_OBJ[] CAM_HEADER = new CAMERA_HEADER_OBJ[0];
        public RDT_SELECTED_OBJ RDT_SELECTED = new RDT_SELECTED_OBJ();
    
         CAMERA_SUB_OBJ[] CAM_DATA = new CAMERA_SUB_OBJ[0];
	     LGS_HEADER_OBJ LGS_HEADER = new LGS_HEADER_OBJ();
	     LGS_DATA_OBJ[] LGS_DATA = new LGS_DATA_OBJ[0];
	     Camera_Properties CP = new Camera_Properties();
	     LGS_Properties LGSP = new LGS_Properties();
     
	  
	  #region class wide globals
     public Int32 total_cams;
     public string G_RDT = "";
        #endregion



       /// <summary>
       /// Parse RDT MAIN HEADER, from AFS LIB TO RDT LIST
       /// </summary>
       /// <param name="fs">Current stream</param>
       /// <param name="start_off">file location/offset</param>
       /// <param name="sel_idx">AFS LIB selected index</param>
       /// <param name="LV_AFS">AFS LIB REF</param>
       /// <param name="LV_RDT">RDT TARGET LISTVIEW</param>
       /// <param name="RT">Target Debug</param>
        public void Read_RDT(Stream fs, int start_off, int sel_idx, ListView LV_AFS, int afs_rdt_off, ListView LV_RDT, RichTextBox RT, ToolStripStatusLabel Selected_RDT, ToolStripStatusLabel Selected_RDTSIZE, ToolStripStatusLabel Selected_RDTOFF) 
        {


            LV_RDT.Items.Clear();

            int total = start_off + afs_rdt_off;

           


            BinaryReader br = new BinaryReader(fs);
            byte[] RDT_BUFFER = new byte[0];


          //  MessageBox.Show("total: " + total.ToString());




            //  int LvIndex = LV.SelectedIndices[0]; // wrong 


            RDT_SELECTED.File_Offset = int.Parse(LV_AFS.Items[sel_idx].SubItems[1].Text) + start_off;

            Selected_RDTOFF.Text = RDT_SELECTED.File_Offset.ToString();

            //  MessageBox.Show(RDT_SELECTED.File_Offset.ToString());

            RDT_SELECTED.File_Size = int.Parse(LV_AFS.Items[sel_idx].SubItems[2].Text);
            RDT_SELECTED.File_Name = LV_AFS.Items[sel_idx].SubItems[3].Text;
            

            Array.Resize(ref RDT_BUFFER, RDT_SELECTED.File_Size);
          
           

            fs.Seek(RDT_SELECTED.File_Offset, SeekOrigin.Begin);

            for (int i = 0; i < RDT_SELECTED.File_Size; i++)
            {
                RDT_BUFFER[i] = br.ReadByte();

            }






            



            fs.Seek(RDT_SELECTED.File_Offset, SeekOrigin.Begin);

            Int32 offset = 0;          
                                       // read 1st offset, divide by 8 to get total numer of items(includinbut cg offset and size as 1 item)
            offset = br.ReadInt32();
            Array.Resize(ref RDT_HEADER, offset / 8); // resize the struct array to match the number of objects to read


          
            fs.Seek(RDT_SELECTED.File_Offset, SeekOrigin.Begin);


            RT.AppendText("Total Entires: " + RDT_HEADER.Length);
              //  LV.BackColor = Color.DimGray;
			
				// loop through header to find and display actual chunk offsets
				for (int i = 0; i < RDT_HEADER.Length; i++)
				{
					RDT_HEADER[i]._offset = br.ReadInt32();
					RDT_HEADER[i]._size = br.ReadInt32();


                    LV_RDT.Items.Add(i.ToString());
                LV_RDT.Items[i].SubItems.Add(RDT_HEADER[i]._offset.ToString());
                LV_RDT.Items[i].SubItems.Add(RDT_HEADER[i]._size.ToString());


                Selected_RDT.Text = RDT_SELECTED.File_Name;
                Selected_RDTSIZE.Text = "Size:" + RDT_SELECTED.File_Size.ToString();
                

				//	RT.BackColor = Color.Black;
				//	RT.ForeColor = Color.LightCyan;


                      

					RT.AppendText("\n" + i.ToString() + "]\n\t");
					RT.AppendText(" Offset: [" + RDT_HEADER[i]._offset.ToString() + "]");
					RT.AppendText(" Size: [" + RDT_HEADER[i]._size.ToString() + "]");


                if (RDT_HEADER[i]._size == 0)
                {
                    LV_RDT.Items[i].ForeColor = Color.DarkRed;
                    LV_RDT.Items[i].SubItems.Add("_N/A");
                }
                else
                    LV_RDT.Items[i].ForeColor = Color.LightSeaGreen;

					// LI.Items[i].ForeColor = Color.White;

					switch (i)
					{
						case 0:
                        LV_RDT.Items[i].SubItems.Add("_CAM");
                        LV_RDT.Items[i].SubItems.Add("Camera Data");
							break;
						case 2:
                        LV_RDT.Items[i].SubItems.Add("_MOMO");
                        LV_RDT.Items[i].SubItems.Add("Sound Package");
                        break;
						case 3:
                        LV_RDT.Items[i].SubItems.Add("_MOMO");
                        LV_RDT.Items[i].SubItems.Add("Sound Package");

                        break;
						case 7:
                        LV_RDT.Items[i].SubItems.Add("_ANPK");
                        LV_RDT.Items[i].SubItems.Add("Animation Package");
                        break;
						case 13:
                        LV_RDT.Items[i].SubItems.Add("_FOG");
                        LV_RDT.Items[i].SubItems.Add("FOG DATA");
                        break;
						case 10:
                        LV_RDT.Items[i].SubItems.Add("_AOT");
                        LV_RDT.Items[i].SubItems.Add("TRIGGER ZONES");
                        break;
						case 1:
                        LV_RDT.Items[i].SubItems.Add("_SGL");
                        LV_RDT.Items[i].SubItems.Add("SCRIPT/GAME LANGUAGE?");
                        break;
						case 11:
                        LV_RDT.Items[i].SubItems.Add("_UNK");
                        break;
                    case 15:
                        LV_RDT.Items[i].SubItems.Add("_UNK");
                        break;
                    case 16:
                        LV_RDT.Items[i].SubItems.Add("_GRD");
                        LV_RDT.Items[i].SubItems.Add("SOUND ZONE DATA");
                        break;
					}

					
				}




           

            // TSC.Text = TSC.Items[0].ToString();

        
            fs.Close();
            br.Close();
                
          

        } // reads any RDT and stores header info in listview




        /// <summary>
        /// Parse RDT from afs list
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="LI"></param>
        /// <param name="RT"></param>
        /// <param name="LB"></param>
        /// <param name="off"></param>
	  public void AFS_2_RDT(string fp, ListView LI, RichTextBox RT, ListBox LB, Int32 off) 
	  {

		 

			  LI.Items.Clear();
			  LB.Items.Clear();

           
			  Scenario_Check(fp);

			  Int32 sz = 0;

			  FileStream fs = new FileStream(fp, FileMode.Open); // open the streams
			  BinaryReader br = new BinaryReader(fs);

			 
			  // read 1st offset, divide by 8 to get total numer of items(including offset and size as 1 item)
			  fs.Seek(off, SeekOrigin.Begin);
			  sz = br.ReadInt32();
			  MessageBox.Show(sz.ToString());
			  Array.Resize(ref RDT_HEADER, sz / 8); // resize the struct array to match the number of objects to read


			  



			  RT.AppendText("Total Entires: " + RDT_HEADER.Length);
			  LI.BackColor = Color.DimGray;



			  fs.Seek(off, SeekOrigin.Begin);

			  // loop through header to find and display actual chunk offsets
			  for (int i = 0; i < RDT_HEADER.Length; i++)
			  {
				  RDT_HEADER[i]._offset = br.ReadInt32();
				  RDT_HEADER[i]._size = br.ReadInt32();

				  LI.Items.Add(i.ToString());
				  LI.Items[i].SubItems.Add(RDT_HEADER[i]._offset.ToString());
				  LI.Items[i].SubItems.Add(RDT_HEADER[i]._size.ToString());



				  RT.BackColor = Color.Black;
				  RT.ForeColor = Color.LightCyan;


				  RT.AppendText("\n" + i.ToString() + "]\n\t");
				  RT.AppendText(" Offset: [" + RDT_HEADER[i]._offset.ToString() + "]");
				  RT.AppendText(" Size: [" + RDT_HEADER[i]._size.ToString() + "]");



                if (RDT_HEADER[i]._size == 0)
                {
                    LI.Items[i].ForeColor = Color.DarkRed;
                    LI.Items[i].SubItems.Add("_N/A");
                }
                else
                    LI.Items[i].ForeColor = Color.GhostWhite;
				  // LI.Items[i].ForeColor = Color.White;

				  switch (i)
				  {
					  case 0: LI.Items[i].SubItems.Add("_CAM");
						  break;
					  case 2: LI.Items[i].SubItems.Add("_MOMO");
						  break;
					  case 3: LI.Items[i].SubItems.Add("_MOMO");
						  break;
					  case 7: LI.Items[i].SubItems.Add("_ANPK");
						  break;
					  case 13: LI.Items[i].SubItems.Add("_LGS");
						  break;
					  case 10: LI.Items[i].SubItems.Add("_DOR");
						  break;
					  case 1:
					  case 11:
					  case 15:
					  case 16:
						  LI.Items[i].SubItems.Add("_UNK");
						  break;
				  }
			  }

			  fs.Close();
			  br.Close();
		  

		
	  
	  } // send RDT from afs panel to RDT int




        /// <summary>
        ///  UNPACK RDT CHUNKS (AFS RELATIVE)
        /// </summary>
        /// <param name="input_file"></param>
        /// <param name="output_file"></param>
        public void Unpack_RDT_AFS(Stream fs, ToolStripStatusLabel LBL_RDT_FILE,ToolStripStatusLabel LBL_RDT_OFF) // unpack RDT to work folder
        {



                int offset = int.Parse(LBL_RDT_OFF.Text); 
                string output_file = string.Empty;


            RDT_HEADER_OBJ[] RDT_DATA = new RDT_HEADER_OBJ[0];

            string unpack_DI = AppDomain.CurrentDomain.BaseDirectory + "\\RDT_UPK " + LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8);

            // CREATE DIR IF DOESENT EXIST...

            if (false == Directory.Exists(unpack_DI))
            {
                DirectoryInfo DI = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\RDT_UPK " + LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8));

            }
            else
            {
                MessageBox.Show("Directory already exists");
            }



            byte[] _buffer = new byte[0];
          
            BinaryReader br = new BinaryReader(fs);




            fs.Seek(offset, SeekOrigin.Begin);


            int _subcount = br.ReadInt32();
            _subcount = _subcount / 8;
            Array.Resize(ref RDT_DATA, _subcount);

            fs.Seek(offset, SeekOrigin.Begin);

            // loop through header to find and display actual chunk offsets
            for (int i = 0; i < RDT_DATA.Length; i++)
            {
                RDT_DATA[i]._offset = br.ReadInt32();
                RDT_DATA[i]._size = br.ReadInt32();
            }


            for (int x = 0; x < RDT_DATA.Length; x++) // loop through main header offsets to label chunks
            {
                switch (x)
                {
                    case 0:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_CAM";
                        break;
                    case 1:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_SGL";
                        break;
                    case 2:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_SND1";
                        break;
                    case 3:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_SND2";
                        break;
                    case 7:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_ANPK";
                        break;
                    case 10:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_AOT";
                        break;

                    case 11:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_LIG";
                        break;
                    case 13:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_FOG";
                        break;
                    case 15:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_UNK1";
                        break;
                    case 16:
                        output_file = LBL_RDT_FILE.Text.Substring(LBL_RDT_FILE.Text.Length - 12, 8) + "_GRD";
                        break;

                }


                if (RDT_DATA[x]._size != 0 && RDT_DATA[x]._size > 0)
                {
                    fs.Seek(RDT_DATA[x]._offset + offset, SeekOrigin.Begin);
           
                    Array.Resize(ref _buffer, RDT_DATA[x]._size);
                    br.Read(_buffer, 0, _buffer.Length);

                    FileStream fs2 = new FileStream(unpack_DI + "\\" + output_file, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs2);

                    bw.Write(_buffer, 0, _buffer.Length);
                    fs2.Close();
                    bw.Close();
                }
                else 
                {
                    continue;
                }

            }



            fs.Close();
            br.Close();

            MessageBox.Show("File was written succesfully", "UNPACK", MessageBoxButtons.OK, MessageBoxIcon.Information);


        } // unpacks every chunk to output directory



        /// <summary>
        ///  UNPACK RDT CHUNKS (FILE RELATIVE)
        /// </summary>
        /// <param name="input_file"></param>
        /// <param name="output_file"></param>
        public void Unpack_RDT(string input_file,string output_file) // unpack RDT to work folder
        {
       
            string unpack_DI = AppDomain.CurrentDomain.BaseDirectory + "\\RDT_UPK " + input_file.Substring(input_file.Length - 12, 8);
          
            if (false == Directory.Exists(unpack_DI)) 
            {
                DirectoryInfo DI = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\RDT_UPK " + input_file.Substring(input_file.Length - 12, 8));
               
            }
            else
            {
                MessageBox.Show("Directory already exists");
            } 



            byte[] _buffer = new byte[0];
            FileStream fs = new FileStream(input_file, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            fs.Seek(0, SeekOrigin.Begin);
            MessageBox.Show(RDT_HEADER.Length.ToString());

            for (int x = 0; x < RDT_HEADER.Length; x++) // loop through main header offsets to label chunks
            {
                switch (x)
                {
                    case 0: output_file = input_file.Substring(input_file.Length - 12, 8) + "_CAM";
                        break;
                    case 1: output_file = input_file.Substring(input_file.Length - 12, 8) + "_BIN";
                        break;
                    case 2: output_file = input_file.Substring(input_file.Length - 12, 8) + "_SND1";
                        break;
                    case 3: output_file = input_file.Substring(input_file.Length - 12, 8) + "_SND2";
                        break;
                    case 7: output_file = input_file.Substring(input_file.Length - 12, 8) + "_ANPK";
                        break;
                    case 10: output_file = input_file.Substring(input_file.Length - 12, 8) + "_DOR";
                        break;
                    case 13: output_file = input_file.Substring(input_file.Length - 12, 8) + "_LGS";
                        break;
					case 15: output_file = input_file.Substring(input_file.Length - 12, 8) + "_UNK1";
						break;
					case 16: output_file = input_file.Substring(input_file.Length - 12, 8) + "_SoundZ";
						break;

                }


                if(RDT_HEADER[x]._size != 0 && RDT_HEADER[x]._size > 0)
                { 
                    fs.Seek(RDT_HEADER[x]._offset, SeekOrigin.Begin);
                    Array.Resize(ref _buffer, RDT_HEADER[x]._size);
                    br.Read(_buffer, 0, _buffer.Length);

                FileStream fs2 = new FileStream(unpack_DI + "\\" + output_file, FileMode.Create);    
                BinaryWriter bw = new BinaryWriter(fs2);

                bw.Write(_buffer, 0, _buffer.Length);
                fs2.Close();
                bw.Close();
                }

            }
            

       
            fs.Close();          
            br.Close();

           

            MessageBox.Show("File was written succesfully");

        

        } // unpacks every chunk to output directory

        public void Unpack_subchk(string input_file, string output_file, ListView LI) // unpack a specific index
        {
            byte[] buffer = new byte[0];     
            Int32 offset = 0;
            int id = LI.SelectedIndices[0];
            string unpack_DI = AppDomain.CurrentDomain.BaseDirectory + "\\" + input_file.Substring(input_file.Length - 12, 8);

            if (false == Directory.Exists(unpack_DI))
            {
                DirectoryInfo DI = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\" + input_file.Substring(input_file.Length - 12, 8));
            }
            else
            {
                MessageBox.Show("Directory already exists");
            } 


            Array.Resize(ref buffer, RDT_HEADER[id]._size);
            offset = RDT_HEADER[id]._offset;


            if (RDT_HEADER[id]._size <= 0) 
            {
                MessageBox.Show("Dummy offset, no data here", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }
           
        
                switch (id)
                {
                    case 0: output_file = input_file.Substring(input_file.Length - 12, 8) + "_CAM";
                        break;
                    case 1: output_file = input_file.Substring(input_file.Length - 12, 8) + "_BIN";
                        break;
                    case 2: output_file = input_file.Substring(input_file.Length - 12, 8) + "_SND1";
                        break;
                    case 3: output_file = input_file.Substring(input_file.Length - 12, 8) + "_SND2";
                        break;
                    case 7: output_file = input_file.Substring(input_file.Length - 12, 8) + "_ANPK";
                        break;
                    case 10: output_file = input_file.Substring(input_file.Length - 12, 8) + "_DOR";
                        break;
                    case 13: output_file = input_file.Substring(input_file.Length - 12, 8) + "_LGS";
                        break;
                    case 11: output_file = input_file.Substring(input_file.Length - 12, 8) + "_LZ";
                        break;

                }



                FileStream fs = new FileStream(input_file, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                fs.Seek(offset, SeekOrigin.Begin);
                br.Read(buffer, 0, buffer.Length);

                fs.Close();
                br.Close();



                FileStream fs2 = new FileStream(unpack_DI + "\\" + output_file, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs2);

                fs2.Seek(0, SeekOrigin.Begin);

                bw.Write(buffer, 0, buffer.Length);
            
                if (fs2.Position == buffer.Length)
                {
                    MessageBox.Show(output_file + " Extraced Succesfully to" , "Hooray!");
                }


                fs2.Close();
                bw.Close();

            } // unpacks selected listview index into output directory



        
     // change this tow ork with a direct stream instead of string input path
        public void RDT_Properties(Stream fs, ListView LV_RDT, RichTextBox RT, PropertyGrid PG, ListBox LB) // opens file stream and seeks to selected RDT CHUNK INDEX to handle the struct
        {
            

            int idx = LV_RDT.SelectedIndices[0];

            int ListBox_Index = LB.SelectedIndex;
           
           
           

            byte[] buffer = new byte[RDT_HEADER[idx]._size]; // set buffer size to selected chunk size

		
            BinaryReader br = new BinaryReader(fs);

			
            switch (idx) // run a switch based of selected chunk index
            {
                case 0: // if cam chunk selected 
                   fs.Seek(RDT_SELECTED.File_Offset + RDT_HEADER[idx]._offset, SeekOrigin.Begin); // seek to offset

                    CP._tag = br.ReadInt32(); // read/store tag
                   CP.cam_count= br.ReadInt32(); // read/store cam count


                    Array.Resize(ref CAM_HEADER, CP.cam_count); // resize array to match cam count
					Array.Resize(ref CAM_DATA, CP.cam_count);


                    for (int i = 0; i < CP.cam_count; i++) // loop through cam count to read/add both relative and unrelative offsets from the cam chunk header to the camera class to be passed to prop grid
                    {
                        CAM_HEADER[i]._offset = br.ReadInt32();
                        CAM_HEADER[i].new_off = CAM_HEADER[i]._offset + RDT_HEADER[idx]._offset;

                        CP._Camera_OFF_R.Add(CAM_HEADER[i].new_off); // update RDT relevant offsets
                        CP._Camera_OFF_H.Add(CAM_HEADER[i]._offset); // update Header Releveant offset

						if (LB.Items.Count <= CP.cam_count - 1) // this prevents dupe cam index's from being listed 
						{
							LB.Items.Add("Camera(" + i.ToString() + ")"); // add cams index to listbox to be cycled through
						}
						
                    }

					for (int x = 0; x < CP.cam_count; x++) // loop through sub chunk cameras and seek to rdt relative offset to read/dump camera data to prop grid
					{

                        fs.Seek(RDT_SELECTED.File_Offset + CAM_HEADER[x].new_off, SeekOrigin.Begin);

                        CAM_DATA[x].Camera_Type = br.ReadInt32();
                        CAM_DATA[x].UNK_00 = br.ReadInt32();
                        CAM_DATA[x].UNK_01 = br.ReadInt32();
                        CAM_DATA[x].UNK_02 = br.ReadInt32();
                        CAM_DATA[x].UNK_03 = br.ReadInt32();
                        CAM_DATA[x].Horizontal_Rotation = br.ReadInt32();
                        CAM_DATA[x].Verticala_Rotation = br.ReadInt32();
                        CAM_DATA[x].H_FOV = br.ReadSingle();
                        CAM_DATA[x].V_FOV = br.ReadSingle();

                        
                        fs.Seek(RDT_SELECTED.File_Offset + CAM_HEADER[x].new_off + 156, SeekOrigin.Begin); // jump to positions



                        // please try to stick to X Z Y ORDER......... YOU FUCKTARD
                        CAM_DATA[x].x1 = br.ReadInt32();
                        CAM_DATA[x].height_1 = br.ReadInt32();
                        CAM_DATA[x].y1 = br.ReadInt32();
                       
                        // read cam obj struct in order

                        CAM_DATA[x].x2 = br.ReadInt32();
                        CAM_DATA[x].height_2 = br.ReadInt32();
                        CAM_DATA[x].y2 = br.ReadInt32();


                        CAM_DATA[x].Target_x = br.ReadInt32();
                        CAM_DATA[x].Target_z = br.ReadInt32();
                        CAM_DATA[x].Target_y = br.ReadInt32();
                       
                        
                    }

                if (LB.SelectedItems.Count <= 0) // if no index selected read chunk 0 by default
			    {
				LB.SelectedIndex = 0;
				CP._cam_posx00 = CAM_DATA[0].x1;
				CP._cam_posy00 = CAM_DATA[0].y1;
				CP._cam_height00 = CAM_DATA[0].height_1;
			    }
			   else // read whats selected
				    LB.SelectedIndex = LB.SelectedIndex;

                   
                

                    CP._cam_type = CAM_DATA[LB.SelectedIndex].Camera_Type;
                    CP._rotation_clock = CAM_DATA[LB.SelectedIndex].Horizontal_Rotation;
                    CP._rotation_counterclock = CAM_DATA[LB.SelectedIndex].Verticala_Rotation;
                    CP._FOV00 = CAM_DATA[LB.SelectedIndex].H_FOV;
                    CP._FOV01 = CAM_DATA[LB.SelectedIndex].V_FOV;                    
			        CP._cam_posx00 = CAM_DATA[LB.SelectedIndex].x1;
			        CP._cam_posy00 = CAM_DATA[LB.SelectedIndex].y1;
			        CP._cam_height00 = CAM_DATA[LB.SelectedIndex].height_1;
                    CP._cam_posx01 = CAM_DATA[LB.SelectedIndex].x2;
                    CP._cam_posy01 = CAM_DATA[LB.SelectedIndex].y2;
                    CP._cam_height01 = CAM_DATA[LB.SelectedIndex].height_2;

                    CP._cam_Targetx = CAM_DATA[LB.SelectedIndex].Target_x;
                    CP._cam_Targetz = CAM_DATA[LB.SelectedIndex].Target_z;
                    CP._cam_Targety = CAM_DATA[LB.SelectedIndex].Target_y;

                    

                    PG.SelectedObject = CP; // refresh prop grid object after new reads

						break;

                case 13: // handle cam relative light data
					
						fs.Seek(RDT_SELECTED.File_Offset + RDT_HEADER[idx]._offset, SeekOrigin.Begin);
                  
						LGS_HEADER.roomID = br.ReadInt32();
					    LGS_HEADER.total_cams = br.ReadInt32();
						Array.Resize(ref LGS_HEADER.offset, LGS_HEADER.total_cams);
						Array.Resize(ref LGS_DATA, LGS_HEADER.total_cams);

						for (int i = 0; i < LGS_HEADER.total_cams; i++) // loop thru total cams store offsets..
						{
							LGS_HEADER.offset[i] = br.ReadInt32();		// read lgs header store offsets					   
						

							if (LB.Items.Count <= LGS_HEADER.total_cams - 1) // this prevents dupe cam index's from being listed 
							{
                                 LB.Items.Add("Camera(" + i.ToString() + ")"); // add cams index to listbox
                             }

						}



						for (int x = 0; x < LGS_HEADER.total_cams; x++) // loop through total cams
						{
							fs.Seek(RDT_SELECTED.File_Offset + RDT_HEADER[idx]._offset + LGS_HEADER.offset[x], SeekOrigin.Begin); // seek to LGS Data obj store data for each cam index in array of struct
							
							LGS_DATA[x].tag = br.ReadInt32();
							LGS_DATA[x].fade00 = br.ReadSingle();
							LGS_DATA[x].Ulong01 = br.ReadSingle();
                            LGS_DATA[x].Fog_B = br.ReadByte();
                            LGS_DATA[x].Fog_G = br.ReadByte();
                            LGS_DATA[x].Fog_R = br.ReadByte();
                            LGS_DATA[x].Fog_A = br.ReadByte();
                            
							LGS_DATA[x].cam_B = br.ReadByte();
							LGS_DATA[x].cam_G = br.ReadByte();
							LGS_DATA[x].cam_R = br.ReadByte();
							LGS_DATA[x].cam_alpha = br.ReadByte();
							LGS_DATA[x].Ulong04 = br.ReadInt32();
							LGS_DATA[x].Shadow01 = br.ReadInt32();
							LGS_DATA[x].Shadow02 = br.ReadInt32();
							LGS_DATA[x].Shadow03 = br.ReadInt32();
							LGS_DATA[x].hue_red = br.ReadSingle();
							LGS_DATA[x].hue_green = br.ReadSingle();
							LGS_DATA[x].hue_blue = br.ReadSingle();

							RT.Clear();				
						}

					
					    

					
			if (LB.SelectedItems.Count <= 0) // if no index selected read chunk 0 by default
			{
				LB.SelectedIndex = 0;

                        //fix this bullshit later
				//RT.AppendText("TAG: " + LGS_DATA[LB.SelectedIndex].tag.ToString() + "\n");
				//RT.AppendText("Fog intensity: " + LGS_DATA[LB.SelectedIndex].fade00.ToString() + "\n");
				//RT.AppendText("Fog Distance: " + LGS_DATA[LB.SelectedIndex].Ulong01.ToString() + "\n");
				//RT.AppendText("CAM_B: " + LGS_DATA[LB.SelectedIndex].cam_B.ToString() + "\n");
				//RT.AppendText("CAM_G: " + LGS_DATA[LB.SelectedIndex].cam_G.ToString() + "\n");
				//RT.AppendText("CAM_R: " + LGS_DATA[LB.SelectedIndex].cam_R.ToString() + "\n");
				//RT.AppendText("UNK3: " + LGS_DATA[LB.SelectedIndex].cam_alpha.ToString() + "\n");
				//RT.AppendText("UNK4: " + LGS_DATA[LB.SelectedIndex].Ulong04.ToString() + "\n");
				//RT.AppendText("SDW0: " + LGS_DATA[LB.SelectedIndex].Shadow01.ToString() + "\n");
				//RT.AppendText("SDW1: " + LGS_DATA[LB.SelectedIndex].Shadow02.ToString() + "\n");
				//RT.AppendText("SDW2: " + LGS_DATA[LB.SelectedIndex].Shadow03.ToString() + "\n");
				//RT.AppendText("R: " + LGS_DATA[LB.SelectedIndex].hue_red.ToString() + "\n");
				//RT.AppendText("G " + LGS_DATA[LB.SelectedIndex].hue_green.ToString() + "\n");
				//RT.AppendText("B" + LGS_DATA[LB.SelectedIndex].hue_blue.ToString() + "\n");
			}
			else // read whats selected. set lgsp class to selected index of previously read struct
				LB.SelectedIndex = LB.SelectedIndex;


			LGSP.tag = LGS_DATA[LB.SelectedIndex].tag;                // This passes the data frmo the struct to the class to be used in prop grid
			LGSP.Fade00 = LGS_DATA[LB.SelectedIndex].fade00;
			LGSP.Ulong01 = LGS_DATA[LB.SelectedIndex].Ulong01;
            LGSP.fogB = LGS_DATA[LB.SelectedIndex].Fog_B;
            LGSP.fogG = LGS_DATA[LB.SelectedIndex].Fog_G;
            LGSP.fogR = LGS_DATA[LB.SelectedIndex].Fog_R;
            LGSP.fogA = LGS_DATA[LB.SelectedIndex].Fog_A;
            
			
			LGSP._Cam_B = LGS_DATA[LB.SelectedIndex].cam_B;
			LGSP._Cam_G = LGS_DATA[LB.SelectedIndex].cam_G;
			LGSP._Cam_R = LGS_DATA[LB.SelectedIndex].cam_R;
			LGSP.CAM_ALPHA = LGS_DATA[LB.SelectedIndex].cam_alpha;
			LGSP.Ulong04 = LGS_DATA[LB.SelectedIndex].Ulong04;
			LGSP._SDW00 = LGS_DATA[LB.SelectedIndex].Shadow01;
			LGSP._SDW01 = LGS_DATA[LB.SelectedIndex].Shadow02;
			LGSP._SDW02 = LGS_DATA[LB.SelectedIndex].Shadow03;
			LGSP._R = LGS_DATA[LB.SelectedIndex].hue_red;
			LGSP._G = LGS_DATA[LB.SelectedIndex].hue_green;
			LGSP._B = LGS_DATA[LB.SelectedIndex].hue_blue;

			
            

		                    RT.AppendText("TAG: " + LGS_DATA[LB.SelectedIndex].tag.ToString() + "\n");
							RT.AppendText("FOG Intensity: " + LGS_DATA[LB.SelectedIndex].fade00.ToString() + "\n");
							RT.AppendText("FOG Distance: " + LGS_DATA[LB.SelectedIndex].Ulong01.ToString() + "\n");
                             RT.AppendText("FOG COLOR B:" + LGS_DATA[LB.SelectedIndex].Fog_B);
                            RT.AppendText("FOG COLOR G:" + LGS_DATA[LB.SelectedIndex].Fog_G);
                            RT.AppendText("FOG COLOR R:" + LGS_DATA[LB.SelectedIndex].Fog_R);
                            RT.AppendText("FOG COLOR A:" + LGS_DATA[LB.SelectedIndex].Fog_A);
                            RT.AppendText("CAM_B: " + LGS_DATA[LB.SelectedIndex].cam_B.ToString() + "\n");
							RT.AppendText("CAM_G: " + LGS_DATA[LB.SelectedIndex].cam_G.ToString() + "\n");
							RT.AppendText("CAM_R: " + LGS_DATA[LB.SelectedIndex].cam_R.ToString() + "\n");
							RT.AppendText("UNK4: " + LGS_DATA[LB.SelectedIndex].Ulong04.ToString() + "\n");
							RT.AppendText("SDW0: " + LGS_DATA[LB.SelectedIndex].Shadow01.ToString() + "\n");
							RT.AppendText("SDW1: " + LGS_DATA[LB.SelectedIndex].Shadow02.ToString() + "\n");
							RT.AppendText("SDW2: " + LGS_DATA[LB.SelectedIndex].Shadow03.ToString() + "\n");
							RT.AppendText("R: " + LGS_DATA[LB.SelectedIndex].hue_red.ToString() + "\n");
							RT.AppendText("G " + LGS_DATA[LB.SelectedIndex].hue_green.ToString() + "\n");
							RT.AppendText("B" + LGS_DATA[LB.SelectedIndex].hue_blue.ToString() + "\n");


							PG.SelectedObject = LGSP;


                    break;
                   
                    // handle the rest of the chunks
                 
            }



            fs.Close();
            br.Close();




        } // dumps selected chunk data to property grid
	 
        
        public void Repack_RDT() // broken repack, use grab file fnuction from cmd line tool later
        {
			FolderBrowserDialog FBD = new FolderBrowserDialog();
			FBD.ShowDialog();

			string spath = FBD.SelectedPath;

			if (spath.Length > 15) 
			{
				G_RDT = FBD.SelectedPath.Substring(spath.Length - 8, 8);
			}

			MessageBox.Show(G_RDT);
            
		
		}


        public void Scenario_Check(string input_file) 
        {
            switch (input_file.Substring(input_file.Length - 10, 2)) 
            {
                case "10":
                    // underbelly
                    break;

                case "15":
                  //  Main_Form.ActiveForm.Text = "DT";
                    break;

                case "26":
                    // FB
                    break;

                case "06":
                    // EOTR
                    break;

                case "40":
                    // wild things
                    break;


                    // sort out elim's showdows and file 1 scenarios
            }
             
        } // runs a check on inputfile string for certain file ID to determine scenario 


	




        public void Write_Update_Cam(string fp, ListBox LB, PropertyGrid PG)
        {
            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryWriter bw = new BinaryWriter(fs);

            MessageBox.Show(CAM_HEADER[0].new_off.ToString());

            fs.Seek(CAM_HEADER[LB.SelectedIndex].new_off, SeekOrigin.Begin);

            bw.Write(CP.cam_type);
            bw.Write(CAM_DATA[LB.SelectedIndex].UNK_00);
            bw.Write(CAM_DATA[LB.SelectedIndex].UNK_01);
            bw.Write(CAM_DATA[LB.SelectedIndex].UNK_02);
            bw.Write(CAM_DATA[LB.SelectedIndex].UNK_03);
            bw.Write(CP.rotation_clock);
            bw.Write(CP.rotation_counterclock);
            bw.Write(CP.FOV00);
            bw.Write(CP.FOV01);

            fs.Seek(CAM_HEADER[LB.SelectedIndex].new_off + 156, SeekOrigin.Begin); // jump to current cam's position data for writing...

            bw.Write(CP.cam_posx00);
            bw.Write(CP.cam_height00);
            bw.Write(CP.cam_posy00);

            bw.Write(CP.cam_posx01);
            bw.Write(CP.cam_height01);
            bw.Write(CP.cam_posy01);

            bw.Write(CP.cam_targetx);
            bw.Write(CP.cam_targetz);
            bw.Write(CP.cam_targety);





            fs.Close();
            bw.Close();



        }


        public void Write_Update_FOG(string fp, ListBox LB, PropertyGrid PG)
        {
            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryWriter bw = new BinaryWriter(fs);




            fs.Seek(RDT_HEADER[13]._offset + LGS_HEADER.offset[LB.SelectedIndex], SeekOrigin.Begin);

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



        public class Camera_Properties
        {

            public int _tag = 0;
            public int cam_count = 0;
            public int _room_id;
            public int _scenario_id;
            public string _file_name = string.Empty;
            public string _scenario = string.Empty;
            public string _room_name = string.Empty;

            public Int32 _cam_type;
            public Int32 _rotation_clock;
            public Int32 _rotation_counterclock;

            public Single _FOV00; // horizontal?
            public Single _FOV01; // vertical
            
            public Int32 _cam_posx00 = 0;
            public Int32 _cam_height00 = 0;
            public Int32 _cam_posy00 = 0;
            
            public Int32 _cam_posx01 = 0;
            public Int32 _cam_height01 = 0;
            public Int32 _cam_posy01 = 0;
          
            public Int32 _cam_Targetx = 0;
            public Int32 _cam_Targetz = 0;
            public Int32 _cam_Targety = 0;




            public List<int> _Camera_OFF_R = new List<int>();
            public List<int> _Camera_OFF_H = new List<int>();



            [Category("Camera Details")]
            [ReadOnly(false)]
            public int tag // display tag
            {
                get { return _tag; }
                set { _tag = value; }
            }

            [Category("Camera Details")]
            [DisplayName("Total Camera Angles")]

            public int count_cams // total cam count for room
            {
                get { return cam_count; }
                set { cam_count = value; }
            }

            [Category("Camera Details")]
            [ReadOnly(false)]

            public int room_id
            {
                get { return _room_id; }
                set { _room_id = value; }
            }

            [Category("Camera Details")]
            [DisplayName("Camera Offset List(R)")]
            [Description("Camera chunk offsets relevant to the RDT offset/size")]
            [ReadOnly(false)]


            public List<int> Camera_off_R
            {
                get { return _Camera_OFF_R; }
                set { _Camera_OFF_R = value; }
            }



            [Category("Camera Details")]
            [DisplayName("Camera Offset List(H)")]
            [Description("Camera chunk offsets relevant to the cam header offset/size")]
            [ReadOnly(false)]


            public List<int> Camera_off_H
            {
                get { return _Camera_OFF_H; }
                set { _Camera_OFF_H = value; }
            }


            [Category("Camera Details")]
            [DisplayName("Camera Type")]
            [Description("Switch between camera types")]
            [ReadOnly(false)]



            public Int32 cam_type
            {
                get { return _cam_type; }
                set { _cam_type = value; }
            }


            [Category("Camera Details")]
            [DisplayName("Rotation00")]
            [Description("Clockwise rotation")]
            [ReadOnly(false)]

            public Int32 rotation_clock // display tag
            {
                get { return _rotation_clock; }
                set { _rotation_clock = value; }
            }



            [Category("Camera Details")]
            [DisplayName("Rotation01")]
            [Description("Counter Clockwise rotation")]
            [ReadOnly(false)]

            public Int32 rotation_counterclock // display tag
            {
                get { return _rotation_counterclock; }
                set { _rotation_counterclock = value; }
            }


            [Category("Camera Details")]
            [DisplayName("FOV00")]
            [Description("Vertical FOV?")]
            [ReadOnly(false)]



            public Single FOV00
            {
                get { return _FOV00; }
                set { _FOV00 = value; }
            }


            [Category("Camera Details")]
            [DisplayName("FOV01")]
            [Description("Horizontal FOV?")]
            [ReadOnly(false)]



            public Single FOV01
            {
                get { return _FOV01; }
                set { _FOV01 = value; }
            }

            [Category("Camera Details")]
            [DisplayName("X Pos 00")]
            [Description("Cam X Axis value")]
            [ReadOnly(false)]



            public int cam_posx00 // x
            {
                get { return _cam_posx00; }
                set { _cam_posx00 = value; }
            }

            [Category("Camera Details")]
            [DisplayName("Z Pos 00")]
            [Description("Height")]
            [ReadOnly(false)]




            public int cam_height00 // z
            {
                get { return _cam_height00; }
                set { _cam_height00 = value; }
            }



            [Category("Camera Details")]
            [DisplayName("Y Pos 00")]
            [Description("Y Coordinate (Left/Right)")]
            [ReadOnly(false)]



            public int cam_posy00
            {
                get { return _cam_posy00; }
                set { _cam_posy00 = value; }
            }


            [Category("Camera Details")]
            [DisplayName("X Pos 01")]
            [Description("X Coordinate (Forward/Back)")]
            [ReadOnly(false)]


            public int cam_posx01
            {
                get { return _cam_posx01; }
                set { _cam_posx01 = value; }
            }

            [Category("Camera Details")]
            [DisplayName("Z Pos 01")]
            [Description("Z (Height)")]
            [ReadOnly(false)]



            public int cam_height01
            {
                get { return _cam_height01; }
                set { _cam_height01 = value; }
            }



            [Category("Camera Details")]
            [DisplayName("Y Pos 01")]
            [Description("Y Coordinate")]
            [ReadOnly(false)]

           

            public int cam_posy01
            {
                get { return _cam_posy01; }
                set { _cam_posy01 = value; }
            }




            [Category("Camera Details")]
            [DisplayName("Target X")]
            [Description("Target/Aim pos, (X)")]
            [ReadOnly(false)]



            public int cam_targetx
            {
                get { return _cam_Targetx; }
                set { _cam_Targetx = value; }
            }



            [Category("Camera Details")]
            [DisplayName("Target Z")]
            [Description("Target/Aim pos, (Z)")]
            [ReadOnly(false)]



            public int cam_targetz
            {
                get { return _cam_Targetz; }
                set { _cam_Targetz = value; }
            }


            [Category("Camera Details")]
            [DisplayName("Target Y")]
            [Description("Target/Aim pos, (Y)")]
            [ReadOnly(false)]



            public int cam_targety
            {
                get { return _cam_Targety; }
                set { _cam_Targety = value; }
            }




        }



        public class LGS_Properties 
	  {
		  public Int32 _tag;
		  public Single _fade00; // fog intentisty
		  public Single _Ulong01; // fog distance?
		  public byte _fogB; // fog color
            public byte _fogG;
            public byte _fogR;
            public byte _fogA; 
		  public byte _Cam_B;
		  public byte _Cam_G;
		  public byte _Cam_R;
          public byte _Cam_Alpha;
		  public Int32 _Ulong04;
		  public Int32 _SDW00;
		  public Int32 _SDW01;
		  public Int32 _SDW02;
		  public Single _R;
		  public Single _G;
		  public Single _B;



		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Tag/Flag")]
		  [ReadOnly(true)]
		  public int tag // display tag
		  {
			  get { return _tag; }
			  set { _tag = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Fog Density")]

		  public float Fade00 // total cam count for room
		  {
			  get { return _fade00; }
			  set { _fade00 = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Fog Distance")]

		  public float Ulong01 // total cam count for room
		  {
			  get { return _Ulong01; }
			  set { _Ulong01 = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Fog Color B")]

		  public byte fogB // total cam count for room
		  {
			  get { return _fogB; }
			  set { _fogB = value; }
		  }

            [Category("Light/Ground/Shadow Properties")]
            [DisplayName("Fog Color G")]

            public byte fogG // total cam count for room
            {
                get { return _fogG; }
                set { _fogG = value; }
            }

            [Category("Light/Ground/Shadow Properties")]
            [DisplayName("Fog Color R")]

            public byte fogR // total cam count for room
            {
                get { return _fogR; }
                set { _fogR = value; }
            }

            [Category("Light/Ground/Shadow Properties")]
            [DisplayName("Fog Color B")]

            public byte fogA // total cam count for room
            {
                get { return _fogA; }
                set { _fogA = value; }
            }






            [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Camera(B)")]

		 

		  public byte CAM_B
		  {
			  get { return _Cam_B; }
			  set { _Cam_B = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Camera(G)")]

		  public byte CAM_G
		  {
			  get { return _Cam_G; }
			  set { _Cam_G = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Camera(R)")]

		  public byte CAM_R
		  {
			  get { return _Cam_R; }
			  set { _Cam_R = value; }
		  }

		 


		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Alpha (BGRA)")]

		  public byte CAM_ALPHA
		  {
			  get { return _Cam_Alpha ; }
			  set { _Cam_Alpha = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("T_Cam")]

		  public int Ulong04 // total cam count for room
		  {
			  get { return _Ulong04; }
			  set { _Ulong04 = value; }
		  }


		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Shadow Intensity")]

		  public int SDW00 // total cam count for room
		  {
			  get { return _SDW00; }
			  set { _SDW00 = value; }
		  }


		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Shadow Y")]

		  public int SDW01 // total cam count for room
		  {
			  get { return _SDW01; }
			  set { _SDW01 = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Shadow X")]

		  public int SDW02 // total cam count for room
		  {
			  get { return _SDW02; }
			  set { _SDW02 = value; }
		  }

		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Player(R)")]

		  public float R // total cam count for room
		  {
			  get { return _R; }
			  set { _R = value; }
		  }


		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Player(G)")]

		  public float G // total cam count for room
		  {
			  get { return _G; }
			  set { _G = value; }
		  }




		  [Category("Light/Ground/Shadow Properties")]
		  [DisplayName("Player(B)")]

		  public float B // total cam count for room
		  {
			  get { return _B; }
			  set { _B = value; }
		  }




	  }



    }

 


}
