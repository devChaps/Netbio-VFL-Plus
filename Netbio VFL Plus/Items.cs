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
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Media;


///////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Holds structure for item tables, item objects and any functions needed to handle these type of files .TBL //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////

namespace Netbio_VFL_Plus
{
    public class Items
    {

        public struct TBL_Header_Obj // tbl header
        {
            public Int32 tag;
            public Int32 Item_count;
        }

        public struct TBL_Item_Obj // tbl entries
        {
            public Int16 Item_val;
            public byte Quantity;
            public byte occurence;
        }


        public struct DAT_HEADER_OBJ // dat header
        {
            public Int32 offset;
            public Int32 size;

        }

        public struct ITEM_PROP_HEADER_OBJ // chunk 0 header
        {
            public Int32 tag;
            public Int32 entry_count;
            public Int32 cmb_sz;
            public Int32 unk_count;
            public Int32[] offsets;
        }



        public struct Item_Properties_Obj // item property data
        {
            public Int16 tag;
            public byte ubyte00;
            public byte ubyte01;
            public Int16 Ushort01;
            public Int16 Ushort02;
            public Int16 durabillity;
            public Int16 Ushort03;
            public Int16 Ushort04;
            public byte Sound_ID; // defines sound played on use
            public byte Type; // defines animation played on equip/use
            public Int16 Menu_type; // defines menu type displayed when selected
            public Int16 Item_ID; // The Item itself
            public Int16 Ushort05;
            public Int16 Ushort06;

        }

        public TBL_Header_Obj TBL_HEADER = new TBL_Header_Obj();
        public TBL_Item_Obj[] TBL_ITEM = new TBL_Item_Obj[0];
        public DAT_HEADER_OBJ[] DAT_HEADER = new DAT_HEADER_OBJ[0];
        public ITEM_PROP_HEADER_OBJ IPROP_HEADER = new ITEM_PROP_HEADER_OBJ();
        public Item_Properties_Obj[] Item_Data = new Item_Properties_Obj[0];
        public Item_Data Item_Properties = new Item_Data();
        //    public Item_memory IMEM = new Item_memory();




            /// <summary>
            /// File 1 Item Table
            /// </summary>
        public static Dictionary<string, int> ItemIcon_Table = new Dictionary<string, int>
        {
            {"Handgun", 0},
            {"Magnum Revolver", 4},
            {"Shotgun", 5},
            {"Burst Handgun", 6},
            {"Submachine gun", 7},
            {"Nail Gun", 8},
            {"Butcher Knife", 11},         
            {"Survival Knife", 10},
            {"Iron Pipe", 12},
            {"Curved Pipe", 13},
            {"Scrub Brush",  14},
            {"Crutch", 15},
            {"Spear", 16 },
            {"Wooden Pole", 17},
            {"Pesticide Spray", 18},
            {"Alcohol Bottle", 19},
            {"Lighter", 20},
            
          
            {"Handgun Rounds 9mm" , 23},
              {".45 auto rounds", 24},
            {"Shotgun Rounds", 25},
             {"Blue Herb", 28},
              {"Red Herb", 29},
               {"Green Herb", 30},
                {"First Aid Spray", 31},
            {"Anti Virus Pill", 32}


        };


