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




		public static Dictionary<string, string> ENEMY_NAME_LUT = new Dictionary<string, string>()
		{
			{"0100","Global Zombie (Yong boy)" },
			{"0101","Worker Zombie 1" },
			{"0102","Worker Zombie 2" },
			{"0103","Worker Zombie 3"},
			{"0104","Worker Zombie 4"},
			{"0105","Worker Zombie 5"},
			{"0106","Worker Zombie 6" },
			{"0107","Worker Zombie 7"},
			{"0108","Worker Zombie 8"},
			{"0109","Citizen Zombie1(Nicolas)" },
			{"010A","Citizen Zombie2(Sean)"},
			{"010B","Citizen Zombie3(Don)"},
			{"010C","Citizen Zombie4"},
			{"010D","Citizen Zombie5"},
			{"010E","Citizen Zombie6"},
			{"010F","Citizen Zombie7(Chuck)"},
			{"0110","Woman Zombie(Ginger)"},
			{"0111","Woman Zombie(Laura)"},
			{"0112","Woman Zombie(America)"},
			{"0113","Police Zombie 1"},
			{"0114","Police Zombie 2"},
			{"0115","Police Zombie 3"},
			{"0116","Police Zombie 4"},
			{"0117","Police Zombie 5"},
			{"0118","Police Zombie Woman 1"},
			{"0119","Police Zombie Woman 2" },
			{"011A","Dr. Zombie 1"},
			{"011B","Dr. Zombie 2"},
			{"011C","Dr. Zombie 3"},
			{"011D","Nurse Zombie 1"},
			{"011E","Nurse Zombie 2"},
			{"011F","Green Zombie 1"},
			{"0120","Green Zombie 2"},
			{"0121","Researcher Zombie 1"},
			{"0122","Researcher Zombie 2"},
			{"0123","Researcher Zombie 3"},
			{"0124","Subway staff Zombie 1"},
			{"0125","Subway staff Zombie 2"},
			{"0126","Subway staff Zombie 3"},
			{"0127","U.S.S.Zombie 1"},
			{"0128","Citizen Zombie(Low polygon)1"},
			{"0129","Citizen Zombie(Low polygon)2"},
			{"012A","Citizen Zombie(Low polygon)3"},
			{"012B","Citizen Zombie(Low polygon)4(Nicolas)"},
			{"012C","Citizen Zombie(Low polygon)5"},
			{"012D","Citizen Zombie(Low polygon)6"},
			{"012E","Woman Zombie(Low polygon)(Laura)1"},
			{"012F","Citizen Zombie(Low polygon)7"},
			{"0130","Citizen Zombie(Low polygon)8"},
			{"0131","Citizen Zombie(Low polygon)9"},
			{"0132","Citizen Zombie(Low polygon)10"},
			{"0133","Citizen Zombie(Low polygon)11"},
			{"0134","Citizen Zombie(Low polygon)12"},
			{"0135","Bob zombie(for FILE1)"},
			{"0136","Citizen Zombie(Low polygon)13"},
			{"0137","Peter zombie(for FILE1)"},
			{"0138","Thin body zombies that are out of focus"},
			{"0139","Woman Zombie(Low polygon)(Laura)2"},
			{"013A","Citizen Zombie(Low polygon)(Nicolas)14"},
			{"013B","U.S.S.Zombie 2"},
			{"013C","U.S.S.Zombie 3"},
			{"0146","Kevin zombie"},
			{"0147","Mark zombie"},
			{"0148","Jim zombie"},
			{"0149","George zombie"},
			{"014A","David zombie"},
			{"014B","Alyssa zombie"},
			{"014C","Yoko zombie"},
			{"014D","Cindy zombie"},
			{"0150","Bob zombie"},
			{"0151","Peter zombie(for FILE2)"},
			{"0155","Will zombie"},
			{"015A","unused low plygon zombie1"},
			{"015E","unused low plygon zombie2"},
			{"0163","unused low plygon zombie3"},
			{"3B00","Zombie's two arms"},
			{"0200","Naked double-headed dog(unused)"},
			{"0201","Zombie Doberman"},
			{"0202","Gray dog 1(not zombie)"},
			{"0203","Doberman(not zombie)"},
			{"0204","Gray dog 2(not zombie)"},
			{"0400","Zombie Mouse"},
			{"0500","Crow"},
			{"1000","Gnew"},
			{"1001","Gnew"},
			{"1900","Zombie shark1"},
			{"1A00","Zombie shark2"},
			{"2101","Female lion"},
			{"3100","Hornbill"},
			{"4100","Hyena"},
			{"0300","Cockroach"},
			{"0600","Wasp"},
			{"0700","Giant Spider"},
			{"0800","Spider"},
			{"0900","Giant Moth"},
			{"0A00","Caterpillar"},
			{"1200","Giga Byte"},
			{"1201","Mega byte"},
			{"1500","Unused larvae"},
			{"1800","Unused elongated larvae"},
			{"2400","Scissor tail(brown)"},
			{"2401","Scissor tail(gray)1"},
			{"2402","Scissor tail(gray)2"},
			{"2700","Moth larva?"},
			{"3000","Flying bug"},
			{"0000","LICKER"},
			{"0001","LICKER"},
			{"1600","Hunter"},
			{"1601","Hunter(Frozen)"},
			{"1602","Hunter(Frozen)"},
			{"1700","Hunter γ"},
			{"1B00","Leech man1(Kevin)"},
			{"1B01", "Leech man2 (Mark)"},
			{"1B02", "Leech man3(Jim)"},
			{"1B03","Leech man4 (Geroge)"},
			{"1B04","Leech man5(David)"},
			{"1B05", "Leech man6(Alyssa)"},
			{"1B06","Leech man7(Yoko)"},
			{"1B07","Leech man8(Cindy)"},
			{"1B08", "Leech man9(Hursh)"},
			{"1B09", "Leech man10(First man)"},
			{"3700", "Leech"},
			{"0B00", "Plants absorbed from above"},
			{"0C00", "Unknown plant."},
			{"0D00", "Evil Shade"},
			{"0E00", "Unknown Plant"},
			{"2200", "Twist upper"},
			{"2300", "Ivy entwined in the foot"},
			{"2E00", "Rafflesia with open petals"},
			{"2E01", "Rafflesia with closed petals"},
			{"2E02","Rafflesia on the bud"},
			{"2F00", "Nepenthes rafflesiana Jack"},

			{"2F01","Hanging ivy"},
			{"1400", "Suspented"},
			{"1D00","G mutant"},
			{"2000","Zombie Elephant"},
			{"2100", "Male lion"},
			{"2900","Tyrant A"},
			{"2901","Tyrant R"},
			{"2902","Tyrant G"},
			{"2903","Tyrant C"},
			{"2B00","Tanatos"},
			{"2B01","Tanatos R"},
			{"2C00","Nyx"},
			{"2D00","Axe man"},
			{"1300","Giant leech"},
			{"4000","Gigabyte"},
			{"3800","Giant leeches tentacles"},
			{"0F00","NYX back tentacles"},
			{"1E00","G mutant larvae"},
			{"1D02","Flesh of G mutant (unknown)"},
			{"2A00","Nyx foot tentacle attack"},
			{"3E00", "Nyx chunks of meat"},
			{"3F00","Megabyte(move while rotating)"},
			{"1100", "Shadows of multiple zombies"},
			{"1101", "Multiple zombies"},
			{"1102", "Multiple zombies falling"},
			{"2500", "Zombie with thin body1"},
			{"2501", "Zombie with thin body2"},
			{"2502", "Zombie with thin body3"},
			{"2503", "Zombie with thin body4"},
			{"2600", "Moth cocoon"},
			{"3200", "Rusty gray iron plate"},
			{"3300", "Destructible wooden box"},
			{"3500", "Stones falling from the ceiling"},
			{"3600", "Anti-personnel mines with legs"},
			{"3601", "Anti-personnel mines without legs"},
			{"3900", "ARNOLD shooting"},
			{"3A00", "Plastic tank"},
			{"3A01", "Handle and device"},
			{"3C00", "Burning flame"},
			{"3D00", "Typewriter (without pedestal)"},
			{"3D01", "Typewriter (with pedestal)"},
			{"1C00", "William Birkin infected with G virus(unused)"},
			{"1F00", "Naked Giant(unused)"},
			{"2201", "Tanaotos (unused)?"},
			{"2202", "Tanaotos R (unused)"},
			{"2800", "Unused Tanatos (Gray)"},



		};



		public static Dictionary<byte, string> ZOMBIE_REVIVE_LUT = new Dictionary<byte, string>()
		{
			{0, "CORPSE REVIVE" },
			{1, "CORPSE DISSAPEAR"},
			{2, "NO REVIVE" }
		};

		public static Dictionary<byte, string> ZOMBIE_ANIMATION_LUT = new Dictionary<byte, string>()
		{
			{0x00, "Standing Normally"},
			{0x01, "Standing (Special)"},
			{0x02, "Door Hit + Rush"},
			{0x03, "No Function"},
			{0x04, "Lying Prone"},
			{0x05, "Lying On back"},
			{0x06, "Sitting on the ground"},
			{0x07, "Sitting Dead in a Chair"},
			{0x08, "Sitting Prone in a chair (Peter)"},
			{0x09, "Bites Corpse + Stand"},
			{0x0A, "Crawl from Drawer"},
			{0x0B, "Window Break/Crawl"},
			{0x0C, "N/A"},
			{0x0D, "Lying Down"},
			{0x0E, "Locker Attack"},
			{0x0F, "Unused 00"},
			{0x10, "Unused 01"},
			{0x11, "N/F"},
			{0x12, "Ground Crawl / Stand"},
			{0x13, "Unused 02"},
			{0x14, "Unused 03"},
			{0x15, "Window Break / Slide"},
			{0x16, "??"},
			{0x17, "Unused 04"},
			{0x18, "Hitting Window (Slow)"},
			{0x19, "Elevator Attack"},
			{0x1A, "Unused 05"},
			{0x1B, "Wandering (Unused)"},
			{0x1C, "Hitting Window (Fast)"},
			{0x1D, "Unused 06"},
			{0x1E, "Shot Down by Marvin"},
			{0x1F, "Unused 07"},
			{0x20, "Idle Stand"},
			{0x21, "N/F"},
			{0x22, "N/F"},
			{0x23, "Door Open Attack"},
			{0x24, "Fence/Door Break"},
			{0x25, "Idle Stand / Attack"},
			{0x26, "Lying Prone 02"},
			{0x27, "Lying on Back 02"},
			{0x28, "Jumping out of ground?"},
			{0x29, "N/F"},
			{0x2A, "Unusued 08"},
			{0x2B, "Unusued 09"},
			{0x2C, "Unusued 10"},
			{0x2D, "Unusued 11"},
			{0x2E, "Unusued 12"},
			{0x2F, "Unusued 13"},

		};

		public struct EMD_Enemy_Obj
		{
			public byte Tag;        //  1       Not sure, could be to deactivate/activate an entry?
			public byte No;         //  2       Number of enemy in room?
			public byte NBD_ID0;    //  3         First part of NBD ID to use
			public byte NBD_ID1;    //  4         Second part of NBD ID to use
			public int ULong00;      // 8
			public int ULong01;      // 12
			public Int16 X;            // 16 Could be coords, X? Not sure if long or float...
			public Int16 Z;           //  20 Could be coords, Z? Not sure if long or float...
			public Int16 Y;           //  24 Could be coords, Y? Not sure if long or float...
			public Int16 R;           //  28 Could be Rotation? Not sure if long or float...
			public byte Room_ID;    // 29
			public byte SpawnIDX; // SPAWN INDEX
			public byte EMD_DFC;
			public byte UnkB01;
			public Int16 UShort02;
			public byte UByte00;
			public byte UByte01;
			public Int16 UShort03;
			public byte Zombie_ressurect; // + 38
			public byte UByte02;
			public int ULong02;
			public int ULong03;
			public byte UByte03;
			public byte EMD_STATE; // ENEMY ATTACK STATE (NEEDS LIST)
			public byte EMD_STR; // only works for tyrant?
			public byte EMD_HP;
			public Int16 UShort07;
			public Int16 UShort08;
			public Int16 UShort09;
			public Int16 UShort10;
			public byte Ubyte04;
			public byte Ubyte05;
			public byte Ubyte06;
			public byte EMD_KNOCKBACK; // + 59
			public byte EMD_SPEED; //  + 60
			public byte UByte07;
			public int ULong05;
			public Int16 EMD_SCALE;
			public byte UByte08;
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
        public void Parse_EMDStream(Stream fs, int start_off, string sce_val, byte GameVal, ListView LST_AFS, ListBox LB_EMDOFF, PictureBox CurrentRoom, PictureBox Emd_Pic, ToolStripStatusLabel LBL_OFFSET, ToolStripStatusLabel LBL_FTYPE)
        {
            
                int Emd_Offset = int.Parse(LST_AFS.FocusedItem.SubItems[1].Text);
				string f_name = LST_AFS.FocusedItem.SubItems[3].Text;
                byte[] EMD_BUFFER = new byte[0];
                int t_sz = int.Parse(LST_AFS.FocusedItem.SubItems[2].Text);


				ARCHIVE_OFFSET = start_off;
				EMD_OFFSET = Emd_Offset;

			   
				

				// PREVENT DUPES N SHIT
				LB_EMDOFF.Items.Clear();

				// SET SCENARIO DATA
				GAME_VALUE = GameVal;
				SCE_VALUE = sce_val;


			// SET LBL BASED ON FTYPE
			if (f_name.Substring(f_name.Length - 3, 3).ToUpper() == "EMD" && f_name.Substring(0, 1).ToUpper() == "S")
			{
				LBL_FTYPE.ForeColor = Color.Red;
				LBL_FTYPE.Text = "OFFLINE";
			}
			else 
			{
				LBL_FTYPE.ForeColor = Color.Blue;
				LBL_FTYPE.Text = "ONLINE";
			}
			

                //  Emd_DebugLog.AppendText("Archive Offset: " + start_off.ToString() + "\n EMD_Offset: " + Emd_Offset.ToString());

                fs.Seek(Emd_Offset + start_off, SeekOrigin.Begin); // jump to right loc from disc
																   //    MessageBox.Show(Emd_Offset + start_off.ToString());

				using (BinaryReader br = new BinaryReader(fs)) 
				{
				

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
								EMD_DATA[x].Enemy[j].X = br.ReadInt16();
								fs.Seek(+2, SeekOrigin.Current);
								//  Emd_DebugLog.AppendText("X: " + EMD_DATA[x].Enemy[j].X.ToString() + "\n");
								EMD_DATA[x].Enemy[j].Z = br.ReadInt16();
								fs.Seek(+2, SeekOrigin.Current);
						//  Emd_DebugLog.AppendText("Z: " + EMD_DATA[x].Enemy[j].Z.ToString() + "\n");
						        EMD_DATA[x].Enemy[j].Y = br.ReadInt16();
							    fs.Seek(+2, SeekOrigin.Current);
						//  Emd_DebugLog.AppendText("Y: " + EMD_DATA[x].Enemy[j].Y.ToString() + "\n");
							    EMD_DATA[x].Enemy[j].R = br.ReadInt16();
								fs.Seek(+2, SeekOrigin.Current);
						// Emd_DebugLog.AppendText("R: " + EMD_DATA[x].Enemy[j].R.ToString() + "\n");
								EMD_DATA[x].Enemy[j].Room_ID = br.ReadByte();
								EMD_DATA[x].Enemy[j].SpawnIDX = br.ReadByte(); // SPAWN INDEX
																			   //  Emd_DebugLog.AppendText("Room ID: " + EMD_DATA[x].Enemy[j].Room_ID.ToString() + "\n");
								EMD_DATA[x].Enemy[j].EMD_DFC = br.ReadByte();
								EMD_DATA[x].Enemy[j].UnkB01 = br.ReadByte();
								//	EMD_DATA[x].Enemy[j].UShort01 = br.ReadInt16();
								EMD_DATA[x].Enemy[j].UShort02 = br.ReadInt16();
								EMD_DATA[x].Enemy[j].UByte00 = br.ReadByte();
								EMD_DATA[x].Enemy[j].UByte01 = br.ReadByte();
								EMD_DATA[x].Enemy[j].UShort03 = br.ReadInt16();
								EMD_DATA[x].Enemy[j].Zombie_ressurect = br.ReadByte();
								EMD_DATA[x].Enemy[j].UByte02 = br.ReadByte();
								EMD_DATA[x].Enemy[j].ULong02 = br.ReadInt32();
								EMD_DATA[x].Enemy[j].ULong03 = br.ReadInt32();
								EMD_DATA[x].Enemy[j].UByte03 = br.ReadByte();
								EMD_DATA[x].Enemy[j].EMD_STATE = br.ReadByte();
								EMD_DATA[x].Enemy[j].EMD_STR = br.ReadByte();
								EMD_DATA[x].Enemy[j].EMD_HP = br.ReadByte();
								EMD_DATA[x].Enemy[j].UShort07 = br.ReadInt16();
								EMD_DATA[x].Enemy[j].UShort08 = br.ReadInt16();
								EMD_DATA[x].Enemy[j].UShort09 = br.ReadInt16();
								EMD_DATA[x].Enemy[j].UShort10 = br.ReadInt16();
								EMD_DATA[x].Enemy[j].Ubyte04 = br.ReadByte();
						        EMD_DATA[x].Enemy[j].Ubyte05 = br.ReadByte();
								EMD_DATA[x].Enemy[j].Ubyte06 = br.ReadByte();
								EMD_DATA[x].Enemy[j].EMD_KNOCKBACK = br.ReadByte();
								EMD_DATA[x].Enemy[j].EMD_SPEED = br.ReadByte();
								EMD_DATA[x].Enemy[j].UByte07 = br.ReadByte();
								EMD_DATA[x].Enemy[j].ULong05 = br.ReadInt32();
								EMD_DATA[x].Enemy[j].EMD_SCALE = br.ReadInt16();
								EMD_DATA[x].Enemy[j].UByte08 = br.ReadByte();
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

			   
				br.Dispose();
				br.Close();
				
				}

			FRM_MAIN.Img.Read_Image.Dispose();
			
				fs.Dispose();
				fs.Close();

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

		public static void Set_pic(byte NBD0, byte NBD1, PictureBox PB, Label NBD_FILE) // sets current enemy entry's appropriate picture
		{
			try
			{
				string enviro = AppDomain.CurrentDomain.BaseDirectory + "\\enemy_image\\IMG\\";
				string joint_val = string.Empty;
				//	string nbd00 = NBD0.Value.ToString();
				//	string nbd01 = NBD1.Value.ToString();


				string img_string = string.Empty;

				string nbdval0 = NBD0.ToString("00");
				string nbdval1 = NBD1.ToString("00");


				img_string = enviro + "\\" + "E" + nbdval0 + "_" + nbdval1 + ".jpg";

				NBD_FILE.Text = img_string.Substring(img_string.Length - 10, 7) + "NBD";

				Image em_img = Image.FromFile(img_string);
				PB.Image = em_img;


				//	joint_val = nbd00 + nbd01;

				//	Image enemy_image = Image.FromFile(enviro + "\\" + nbdstring + ".jpg");
			}
			catch (FileNotFoundException FNF) 
			{

				Image em_img = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\enemy_image\\IMG\\unknown.jpg");
				PB.Image = em_img;
				//MessageBox.Show(FNF.Message);
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


