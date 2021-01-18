using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;



namespace Netbio_VFL_Plus
{
    /// <summary>
    /// extension for parsing NBD/AMO MAYBE>...
    /// </summary>
    public class NBD_IO
    {

        /// <summary>
        /// Entry of NBD COntainer
        /// each entry inside nbd..
        ///  TID 0x444954h (texture indices.)
        ///  AMO 0x4F4D41h (Animated model object?)
        ///  AHI 0x494841h (Animation Heirarchy>?)
        ///  SDW 0x574453h (SDW? THE FUCK) (SHADOW?)
        ///  TEX 0x584554h 

        /// </summary>
        /// 

        public Dictionary<uint, string> LUT_NBD_ENTRY = new Dictionary<uint, string>()
        {
            {0x444954, "TID"},
            {0x4F4D41, "AMO"},
            {0x494841, "AHI"},
            {0x574453, "SDW"},
            {0x584554, "TEX"},
            
        };




        public struct NBD_ENTRY_OBJ
        {
            public UInt32 ID;
            public UInt32 Offset;
            public UInt32 Length;
            public UInt32 numobj;
        }


        public struct TID_ENTRY_OBJ
        {
            public int sld_count; // # of slds per room..
            public int[] sld_indexes;

        }

        /// <summary>
        /// Structure of chunks in AMO/AHI
        /// </summary>
        public struct SChunkHeader
        {
            UInt32 chunkType;
            UInt32 chunk_Entries;
            UInt32 chunkSize;

        }

        /// <summary>
        /// Verts/Normals
        /// </summary>
        public struct Vert_Points
        {
            float x, y, z;
        }
        
        /// <summary>
        /// Tex Coordinates
        /// </summary>
        public struct TexCoordinate_Obj
        {
            float x, y;
        }
        
        struct s_triangle_obj
        {
            UInt32 a, b, c;
        }
        
        /// <summary>
        /// Structure for material(geuss) modifiers
        /// </summary>
        struct s_modif_obj
        {
            float a, b, c, d;
        }



        struct s_bone_obj
        {
            UInt32 bone_id;
            UInt32 bone_prev;
            UInt32 bone_next;
            UInt32 Bone_obj;
            float s_x, s_y, s_z; // scale
            float s_4; // ?
            
        }


        struct s_model_obj
        {
            UInt32 num_obj;
            UInt32 num_bones;
            

        }



        /// <summary>
        /// Each NBD Header is always 0x50 in length, 5 entries regardless of room or player..
        /// </summary>
        public NBD_ENTRY_OBJ[] NBD_ENTRIES = new NBD_ENTRY_OBJ[4];
        public TID_ENTRY_OBJ TID_ENTRY = new TID_ENTRY_OBJ();


        public void Parse_NBD_STREAM(Stream fs, int start_offset, ListView LV_AFS, ListView LV_NBD, RichTextBox Debug_Log)
        {
            try
            {
                //prevent dupes..
                Debug_Log.Clear();
                LV_NBD.Items.Clear();


                int NBD_OFF = int.Parse(LV_AFS.FocusedItem.SubItems[1].Text);
                int NBD_SZ = int.Parse(LV_AFS.FocusedItem.SubItems[2].Text);
                int relative_offset = NBD_OFF + start_offset;
                byte[] NBD_BUFFEr = new byte[NBD_SZ];


                LV_AFS.FocusedItem.Selected = false;




                Debug_Log.AppendText("Seeked Offset: " + relative_offset.ToString());


                fs.Seek(start_offset + NBD_OFF, SeekOrigin.Begin);

                BinaryReader br = new BinaryReader(fs);


                Debug_Log.AppendText("------ NBD HEADER ----------------");



                for (int i = 0; i < NBD_ENTRIES.Length; i++)
                {
                    NBD_ENTRIES[i].ID = br.ReadUInt32();
                    NBD_ENTRIES[i].Offset = br.ReadUInt32();
                    NBD_ENTRIES[i].Length = br.ReadUInt32();
                    NBD_ENTRIES[i].numobj = br.ReadUInt32();

                    LV_NBD.Items.Add(i.ToString());
                    LV_NBD.Items[i].SubItems.Add(LUT_NBD_ENTRY[NBD_ENTRIES[i].ID]);
                    LV_NBD.Items[i].SubItems.Add(NBD_ENTRIES[i].Offset.ToString());
                    LV_NBD.Items[i].SubItems.Add(NBD_ENTRIES[i].Length.ToString());
                    LV_NBD.Items[i].SubItems.Add(NBD_ENTRIES[i].numobj.ToString());

                   
                    
                    Debug_Log.AppendText("\n" + LUT_NBD_ENTRY[NBD_ENTRIES[i].ID] + " Offset: 0x" + NBD_ENTRIES[i].Offset.ToString("X") + " Length?: 0x" + NBD_ENTRIES[i].Length.ToString("X") + " numobj: " + NBD_ENTRIES[i].numobj.ToString("X"));
                    
                }

                //seek to TID offsets..
                fs.Seek(start_offset + NBD_OFF + 128, SeekOrigin.Begin);

                TID_ENTRY.sld_count = br.ReadInt32();

                Array.Resize(ref TID_ENTRY.sld_indexes, TID_ENTRY.sld_count);

                for (int x = 0; x < TID_ENTRY.sld_count; x++)
                {
                    TID_ENTRY.sld_indexes[x] = br.ReadInt32();

                    LV_AFS.Items[TID_ENTRY.sld_indexes[x]].Selected = true; // select corresponding room slds..(focus)

                    Debug_Log.AppendText("\n[" + x.ToString() + "]" + "SLD INDEX" + TID_ENTRY.sld_indexes[x].ToString());

                }

               

                Debug_Log.AppendText("\nTotal Sld Count: " + TID_ENTRY.sld_count.ToString());

                

               
                


                fs.Close();
                br.Close();

                //close file streams..



            }
            catch (Exception ex)
            {

                Debug_Log.AppendText("\nException: " + ex.Message);

            }
            
              








        }

    }
}