        /// <summary>
        /// File 2 Item ID's/Item Names the way the game assigns them..
        /// </summary>
        public static Dictionary<Int16, string> m_ItemLookup = new Dictionary<Int16, string>
             {   {-1, "Null" },
                { 00, "Handgun"},
                { 01, "Handgun SG"},
                { 02, "Handgun GL" },
                { 03, "Magnum Handgun"},
                { 04, "Magnum Revolver"},
                { 05, "Handgun HP"},
                { 06, "Model 600"},
                { 07, "Revolver"},
                { 08, "Burst Handgun"},
                { 10, "Submachine gun"},
                { 11, "Shotgun"},
                { 12, "Shotgun E"},
                { 13, "Special Hunting Gun"},
                { 14, "Assault Rifle"},
                { 15, "Pill Shooter(Blue)"},
                { 16, "Pill Shooter(Red)"},
                { 17, "Pill Shooter(Green)"},
                { 18, "Pill Shooter(White)"},
                { 19, "Mine Detector"},
                { 20, "Rocket Launcher"},
                { 23, "Grenade Launcher (Burst)"},
                { 24, "Grenade Launcher (Flame)"},
                { 25, "Grenade Launcher (Acid)"},
                { 26, "Grenade Launcher (??)"},
                { 27, "Grenade Launcher (BOW GAS)"},
                { 28, "Pesticide Spray"},
                { 29, "Flame Spray"},
                { 30, "Stun Gun"},
                { 31, "Nail Gun"}, // ampoule in f2, nail gun in f1? you need 2 lists...
                { 32, "Ampoule Shooter" },
                { 100, "Survival Knife"},
                { 101, "Folding Knife"},
                { 102, "Butcher Knife"},
                { 103, "Iron Pipe"},
                { 104, "Curved Iron Pipe"},
                { 105, "Bent Iron Pipe"},
                { 106, "Long Pole"},
                { 107, "Square Timber"},
                { 108, "Bomb switch"},
                { 109, "Axe"},
                { 110, "Scrub Brush"},
                { 111, "Wooden Pole"},
                { 112, "Throwable Stick"},
                { 113, "Spear"},
                { 114, "Molotov Cocktail"},
                { 115, "Hammer"},
                { 116, "Crutch"},
                { 117, "Stun Rod"},
                { 118, "Concrete Piece"},
                { 119, "Broken Crutch"},
                { 155, "Empty Bottle"},
                { 157, "Chemical Solvent (green)"},
                { 158, "Yellow Chemical Bottle"},
                { 159, "Gray Chemical Bottle"},
                { 160, "Active Time bomb"},
                { 161, "Inactive Time bomb"},
                { 200, "Handgun Magazine"},
                { 201, "Handgun SG Magazine"},
                { 202, "Handgun GL Magazine"},
                { 203, "Magnum Clip"},
                { 204, "Revolver Speed Loader"},
                { 205, "Submachine Gun Clip"},  
                { 206, "Sub Machine Gun Clip"},
                { 207, "Assault Rifle Clip"},
                { 209, "Burst HG Magazine"},
                { 210, ".45 Auto Magazine"},
                { 211, "Handgun HP Magazine"},
                { 250, "Handgun Rounds 9mm"},
                { 251, "Magnum HG Rounds"},
                { 252, "Magnum Revolver Rounds"},
                { 253, "Revolver Rounds"},
                { 254, "Shotgun Rounds"},
                { 255, "Rifle Rounds"},
                { 256, "Rocket Rounds"},
                { 257, "Burst Rounds"},
                { 258, "Flame Rounds"},
                { 259, "Acid Rounds"},
                { 262, ".45 auto rounds" },
                { 263, "High Power Revolver Rounds"},
                { 300, "Green Herb" },
                { 301, "Blue Herb" },
                { 302, "Red Herb" },
                { 303, "Green + Green Mixed Herb" },
                { 304, "Green + Green + Green Mixed Herb" },
                { 305, "Green + Red Mixed Herb" },
                { 306, "Green + Blue Mixed Herb" },
                { 307, "Green + Green + Blue Mixed Herb" },
                { 308, "Green + Red + Blue Mixed Herb" },
                { 309, "First Aid Spray" },
                { 310, "Recovery Medicine"},
                { 311, "Hemostat"},
                { 312, "Day Light" },
                { 313, "Blue + Red Mixed Herb"},
                { 314, "Antidote"},
                { 315, "Large Recovery Medicine"},
                { 316, "Anti Virus Pill"},
                { 317, "Large Anti Virus"},
                { 318, "Recovery Medicine Base"},
                { 400, "Kevin's 45 auto"},
                { 401, "Mark's Handgun" },
                { 403, "Jim's Coin"},
                { 405, "Medical Set"},
                { 406, "Tool box" },
                { 408, "Monkey Wrench" },
                { 407, "Folding Knife" },
                { 409, "Vinyl Tape" },
                { 410, "Junk Parts"},
                { 411, "Picking Tool" },
                { 412, "Knapsack" },
                { 413, "Herb Case" },
                { 414, "I-Shaped Pick" },
                { 415, "S-Shaped Pick" },
                { 416, "W-Shaped Pick" },
                { 417, "P-Shaped Pick" },
                { 418, "Bandage" },
                { 419, "Lucky Coin" },
                { 420, "Charm" },
                { 450, "Lighter"},
                { 451, "Alcohol Bottle"},
                { 452, "Bottle + news Paper"},
                { 453, "Broken Handgun"},
                { 454, "Broken Shotgun"},
                { 455, "Battery"},
                { 456, "Broken Handgun SG"},
                { 10100, "Staff Room Key" },
                { 10101, "Key with Red Tag" },
                { 10102, "Key with Blue Tag" },
                { 10103, "Forklift Key" },
                { 10105, "Storage Key" },
                { 10106, "Detonator Handle" },
                { 10107, "Main Detonator" },
                { 10108, "Detonator Switch" },





                { 10600, "Examination Room Key"},
                { 10601, "ID Card Lv1"},
                { 10602, "ID Card Lv2"},
                { 10603, "MO DISK"},
                { 10604, "MO DISK (Code A)"},
                { 10605, "MO DISK (Code B)"},
                { 10609, "Valve Handle (6 Sided)"},
                { 10610, "Valve Handle (4 Sided)"},
                { 10611, "Crowbar"},
                { 10612, "Model Grenade Launcher"},
                { 10650, "Newspaper 1"},
                { 10651, "Newspaper 2"},
                { 10652, "Newspaper 3"},
                { 11000, "Employee Area Key"},
                { 11001, "B2F Key"},
                { 11002, "Ventilation Tower Key"},
                { 11003, "Valve Handle"},
                { 11004, "Repair Tape"},
                { 11005, "Rubber Sheet"},
                { 11006, "Founder's Emblem(Werner/Gold)"},
                { 11007, "Founder's Emblem(Oral/Blue"},
                { 11008, "Model Train Wheel"},
                { 11009, "Used Bloodpack"},
                { 11010, "Blood Pack"},
                { 11050, "Newspaper 1"},
                { 11051, "Newspaper 2"},
                { 11052, "Newspaper 3"},
                { 11500, "Joker Key"},
                { 11501, "Onyx Plate"},
                { 11502, "Sapphire Plate"},
                { 11503, "Ruby Plate"},
                { 11504, "Emerald Plate"},
                { 11505, "Amethyst Plate"},
                { 11506, "Padlock Key"},
                { 11507, "Ace Key"},
                { 11508, "Gas Canister"},
                { 11509, "Plywood Board"},
                { 11510, "Film A"},
                { 11511, "Used Gas Canister"},
                { 11512, "Unicorn Medal"},
                { 11513, "Film B"},
                { 11514, "Film C"},
                { 11515, "Film D"},
                { 11550, "Secret File"},
                { 12600, "Auxiliary Building Key" },
                { 12601, "Adminstrator's Office Key"},
                { 12602, "Rusty Key"},
                { 12603, "Syringe (empty)"},
                { 12604, "Syringe (Solvent)"},
                { 12605, "Pendant"},
                { 14000, "Bolt Cutters"},
                { 14001, "Elephant Key"},
                { 14002, "Alligator Key"},
                { 14003, "Lion key"},
                { 14004, "Office Key"},
                { 14005, "Mr Racoon Medal"},
                { 14006, "Lion Emblem (Red)"},
                { 14007, "Lion Emblem (Blue)"},
                { 14008, "Blank Tape"},
                { 14009, "Parade BGM Tape"},
                { 14010, "Empty entry"}
            };



