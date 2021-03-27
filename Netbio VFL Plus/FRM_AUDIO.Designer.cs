namespace Netbio_VFL_Plus
{
    partial class FRM_AUDIO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_AUDIO));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanSNDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MAINSTATUS_STRIP = new System.Windows.Forms.StatusStrip();
            this.LBL_FILE = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_TCOUNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_AD_STATUS = new System.Windows.Forms.ToolStripStatusLabel();
            this.LV_AUDIO = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RB_STEREO = new System.Windows.Forms.RadioButton();
            this.RB_MONO = new System.Windows.Forms.RadioButton();
            this.LBL_OFF = new System.Windows.Forms.Label();
            this.LBL_BLK = new System.Windows.Forms.Label();
            this.SND_TIMER = new System.Windows.Forms.Timer(this.components);
            this.PG_SOUND = new System.Windows.Forms.ToolStripProgressBar();
            this.BTN_DEBUG = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.MAINSTATUS_STRIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(752, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanSNDToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // scanSNDToolStripMenuItem
            // 
            this.scanSNDToolStripMenuItem.Name = "scanSNDToolStripMenuItem";
            this.scanSNDToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.scanSNDToolStripMenuItem.Text = "SND SCAN";
            this.scanSNDToolStripMenuItem.Click += new System.EventHandler(this.scanSNDToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTN_DEBUG});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(752, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MAINSTATUS_STRIP
            // 
            this.MAINSTATUS_STRIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_FILE,
            this.LBL_TCOUNT,
            this.LBL_AD_STATUS,
            this.PG_SOUND});
            this.MAINSTATUS_STRIP.Location = new System.Drawing.Point(0, 467);
            this.MAINSTATUS_STRIP.Name = "MAINSTATUS_STRIP";
            this.MAINSTATUS_STRIP.Size = new System.Drawing.Size(752, 24);
            this.MAINSTATUS_STRIP.TabIndex = 12;
            this.MAINSTATUS_STRIP.Text = "statusStrip1";
            // 
            // LBL_FILE
            // 
            this.LBL_FILE.AutoSize = false;
            this.LBL_FILE.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_FILE.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_FILE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_FILE.Name = "LBL_FILE";
            this.LBL_FILE.Size = new System.Drawing.Size(515, 19);
            this.LBL_FILE.Text = "[Path]";
            // 
            // LBL_TCOUNT
            // 
            this.LBL_TCOUNT.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_TCOUNT.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_TCOUNT.Name = "LBL_TCOUNT";
            this.LBL_TCOUNT.Size = new System.Drawing.Size(52, 19);
            this.LBL_TCOUNT.Text = "[Count]";
            // 
            // LBL_AD_STATUS
            // 
            this.LBL_AD_STATUS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_AD_STATUS.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_AD_STATUS.Name = "LBL_AD_STATUS";
            this.LBL_AD_STATUS.Size = new System.Drawing.Size(51, 19);
            this.LBL_AD_STATUS.Text = "[Status]";
            // 
            // LV_AUDIO
            // 
            this.LV_AUDIO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5});
            this.LV_AUDIO.FullRowSelect = true;
            this.LV_AUDIO.GridLines = true;
            this.LV_AUDIO.HideSelection = false;
            this.LV_AUDIO.Location = new System.Drawing.Point(23, 30);
            this.LV_AUDIO.MultiSelect = false;
            this.LV_AUDIO.Name = "LV_AUDIO";
            this.LV_AUDIO.Size = new System.Drawing.Size(634, 396);
            this.LV_AUDIO.TabIndex = 13;
            this.LV_AUDIO.UseCompatibleStateImageBehavior = false;
            this.LV_AUDIO.View = System.Windows.Forms.View.Details;
            this.LV_AUDIO.SelectedIndexChanged += new System.EventHandler(this.LV_AUDIO_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Clip";
            this.columnHeader2.Width = 203;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Offset";
            this.columnHeader3.Width = 111;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Size";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Freq(hz)";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Loop";
            // 
            // RB_STEREO
            // 
            this.RB_STEREO.AutoSize = true;
            this.RB_STEREO.Checked = true;
            this.RB_STEREO.Location = new System.Drawing.Point(23, 429);
            this.RB_STEREO.Name = "RB_STEREO";
            this.RB_STEREO.Size = new System.Drawing.Size(69, 17);
            this.RB_STEREO.TabIndex = 14;
            this.RB_STEREO.TabStop = true;
            this.RB_STEREO.Text = "STEREO";
            this.RB_STEREO.UseVisualStyleBackColor = true;
            this.RB_STEREO.CheckedChanged += new System.EventHandler(this.RB_STEREO_CheckedChanged);
            // 
            // RB_MONO
            // 
            this.RB_MONO.AutoSize = true;
            this.RB_MONO.Location = new System.Drawing.Point(98, 429);
            this.RB_MONO.Name = "RB_MONO";
            this.RB_MONO.Size = new System.Drawing.Size(58, 17);
            this.RB_MONO.TabIndex = 15;
            this.RB_MONO.Text = "MONO";
            this.RB_MONO.UseVisualStyleBackColor = true;
            this.RB_MONO.CheckedChanged += new System.EventHandler(this.RB_MONO_CheckedChanged);
            // 
            // LBL_OFF
            // 
            this.LBL_OFF.Location = new System.Drawing.Point(185, 431);
            this.LBL_OFF.Name = "LBL_OFF";
            this.LBL_OFF.Size = new System.Drawing.Size(172, 23);
            this.LBL_OFF.TabIndex = 16;
            this.LBL_OFF.Text = "OFFSET:";
            // 
            // LBL_BLK
            // 
            this.LBL_BLK.Location = new System.Drawing.Point(363, 429);
            this.LBL_BLK.Name = "LBL_BLK";
            this.LBL_BLK.Size = new System.Drawing.Size(172, 23);
            this.LBL_BLK.TabIndex = 17;
            this.LBL_BLK.Text = "BLK SZ:";
            // 
            // SND_TIMER
            // 
            this.SND_TIMER.Tick += new System.EventHandler(this.SND_TIMER_Tick);
            // 
            // PG_SOUND
            // 
            this.PG_SOUND.Name = "PG_SOUND";
            this.PG_SOUND.Size = new System.Drawing.Size(100, 18);
            // 
            // BTN_DEBUG
            // 
            this.BTN_DEBUG.Name = "BTN_DEBUG";
            this.BTN_DEBUG.Size = new System.Drawing.Size(180, 22);
            this.BTN_DEBUG.Text = "Debug";
            this.BTN_DEBUG.Click += new System.EventHandler(this.BTN_DEBUG_Click);
            // 
            // FRM_AUDIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 491);
            this.Controls.Add(this.LBL_BLK);
            this.Controls.Add(this.LBL_OFF);
            this.Controls.Add(this.RB_MONO);
            this.Controls.Add(this.RB_STEREO);
            this.Controls.Add(this.LV_AUDIO);
            this.Controls.Add(this.MAINSTATUS_STRIP);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRM_AUDIO";
            this.Text = "SOUND UTILS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MAINSTATUS_STRIP.ResumeLayout(false);
            this.MAINSTATUS_STRIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanSNDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip MAINSTATUS_STRIP;
        public System.Windows.Forms.ToolStripStatusLabel LBL_FILE;
        public System.Windows.Forms.ToolStripStatusLabel LBL_TCOUNT;
        public System.Windows.Forms.ToolStripStatusLabel LBL_AD_STATUS;
        public System.Windows.Forms.ListView LV_AUDIO;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.RadioButton RB_STEREO;
        private System.Windows.Forms.RadioButton RB_MONO;
        private System.Windows.Forms.Label LBL_OFF;
        private System.Windows.Forms.Label LBL_BLK;
        private System.Windows.Forms.Timer SND_TIMER;
        private System.Windows.Forms.ToolStripProgressBar PG_SOUND;
        private System.Windows.Forms.ToolStripMenuItem BTN_DEBUG;
    }
}