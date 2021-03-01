using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Netbio_VFL_Plus
{
    public partial class FRM_AUDIO : Form
    {
        public FRM_AUDIO()
        {
            InitializeComponent();
        }

        private void scanSNDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.ShowDialog();

            LIB_AUDIO.SND_PARSE(OFD.FileName, LV_AUDIO, LBL_TCOUNT);

            LBL_FILE.Text = OFD.FileName;

            
        }

        private void LV_AUDIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int i = LV_AUDIO.SelectedIndices[0];
                int sel_offset = int.Parse(LV_AUDIO.Items[i].SubItems[2].Text);
                int next_offset = int.Parse(LV_AUDIO.Items[i + 1].SubItems[2].Text);
                int freq = int.Parse(LV_AUDIO.Items[i].SubItems[4].Text);

                int t_sz = next_offset - sel_offset;

                LIB_AUDIO.PLAY_LV_CLIP(LBL_FILE.Text, sel_offset, t_sz, freq);





            }
            catch (System.ArgumentOutOfRangeException AOR) 
            {
            
            }
        }
    }
}