        public static Dictionary<Int16, string> m_ItesmLookup = new Dictionary<Int16, string>
        {


        };



        /// <summary>
        /// Parse itemdat from memory stream..
        /// </summary>
        /// <param name="fs">The memory straem </param>
        /// <param name="start_off">The offset to the memory stream</param>
        /// <param name="LV_AFS">The AFS Listview Control</param>
        /// <param name="LV_HEADER">The Target Listview Where main Header data will be dumped</param>
        /// <param name="Lv_IData">The Target Listview where ItemData itself will be dumped?</param>
        public void Parse_IDataStream(Stream fs, int start_off, ListView LV_AFS, ListView LV_HEADER, ListView Lv_IData)
        {
            Int32 subh_sz = 0;
            int ItemDat_Offset = int.Parse(LV_AFS.FocusedItem.SubItems[1].Text);

            fs.Seek(ItemDat_Offset + start_off, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(fs);

            int h_sz = br.ReadInt32() / 8;

            fs.Seek(ItemDat_Offset + start_off, SeekOrigin.Begin);

            Array.Resize(ref DAT_HEADER, h_sz);
            Array.Resize(ref IPROP_HEADER.offsets, h_sz);



            for (int i = 0; i < h_sz; i++)
            {
                DAT_HEADER[i].offset = br.ReadInt32();
                DAT_HEADER[i].size = br.ReadInt32();
                LV_HEADER.Items.Add(i.ToString());
                LV_HEADER.Items[i].SubItems.Add(DAT_HEADER[i].offset.ToString());
                LV_HEADER.Items[i].SubItems.Add(DAT_HEADER[i].size.ToString());

                switch (i) // run this to fill descriptions
                {
                    case 0: LV_HEADER.Items[i].SubItems.Add("Item Properties & Item Combination Data"); break;
                    case 1: LV_HEADER.Items[i].SubItems.Add("Item Coordinate data"); break;
                    case 2: LV_HEADER.Items[i].SubItems.Add("N\\A, Possibly related to 3d inventory icons"); break;
                }

            }

            IPROP_HEADER.tag = br.ReadInt32();
            IPROP_HEADER.entry_count = br.ReadInt32();
            IPROP_HEADER.cmb_sz = br.ReadInt32();
            IPROP_HEADER.unk_count = br.ReadInt32();
            subh_sz = br.ReadInt32(); // first offset in sub header = total subheader size


            for (int j = 0; j < h_sz; j++)
            {
                IPROP_HEADER.offsets[j] = br.ReadInt32() + 24;
            }

            Array.Resize(ref Item_Data, IPROP_HEADER.entry_count);


            for (int x = 0; x < Item_Data.Length; x++)
            {

                Item_Data[x].tag = br.ReadInt16();
                Item_Data[x].ubyte00 = br.ReadByte();
                Item_Data[x].ubyte01 = br.ReadByte();
                Item_Data[x].Ushort01 = br.ReadInt16();
                Item_Data[x].Ushort02 = br.ReadInt16();
                Item_Data[x].durabillity = br.ReadInt16();
                Item_Data[x].Ushort03 = br.ReadInt16();
                Item_Data[x].Ushort04 = br.ReadInt16();
                Item_Data[x].Sound_ID = br.ReadByte();
                Item_Data[x].Type = br.ReadByte();
                Item_Data[x].Menu_type = br.ReadInt16();
                Item_Data[x].Item_ID = br.ReadInt16();
                Item_Data[x].Ushort05 = br.ReadInt16();
                Item_Data[x].Ushort06 = br.ReadInt16();

                Lv_IData.Items.Add(x.ToString());

                if (m_ItemLookup.ContainsKey(Item_Data[x].Item_ID))
                {
                    Lv_IData.Items[x].ImageIndex = Item_Data[x].Item_ID;
                    Lv_IData.Items[x].SubItems.Add(m_ItemLookup[Item_Data[x].Item_ID]);

                }

                

            }

            fs.Close();
            br.Close();


        }

        public void Parse_Dat(string fp, ListView LV_HEADER, ListView LV_DATA)
        {
            Int32 subh_sz;

           
            FileStream fs = new FileStream(fp, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);

            int h_sz = br.ReadInt32() / 8;

            fs.Seek(0, SeekOrigin.Begin);

            Array.Resize(ref DAT_HEADER, h_sz);                                    
            Array.Resize(ref IPROP_HEADER.offsets, h_sz);

            for (int i = 0; i < h_sz; i++)
            {
                DAT_HEADER[i].offset = br.ReadInt32();
                DAT_HEADER[i].size = br.ReadInt32();
                LV_HEADER.Items.Add(i.ToString());
                LV_HEADER.Items[i].SubItems.Add(DAT_HEADER[i].offset.ToString());
                LV_HEADER.Items[i].SubItems.Add(DAT_HEADER[i].size.ToString());

                switch (i) // run this to fill descriptions
                {
                    case 0: LV_HEADER.Items[i].SubItems.Add("Item Properties & Item Combination Data"); break;
                    case 1: LV_HEADER.Items[i].SubItems.Add("Item Coordinate data"); break;
                    case 2: LV_HEADER.Items[i].SubItems.Add("N\\A, Possibly related to 3d inventory icons"); break;
                }

            }

            IPROP_HEADER.tag = br.ReadInt32();
            IPROP_HEADER.entry_count = br.ReadInt32();
            IPROP_HEADER.cmb_sz = br.ReadInt32();
            IPROP_HEADER.unk_count = br.ReadInt32();
            subh_sz = br.ReadInt32(); // first offset in sub header = total subheader size


            for (int j = 0; j < h_sz; j++)
            {
                IPROP_HEADER.offsets[j] = br.ReadInt32() + 24;
            }

            Array.Resize(ref Item_Data, IPROP_HEADER.entry_count);


            for (int x = 0; x < Item_Data.Length; x++)
            {

                Item_Data[x].tag = br.ReadInt16();
                Item_Data[x].ubyte00 = br.ReadByte();
                Item_Data[x].ubyte01 = br.ReadByte();
                Item_Data[x].Ushort01 = br.ReadInt16();
                Item_Data[x].Ushort02 = br.ReadInt16();
                Item_Data[x].durabillity = br.ReadInt16();
                Item_Data[x].Ushort03 = br.ReadInt16();
                Item_Data[x].Ushort04 = br.ReadInt16();
                Item_Data[x].Sound_ID = br.ReadByte();
                Item_Data[x].Type = br.ReadByte();
                Item_Data[x].Menu_type = br.ReadInt16();
                Item_Data[x].Item_ID = br.ReadInt16();
                Item_Data[x].Ushort05 = br.ReadInt16();
                Item_Data[x].Ushort06 = br.ReadInt16();

                LV_DATA.Items.Add(x.ToString());

                if (m_ItemLookup.ContainsKey(Item_Data[x].Item_ID))
                {
                    LV_DATA.Items[x].ImageIndex = Item_Data[x].Item_ID;
                    LV_DATA.Items[x].SubItems.Add(m_ItemLookup[Item_Data[x].Item_ID]);
                  
                }


              


            }
            fs.Close();
            br.Close();
        }




        public void READ_TABLE_FILE()
        {

        }



       /// <summary>
       ///  Read table from netbio stream..
       /// </summary>
       /// <param name="fs"></param>
       /// <param name="start_off"></param>
       /// <param name="LV"></param>
       /// <param name="CMB"></param>
       /// <param name="f_type"></param>
       /// <param name="Debug_Log"></param>
		public void READ_TABLE_STREAM(Stream fs, int start_off, ListView LV_AFS, ListView LV_ITABLE, ComboBox CMB, bool f_type, RichTextBox Debug_Log)
		{

            int tbl_offset = int.Parse(LV_AFS.FocusedItem.SubItems[1].Text);
		

			LV_ITABLE.Items.Clear();  // claer to prevent dupes


		         
			BinaryReader br = new BinaryReader(fs);


			string[] item_names = new string[0];
			int null_count = 0;

			fs.Seek(start_off + tbl_offset, SeekOrigin.Begin);

			TBL_HEADER.tag = br.ReadInt32();
			TBL_HEADER.Item_count = br.ReadInt32();   // get info

			Debug_Log.AppendText("\n Defined Item Count: " + TBL_HEADER.Item_count.ToString());

			if (f_type) // if online file multiply to get the extra entries
			{
				TBL_HEADER.Item_count *= 3;
			}

			Array.Resize(ref TBL_ITEM, TBL_HEADER.Item_count);    // resize arrays
			Array.Resize(ref item_names, TBL_HEADER.Item_count);  

			for (int i = 0; i < TBL_HEADER.Item_count; i++) // loop through item count read/store item objects 
			{
				TBL_ITEM[i].Item_val = br.ReadInt16();
				TBL_ITEM[i].Quantity = br.ReadByte();
				TBL_ITEM[i].occurence = br.ReadByte();


				LV_ITABLE.Items.Add(i.ToString());
                LV_ITABLE.Items[i].SubItems.Add(TBL_ITEM[i].Item_val.ToString()); // dump index and item value to listview

				if (TBL_ITEM[i].Item_val == -1) // check if entry is null
				{
                  //  LV_ITABLE.Items[i].Group = LV_ITABLE.Groups[0];
					null_count += 1;
                    LV_ITABLE.Items[i].SubItems.Add("Null");
                    LV_ITABLE.Items[i].ForeColor = Color.PaleVioletRed;
                    LV_ITABLE.Items[i].Font = new System.Drawing.Font("Lucida Console", 9);

                   
				}


                // if entry is equal to one of the dictionary keys 

				if (m_ItemLookup.ContainsKey(TBL_ITEM[i].Item_val))
				{
                    LV_ITABLE.Items[i].SubItems.Add(m_ItemLookup[TBL_ITEM[i].Item_val]); // add matching item
                    LV_ITABLE.Items[i].SubItems.Add(TBL_ITEM[i].Quantity.ToString());
                    LV_ITABLE.Items[i].SubItems.Add(TBL_ITEM[i].occurence.ToString());
                    //	CMB.Items.Add(m_ItemLookup[TBL_ITEM[i].Item_val].ToString()); // this only adds currently read items to the combo box, not entire dictionary

                    // color herbs lol
                    //         if (m_ItemLookup[TBL_ITEM[i].Item_val] == "Green Herb") { LV_ITABLE.Items[i].ForeColor = Color.DarkGreen; }
                    //		if (m_ItemLookup[TBL_ITEM[i].Item_val] == "Red Herb") { LV_ITABLE.Items[i].ForeColor = Color.Red; }
                    //		if (m_ItemLookup[TBL_ITEM[i].Item_val] == "Blue Herb") { LV_ITABLE.Items[i].ForeColor = Color.Blue; }


                    // if itemIcon table contains lv item name
                    if (ItemIcon_Table.ContainsKey(LV_ITABLE.Items[i].SubItems[2].Text))
                    {
                        // set item index to correct icon list index..
                            LV_ITABLE.Items[i].ImageIndex = ItemIcon_Table[LV_ITABLE.Items[i].SubItems[2].Text];
                    }

					
				}

			}


			foreach (string item_name in m_ItemLookup.Values)  // add item names in dictionary to combo box
			{
				CMB.Items.Add(item_name);
			}

			Debug_Log.AppendText("\n Total null items Read: " + null_count.ToString());


			fs.Close();
			br.Close(); 


		} // parse .TBL's dump info to debug log


		public void string_match(string selected_item, ListView LV, ComboBox cmbo) // send selected string from listview to combo box
		{
			selected_item = LV.FocusedItem.SubItems[2].Text;


			if (cmbo.Items.Contains(selected_item))
			{
				cmbo.SelectedItem = selected_item;
			}

		}







        /// <summary>
        /// re write tbl entry to local file..
        /// </summary>
        /// <param name="fp"></param>
        /// <param name="slct_idx"></param>
        /// <param name="new_itemID"></param>
        /// <param name="new_quantity"></param>
        /// <param name="new_occ"></param>
        /// <param name="Debug_Log"></param>
		public void write_item_file(string fp, int slct_idx, Int16 new_itemID, byte new_quantity, byte new_occ, RichTextBox Debug_Log)
		{

			FileStream fs = new FileStream(fp, FileMode.Open);
			BinaryWriter bw = new BinaryWriter(fs);

			fs.Seek(8 + 4 * slct_idx, SeekOrigin.Begin);

			Debug_Log.AppendText("\nnew Item ID : " + new_itemID.ToString() + "@ Offset: " + fs.Position.ToString());
			bw.Write(new_itemID);
			Debug_Log.AppendText("\nnew Quantity Value :" + new_quantity.ToString() + "@ Offset: " + fs.Position.ToString());
			bw.Write(new_quantity);
			Debug_Log.AppendText("\nnew Occurence Value : " + new_occ.ToString() + "@ Offset: " + fs.Position.ToString());
			bw.Write(new_occ);


			fs.Close();
			bw.Close();

		}



        public void write_item(Stream fs, int start_offset, ListView AFS_LIST,int slct_idx, Int16 new_itemID, byte new_quantity, byte new_occ, RichTextBox Debug_Log)
        {
            int cur_tbl_offset = start_offset + int.Parse(AFS_LIST.FocusedItem.SubItems[1].Text);
     
            BinaryWriter bw = new BinaryWriter(fs);

            fs.Seek(cur_tbl_offset + 8 + 4 * slct_idx, SeekOrigin.Begin);

            Debug_Log.AppendText("\nnew Item ID : " + new_itemID.ToString() + "@ Offset: " + fs.Position.ToString());
            bw.Write(new_itemID);
            Debug_Log.AppendText("\nnew Quantity Value :" + new_quantity.ToString() + "@ Offset: " + fs.Position.ToString());
            bw.Write(new_quantity);
            Debug_Log.AppendText("\nnew Occurence Value : " + new_occ.ToString() + "@ Offset: " + fs.Position.ToString());
            bw.Write(new_occ);


            fs.Close();
            bw.Close();

        }


        public void file_info(string fp, RichTextBox Debug) // run 2 switches on file name to determine difficulty and scenario
		{
			Debug.Clear();

			switch (fp.Substring(fp.Length - 8, 2))
			{
				case "10":
					Debug.AppendText("Underbelly\n");
					break;

				case "15":
					Debug.AppendText("Desperate Times\n");
					break;

				case "26":
					Debug.AppendText("Flashback\n");
					break;

				case "06":
					Debug.AppendText("End of the Road\n");
					break;

				case "40":
					Debug.AppendText("Wild Things\n");
					break;

				case "20":
					Debug.AppendText("Training Ground\n");
					break;

				case "21":
					Debug.AppendText("Showdown 1\n");
					break;

				case "22":
					Debug.AppendText("Showdown 2\n");
					break;
			
				case "23":
					Debug.AppendText("Showdown 3\n");
					break;

				case "27":
					Debug.AppendText("Elimintation 1");
					break;

				case "29":
					Debug.AppendText("Elimination 2");
					break;

				case "30":
					Debug.AppendText("Elimination 3");
					break;
		


			}



			switch (fp.Substring(fp.Length - 6, 2))
			{
				case "16":
					Debug.AppendText("Easy Mode Offline\n");
					break;

				case "17":
					Debug.AppendText("Normal Mode Offline\n");
					break;

				case "18":
					Debug.AppendText("Hard Mode Offline\n");
					break;

				case "19":
					Debug.AppendText("Very Hard Mode Offline\n");
					break;


			}

		}

        public void Set_ID_OBJ(ListView LV, PropertyGrid PG) // load struct data into prop grid
        {
            int cur_idx = LV.FocusedItem.Index;
            Item_Properties._tag = Item_Data[cur_idx].tag;
            Item_Properties._ubyte00 = Item_Data[cur_idx].ubyte00;
            Item_Properties._Ushort01 = Item_Data[cur_idx].Ushort01;
            Item_Properties._Ushort02 = Item_Data[cur_idx].Ushort02;
            Item_Properties._durabillity = Item_Data[cur_idx].Ushort01;
            Item_Properties._Ushort03 = Item_Data[cur_idx].Ushort03;
            Item_Properties._Ushort04 = Item_Data[cur_idx].Ushort04;
            Item_Properties._Sound_ID = Item_Data[cur_idx].Sound_ID;
            Item_Properties._Type = Item_Data[cur_idx].Type;
            Item_Properties._Menu_type = Item_Data[cur_idx].Menu_type;
            Item_Properties._Item_ID = Item_Data[cur_idx].Item_ID;
            Item_Properties._Ushort05 = Item_Data[cur_idx].Ushort05;
            Item_Properties._Ushort06 = Item_Data[cur_idx].Ushort06;

            PG.SelectedObject = Item_Properties;
        }

        public string GET_ITEM_NAME(Int16 Item_ID)
        {
            string found_item = string.Empty;

            if (m_ItemLookup.ContainsKey((Item_ID)))
            {
                found_item = m_ItemLookup[Item_ID];
            }


            return found_item;

        }


    }


