using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Netbio_VFL_Plus
{


    //==============================================================================
    //File 1
    //==============================================================================
    //Biohazard Outbreak            (NTSC-J)    0x202321B3  [STRING*10] = SLPM-65428
    //Resident Evil Outbreak        (NTSC-U)    0x2024FB23  [STRING*10] = SLUS-20765
    //Resident Evil Outbreak        (PAL)       0x202339B2  [STRING*10] = SLES-51589
    //==============================================================================
    //File 2
    //==============================================================================
    //Biohazard Outbreak File 2     (NTSC-J)    0x2023DFD3  [STRING*10] = SLPM-65692
    //Resident Evil Outbreak File 2 (NTSC-U)    0x20255083  [STRING*10] = SLUS-20984
    //Resident Evil Outbreak File 2 (PAL)       0x2024E5A2  [STRING*10] = SLES-53319


    // STRUCT FOR PLAYER DATA + OFFSETS
    public struct NETBIO_PLAYER 
    {

        public int X_OFFSET;
        public int Y_OFFSET;
        public int Z_OFFSET;
        public float X;
        public float Y;
        public float Z;

        // probabaly wont need these..
        Int16 CURRENT_HP;
        Int16 MAX_HP;
        public int VIRUS; 
    
    }


    public struct NETBIO_ROOM_DATA 
    {
        public int ROOM_ID_OFFSET;
        public int CAM_ID_OFFSET;
        public byte ROOM_ID;
        public byte CAM_ID;
        public byte STAGE_ID;
        public Int16 GameTimer;

    }

    /// <summary>
    /// HELPER CLASS FOR VARIOUS REUSABLE MEMORY ROUTINES
    /// </summary>
    public static class LIB_MEMORY
    {

         // INSTANTIATE STRUCTS..
        public static NETBIO_PLAYER G_PLAYER = new NETBIO_PLAYER();
        public static NETBIO_ROOM_DATA G_ROOM_DATA = new NETBIO_ROOM_DATA();


        public static bool g_STATE = false; // PCSX2_STATE
        public static string g_PROCESS_NAME = string.Empty; // PCSX2 PROC NAME
       
        
        public static int g_GAME_ID; // FILE 1 OR FILE 2
        public static int g_GAME_REGION; // NTSCU/NTSCJ/PAL...


        public static string SEL_FMT; // for RDT BASED FORMAT SELECTION CAM/LIGHT




        /// <summary>
        /// HELPER FUNCTION TO FIND TARGET PCSX2 PROCESs
        /// </summary>
        public static void GET_PCSX2_PROC() 
        {

            Process[] EXE_PROCS = Process.GetProcesses();
            List<string> tmp_list = new List<string>();

            g_PROCESS_NAME = string.Empty;


            foreach (Process theProc in EXE_PROCS) 
            {
                tmp_list.Add(theProc.ProcessName);           
            }


            // LOOP THROUGH ALL DETECTED PROCS AND COLLECT TARGET PROC
            for (int i = 0; i < tmp_list.Count; i++)
            {
                if (tmp_list[i].Length > 4 && tmp_list[i].Substring(0, 5).ToUpper() == "PCSX2")
                {
                    g_PROCESS_NAME = tmp_list[i];
                }
             
            }

            
        
        }


        /// <summary>
        /// HELP FUNCTION TO VERIFY GAME REGION
        /// </summary>
        public static string VERIFY_GAME_REGION() 
        {
            try
            {
                // get current pcsx2 proc
                var procs = Process.GetProcessesByName(g_PROCESS_NAME);

                var proc = procs[0];



                g_GAME_ID = 0;
                g_GAME_REGION = 0;

                string g_VERSION = string.Empty;

                // BIOHAZARD OUTBREAK (NTSC-j)
                if (Memory.Read<int>(proc, new IntPtr(0x202321B3)) == 0x4D504C53)
                {
                    g_GAME_ID = 1;
                    g_GAME_REGION = 1;

                    G_ROOM_DATA.CAM_ID_OFFSET = 0x203AEF53;
                    G_ROOM_DATA.ROOM_ID_OFFSET = 0x203065AC;

                    g_VERSION = "Biohazard Outbreak (NTSC-J)";
                }

                // RESIDENT EVIL OUTBREAK (NTSC-U)
                if (Memory.Read<int>(proc, new IntPtr(0x2024FB23)) == 0x53554C53)
                {
                    g_GAME_ID = 1;
                    g_GAME_REGION = 2;

                    g_VERSION = "Resident Evil Outbreak (NTSC-U)";
                }


                // RESIDENT EVIL OUTBREAK (PAL)
                if (Memory.Read<int>(proc, new IntPtr(0x2024E5A2)) == 0x53454C53)
                {
                    g_GAME_ID = 1;
                    g_GAME_REGION = 3;

                    g_VERSION = "Biohazard Outbreak (PAL)";
                }

                // BIOHAZARD OUTBREAK FILE 2 (NTSC-J)
                if (Memory.Read<int>(proc, new IntPtr(0x2023DFD3)) == 0x4D504C53)
                {
                    g_GAME_ID = 2;
                    g_GAME_REGION = 1;
                    G_ROOM_DATA.ROOM_ID_OFFSET = 0x203137BC;
                    G_ROOM_DATA.CAM_ID_OFFSET = 0x203B31D3;

                    g_VERSION = "Biohazard Outbreak File 2 (NTSC-J)";

                }

                // RESIDENT EVIL OUTBREAK FILE 2 (NTSC-U)
                if (Memory.Read<int>(proc, new IntPtr(0x20255083)) == 0x53554C53)
                {
                    g_GAME_ID = 2;
                    g_GAME_REGION = 2;

                    return "Biohazard Outbreak File 2 (NTSC-U)";
                }

                // RESIDENT EVIL OUTBREAK FILE 2(PAL)
                if (Memory.Read<int>(proc, new IntPtr(0x2024E5A2)) == 0x53454C53)
                {
                    g_GAME_ID = 2;
                    g_GAME_REGION = 3;

                    g_VERSION = "Biohazard Outbreak File 2 (PAL)";
                }


                return g_VERSION;

            }
            catch (System.IndexOutOfRangeException IOR) 
            {
                return "Null";
                MessageBox.Show("PCSX2 NOT DETECTED?");
            }

        }



        public static int GET_OFFSET_BASE(int g_REGION, int g_ID) 
        {
            int offset_base = 0x2047BD30;


            // FILE 1
            if (g_ID == 1 && g_REGION == 1) { offset_base = 0x2047BD30; }
            if (g_ID == 1 && g_REGION == 2) { offset_base = 0x204A5BB4; }  // US >> PAL (SUB) 0x40FB0
            if (g_ID == 1 && g_REGION == 3) { offset_base = 0x20464C04; }

            // FILE 2
            if (g_ID == 2 && g_REGION == 1) { offset_base = 0x2047BD30; }
            if (g_ID == 2 && g_REGION == 2) { offset_base = 0x2047BD30 + 0x4A0E0; }  //ADJUST JP OFFSETS by + 0x4A0E0
            if (g_ID == 2 && g_REGION == 3) { offset_base = 0x2047BD30 + 0x69360; }


            return offset_base;
        
        }


        /// <summary>
        /// DYNAMICALLY SET FILE 1 / FILE 2 MEMORY DATA
        /// </summary>
        /// <param name="offset_base"></param>
        public static void GET_MEM_STATS(int offset_base) 
        {

            Process[] exe_proc = Process.GetProcessesByName(g_PROCESS_NAME);
            var proc = exe_proc[0];

            G_PLAYER.X = Memory.Read<float>(proc, new IntPtr(offset_base + 0x38)); // READ PLAYER_X_POSTION
            G_PLAYER.Y = Memory.Read<float>(proc, new IntPtr(offset_base + 0x3C)); // READ PLAYER_Y_POSTION
            G_PLAYER.Z = Memory.Read<float>(proc, new IntPtr(offset_base + 0x40)); // READ PLAYER_Z_POSTION

         
            // SET ROOM ID
            G_ROOM_DATA.ROOM_ID = Memory.Read<byte>(proc, new IntPtr(G_ROOM_DATA.ROOM_ID_OFFSET));
            G_ROOM_DATA.CAM_ID = Memory.Read<byte>(proc, new IntPtr(G_ROOM_DATA.CAM_ID_OFFSET));

        }


    }
}
