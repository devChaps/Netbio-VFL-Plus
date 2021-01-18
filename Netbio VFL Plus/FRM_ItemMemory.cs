using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Netbio_VFL_Plus
{
    public partial class FRM_ItemMemory : Form
    {


        public int last_focus;

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



        public struct combine_obj
        {
            public Int16 ival_base;
            public Int16 ival_target;
            public Int16 flag;

        }



        public FRM_ItemMemory()
        {
            InitializeComponent();

            FIND_PROCESS();
            Peek_Structs(91);


            foreach (string item_name in Items.m_ItemLookup.Values)  // add item names in dictionary to combo box
            {
                cmb_itemList.Items.Add(item_name);
            }

        }


        public string g_PROCESS_NAME = "";
        public Item_Properties_Obj[] Item_Props = new Item_Properties_Obj[91];
        public Item_Data IDATA = new Item_Data();
        public Int32[] entry_off = new Int32[0]; // offsets for each 24 byte item property entry
        public Int32[] combo_off = new Int32[0]; // offsets for each 6 byte combo data entry
        public combine_obj[] combo_data = new combine_obj[134];






        private void FIND_PROCESS()
        {
            Process[] processlist = Process.GetProcesses();
            List<string> tmp_list = new List<string>();


            foreach (Process theprocess in processlist)
            {
                tmp_list.Add(theprocess.ProcessName);
            }

            for (int i = 0; i < tmp_list.Count; i++)
            {
                if (tmp_list[i].Length > 4 && tmp_list[i].Substring(0, 5) == "pcsx2")
                {
                    g_PROCESS_NAME = tmp_list[i];
                }
            }

            if (g_PROCESS_NAME.Length != 0)
            {
                imem_statuslbl.Text = "PCSX2 DETECTED : " + g_PROCESS_NAME.ToString();
                //LBL_STATUS.Text = "PCSX2 DETECTED : " + g_PROCESS_NAME.ToString();
            }
            else if (g_PROCESS_NAME.Length == null || g_PROCESS_NAME.Length == 0)
            {
                imem_statuslbl.Text = "PCSX2 NOT FOUND!!!";
                //LBL_STATUS.Text = "PCSX2 IS NOT RUNNING";
            }


        }



        public void Peek_Structs(Int32 count) // loop through all defined item entries in memory
        {
            LV_IMEM.Items.Clear();

            var ps2_proc = Process.GetProcessesByName(g_PROCESS_NAME);

            if (ps2_proc == null || ps2_proc.Length == 0)
                return;
            var pcsx2 = ps2_proc[0];

            Int32 start_offset = 0x2075D100;

            Array.Resize(ref entry_off, count);

            for (int i = 0; i < count; i++)
            {


                entry_off[i] = start_offset + 24 * i;


                Item_Props[i].tag = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]));
                Item_Props[i].ubyte00 = Memory.Read<byte>(pcsx2, new IntPtr(entry_off[i]) + 2);
                Item_Props[i].ubyte01 = Memory.Read<byte>(pcsx2, new IntPtr(entry_off[i]) + 3);
                Item_Props[i].Ushort01 = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]) + 4);
                Item_Props[i].Ushort02 = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]) + 6);
                Item_Props[i].durabillity = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]) + 8);
                Item_Props[i].Ushort03 = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]) + 10);
                Item_Props[i].Ushort04 = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]) + 12);
                Item_Props[i].Sound_ID = Memory.Read<byte>(pcsx2, new IntPtr(entry_off[i]) + 14);
                Item_Props[i].Type = Memory.Read<byte>(pcsx2, new IntPtr(entry_off[i]) + 15);
                Item_Props[i].Menu_type = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]) + 16);
                Item_Props[i].Item_ID = Memory.Read<Int16>(pcsx2, new IntPtr(entry_off[i]) + 18);



                LV_IMEM.Items.Add(i.ToString());
                LV_IMEM.Items[i].SubItems.Add("0x" + entry_off[i].ToString("X"));


                if (Items.m_ItemLookup.ContainsKey(Item_Props[i].Item_ID))
                {
                    LV_IMEM.Items[i].SubItems.Add(Items.m_ItemLookup[Item_Props[i].Item_ID]);

                }

            }

            pg_imem.SelectedObject = IDATA;
        }


        public void combo_table() // parse item combo data from memory block
        {
            imem_dbglog.Clear();

            Int32 off = 0x2075DD60;
            var proc = Process.GetProcessesByName(g_PROCESS_NAME);
            if (proc == null || proc.Length == 0)
                return;

            var ps2_proc = proc[0];


            Array.Resize(ref combo_off, 134);

            imem_dbglog.ForeColor = Color.BlanchedAlmond;
            imem_dbglog.AppendText("                              \t[COMBINATION DATA TABLE]\n\n\n");
            imem_dbglog.AppendText("[Input Item]                                             [Output Item / Flag]\n");


            for (int i = 0; i < combo_data.Length; i++)
            {


                combo_off[i] = off + 6 * i;

                combo_data[i].ival_base = Memory.Read<Int16>(ps2_proc, new IntPtr(combo_off[i]));
                combo_data[i].ival_target = Memory.Read<Int16>(ps2_proc, new IntPtr(combo_off[i]) + 2);
                combo_data[i].flag = Memory.Read<Int16>(ps2_proc, new IntPtr(combo_off[i]) + 4);


                imem_dbglog.ForeColor = Color.PaleGoldenrod;

                if (Items.m_ItemLookup.ContainsKey(combo_data[i].ival_base) && Items.m_ItemLookup.ContainsKey(combo_data[i].ival_target))
                {
                    imem_dbglog.AppendText(String.Format("[{0,-1}]  {1,-40}  {2,-15} [{3,0}]\n", i, Items.m_ItemLookup[combo_data[i].ival_base], Items.m_ItemLookup[combo_data[i].ival_target], combo_data[i].flag));
                }


            }



        }


        public void Update()
        {

            var ps2_proc = Process.GetProcessesByName(g_PROCESS_NAME);

            if (ps2_proc == null || ps2_proc.Length == 0)
                return;
            var pcsx2 = ps2_proc[0];

            Int32 start_offset = entry_off[last_focus]; // jump to selected index mem offset
            string hexstr = entry_off[last_focus].ToString("X");

            // re write a new 24 byte struct at selected index in memory sent from user input
            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]), IDATA._tag);
            imem_dbglog.AppendText("Wrote : " + IDATA._tag + " @ Address 0x" + hexstr);
            Memory.Write<byte>(pcsx2, new IntPtr(entry_off[last_focus]) + 2, IDATA._ubyte00);
            //imem_dbglog.AppendText("\nWrote : " + IDATA._ubyte00 + " @ Address 0x" + hexstr += 2);
            Memory.Write<byte>(pcsx2, new IntPtr(entry_off[last_focus]) + 3, IDATA._ubyte01);
            imem_dbglog.AppendText("\nWrote : " + IDATA._ubyte01 + " @ Address 0x" + entry_off[last_focus].ToString("X") + 3);
            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]) + 4, IDATA._Ushort01);
            imem_dbglog.AppendText("\nWrote : " + IDATA._Ushort01 + " @ Address 0x" + entry_off[last_focus].ToString("X") + 4);
            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]) + 6, IDATA._Ushort02);
            imem_dbglog.AppendText("\nWrote : " + IDATA._Ushort02 + " @ Address 0x" + entry_off[last_focus].ToString("X") + 6);
            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]) + 8, IDATA._durabillity);
            imem_dbglog.AppendText("\nWrote : " + IDATA._durabillity + " @ Address 0x" + entry_off[last_focus].ToString("X") + 8);

            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]) + 10, IDATA._Ushort03);
            imem_dbglog.AppendText("\nWrote : " + IDATA._Ushort03 + " @ Address 0x" + entry_off[last_focus].ToString("X") + 10);
            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]) + 12, IDATA._Ushort04);
            imem_dbglog.AppendText("\nWrote : " + IDATA._Ushort04 + " @ Address 0x" + entry_off[last_focus].ToString("X") + 12);
            Memory.Write<byte>(pcsx2, new IntPtr(entry_off[last_focus]) + 14, IDATA._Sound_ID);
            imem_dbglog.AppendText("\nWrote : " + IDATA._Sound_ID + " @ Address 0x" + entry_off[last_focus].ToString("X") + 14);
            Memory.Write<byte>(pcsx2, new IntPtr(entry_off[last_focus]) + 15, IDATA._Type);
            imem_dbglog.AppendText("\nWrote : " + IDATA.Type + " @ Address 0x" + entry_off[last_focus].ToString("X") + 15);
            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]) + 16, IDATA._Menu_type);
            imem_dbglog.AppendText("\nWrote : " + IDATA._Menu_type + " @ Address 0x" + entry_off[last_focus].ToString("X") + 16);
            Memory.Write<Int16>(pcsx2, new IntPtr(entry_off[last_focus]) + 18, IDATA._Item_ID);
            imem_dbglog.AppendText("\nWrote : " + IDATA._Item_ID + " @ Address 0x" + entry_off[last_focus].ToString("X") + 18);

            Peek_Structs(91);

        }



        private void rescanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LV_IMEM_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = LV_IMEM.FocusedItem.Index;

            foreach (string itename in cmb_itemList.Items) // loop through all items already in combo box
            {
                if (itename == LV_IMEM.FocusedItem.SubItems[2].Text.ToString()) // if match between selected lv item name and one of the combo box items
                {
                    cmb_itemList.SelectedItem = itename; // set selected combo box item to the matching value


                    nud_itemval.Value = Item_Props[idx].Item_ID;  // set nuds
                    nud_soundval.Value = Item_Props[idx].Sound_ID;
                    nud_durabillity.Value = Item_Props[idx].durabillity;
                    nud_iprops.Value = Item_Props[idx].Type;
                    nud_mtype.Value = Item_Props[idx].Menu_type;



                    // set item properties class to currently selected item entry
                    IDATA._tag = Item_Props[idx].tag;
                    IDATA._ubyte00 = Item_Props[idx].ubyte00;
                    IDATA._ubyte01 = Item_Props[idx].ubyte01;
                    IDATA._Ushort01 = Item_Props[idx].Ushort01;
                    IDATA._Ushort02 = Item_Props[idx].Ushort02;
                    IDATA._durabillity = Item_Props[idx].durabillity;
                    IDATA._Ushort03 = Item_Props[idx].Ushort03;
                    IDATA._Ushort04 = Item_Props[idx].Ushort04;
                    IDATA.Sound_ID = Item_Props[idx].Sound_ID;
                    IDATA._Type = Item_Props[idx].Type;
                    IDATA._Menu_type = Item_Props[idx].Menu_type;
                    IDATA._Item_ID = Item_Props[idx].Item_ID;

                    pg_imem.SelectedObject = IDATA; // then pass it to prop grid


                    imem_dbglog.Clear();

                    imem_dbglog.AppendText(LV_IMEM.FocusedItem.SubItems[2].Text + "\n\n");
                    imem_dbglog.AppendText("-----------------------------------------\n");
                    // dump selected data to list view
                    imem_dbglog.AppendText("Tag: " + IDATA.tag.ToString() + "\n");
                    imem_dbglog.AppendText("Ubyte00: " + IDATA.ubyte00.ToString() + "\n");
                    imem_dbglog.AppendText("Ubyte01: " + IDATA.ubyte01.ToString() + "\n");
                    imem_dbglog.AppendText("Ushort01: " + IDATA.Ushort01.ToString() + "\n");
                    imem_dbglog.AppendText("Ushort02: " + IDATA.Ushort02.ToString() + "\n");
                    imem_dbglog.AppendText("durabillity: " + IDATA.durabillity.ToString() + "\n");
                    imem_dbglog.AppendText("Ushort03: " + IDATA.Ushort03.ToString() + "\n");
                    imem_dbglog.AppendText("Ushort04: " + IDATA.Ushort04.ToString() + "\n");
                    imem_dbglog.AppendText("Sound ID: " + IDATA.Sound_ID.ToString() + "\n");
                    imem_dbglog.AppendText("Animation Type: " + IDATA._Type.ToString() + "\n");
                    imem_dbglog.AppendText("Menu Type: " + IDATA.Menu_type.ToString() + "\n");
                    imem_dbglog.AppendText("Item Id: " + IDATA.Item_ID.ToString() + "\n");


                    //  Load_Image(nud_itemval, nud_mtype); // call correct icon
                }
            }
        }

        private void IMEM_TIMER_Tick(object sender, EventArgs e)
        {
            var proc = Process.GetProcessesByName(g_PROCESS_NAME);

            if (proc.Length == 0 || proc == null)
                return;

            var pcsx2 = proc[0];
        }

        private void LV_IMEM_Leave(object sender, EventArgs e)
        {
            last_focus = LV_IMEM.FocusedItem.Index;
        }

        private void pg_imem_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Update();
        }

        private void BTN_UPDATE_Click(object sender, EventArgs e)
        {
            int idx = LV_IMEM.FocusedItem.Index;


            // store user input back into item data object
            IDATA._Item_ID = short.Parse(nud_itemval.Value.ToString());
            IDATA._Menu_type = short.Parse(nud_mtype.Value.ToString());
            IDATA._Sound_ID = byte.Parse(nud_soundval.Value.ToString());
            IDATA._durabillity = short.Parse(nud_durabillity.Value.ToString());
            IDATA._Type = byte.Parse(nud_iprops.Value.ToString());

            Update();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