    public class Item_Data
    {


        public Int16 _tag;
        public byte _ubyte00;
        public byte _ubyte01;
        public Int16 _Ushort01;
        public Int16 _Ushort02;
        public Int16 _durabillity;
        public Int16 _Ushort03;
        public Int16 _Ushort04;
        public byte _Sound_ID; // defines sound played on use
        public byte _Type; // defines animation played on equip/use
        public Int16 _Menu_type; // defines menu type displayed when selected
        public Int16 _Item_ID; // The Item itself
        public Int16 _Ushort05;
        public Int16 _Ushort06;


        [Category("ITEM DATA")]
        [DisplayName("Tag/Flag")]
        [Description("N/A")]


        public Int16 tag // display tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        [Category("ITEM DATA")]
        [DisplayName("ubyte00")]
        [Description("N/A")]


        public byte ubyte00 // display tag
        {
            get { return _ubyte00; }
            set { _ubyte00 = value; }
        }

        [Category("ITEM DATA")]
        [DisplayName("ubyte01")]
        [Description("N/A")]

        public byte ubyte01 // display tag
        {
            get { return _ubyte01; }
            set { _ubyte01 = value; }
        }

        [Category("ITEM DATA")]
        [DisplayName("ushort01")]
        [Description("N/A")]


        public Int16 Ushort01 // display tag
        {
            get { return _Ushort01; }
            set { _Ushort01 = value; }
        }

