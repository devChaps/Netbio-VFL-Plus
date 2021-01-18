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
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
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

                TB_HEX.Text = "0x" + hexval.ToUpper();

            }
            catch (System.FormatException FE) 
            {
             
            }
        }
    }
}
