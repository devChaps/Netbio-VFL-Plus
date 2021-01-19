using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Netbio_VFL_Plus
{
    public class NPC_IO
    {

        #region globals;
        string file_path;
        public byte entry_index;
        public bool debug_enable;

        public static byte GAME_VALUE = 0;  // 0 for FILE 1, 1 for FILE 2 
        public static string SCE_VALUE = string.Empty; // holds scenario archive string

        public int ARCHIVE_OFFSET;
        public int NPC_OFFSET;
     
        #endregion

        public struct NPC_HEADER_OBJ
        {
            public Int32 offset; // 1st offset is end of main header
            public Int32 size;
        }

        public struct NPC_SUB_HEADER_OBJ
        {
            public Int32 Entries;
            public Int32[] offset; //relative to the NPC block, not from the header


        }

        public struct NPC_DATA_OBJ // 128 byte NPC script
        {
            public int tag;
            public int Room_ID;
            public int Ulong00;
            public int N_ID; // npc that loads from the N table 
            public float coord00; // its a float, y
            public int Ulong01; // not sure what this does
            public float coord01; // float, x
            public Int16 rotation; // npc rotation
            public int Ulong02;
            public int Ulong03;
            public int Ulong04;
            public Int16 Ushort01;
            public byte Anim_ID;
            public byte Anim_Flag; // 2 bytes(animation + intervel)
            public Int16 Ushort02; // 
            public byte Anim_ID2; // optional
            public byte Anim_Flag2;
            public int Ulong05;
            public int Ulong06;
            public int Ulong07;
            public int Ulong08;
            public int Ulong09;
            public Int16 Ushort03;
            public int Alive_flag; // setting this to 0 kills the NPC 
            public byte boundary; // (Scale boundary)
            public int Ulong10;
            public int Ulong11;
            public int Ulong12;
            public int Ulong13;
            public int Ulong14;
            public int Ulong15;      // these last longs are just blank data
            public int Ulong16;
            public int Ulong17;
            public int Ulong18;
            public int Ulong19;
            public int Ulong20;
            public int Ulong21;
            public Int16 uShort04;
        }


        public struct NPC_SET // array of NPC structs
        {
            public NPC_DATA_OBJ[] NPC;

        }


        public static NPC_HEADER_OBJ[] NPC_HEADER = new NPC_HEADER_OBJ[0];
        public static NPC_SUB_HEADER_OBJ[] SUB_HEADER = new NPC_SUB_HEADER_OBJ[0];
        public static NPC_SET[] NPC_DATA = new NPC_SET[0];


        public void READ_NPC_STREAM(Stream fs, int start_off, byte gameval, string sce_val, ListView LST_AFS, ListView LST_NPC, ListBox LB_NPC)
        {
           
                int NPC_LSTVIEW_OFF = int.Parse(LST_AFS.FocusedItem.SubItems[1].Text);
                byte[] EMD_BUFFER = new byte[0];
                int t_sz = int.Parse(LST_AFS.FocusedItem.SubItems[2].Text);


                ARCHIVE_OFFSET = start_off;
                NPC_OFFSET = NPC_LSTVIEW_OFF; // set listview to global 

                 GAME_VALUE = gameval;
                 SCE_VALUE = sce_val;

            // PREVENT DUPES N SHIT
            //   LB_EMDOFF.Items.Clear();

            // SET SCENARIO DATA
            //   GAME_VALUE = GameVal;
            //    SCE_VALUE = sce_val;

            LST_NPC.Items.Clear(); // clear dupes n shit




                // CREATE BINARY READER SEEK TO NPC OFFSET ON DISK
                BinaryReader br = new BinaryReader(fs);
                fs.Seek(NPC_OFFSET + start_off, SeekOrigin.Begin); // jump to right loc from disc
                                                                   //    MessageBox.Show(Emd_Offset + start_off.ToString());



                //  LST_EMD.Items.Clear();


                // READ FIRST OFFSET AND CALCULATE STRUCTURE SIZES
                Int32 h_offset = br.ReadInt32();
           

                Array.Resize(ref NPC_HEADER, (h_offset / 8));
                Array.Resize(ref SUB_HEADER, (h_offset / 8));
                Array.Resize(ref NPC_DATA, SUB_HEADER.Length);



                fs.Seek(-4, SeekOrigin.Current); // jump back to Start of file..



                // READ HEADER N DUMP TO LISTVIEW
                for (int i = 0; i < NPC_HEADER.Length; i++)
                {
                    NPC_HEADER[i].offset = br.ReadInt32();
            
                    NPC_HEADER[i].size = br.ReadInt32();

                    LST_NPC.Items.Add(i.ToString());
                    LST_NPC.Items[i].SubItems.Add(NPC_HEADER[i].offset.ToString());
                    LST_NPC.Items[i].SubItems.Add(NPC_HEADER[i].size.ToString());

                }



                for (int i = 0; i < NPC_HEADER.Length; i++) // npc header length is = to as many block entries there are
                {
                    fs.Seek(NPC_HEADER[i].offset + NPC_OFFSET + start_off, SeekOrigin.Begin); // seek to each offset and read each block entry count
                    SUB_HEADER[i].Entries = br.ReadInt32(); // store the number of entries into sub header entry array
                

                Array.Resize(ref SUB_HEADER[i].offset, SUB_HEADER[i].Entries); // resize sub header offset array to the number of entries for that block

                    for (int j = 0; j < SUB_HEADER[i].Entries; j++) // loop through current blocks sub header entries 
                    {
                        SUB_HEADER[i].offset[j] = br.ReadInt32(); // read each sub header offset into sub header offset array
                    }

                    for (int j = 0; j < SUB_HEADER[i].Entries; j++)
                    {

                        Array.Resize(ref NPC_DATA[i].NPC, NPC_HEADER[i].offset);
                        fs.Seek(NPC_HEADER[i].offset + SUB_HEADER[i].offset[j] + NPC_OFFSET + start_off, SeekOrigin.Begin); // skip past entry sub header to actual data

                        //   Debug_log.AppendText("\n\n [Entry Offset: " + fs.Position.ToString() + "]"); // dump actual data offset


                        NPC_DATA[i].NPC[j].tag = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Room_ID = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ulong00 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].N_ID = br.ReadInt32();
                        NPC_DATA[i].NPC[j].coord00 = br.ReadSingle();                 // <> read actual data
                        NPC_DATA[i].NPC[j].Ulong01 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].coord01 = br.ReadSingle();
                        NPC_DATA[i].NPC[j].rotation = br.ReadInt16();
                        NPC_DATA[i].NPC[j].Ulong02 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ulong03 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ulong04 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ushort01 = br.ReadInt16();
                        NPC_DATA[i].NPC[j].Anim_ID = br.ReadByte();
                        NPC_DATA[i].NPC[j].Anim_Flag = br.ReadByte();
                        NPC_DATA[i].NPC[j].Ushort02 = br.ReadInt16();
                        NPC_DATA[i].NPC[j].Anim_ID2 = br.ReadByte();
                        NPC_DATA[i].NPC[j].Anim_Flag2 = br.ReadByte();
                        NPC_DATA[i].NPC[j].Ulong05 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ulong06 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ulong07 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ulong08 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ulong09 = br.ReadInt32();
                        NPC_DATA[i].NPC[j].Ushort03 = br.ReadInt16();
                        NPC_DATA[i].NPC[j].Alive_flag = br.ReadInt32();
                        NPC_DATA[i].NPC[j].boundary = br.ReadByte();






                    }

                    LST_NPC.Items[i].SubItems.Add(NPC_DATA[i].NPC[0].Room_ID.ToString());

                }


            fs.Close();
            br.Close();


          
        }



        public static void Set_ROOM(string sce_ID, int ROOMID, PictureBox PB) // sets current enemy entry's appropriate picture
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




        // READ NPC FILE from local disk
        public void READ_NPC_FILE(string NPC_FILE)
        {

           // Lst_Header.Items.Clear();


            FileStream fs = new FileStream(NPC_FILE, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);



            Int32 offset = br.ReadInt32();
            Array.Resize(ref NPC_HEADER, (offset / 8));
            Array.Resize(ref SUB_HEADER, (offset / 8));
            Array.Resize(ref NPC_DATA, SUB_HEADER.Length);

       



            fs.Seek(0, SeekOrigin.Begin);


            for (int i = 0; i < NPC_HEADER.Length; i++)
            {
                NPC_HEADER[i].offset = br.ReadInt32();
                NPC_HEADER[i].size = br.ReadInt32();



                //Lst_Header.Items.Add(i.ToString());
                //Lst_Header.Items[i].SubItems.Add(NPC_HEADER[i].offset.ToString());
                //Lst_Header.Items[i].SubItems.Add(NPC_HEADER[i].size.ToString());


               // Debug_log.AppendText("Entry " + i + " Offset: " + NPC_HEADER[i].offset.ToString());
                // Debug_log.AppendText("\t");
              //  Debug_log.AppendText("            Entry " + i + " Size: " + NPC_HEADER[i].size.ToString() + "\n");


            }
//            Debug_log.AppendText("--------------------------------------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < NPC_HEADER.Length; i++) // npc header length is = to as many block entries there are
            {
                fs.Seek(NPC_HEADER[i].offset, SeekOrigin.Begin); // seek to each offset and read each block entry count
                SUB_HEADER[i].Entries = br.ReadInt32(); // store the number of entries into sub header entry array

                Array.Resize(ref SUB_HEADER[i].offset, SUB_HEADER[i].Entries); // resize sub header offset array to the number of entries for that block

                for (int j = 0; j < SUB_HEADER[i].Entries; j++) // loop through current blocks sub header entries 
                {
                    SUB_HEADER[i].offset[j] = br.ReadInt32(); // read each sub header offset into sub header offset array
                }

                for (int j = 0; j < SUB_HEADER[i].Entries; j++)
                {

                    Array.Resize(ref NPC_DATA[i].NPC, NPC_HEADER[i].offset);
                    fs.Seek(NPC_HEADER[i].offset + SUB_HEADER[i].offset[j], SeekOrigin.Begin); // skip past entry sub header to actual data

                  //  Debug_log.AppendText("\n\n [Entry Offset: " + fs.Position.ToString() + "]"); // dump actual data offset


                    NPC_DATA[i].NPC[j].tag = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Room_ID = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ulong00 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].N_ID = br.ReadInt32();
                    NPC_DATA[i].NPC[j].coord00 = br.ReadSingle();                 // <> read actual data
                    NPC_DATA[i].NPC[j].Ulong01 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].coord01 = br.ReadSingle();
                    NPC_DATA[i].NPC[j].rotation = br.ReadInt16();
                    NPC_DATA[i].NPC[j].Ulong02 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ulong03 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ulong04 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ushort01 = br.ReadInt16();
                    NPC_DATA[i].NPC[j].Anim_ID = br.ReadByte();
                    NPC_DATA[i].NPC[j].Anim_Flag = br.ReadByte();
                    NPC_DATA[i].NPC[j].Ushort02 = br.ReadInt16();
                    NPC_DATA[i].NPC[j].Anim_ID2 = br.ReadByte();
                    NPC_DATA[i].NPC[j].Anim_Flag2 = br.ReadByte();
                    NPC_DATA[i].NPC[j].Ulong05 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ulong06 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ulong07 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ulong08 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ulong09 = br.ReadInt32();
                    NPC_DATA[i].NPC[j].Ushort03 = br.ReadInt16();
                    NPC_DATA[i].NPC[j].Alive_flag = br.ReadInt32();
                    NPC_DATA[i].NPC[j].boundary = br.ReadByte();



                    // Debug_log.ForeColor = Color.White;
                 //   Debug_log.AppendText("\n [Tag: " + NPC_DATA[i].NPC[j].tag.ToString() + "]\n");
                  //  Debug_log.AppendText(" [Room ID: " + NPC_DATA[i].NPC[j].Room_ID.ToString() + "]\n");
                   // Debug_log.AppendText(" [NPC ID: " + NPC_DATA[i].NPC[j].N_ID.ToString() + "]\n");
                   // Debug_log.AppendText(" [Position Y: " + NPC_DATA[i].NPC[j].coord00.ToString() + "]");        // <> dump actual data
                   // Debug_log.AppendText(" [Position X: " + NPC_DATA[i].NPC[j].coord01.ToString() + "]");
                   // Debug_log.AppendText(" [Rotation: " + NPC_DATA[i].NPC[j].rotation.ToString() + "]");
                    //Debug_log.AppendText(" [Anim ID1: " + NPC_DATA[i].NPC[j].Anim_ID.ToString() + "]");
                   // Debug_log.AppendText(" [Anim Flag1: " + NPC_DATA[i].NPC[j].Anim_Flag.ToString() + "]");
                   // Debug_log.AppendText(" [Anim ID2: " + NPC_DATA[i].NPC[j].Anim_ID2.ToString() + "]");
                   // Debug_log.AppendText(" [Anim Flag2: " + NPC_DATA[i].NPC[j].Anim_Flag2.ToString() + "]\n");
                   // Debug_log.AppendText(" [Alive Flag: " + NPC_DATA[i].NPC[j].Alive_flag.ToString() + "]");
                   // Debug_log.AppendText(" [Bounadry: " + NPC_DATA[i].NPC[j].boundary.ToString() + "]");
                   // Debug_log.AppendText("\n------------------------------------------------------------------------------------------------------------------------------------------------------");



                }

              //  Lst_Header.Items[i].SubItems.Add(NPC_DATA[i].NPC[0].Room_ID.ToString());

            }


            fs.Close();
            br.Close();



        }


    }
}