        [Category("ITEM DATA")]
        [DisplayName("UShort01")]
        [Description("N/A")]


        public Int16 Ushort02 // display tag
        {
            get { return _Ushort02; }
            set { _Ushort02 = value; }
        }



        [Category("ITEM DATA")]
        [DisplayName("Durability/Capacity?")]
        [Description("N/A")]


        public Int16 durabillity // display tag
        {
            get { return _durabillity; }
            set { _durabillity = value; }
        }



        [Category("ITEM DATA")]
        [DisplayName("UShort03")]
        [Description("N/A")]


        public Int16 Ushort03 // display tag
        {
            get { return _Ushort03; }
            set { _Ushort03 = value; }
        }


        [Category("ITEM DATA")]
        [DisplayName("UShort04")]
        [Description("N/A")]


        public Int16 Ushort04 // display tag
        {
            get { return _Ushort04; }
            set { _Ushort04 = value; }
        }


        [Category("ITEM DATA")]
        [DisplayName("Sound ID")]
        [Description("Item's Sound ID")]


        public byte Sound_ID // display tag
        {
            get { return _Sound_ID; }
            set { _Sound_ID = value; }
        }

        [Category("ITEM DATA")]
        [DisplayName("Animation, Item Type")]
        [Description("Item Type (Animation, effect)")]


        public byte Type // display tag
        {
            get { return _Type; }
            set { _Type = value; }
        }


        [Category("ITEM DATA")]
        [DisplayName("Menu Type")]
        [Description("Defines the menu type the item uses")]


        public Int16 Menu_type // display tag
        {
            get { return _Menu_type; }
            set { _Menu_type = value; }
        }


        [Category("ITEM DATA")]
        [DisplayName("Item ID")]
        [Description("The Item ID of current entry")]


        public Int16 Item_ID // display tag
        {
            get { return _Item_ID; }
            set { _Item_ID = value; }
        }


        [Category("ITEM DATA")]
        [DisplayName("UShort05")]
        [Description("N/A")]


        public Int16 Ushort05 // display tag
        {
            get { return _Ushort05; }
            set { _Ushort05 = value; }
        }

        [Category("ITEM DATA")]
        [DisplayName("UShort06")]
        [Description("N/A")]


        public Int16 Ushort06 // display tag
        {
            get { return _Ushort06; }
            set { _Ushort06 = value; }
        }



    }



}
