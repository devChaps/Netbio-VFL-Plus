using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Netbio_VFL_Plus
{
	public class EMD_IO
	{

		public static byte GAME_VALUE = 0;  // 0 for FILE 1, 1 for FILE 2 
		public static string SCE_VALUE = string.Empty; // holds scenario archive string
		public static int ARCHIVE_OFFSET;
		public static int EMD_OFFSET;
	
		public struct EMD_Header_Obj
		{
			public int Offset;
			public int Size;
		}

		public struct EMD_Enemy_Obj
		{
			public byte Tag;        //  1       Not sure, could be to deactivate/activate an entry?
			public byte No;         //  2       Number of enemy in room?
			public byte NBD_ID0;    //  3         First part of NBD ID to use
			public byte NBD_ID1;    //  4         Second part of NBD ID to use
			public int ULong00;      // 8
			public int ULong01;      // 12
			public int X;            // 16 Could be coords, X? Not sure if long or float...
			public int Z;           //  20 Could be coords, Z? Not sure if long or float...
			public int Y;           //  24 Could be coords, Y? Not sure if long or float...
			public int R;           //  28 Could be Rotation? Not sure if long or float...
			public byte Room_ID;    // 29
			public byte UnkB00; // allows enemy to follow?    0 NO 1 YES, 1 needs further EVB config?
			public byte EMD_DFC;
			public byte UnkB01;
			public Int16 UShort02;
			public byte UByte00;
			public byte UByte01;
			public Int16 UShort03;
			public Int16 UShort04;
			public int ULong02;
			public int ULong03;
			public byte Ubyte02;
			public byte EMD_STATE; // ENEMY ATTACK STATE (NEEDS LIST)
			public byte EMD_STR; // only works for tyrant?
			public byte EMD_HP;
			public Int16 UShort07;
			public Int16 UShort08;
			public Int16 UShort09;
			public Int16 UShort10;
			public int ULong04;
			public byte EMD_SPEED;
			public byte UByte03;
			public int ULong05;
			public Int16 EMD_SCALE;
			public byte UByte04;
			public byte EMD_FOLLOW;
			public Int16 UShort14;
			public int ULong06;
			public int ULong07;
			public int ULong08;
			public int ULong09;
			public int ULong10;
			public byte[] Emd_block;
		}


		public struct EMD_Enemy_Set
		{
			public EMD_Enemy_Obj[] Enemy;        //Array of EMD_Enemy_Obj structs, of undefined size. It will be sized later on
		}

		public EMD_Header_Obj[] EMD_HEADER = new EMD_Header_Obj[0];     //Declaration of Header struct array, init it with a size 
		//of 0 because we don't know the real size to use yet 

		public static EMD_Enemy_Set[] EMD_DATA = new EMD_Enemy_Set[0];         //Declaration of Enemy object struct array, again init with 
		//0 cuz we have no clue of the real size yet


		public EMD_Properties EMD_PROP = new EMD_Properties();




        /// <summary>
        /// parse emd stream for afs list..
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="start_off"></param>
        /// <param name="LST_AFS"></param>
        /// <param name="LST_EMD"></param>
        /// <param name="LB_Entries"></param>
        /// <param name="HB_EMD"></param>
        /// <param name="PG_EMD"></param>
        /// <param name="Emd_DebugLog"></param>
        public void Parse_EMDStream(Stream fs, int start_off, string sce_val, byte GameVal, ListView LST_AFS, ListBox LB_EMDOFF, PictureBox CurrentRoom, PictureBox Emd_Pic, ToolStripStatusLabel LBL_OFFSET)
        {
            
            try
            {
                int Emd_Offset = int.Parse(LST_AFS.FocusedItem.SubItems[1].Text);
                byte[] EMD_BUFFER = new byte[0];
                int t_sz = int.Parse(LST_AFS.FocusedItem.SubItems[2].Text);


				ARCHIVE_OFFSET = start_off;
				EMD_OFFSET = Emd_Offset;


				

				// PREVENT DUPES N SHIT
				LB_EMDOFF.Items.Clear();

				// SET SCENARIO DATA
				GAME_VALUE = GameVal;
				SCE_VALUE = sce_val;
			

                //  Emd_DebugLog.AppendText("Archive Offset: " + start_off.ToString() + "\n EMD_Offset: " + Emd_Offset.ToString());

                fs.Seek(Emd_Offset + start_off, SeekOrigin.Begin); // jump to right loc from disc
            //    MessageBox.Show(Emd_Offset + start_off.ToString());

                BinaryReader br = new BinaryReader(fs);

              //  LST_EMD.Items.Clear();


                    int t_off = br.ReadInt32(); // read first offset
                    int lv_idx = 0;

                    Array.Resize(ref EMD_HEADER, (t_off / 8) - 1); // resize to x entries
                    Array.Resize(ref EMD_DATA, EMD_HEADER.Length); // resize data to x entries
                    Array.Resize(ref EMD_BUFFER, t_sz); // resize EMD buffer to match selected emd fsize..

                    fs.Seek(start_off + Emd_Offset, SeekOrigin.Begin); // seek back to start

                    for (int i = 0; i < EMD_HEADER.Length; i++) // parse and dump entries offset/size and enemey counts
                    {
                        EMD_HEADER[i].Offset = br.ReadInt32();
						EMD_HEADER[i].Size = br.ReadInt32();

					// resize enemy data array based on room/count block
					Array.Resize(ref EMD_DATA[i].Enemy, EMD_HEADER[i].Size / 96);

					// add offsets to list
					LB_EMDOFF.Items.Add(EMD_HEADER[i].Offset);


				}

				// reloop and dump data to hex view..



				


					// READ DATA
                for (int x = 0; x < EMD_HEADER.Length; x++)
                {
				

					fs.Seek(EMD_HEADER[x].Offset + start_off + Emd_Offset, SeekOrigin.Begin);


                    for (int j = 0; j < EMD_DATA[x].Enemy.Length; j++)
                    {

						// resize each byte array inside EMD structure to 96 to store the whole byte string
						Array.Resize(ref EMD_DATA[x].Enemy[j].Emd_block, 96);

						EMD_DATA[x].Enemy[j].Emd_block = br.ReadBytes(96);

						fs.Seek(-96, SeekOrigin.Current);

						//   Emd_DebugLog.AppendText("########### STORED DATA ############\n\n\n");

						// Emd_DebugLog.AppendText("\nBlock Index: " + x.ToString() + "\n");
						//  Emd_DebugLog.AppendText("Entry Index: " + j.ToString() + "\n");
						EMD_DATA[x].Enemy[j].Tag = br.ReadByte();
                      //  Emd_DebugLog.AppendText("Tag: " + EMD_DATA[x].Enemy[j].Tag.ToString() + "\t");
                        EMD_DATA[x].Enemy[j].No = br.ReadByte();
                      //  Emd_DebugLog.AppendText("No#: " + EMD_DATA[x].Enemy[j].No.ToString() + "\t");
                        EMD_DATA[x].Enemy[j].NBD_ID0 = br.ReadByte();
                     //   Emd_DebugLog.AppendText("NBDID0: " + EMD_DATA[x].Enemy[j].NBD_ID0.ToString() + "\n");
                        EMD_DATA[x].Enemy[j].NBD_ID1 = br.ReadByte();
                      //  Emd_DebugLog.AppendText("NBDID1: " + EMD_DATA[x].Enemy[j].NBD_ID1.ToString() + "\n");
                        EMD_DATA[x].Enemy[j].ULong00 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].ULong01 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].X = br.ReadInt32();
                      //  Emd_DebugLog.AppendText("X: " + EMD_DATA[x].Enemy[j].X.ToString() + "\n");
                        EMD_DATA[x].Enemy[j].Z = br.ReadInt32();
                      //  Emd_DebugLog.AppendText("Z: " + EMD_DATA[x].Enemy[j].Z.ToString() + "\n");
                        EMD_DATA[x].Enemy[j].Y = br.ReadInt32();
                      //  Emd_DebugLog.AppendText("Y: " + EMD_DATA[x].Enemy[j].Y.ToString() + "\n");
                        EMD_DATA[x].Enemy[j].R = br.ReadInt32();
                       // Emd_DebugLog.AppendText("R: " + EMD_DATA[x].Enemy[j].R.ToString() + "\n");
                        EMD_DATA[x].Enemy[j].Room_ID = br.ReadByte();
						EMD_DATA[x].Enemy[j].UnkB00 = br.ReadByte();
						//  Emd_DebugLog.AppendText("Room ID: " + EMD_DATA[x].Enemy[j].Room_ID.ToString() + "\n");
						EMD_DATA[x].Enemy[j].EMD_DFC = br.ReadByte();
						EMD_DATA[x].Enemy[j].UnkB00 = br.ReadByte();
					//	EMD_DATA[x].Enemy[j].UShort01 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].UShort02 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].UByte00 = br.ReadByte();
                        EMD_DATA[x].Enemy[j].UByte01 = br.ReadByte();
                        EMD_DATA[x].Enemy[j].UShort03 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].UShort04 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].ULong02 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].ULong03 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].Ubyte02 = br.ReadByte();
						EMD_DATA[x].Enemy[j].EMD_STATE = br.ReadByte();
						EMD_DATA[x].Enemy[j].EMD_STR = br.ReadByte();
						EMD_DATA[x].Enemy[j].EMD_HP = br.ReadByte();
                        EMD_DATA[x].Enemy[j].UShort07 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].UShort08 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].UShort09 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].UShort10 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].ULong04 = br.ReadInt32();
					
						EMD_DATA[x].Enemy[j].EMD_SPEED = br.ReadByte();
						EMD_DATA[x].Enemy[j].UByte03 = br.ReadByte();
						EMD_DATA[x].Enemy[j].ULong05 = br.ReadInt32();
						EMD_DATA[x].Enemy[j].EMD_SCALE = br.ReadInt16();
						EMD_DATA[x].Enemy[j].UByte04 = br.ReadByte();
						EMD_DATA[x].Enemy[j].EMD_FOLLOW = br.ReadByte(); // prob wrong
                        EMD_DATA[x].Enemy[j].UShort14 = br.ReadInt16();
                        EMD_DATA[x].Enemy[j].ULong06 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].ULong07 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].ULong08 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].ULong09 = br.ReadInt32();
                        EMD_DATA[x].Enemy[j].ULong10 = br.ReadInt32();

						// RETURN TO START OF EMD BLOCK

			




					}

			
					//fs.Seek(EMD_HEADER[x].Offset + start_off + Emd_Offset, SeekOrigin.Begin);


					//    LST_EMD.Items[x].SubItems.Add(EMD_DATA[x].Enemy[0].Room_ID.ToString());

				}



				

				fs.Close();
                    br.Close();



                

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }


        /// <summary>
        /// Read EMD Locally
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="LST_HEADER"></param>
        /// <param name="LB"></param>
        /// <param name="HB"></param>
        /// <param name="fsize"></param>
        /// <param name="PG"></param>
        /// <param name="Debug_Log"></param>
        public void READ_EMD(string sFile, ListView LST_HEADER, ListBox LB, PropertyGrid PG, RichTextBox Debug_Log)
		{
			try
			{


			

				FileStream fs = new FileStream(sFile, FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
			




				//Clear header info
				LST_HEADER.Items.Clear();

				if (sFile.Substring(sFile.Length - 3, 3) != "emd")
				{
					MessageBox.Show("Unsupported file type", "USF", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
				}


				//First find out how long the header and therefore how big the amount of header entries are.
				int test_offset = br.ReadInt32();   //We read the 1st 4 bytes, the first offset. We know that the header will end where the first data block will start
				int lv_idx = 0;
				long t_size = fs.Length;

				Array.Resize(ref EMD_HEADER, (test_offset / 8) - 1);    //Resize the array, 1st offset / 8 (length of a header entry) = amount of header entries/objects

				Array.Resize(ref EMD_DATA, EMD_HEADER.Length);    //Resize the array, number of EMD data blocks = number of header entries/objects


				fs.Seek(0, SeekOrigin.Begin);   //Reset offset to 0.

				//Read full header
				for (int i = 0; i < EMD_HEADER.Length; i++)
				{
					EMD_HEADER[i].Offset = br.ReadInt32();
					EMD_HEADER[i].Size = br.ReadInt32();

					//Resize the current object's EMD DATA block arry to match the entries to read from the header entry offset
					Array.Resize(ref EMD_DATA[i].Enemy, EMD_HEADER[i].Size / 96);


					//Add fresh read header obj info to the listview
					LST_HEADER.Items.Add(i.ToString());                                     //Add current Index
					LST_HEADER.Items[i].SubItems.Add(EMD_HEADER[i].Offset.ToString());      //Add current object offset
					LST_HEADER.Items[i].SubItems.Add(EMD_HEADER[i].Size.ToString());        //Add current object size
					LST_HEADER.Items[i].SubItems.Add(EMD_DATA[i].Enemy.Length.ToString());  //Add current object's count of entries (to find following the offset)
				}


			

			//	fsize.Text = "File Size: " + t_size.ToString();
				



				////Read data...
				//for (int i = 0; i < EMD_HEADER.Length; i++) // loop through amount of header objects
				//{
				//	fs.Seek(EMD_HEADER[i].Offset, SeekOrigin.Begin); // loop the file pointer to each offset

				////	for (int j = 0; j < EMD_DATA[i].Enemy.Length; j++) // read each enemy block
				//	{

				//		Debug_Log.AppendText("########### STORED DATA ############\n\n\n");

				//		Debug_Log.AppendText("\nBlock Index: " + i.ToString() + "\n");
				//		Debug_Log.AppendText("Entry Index: " + j.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].Tag = br.ReadByte();
				//		Debug_Log.AppendText("Tag: " + EMD_DATA[i].Enemy[j].Tag.ToString() + "\t");
				//		EMD_DATA[i].Enemy[j].No = br.ReadByte();
				//		Debug_Log.AppendText("No#: " + EMD_DATA[i].Enemy[j].No.ToString() + "\t");
				//		EMD_DATA[i].Enemy[j].NBD_ID0 = br.ReadByte();
				//		Debug_Log.AppendText("NBDID0: " + EMD_DATA[i].Enemy[j].NBD_ID0.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].NBD_ID1 = br.ReadByte();
				//		Debug_Log.AppendText("NBDID1: " + EMD_DATA[i].Enemy[j].NBD_ID1.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].ULong00 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].ULong01 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].X = br.ReadInt32();
				//		Debug_Log.AppendText("X: " + EMD_DATA[i].Enemy[j].X.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].Z = br.ReadInt32();
				//		Debug_Log.AppendText("Z: " + EMD_DATA[i].Enemy[j].Z.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].Y = br.ReadInt32();
				//		Debug_Log.AppendText("Y: " + EMD_DATA[i].Enemy[j].Y.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].R = br.ReadInt32();
				//		Debug_Log.AppendText("R: " + EMD_DATA[i].Enemy[j].R.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].Room_ID = br.ReadByte();
				//		Debug_Log.AppendText("Room ID: " + EMD_DATA[i].Enemy[j].Room_ID.ToString() + "\n");
				//		EMD_DATA[i].Enemy[j].UByte = br.ReadByte();
				//		EMD_DATA[i].Enemy[j].UShort01 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort02 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UByte00 = br.ReadByte();
				//		EMD_DATA[i].Enemy[j].UByte01 = br.ReadByte();
				//		EMD_DATA[i].Enemy[j].UShort03 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort04 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].ULong02 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].ULong03 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].UShort05 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort06 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort07 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort08 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort09 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort10 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].ULong04 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].UShort11 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].ULong05 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].UShort12 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort13 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].UShort14 = br.ReadInt16();
				//		EMD_DATA[i].Enemy[j].ULong06 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].ULong07 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].ULong08 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].ULong09 = br.ReadInt32();
				//		EMD_DATA[i].Enemy[j].ULong10 = br.ReadInt32();



				//	}


				//	LST_HEADER.Items[i].SubItems.Add(EMD_DATA[i].Enemy[0].Room_ID.ToString());

				//}

				//EMD_PROP._tag = EMD_DATA[0].Enemy[0].Tag;
				//EMD_PROP._No = EMD_DATA[0].Enemy[0].No;
				//EMD_PROP._NBD_ID0 = EMD_DATA[0].Enemy[0].NBD_ID0;
				//EMD_PROP._NBD_ID1 = EMD_DATA[0].Enemy[0].NBD_ID1;
				//EMD_PROP._ULong00 = EMD_DATA[lv_idx].Enemy[0].ULong00;
				//EMD_PROP._ULong01 = EMD_DATA[lv_idx].Enemy[0].ULong01;
				//EMD_PROP._X = EMD_DATA[0].Enemy[0].X;
				//EMD_PROP._Z = EMD_DATA[0].Enemy[0].Z;
				//EMD_PROP._Y = EMD_DATA[0].Enemy[0].Y;
				//EMD_PROP._R = EMD_DATA[0].Enemy[0].R;
				//EMD_PROP._Room_ID = EMD_DATA[0].Enemy[0].Room_ID;

				//PG.SelectedObject = EMD_PROP;




				fs.Close();
				br.Close();
			}

			catch (FileNotFoundException FNF) 
			{
				MessageBox.Show(FNF.Message.ToString() + "File not found");  
			}

		}

        

        /// <summary>
        /// Dump EMd Data To property grid
        /// </summary>
        /// <param name="LST_HEADER"></param>
        /// <param name="LB"></param>
        /// <param name="PG"></param>
		public static void Set_Object(ListView LST_HEADER, ListBox LB, PropertyGrid PG) // get indexs set emd prop grid object to already stored data and send to prop grid
		{
			

		}

		public static void Set_pic(byte NBD0, byte NBD1, PictureBox PB) // sets current enemy entry's appropriate picture
		{
			try 
			{

				string enviro = AppDomain.CurrentDomain.BaseDirectory + "EMD_IMG\\";
				string joint_val = string.Empty;
			//	string nbd00 = NBD0.Value.ToString();
			//	string nbd01 = NBD1.Value.ToString();


			//	joint_val = nbd00 + nbd01;

			

				if (NBD0 <= 9) // if first NBD id value < 10 make sure 0 is loaded in front of the ID value
				{
				    Image enemy_image = Image.FromFile(enviro + "E" +0 + NBD0 + "_" + NBD1 + ".NBD.jpg");
					PB.Image = enemy_image;
				}
				else if(NBD0 >= 10) // if ID greater then 10 remove the 0
				{
				   Image enemy_image0 = Image.FromFile(enviro + "E" + NBD0 + "_" + NBD1 + ".NBD.jpg");
				   PB.Image = enemy_image0;
				}
			}

			catch (Exception ex) // should only happen when NBD id cant link to picture in IMG folder
			{
				//MessageBox.Show("ID NOT FOUND IN DICTIONARY!", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}



		public static void Set_ROOM(string sce_ID, byte ROOMID, PictureBox PB) // sets current enemy entry's appropriate picture
		{
			try
			{

				string enviro = string.Empty;
				string joint_val = string.Empty;


				// IF FILE 1
				if (GAME_VALUE == 0)
				{
					enviro = AppDomain.CurrentDomain.BaseDirectory + "\\File_1\\";

				}


				else if (GAME_VALUE == 1) 
				{
					enviro = AppDomain.CurrentDomain.BaseDirectory + "\\File_2\\";
				}


				string tpath = enviro + "\\" + sce_ID + "\\" + ROOMID.ToString() + ".png";

              //  MessageBox.Show(tpath);


                Image room_image = Image.FromFile(tpath);
              	PB.Image = room_image;



            }

			catch (Exception ex) // should only happen when NBD id cant link to picture in IMG folder
			{
				//MessageBox.Show("ID NOT FOUND IN DICTIONARY!", "NOT FOUND", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}


		}



	

}



public class EMD_Properties 
	{
		public byte _tag;       //  1       Not sure, could be to deactivate/activate an entry?
		public byte _No;         //  2       Number of enemy in room?
		public byte _NBD_ID0;    //  3    First part of NBD ID to use
		public byte _NBD_ID1;    //  4         Second part of NBD ID to use
		public int _ULong00;      // 8
		public int _ULong01;      // 12
		public int _X;            // 16 Could be coords, X? Not sure if long or float...
		public int _Z;           //  20 Could be coords, Z? Not sure if long or float...
		public int _Y;           //  24 Could be coords, Y? Not sure if long or float...
		public int _R;           //  28 Could be Rotation? Not sure if long or float...
		public byte _Room_ID;
		public byte _UByte;
		public Int16 _UShort01;
		public Int16 _UShort02;
		public byte _UByte00;
		public byte _UByte01;
		public Int16 _UShort03;
		public Int16 _UShort04;
		public int _ULong02;
		public int _ULong03;
		public Int16 _UShort05;
		public Int16 _UShort06;
		public Int16 _UShort07;
		public Int16 _UShort08;
		public Int16 _UShort09;
		public Int16 _UShort10;
		public int _ULong04;
		public Int16 _UShort11;
		public int _ULong05;
		public Int16 _UShort12;
		public Int16 _UShort13;
		public Int16 _UShort14;
		public int _ULong06;
		public int _ULong07;
		public int _ULong08;
		public int _ULong09;
		public int _ULong10;



		[Category("EMD DATA")]
		[DisplayName("Tag/Flag")]
		[Description("This is always 1 for some reason")]
		

		public byte tag // display tag
		{
			get { return _tag; }
			set { _tag = value; }
		}

		[Category("EMD DATA")]
		[DisplayName("Count/ Order ID")]
		[Description("The Order that the enemy is called by the script")]

		public byte No // total cam count for room
		{
			get { return _No; }
			set { _No = value; }
		}

		[Category("EMD DATA")]
		[DisplayName("NBD ID0")]

		public byte NBD_ID0 // total cam count for room
		{
			get { return _NBD_ID0; }
			set { _NBD_ID0 = value; }
		}

		[Category("EMD DATA")]
		[DisplayName("NBD ID1")]

		public byte NBD_ID1 // total cam count for room
		{
			get { return _NBD_ID1; }
			set { _NBD_ID1 = value; }
		}

		[Category("EMD DATA")]
		[DisplayName("Unknown Long00")]

		public int ULong00
		{
			get { return _ULong00; ; }
			set { _ULong00  = value; }
		}

		[Category("EMD DATA")]
		[DisplayName("Unknown Long01")]

		public int ULong01
		{
			get { return _ULong01; ; }
			set { _ULong01  = value; }
		}

		[Category("EMD DATA")]
		[DisplayName("X")]
		[Description("X coordinate for set enemy")]

		public int X
		{
			get { return _X; }
			set { _X = value; }
		}


		[Category("EMD DATA")]
		[DisplayName("Z")]
		[Description("Z coordinate for set enemy")]

		public int Z
		{
			get { return _Z; }
			set { _Z = value; }
		}



		[Category("EMD DATA")]
		[DisplayName("Y")]
		[Description("Y Coordinate for set enemy")]

		public int Y
		{
			get { return _Y; }
			set { _Y = value; }
		}


		[Category("EMD DATA")]
		[DisplayName("R")]
		[Description("Rotation Value for set enemy")]

		public int R
		{
			get { return _R; }
			set { _R = value; }
		}



		[Category("EMD DATA")]
		[DisplayName("Room ID")]

		public byte Room_ID
		{
			get { return _Room_ID; }
			set { _Room_ID = value; }
		}

		
	

	
	}




}


