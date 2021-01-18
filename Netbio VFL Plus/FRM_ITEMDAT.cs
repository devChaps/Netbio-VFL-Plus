using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Netbio_VFL_Plus
{
    public static class ItemMemoryThread
    {


        public static void StartMemThread()
        {

            int sleepfor = 5000;


            FRM_ItemMemory IMEM = new FRM_ItemMemory();
            IMEM.ShowDialog();
        }

     }


    public partial class FRM_ITEMDAT : Form
    {

     

        public FRM_ITEMDAT()
        {
            InitializeComponent();
        }

        private void LV_IDataHeader_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LV_ItemData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            ThreadStart memref = new ThreadStart(ItemMemoryThread.StartMemThread);

            Thread ItemThread = new Thread(memref);
            ItemThread.Start();



        }
    }
}
