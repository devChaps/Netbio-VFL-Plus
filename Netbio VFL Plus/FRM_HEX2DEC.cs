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


namespace Netbio_VFL_Plus
{
    public partial class FRM_HEX2DEC : Form
    {

        public static string dec2hex = string.Empty;
        public static string hex2dec = string.Empty;

        public FRM_HEX2DEC()
        {
            InitializeComponent();
        }

        private void TB_DEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                

            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > 0))
            {
                e.Handled = true;
            }





          //  int decValue = Convert.ToInt32(TB_DEC., 16);



        }

        private void TB_HEX_KeyPress(object sender, KeyPressEventArgs e)
        {
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        //(e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //    {
        //        e.Handled = true;
        //    }
        }

        private void TB_DEC_TextChanged(object sender, EventArgs e)
        {

            try
            {
                int decval = int.Parse(TB_DEC.Text);
                string hexval = string.Format("{0:x}", decval);

                dec2hex = "0x" + hexval.ToUpper();

              //  TB_HEX.Text = "0x" + hexval.ToUpper();

            }
            catch (Exception ex) 
            {
               
            }
        }

        private void TB_HEX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string hexval = TB_HEX.Text;
                int intValue = int.Parse(hexval, System.Globalization.NumberStyles.HexNumber);

                hex2dec = intValue.ToString();
                
              //  TB_DEC.Text = decval.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void TB_HEX_Validating(object sender, CancelEventArgs e)
        {
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

            foreach (char character in TB_HEX.Text.ToUpper().ToArray())
            {
                if (!allowedChars.Contains(character))
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("'{0}' is not a hexadecimal character", character));
                    e.Cancel = true;
                }
            }
        }

        private void BTN_DEC_Click(object sender, EventArgs e)
        {
            TB_HEX.Text = dec2hex;
        }

        private void BTN_HEX_Click(object sender, EventArgs e)
        {
            TB_DEC.Text = hex2dec;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TB_DEC.Clear();
            TB_HEX.Clear();
        }
    }
}
