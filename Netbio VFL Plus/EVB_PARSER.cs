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

    public struct EVB_SELECTED_OBJ
    {
        public string File_Name;
        public int File_Offset;
        public int File_Size;

    }

   public struct EVB_HEADER_OBJ
    {
        public Int32 offset00;
        public Int32 offset01; // could be instruction count?
        public Int32 offset02;
    }



    public class EVB_PARSER
    {
        // 

        public EVB_HEADER_OBJ EVB_HEADER = new EVB_HEADER_OBJ();
        public OpenFileDialog OFD = new OpenFileDialog();
         Items Itemz = new Items();

        

        /// <summary>
        /// no idea
        /// </summary>
        public class x08000002
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;

        }


        /// <summary>
        /// no idea until further tested
        /// </summary>
        public class x0B000002
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
            public Int32 uFlag01 = 0; // could be event ID
            public Int32 uFlag02 = 0;

        }

        /// <summary>
        /// Evt_Trigger?
        /// </summary>
        public class x0C000002
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
            public Int32 Event_ID = 0; // maybe
            public Int32 uFlag01 = 0;
        }


        /// <summary>
        /// *NEEDS TESTING*
        /// </summary>
        public class x20010001
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
        }

        /// <summary>
        /// LOAD_ITEM_SET?
        /// </summary>
        public class x31000001
        {
            public Int32 opcode = 0;
            public Int32 TBL_SLOT = 0;
        }

        public class x37000002
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;

        }

        /// <summary>
        /// Player Item_Spawn
        /// </summary>
        public class x39000002 // item set on spawn
        {
            public Int32 opcode = 0;
            public Int32 char_id = 0;
            public Int32 item_id = 0;
            public Int32 quantity = 0;
        }



        /// <summary>
        /// DOOR_LCK
        /// </summary>
        public class x40000002
        {
            public Int32 opcode = 0;
            public Int32 room_id = 0;
            public Int32 door_id = 0;
            public Int32 uFlag00 = 0;

        }


        public class x41000002
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
            public Int32 uFlag01 = 0;
            public Int32 uFlag02 = 0;

        }

        /// <summary>
        /// Timing based event triggers?
        /// </summary>
        public class x45000003
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
            public Int32 Event_ID = 0;
            public Int32 UFlag01 = 0;
            public Int32 Duration = 0;
            public Int32 Ulong00 = 0;
            public Int32 Ulong01 = 0;
            public Int32 Ulong02 = 0;
        }


        /// <summary>
        /// unknown needs etst ***
        /// </summary>
        public class x4C000001
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
        }

        

        /// <summary>
        /// SETS DOOR LOCKS TO KEY ITEM
        /// </summary>
        public class x50000002 
        {
            public Int32 opcode;
            public Int32 uflag00 = 0;
            
        
        }

        public class x50010002
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;
        }

        public class x5F000002
        {
            Int32 opcode = 0;
            Int32 door_id = 0;
            Int32 _Msg_ID = 0;
            Int32 uFlag = 0;
        }
        public class x56010003
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;
            public Int32 uflag03 = 0;
            public Int32 uflag04 = 0;
            public Int32 uflag05 = 0;
            public Int32 uflag06 = 0;


        }


        /// <summary>
        /// not sure atm needs testing
        /// </summary>
        public class x5A000002
        {
            public Int32 opcode = 0;
            public Int32 room_ID = 0; // looks like it, *needs testing*
            public Int32 uFlag00 = 0;
            public Int32 uFlag01 = 0;

        }

        /// <summary>
        /// Play .SFD Cutscene
        /// </summary>
        public class x62000003
        {
            public Int32 opcode = 0;
            public Int32 Flag = 0; // enable/disable
            public Int32 SFD_ID = 0; // SFD to play 
            public Int32 part = 0; // 
            public Int32 Ulong00 = 0;
            public Int32 Ulong01 = 0;

        }





        /// <summary>
        /// Unknown instruction
        /// </summary>
        public class x65000001
        {
            Int32 opcode = 0;
            Int32 uFlag00 = 0;
        }

        public class x65010001
        {
            Int32 opcode = 0;
            Int32 uflag00 = 0;
        }


        /// <summary>
        /// Player Spawn Point
        /// </summary>
        public class x69000002
        {
            public Int32 opcode = 0;
            public Int32 Player_Idx = 0;
            public Int32 Room_ID = 0;
            public Int32 Spawn_Pt = 0;
        }




        public class x6A010002
        {
            Int32 opcode = 0;
            Int32 uFlag00 = 0;
            Int32 uFlag01 = 0;
            Int32 uFlag02 = 0;

        }

        /// <summary>
        /// Unknown 32 byte instruction set
        /// </summary>
        public class x6C000003
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;
            public Int32 uflag03 = 0;
            public Int32 uflag04 = 0;
            public Int32 uflag05 = 0;
            public Int32 uflag06 = 0;
        }


        /// <summary>
        /// Cindy Herb Set
        /// </summary>
        public class x73010002 // cindy herb set
        {
            public Int32 opcode = 0;
            public Int32 herb_id = 0;
            public Int32 quantity = 0;
        }

        /// <summary>
        /// * NEEDS TESTING *
        /// </summary>
        public class x74010002
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;
        }


        /// <summary>
        /// no idea
        /// </summary>
        public class x80000001
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;

        }

        /// <summary>
        /// * NEEDS TESTING*
        /// </summary>
        public class x80010001
        {
            public Int32 opcode = 0;
            public Int32 uFlag = 0;

        }


        /// <summary>
        /// *NEEDS TEST*
        /// </summary>
        public class x85000002
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
            public Int32 uFlag01 = 0;
            public Int32 uFlag02 = 0;
        }


        /// <summary>
        /// No idea needs testing
        /// </summary>
        public class x8B000002
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;
        }


        /// <summary>
        /// * NEEDS TEST *
        /// </summary>
        public class xA00100002
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;
        }


        /// <summary>
        /// * NEEDS TESTING*
        /// </summary>

        public class xA2010002
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
            public Int32 uFlag01 = 0;
            public Int32 uFlag02 = 0;

        }


        /// <summary>
        /// * NOT KNOWN NEEDS TEST*
        /// </summary>
        public class xE3000002
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0;

        }

        /// <summary>
        /// Instruction NOP?
        /// </summary>
        public class xE5000000 // Seems to be a terminator operation
        {
            public Int32 opcode = 0;
        }



        /// <summary>
        /// no fucking clue yet
        /// </summary>
        public class xE6000002
        {
            public Int32 opcode = 0;
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
            public Int32 uflag02 = 0; // padding
        }


        /// <summary>
        /// creamy thinks this is an if condition?
        /// </summary>
        public class xEC000002
        {
            public Int32 opcode = 0;
            public Int32 event_ID = 0; //?
            public Int32 uflag00 = 0;
            public Int32 uflag01 = 0;
        }


        /// <summary>
        /// Evt_Kill ?
        /// </summary>
        public class xED000002
        {
            public Int32 opcode = 0;
            public Int32 event_id = 0;
            public Int32 flag = 0;
            public Int32 Ulong00;
        }


       /// <summary>
       /// an event based trigger, type 02 seems to set up camera related triggers, 01 seems to work off kills in showdowns
       /// more info to be added later
       /// </summary>
        public class xD0000003
        {
            public Int32 opcode = 0;
            public Int32 Type = 0;
            public Int32 Tr_ID = 0;
            public Int32 Duration = 0;
        }

        public class xEE000002
        {
            public Int32 opcode = 0;
            public Int32 uFlag00 = 0;
            public Int32 UFlag01 = 0;
            public Int32 UFlag02 = 0;

        }

        /// <summary>
        /// this seems like some sort of terminator or conditional operation
        /// </summary>
        public class xEF000000
        {
            public Int32 opcode;
        }


        /// <summary>
        /// Door Resistance
        /// </summary>
        public class xF2000002 // set door resistance
        {
            Int32 opcode = 0;
            Int32 Room_ID = 0;
            Int32 Door_ID = 0;
            Int32 Door_Res = 0;

        }


        /// <summary>
        /// Door Properties
        /// </summary>
        public class xF4000002 // make doors indestructible (16 byte instruction)
        {
            Int32 opcode = 0;
            Int32 Room_ID = 0;
            Int32 Door_ID = 0; // indexed in order?
            Int32 Ulong00 = 0;
        }





        /// <summary>
        /// parse EVB from memstream
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="Debug_Log"></param>
        /// <param name="ByteLST"></param>
        /// <param name="CodeLST"></param>
        public void PARSE_EVB_STREAM(Stream fs, int start_off, int evb_length, RichTextBox Debug_Log, ListView AFS_LIST, ListView ByteLST, ListView CodeLST, ToolStripProgressBar ProgBar, FRM_EVB EVB_FORM)
        {

            EVB_SELECTED_OBJ Selected_EVB = new EVB_SELECTED_OBJ();

            Selected_EVB.File_Name = AFS_LIST.FocusedItem.SubItems[3].Text;
            Selected_EVB.File_Offset = int.Parse(AFS_LIST.FocusedItem.SubItems[1].Text) + start_off;
            Selected_EVB.File_Size = int.Parse(AFS_LIST.FocusedItem.SubItems[2].Text);

           
            BinaryReader br = new BinaryReader(fs);


            EVB_FORM.EVB_DEBUG.Clear();
            

            byte[] bytearray = new byte[0];
            Int32 op_buffer;
            string[] cmd_names;
            string bytestr;
            int cmd_len = 0;
            int fs_pos = int.Parse(fs.Position.ToString());

            int skipval = 0;



            //  cmd_names = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "SomeLibrary of indexed cmds");

            fs.Seek(Selected_EVB.File_Offset, SeekOrigin.Begin);

            EVB_HEADER.offset00 = br.ReadInt32();


            EVB_HEADER.offset01 = br.ReadInt32();
            EVB_HEADER.offset02 = br.ReadInt32();


            Debug_Log.AppendText("offset to most instructions : " + EVB_HEADER.offset00.ToString() + "\n");
            Debug_Log.AppendText("Ulong00: " + EVB_HEADER.offset01.ToString() + "\n");
            Debug_Log.AppendText("Ulong01 " + EVB_HEADER.offset02.ToString() + "\n");


          //  fs.Seek(EVB_HEADER.offset00, SeekOrigin.Begin);
            fs.Seek(Selected_EVB.File_Offset + EVB_HEADER.offset00 + 12, SeekOrigin.Begin);


            ProgBar.Maximum = evb_length;
            // loop through the entire stream length simply is a disaster from a volume relative layer.. get true evb size and go that route..
            for (int i = 0; i < evb_length; i++)
            {
                if (i >= evb_length) { break; }

                CodeLST.Items.Add(i.ToString());
                ByteLST.Items.Add(i.ToString());
                CodeLST.Items[i].UseItemStyleForSubItems = false; // what the fuck is this?

                ProgBar.Value = i;


                if (i < evb_length - 256 && fs.Position < fs.Length) // why 256 again?
                {
                    op_buffer = ReverseBytes(br.ReadInt32());

                    
                    // MessageBox.Show(op_buffer.ToString("X"));
                    byte lower = (byte)(op_buffer & 0xFF);

                 

                    switch (lower) {
                        case 0:
                            skipval = 4;                        
                            break;
                        case 1:
                            skipval = 8;
                            break;
                        case 2:
                            skipval = 16;
                            break;
                        case 3:
                            skipval = 32;
                            break;
                    
                    }

                    if (skipval <= 32)
                    {

                        fs.Seek(-4, SeekOrigin.Current);
                  


                        cmd_len = skipval;
                    }

                    //cmd_len = GET_OPCODE_LEN(op_buffer, EVB_FORM);


                }


              //  if (cmd_len == 0) { cmd_len = 1; }

                Array.Resize(ref bytearray, cmd_len);
                bytearray = br.ReadBytes(bytearray.Length);

                fs.Seek(-cmd_len, SeekOrigin.Current);

                fs.Seek(+skipval, SeekOrigin.Current);

                bytestr = "";

                for (int j = 0; j < bytearray.Length; j++)
                {
                    bytestr += bytearray[j].ToString("X").PadLeft(2, '0'); // pad left to read the full byte at a time..                                                                          //  MessageBox.Show(bytestr.ToString());
                }

                ByteLST.Items[i].SubItems.Add(bytestr);
                CodeLST.Items[i].SubItems.Add(SET_CMD(i, ByteLST, CodeLST, cmd_len));

                // filter out null stuff?
                if (cmd_len > 1)
                {
                    ByteLST.Items[i].SubItems.Add(cmd_len.ToString() + " byte opcode");
                }

                // COLOR THE CODE!!
                COLOR_BYTECODE(cmd_len, i, ByteLST);
              //  COLOR_BYTECODE(cmd_len, i, CodeLST);


                //   MessageBox.Show("OPCODE: " + op_buffer.ToString("X") + "LENGTH:" + cmd_len.ToString());

            }


            fs.Close();
            br.Close();

        }


        public void PARSE_RDT_SGL_STREAM(Stream fs, int rdt_off, int rdt_sgl_len, int afs_rdt_off, ListView RDT_LIST, ListView ByteLST, ListView CodeLST, FRM_EVB EVB_FORM) {

            byte[] bytearray = new byte[0];
            Int32 op_buffer;
            string[] cmd_names;
            string bytestr;
            int cmd_len = 0;
            int scriptlen = 0; // script length - header


            int skipval = 0;

            int SGL_OFF = afs_rdt_off + rdt_off;

            fs.Seek(SGL_OFF, SeekOrigin.Begin);

           
            using (BinaryReader br = new BinaryReader(fs)) {


                int ScriptSz = br.ReadInt32();
                int endBlock = br.ReadInt32();

                

               // MessageBox.Show(rdt_sgl_len.ToString());



                int script_off = rdt_sgl_len - ScriptSz;
                int endblk_off = rdt_sgl_len - endBlock;

                int script_len = script_off + endblk_off + 4;

              




                //MessageBox.Show(SGL_OFF + ptr_off.ToString());




                fs.Seek(SGL_OFF + script_off, SeekOrigin.Begin);

                int subptr = br.ReadInt32();
                subptr *= 2;

               // MessageBox.Show(subptr.ToString());



                 fs.Seek(-4, SeekOrigin.Current);
                fs.Seek(subptr, SeekOrigin.Current);




               // ProgBar.Maximum = evb_length;
                // loop through the entire stream length simply is a disaster from a volume relative layer.. get true evb size and go that route..
                for (int i = 0; i < ScriptSz - script_len; i++)
                {
                    if (i >= ScriptSz) { break; }

                    CodeLST.Items.Add(i.ToString());
                    ByteLST.Items.Add(i.ToString());
                    CodeLST.Items[i].UseItemStyleForSubItems = false; // what the fuck is this?

                 //   ProgBar.Value = i;


                         
                        op_buffer = ReverseBytes(br.ReadInt32());

                 
 

                        // MessageBox.Show(op_buffer.ToString("X"));
                        byte lower = (byte)(op_buffer & 0xFF);



                        switch (lower)
                        {
                            case 0:
                                skipval = 4;
                                break;
                            case 1:
                                skipval = 8;
                                break;
                            case 2:
                                skipval = 16;
                                break;
                            case 3:
                                skipval = 32;
                                break;

                        }

                        if (skipval <= 32)
                        {

                            fs.Seek(-4, SeekOrigin.Current);



                            cmd_len = skipval;
                        }

                        //cmd_len = GET_OPCODE_LEN(op_buffer, EVB_FORM);


                    


                    //  if (cmd_len == 0) { cmd_len = 1; }

                    Array.Resize(ref bytearray, cmd_len);
                    bytearray = br.ReadBytes(bytearray.Length);


                    
                    if (bytearray[0] == 0xFF && bytearray[1] == 0xFF) {
                        break;
                    }
                    //if (bytearray.GetLowerBound(0) == 0xFF && bytearray.GetUpperBound(0) == 0xFF) { 

                    //}



                    fs.Seek(-cmd_len, SeekOrigin.Current);

                    fs.Seek(+skipval, SeekOrigin.Current);

                    bytestr = "";

                    for (int j = 0; j < bytearray.Length; j++)
                    {
                        bytestr += bytearray[j].ToString("X").PadLeft(2, '0'); // pad left to read the full byte at a time..                                                                          //  MessageBox.Show(bytestr.ToString());
                    }

                    ByteLST.Items[i].SubItems.Add(bytestr);
                    CodeLST.Items[i].SubItems.Add(SET_CMD(i, ByteLST, CodeLST, cmd_len));

                    // filter out null stuff?
                    if (cmd_len > 1)
                    {
                        ByteLST.Items[i].SubItems.Add(cmd_len.ToString() + " byte opcode");
                    }

                    // COLOR THE CODE!!
                    COLOR_BYTECODE(cmd_len, i, ByteLST);
                    COLOR_BYTECODE(cmd_len, i, CodeLST);


                    //   MessageBox.Show("OPCODE: " + op_buffer.ToString("X") + "LENGTH:" + cmd_len.ToString());

                }


                fs.Close();
                br.Close();















            }






        }


        public void PARSE_EVB_FILE(string fp, RichTextBox Debug_Log, ListView ByteLST, ListView CodeLST, FRM_EVB EVB_FORM) // Parsing Event Based Data
        {


            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            byte[] bytearray = new byte[0];
            Int32 op_buffer;
            string[] cmd_names;
            string bytestr;
            int cmd_len = 0;



            //  cmd_names = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "SomeLibrary of indexed cmds");

            fs.Seek(0, SeekOrigin.Begin);

            EVB_HEADER.offset00 = br.ReadInt32();
            EVB_HEADER.offset01 = br.ReadInt32();
            EVB_HEADER.offset02 = br.ReadInt32();


            Debug_Log.AppendText("offset to most instructions : " + EVB_HEADER.offset00.ToString() + "\n");
            Debug_Log.AppendText("Ulong00: " + EVB_HEADER.offset01.ToString() + "\n");
            Debug_Log.AppendText("Ulong01 " + EVB_HEADER.offset02.ToString() + "\n");


            fs.Seek(EVB_HEADER.offset00, SeekOrigin.Begin);

            for (int i = 0; i < fs.Length; i++)
            {
                if (fs.Position >= fs.Length) { break; }

                CodeLST.Items.Add(fs.Position.ToString());
                ByteLST.Items.Add(fs.Position.ToString());
                CodeLST.Items[i].UseItemStyleForSubItems = false; // what the fuck is this?
                


                //if (fs.Position < fs.Length - 256)
                //{
                //    op_buffer = br.ReadInt32();
                
                //    fs.Seek(-4, SeekOrigin.Current);

                //    cmd_len = GET_OPCODE_LEN(op_buffer, EVB_FORM);

                  

                //}


              //  if (cmd_len == 0) { cmd_len = 1; }

                Array.Resize(ref bytearray, cmd_len);
                bytearray = br.ReadBytes(bytearray.Length);

                bytestr = "";

                for (int j = 0; j < bytearray.Length; j++)
                {
                    bytestr += bytearray[j].ToString("X").PadLeft(2, '0'); // pad left to read the full byte at a time..                                                                          //  MessageBox.Show(bytestr.ToString());
                }

                ByteLST.Items[i].SubItems.Add(bytestr);
                CodeLST.Items[i].SubItems.Add(SET_CMD(i, ByteLST, CodeLST ,cmd_len));

                if (cmd_len > 1) {
                    ByteLST.Items[i].SubItems.Add(cmd_len.ToString() + " byte opcode");
                }

                COLOR_BYTECODE(cmd_len, i, ByteLST);


                //   MessageBox.Show("OPCODE: " + op_buffer.ToString("X") + "LENGTH:" + cmd_len.ToString());

            }


            fs.Close();
            br.Close();




        }


   


        private void COLOR_BYTECODE(int length, int index, ListView LST)
        {
            Color x4byte = Color.MediumVioletRed;
            Color x8byte = Color.MintCream;
            Color x16byte = Color.LimeGreen;
            Color x32byte = Color.LightSteelBlue;



            switch (length)
            {
                case 4: LST.Items[index].ForeColor = x4byte; break;
                case 8: LST.Items[index].ForeColor = x8byte; break;
                case 16: LST.Items[index].ForeColor = x16byte; break;
                case 32: LST.Items[index].ForeColor = x32byte; break;
            }

        } // only colored based on cmd length atm..


        private void COLOR_OPCODE(int length, int index, ListView LST)
        {
           
            //  NEED TO 
            Color x4byte = Color.MediumVioletRed;
            Color x8byte = Color.MintCream;
            Color x16byte = Color.LimeGreen;
            Color x32byte = Color.LightSteelBlue;

            switch (length)
            {
                case 4: LST.Items[index].ForeColor = x4byte; break;
                case 8: LST.Items[index].ForeColor = x8byte; break;
                case 16: LST.Items[index].ForeColor = x16byte; break;
                case 32: LST.Items[index].ForeColor = x32byte; break;
            }

        } // only colored based on cmd length atm..




        private string SET_CMD(int idx, ListView LSTB, ListView LSTC, int cmd_len)
        {
            string attr = string.Empty; // return this
            string opcode = string.Empty; // to hold the main opcode
            string bytestr = string.Empty; // to hold the interpreted byte string
            string duration_fmt = string.Empty; // to set min/sec format clearly
            string char_str = string.Empty; // to wrap player names over IDs;
            string dfclt_str = string.Empty;// wrap difficulty over ids;


            if (cmd_len >= 4)
            {
                opcode = LSTB.Items[idx].SubItems[1].Text.Substring(0, 8);
                bytestr = LSTB.Items[idx].SubItems[1].Text;
            }



            if (opcode == "0C000002") 
            {
                attr = "EVT_CLOSE();";
            }

            if (opcode == "13000002") 
            {
                attr = "CAM_SET();";
            }


            if (opcode == "20000001") 
            {
                attr = "LIG_SET();";               
            }

            if (opcode == "31000001")
            {
                attr = "ITEM_INIT " + "( TBL ID: " + HEX2INT(bytestr, 8, 2) + ")"; // maybe include padding?             
            }

            if (opcode == "31010003") {
                attr = "FILE_SET();";
            }

            if (opcode == "35010003") {
                attr = "SP_ITEM_SET();";
            }

            if (opcode == "38000002")
            {
                
                
                attr = "PL_ITEM_SET" + "( Player ID: " + ReverseBytes(HEX2INT(bytestr, 8, 8)) + ", Item ID: " + Itemz.GET_ITEM_NAME(ReverseShort(HEX2SHORT(bytestr, 16, 4))) + ", Quantity: " + ReverseBytes(HEX2INT(bytestr, 24, 8)) + " )";
            }


            if (opcode == "3A000003") {
                attr = "NPC_ITEM_SET();";
            }

            if (opcode == "3D000002") {
                attr = "NPC_EQUIP_SET();";
            }

            if (opcode == "39000002")
            {
                attr = "CH_ITEM_SET" + "( Char ID: " + Set_Char(ReverseBytes(HEX2INT(bytestr, 8, 8))) + ", Item ID: " + Itemz.GET_ITEM_NAME(ReverseShort(HEX2SHORT(bytestr, 16, 4))) + ", Quantity: " + ReverseBytes(HEX2INT(bytestr, 24, 8)) + " )"; 
            }

            if (opcode == "40000002")
            {
                attr = "DOOR_LOCK " + "( Room ID: " + HEX2INT(bytestr, 8, 2) + ", Door Id: " + HEX2INT(bytestr, 16, 2) + " )"; // maybe include padding?
                // MessageBox.Show(HEX2INT(bytestr, 8).ToString());
            }
            if (opcode == "45000003")
            {
                if (ReverseBytes(HEX2INT(bytestr, 32, 8)) < 1800)
                {
                    duration_fmt = "Seconds";
                }
                else if (ReverseBytes(HEX2INT(bytestr, 32, 8)) >= 1800)
                {
                    duration_fmt = "Minutes";
                }

                attr = "EVT_TIME " + "( uFlag00: " + HEX2INT(bytestr, 8, 2) + ", Event ID: " + HEX2INT(bytestr, 16, 2) + ", uFlag01: " + HEX2INT(bytestr, 24, 2) + ", Duration: " + GET_DURATION(ReverseBytes(HEX2INT(bytestr, 32, 8))) + " " + duration_fmt + " )";
          
            }

             // MAKE DOOR KEY/LOCK FORM FOR THIS
            if (opcode == "50000002") {

                attr = "DOOR_KEY" + "( Item ID: " + ReverseShort(HEX2SHORT(bytestr, 16, 4)) +  ", " + Itemz.GET_ITEM_NAME(ReverseShort(HEX2SHORT(bytestr, 16, 4))) + ")"; 
            }


            // SET ROOM VARIANT
            if (opcode == "5A000002")
            {
                attr = "SET_ROOM();";
            }

            if (opcode == "60000000") {
                attr = "SCENARIO_END();";
            }

            if (opcode == "68000002")
            {
                attr = "PL_TYPE_SPAWN_SET" + "( Player #: " + HEX2INT(bytestr, 8, 2) + ", Room Id: " + HEX2INT(bytestr, 16, 2) + ", Spawn ID: " + HEX2INT(bytestr, 24, 2) + " )";
            }

            if (opcode == "69000002")
            {
                attr = "PL_SPAWN_SET" + "( Player #: " + HEX2INT(bytestr, 8, 2) + ", Room Id: " + HEX2INT(bytestr, 16, 2) + ", Spawn ID: " + HEX2INT(bytestr, 24, 2) + " )";
            }


            if (opcode == "70000001") {
                attr = "BGM_SET();";
            }

            if (opcode == "7100000")
            {
                attr = "BGM_END();";
            }


            if (opcode == "75000001")
            {
                attr = "SND_SET();";
            }


            if (opcode == "85000002: ") {

                attr = "NPC_SPAWN();";
            }


            if (opcode == "A2000000") 
            {
                attr = "GEO_SET();";
            }

            if (opcode == "B0000001")
            {
                attr = "ENVIROMENT_ASSET();";
            }

            if (opcode == "EE000002")
            {
                attr = "IF_DFC" + "( Difficulty : " + SET_DFC(ReverseBytes(HEX2INT(bytestr, 8, 8))) + ", Range: " + HEX2INT(bytestr, 16, 2) + " )" + " {";
            }

            if (opcode == "E4000000")
            {
                attr = "ELSE { ";
            }

            if (opcode == "E5000000")
            {
                attr = "EOF(); }";
            }
            // return the string to be added as a listiew item
          


            if (opcode == "F2000002")
            {
                attr = "DOOR_ATTR" + "( Room ID: " + HEX2INT(bytestr, 8, 2) + ", Door Id: " + HEX2INT(bytestr, 16, 2) + ", Resistance: " + HEX2INT(bytestr, 24, 2) + " )";
            }
            if (opcode == "F4000002")
            {
                attr = "DOOR_UNBREAKABLE" + "( Room ID: " + HEX2INT(bytestr, 8, 2) + ", Door Id: " + HEX2INT(bytestr, 16, 2) + " )";
            }

            if (opcode == "F5000002")
            {
                attr = "DOOR_BREAKABLE" + "( Room ID: " + HEX2INT(bytestr, 8, 2) + ", Door Id: " + HEX2INT(bytestr, 16, 2) + " )";
            }

            if (opcode == "F7000001") {
                attr = "LOCKER_SET();";
            }


            if (opcode == "60010003") 
            {
                attr = "EMD_DEATH_XYZ();";
            
            }

            if (opcode == "64010001")
            {
                attr = "SET_EMD_EVT()";
            }

            if (opcode == "65010001")
            {
                attr = "REMOVE_EMD_EVT()";
            }


            if (opcode == "62000003")
            {
                attr = "SFD_PLAY" + " ( Enable: " + HEX2INT(bytestr, 8, 2) + ", .SFD ID: " + HEX2INT(bytestr, 16, 2) + ", uFlag00:  " + HEX2INT(bytestr, 24, 2) + ", UFlag01: " + HEX2INT(bytestr, 32, 2) + ", UFlag02: " + HEX2INT(bytestr, 40, 4) + ", uFlag03: " + HEX2INT(bytestr, 48, 2) + " )";

            }

            if (opcode == "73010002")
            {

                if (HEX2INT(bytestr, 8, 2) == 44)
                {
                    attr = "HERBCASE_SET" + " ( Green Herb: " + HEX2INT(bytestr, 8, 2) + ", Quantity: " + HEX2INT(bytestr, 16, 2) + " )";
                }
                if (HEX2INT(bytestr, 8, 2) == 45)
                {
                    attr = "HERBCASE_SET" + " ( Blue Herb: " + HEX2INT(bytestr, 8, 2) + ", Quantity: " + HEX2INT(bytestr, 16, 2) + " )";
                }
                if (HEX2INT(bytestr, 8, 2) == 46)
                {
                    attr = "HERBCASE_SET" + " ( Red Herb: " + HEX2INT(bytestr, 8, 2) + ", Quantity: " + HEX2INT(bytestr, 16, 2) + " )";
                }

            }


            return attr;

        }


        public static string SET_COMMENT(ListView LSTC, ListView LSTB, RichTextBox Details)
        {
            string comment = string.Empty;
            string opcode = string.Empty;
            string bytestr = string.Empty;

            int idx = LSTC.FocusedItem.Index;

           
                opcode = LSTB.Items[idx].SubItems[1].Text.Substring(0, 8);
                bytestr = LSTB.Items[idx].SubItems[1].Text;


            try
            {
                // OPEN OPCODE DESC FILE + READ DESC
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\EVB_H\\" + opcode + ".txt"))
                {
                    Details.ForeColor = Color.White;
                    comment = sr.ReadLine();
                }

            }
            catch (FileNotFoundException FNF) 
            {
                Details.ForeColor = Color.Red;
                comment = "No Description Found for selected opcode";
            }

            


            return comment;


        } // needs fixing, maybe use a rtbox instead

        //dtype guide
        // 2 - bytes
        // 4 - 2 bytes
        // 8 = 4 bytes  
        private int HEX2INT(string srcval, int cmdlen, int dtype) // converts an input string to an int32..
        {
            int outval = 0;
            outval = Convert.ToInt32(srcval.Substring(cmdlen, dtype), 16);
            return outval;
        }


        private short HEX2SHORT(string srcval, int cmdlen, int dtype)
        {
            short outval = 0;
            outval = Convert.ToInt16(srcval.Substring(cmdlen, dtype), 16);
            return outval;
        }
        static int ReverseBytes(int val)  // good reverse example
        {
            byte[] intAsBytes = BitConverter.GetBytes(val);
            Array.Reverse(intAsBytes);
            return BitConverter.ToInt32(intAsBytes, 0);
        }

        static short ReverseShort(short val)
        {
            byte[] intAsBytes = BitConverter.GetBytes(val);
            Array.Reverse(intAsBytes);
            return BitConverter.ToInt16(intAsBytes, 0);

        }

        private int GET_DURATION(int duration)
        {
            int div_val = duration / 30; // 30 frames

            if (duration < 1800)
            {
                return div_val;           
            }
            else
            {              
                return div_val / 60; // return val / 60 sec               
            }
            
        }



        private string Set_Char(int id)
        {

            if (id == 0) { return "Kevin"; }
            if (id == 1) { return "Mark"; }
            if (id == 2) { return "Jim"; }
            if (id == 3) { return "George"; }
            if (id == 4) { return "David"; }
            if (id == 5) { return "Alyssa"; }
            if (id == 6) { return "Yoko"; }
            if (id == 7) { return "Cindy"; }

            else
            return "Error";
                
             
            }


        private string SET_DFC(int id)
        {

            if (id == 0) { return "Easy"; }
            if (id == 1) { return "Normal"; }
            if (id == 2) { return "Hard"; }
            if (id == 3) { return "Very Hard"; }
            
            return "error";
        }


        public string ARC2_SCE(string archive_string)
        {
            string SCE_NAME = archive_string.Substring(0, 4);

            switch (SCE_NAME.ToLower())
            {
                case "r001": return "Outbreak"; break;
                case "r002": return "Hellfire"; break;
                case "r028": return "The Hive"; break;
                case "r035": return "Below Freezing Point"; break;
                case "r041": return "Decisions, Decisions"; break;
                case "r006": return "End of the Road"; break;
                case "r015": return "Desperate Times"; break;
                case "r010": return "Underbelly"; break;
                case "r026": return "Flashback"; break;
                case "r020": return "Training Ground"; break;


            }


            return string.Empty;

        }


    } // set char type

    }

