﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using System.IO;
using System.Windows.Forms;


namespace Netbio_VFL_Plus
{
    public static class LIB_AUDIO
    {


        public struct MOMO_HEADER_OBJ 
        {
            public Int32 SCEI_OFFSET;
            public Int32 SCEI_SIZE;
            public Int32 ADPCM_OFFSET;
            public Int32 ADPCM_SIZE;
        
        }


        public struct SCEI_HEADER_OBJ 
        {
            public Int32 HEADER_SZ;
            public Int32 T_ADPCM_SZ;
            public Int32 T_SCEI_VAGI_OFFSET;
        
        }


        public struct VAGI_HEADER_OBJ 
        {
            //public Int32 T_SOUND;
            public Int32 VAGI_TBL_SZ;
            public Int32 T_SOUND;
        
        }

        
        public struct INFO_OBJ 
        {
            public Int32 ADPCM_OFFSET;
            public Int32 ADPCM_SZ; // total size of each clip
            public Int16 FREQ_HZ;
            public byte LOOP_FLAG;
            public byte xFF;
        
        }


        // VERIFY MOMO SIG
        public static bool MOMO_CHECK(Int32 magicNum) 
        {

            if (magicNum == 1330466637)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public static bool VAGI_CHECK(Int64 magicNum) 
        {

            if (magicNum == 6224369862068880713)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static MOMO_HEADER_OBJ MOMO_HEADER = new MOMO_HEADER_OBJ();
        public static SCEI_HEADER_OBJ SCE_HEADER = new SCEI_HEADER_OBJ();
        public static INFO_OBJ[] ADPCM_INFO = new INFO_OBJ[0]; // RESIZE LATER..
        public static VAGI_HEADER_OBJ VAGI_HEADER = new VAGI_HEADER_OBJ();

        public static List<Int32> Relative_Offsets = new List<Int32>();


 
        public static void SND_PARSE(string fpath, ListView AudioList, ToolStripLabel LBL_COUNT) 
        {
            using (FileStream fs = new FileStream(fpath, FileMode.Open)) 
            {
                using (BinaryReader br = new BinaryReader(fs)) 
                {
                    fs.Seek(0, SeekOrigin.Begin);

                    Int32 _magic = br.ReadInt32();
                    
                    // CHECK MOMO SIG..
                    if (MOMO_CHECK(_magic)) 
                    {
                        
                        fs.Seek(0x08, SeekOrigin.Begin);
                        MOMO_HEADER.SCEI_OFFSET = br.ReadInt32();
                        MOMO_HEADER.SCEI_OFFSET = br.ReadInt32();
                        MOMO_HEADER.ADPCM_OFFSET = br.ReadInt32();
                        MOMO_HEADER.ADPCM_SIZE = br.ReadInt32();

                        // SEEK TO SCEI_HEADER INFO
                        fs.Seek(0x5C, SeekOrigin.Begin);
                        SCE_HEADER.HEADER_SZ = br.ReadInt32();
                        SCE_HEADER.T_ADPCM_SZ = br.ReadInt32();

                        fs.Seek(0x70, SeekOrigin.Begin);
                        SCE_HEADER.T_SCEI_VAGI_OFFSET = br.ReadInt32(); // offset from SCEI_HEAD

                        
                        fs.Seek(0x90, SeekOrigin.Begin);

                        Int64 _VagiMagic = br.ReadInt64();

                        if (VAGI_CHECK(_VagiMagic)) 
                        {

                            VAGI_HEADER.VAGI_TBL_SZ = br.ReadInt32();
                            VAGI_HEADER.T_SOUND = br.ReadInt32();

                            LBL_COUNT.Text = VAGI_HEADER.T_SOUND.ToString();

                            // RESIZE ADPCM INFO ARRAY TO # of sounds..
                            Array.Resize(ref ADPCM_INFO, VAGI_HEADER.T_SOUND);

                            for (int i = 0; i < VAGI_HEADER.T_SOUND; i++) 
                            {
                                // read VAGI_relative sound info offsets
                                Int32 r_offset = br.ReadInt32();
                                Relative_Offsets.Add(r_offset);

                             //   MessageBox.Show(r_offset.ToString());

                            }



                            //for (int i = 0; i < Relative_Offsets.Count; i++)
                            //{

                            //    if (i < Relative_Offsets.Count - 1)
                            //    {

                            //        ADPCM_INFO[i].ADPCM_SZ = Relative_Offsets[i + 1] - Relative_Offsets[i];
                            //        ADPCM_INFO[i].ADPCM_SZ += MOMO_HEADER.ADPCM_OFFSET;


                            //     //   MessageBox.Show(ADPCM_INFO[i].ADPCM_SZ.ToString());
                            //    }


                            //}


                            for (int i = 0; i < Relative_Offsets.Count; i++)
                            {
                                // SEEK TO ADPCM DATA INFO
                                fs.Seek(Relative_Offsets[i] + 144, SeekOrigin.Begin);

                                // STORE STRUCTURE INSTANCE
                                ADPCM_INFO[i].ADPCM_OFFSET = br.ReadInt32();
                        
                                ADPCM_INFO[i].ADPCM_OFFSET += MOMO_HEADER.ADPCM_OFFSET;

                         
                                ADPCM_INFO[i].FREQ_HZ = br.ReadInt16();
                                ADPCM_INFO[i].LOOP_FLAG = br.ReadByte();
                                ADPCM_INFO[i].xFF = br.ReadByte();

                                AudioList.Items.Add(i.ToString());
                                AudioList.Items[i].SubItems.Add(fpath);
                                AudioList.Items[i].SubItems.Add(ADPCM_INFO[i].ADPCM_OFFSET.ToString());
                                AudioList.Items[i].SubItems.Add(ADPCM_INFO[i].ADPCM_SZ.ToString());

                                AudioList.Items[i].SubItems.Add(ADPCM_INFO[i].FREQ_HZ.ToString());
                                AudioList.Items[i].SubItems.Add(ADPCM_INFO[i].LOOP_FLAG.ToString());


                            }








                        }
                        


                    }
                    


                }


            
            }




        
        }


        /// <summary>
        /// PLAY SELECTED LV CLIP
        /// </summary>
        /// <param name="path"></param>
        /// <param name="offset"></param>
        /// <param name="freq"></param>
        public static void PLAY_LV_CLIP(string path, Int32 offset, int t_sz, int freq) 
        {
           // byte[] buffer = new byte[t_sz];

         

            //using (FileStream fs = new FileStream(path, FileMode.Open)) 
            //{
             
            //    NAudio.Wave.AdpcmWaveFormat awf = new NAudio.Wave.AdpcmWaveFormat(freq, 1);

            //   // NAudio.Wave.WaveFormat wf = new NAudio.Wave.WaveFormat(freq, 1);

            //    NAudio.Wave.RawSourceWaveStream rawSource = new NAudio.Wave.RawSourceWaveStream(fs,wf);
            
            //   NAudio.Wave.WaveOut wo = new NAudio.Wave.WaveOut();


               

            //    rawSource.Position = offset;

            //    rawSource.Read(buffer, 0, t_sz);

          
                


            //     NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(rawSource);

                
               

            //    NAudio.Wave.WaveFileWriter.CreateWaveFile(AppDomain.CurrentDomain.BaseDirectory + "test1.wav", rawSource);



            //    //   wo.Init(rawSource);
            //    //    wo.Play();



            //    //NAudio.Wave.WaveFormatConversionStream.CreatePcmStream()





            //}
            
            
        
        }





        

    }
}
