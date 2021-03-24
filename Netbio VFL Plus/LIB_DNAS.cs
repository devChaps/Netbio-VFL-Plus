using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Netbio_VFL_Plus
{
    public static class LIB_DNAS
    {

        public static byte[]  f1array = new byte[]{1,0,2,36,8,0,224,3,0,0,0,0,48,0,179,127};
       public static byte[] f2array = new byte[]{1,0,2,36,8,0,224,3};

        public static byte GAME_VER = 0;



        public static void DNAS_PATCH_F2(string sFile)
        {
            try
            {


                byte[] file_id = new byte[1];
               


                FileStream fs = new FileStream(sFile, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fs);


                br.BaseStream.Position = 6191253;
                br.Read(file_id, 0, 1);
                string text = System.Text.Encoding.ASCII.GetString(file_id);



                if (text == "8")
                {

                 //   MessageBox.Show("File 2 iso Unpatched!, Patching now...", "Unpatched!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.BaseStream.Position = 6191248;
                    bw.Write(f2array);


                    // filestream close
                    fs.Close();
                    bw.Close();
                    br.Close();

//                    MessageBox.Show("Dnas is now patched", "PATCHED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                    MessageBox.Show("File 2 is already patched!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            catch
            {
                return;

            }

        } // f2 patch function



        public static void DNAS_PATCH_F1(string sFile) // f1 patch function
        {

            try
            {


                byte[] file_ID = new byte[1];
                byte[] f1_check = new byte[1]; // byte check array




                FileStream fs = new FileStream(sFile, FileMode.Open, FileAccess.ReadWrite);
                BinaryReader br = new BinaryReader(fs);

                br.BaseStream.Position = 16340967;   // send file pointer to patch area
                br.Read(f1_check, 0, 1); // check if patched

                string patch_check = System.Text.Encoding.ASCII.GetString(f1_check); // convert to ascii


                if (patch_check == "$")
                {
                    MessageBox.Show("F1 Iso is unpatched, patching iso....", "Unpatched", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.BaseStream.Position = 16340960;
                    bw.Write(f1array);

                    fs.Close();
                    bw.Close();
                    br.Close();

                    MessageBox.Show("Dnas is now patched!", "Patched!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



                else
                    MessageBox.Show("Iso is already patched, ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                fs.Close();
                br.Close();



            }
            catch
            {
                return;
            }





        }



        public static byte GAME_CHECK()
        {


            
            OpenFileDialog OFD = new OpenFileDialog();

          
            OFD.Filter = "iso files(*.iso)| *.iso | All files(*.*) | *.* ";
            OFD.ShowDialog();
            string fp = OFD.FileName;

            int data_check = 0;
            byte GAME_VERSION = 0;

            try
            {

                using (FileStream fs = new FileStream(fp, FileMode.Open))
                {

                    using (BinaryReader br = new BinaryReader(fs))
                    {

                        // SEEK TO 0x8080 DISC CHECk
                        fs.Seek(33592, SeekOrigin.Begin);
                        data_check = br.ReadInt32();

                        if (data_check == 808924466)
                        {
                            GAME_VERSION = 1;



                        } // FILE 1 
                        if (data_check == 809055544)
                        {


                            GAME_VERSION = 2;



                        } // FILE 2



                       

                    }

                }

                return GAME_VERSION;

            }
            catch (ArgumentException AE) 
            {
                return GAME_VERSION;

            }

            // RUN PATCH ROUTINES
            if (GAME_VERSION == 1) { DNAS_PATCH_F1(fp); }
            if (GAME_VERSION == 2) { DNAS_PATCH_F2(fp); }






        }



    }
}
