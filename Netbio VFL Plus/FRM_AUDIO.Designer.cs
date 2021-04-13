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
            this.BTN_DEBUG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTN_PLAY_ALL = new System.Windows.Forms.ToolStripButton();
            this.BTN_ABORT = new System.Windows.Forms.ToolStripButton();
            this.MAINSTATUS_STRIP = new System.Windows.Forms.StatusStrip();
            this.LBL_FILE = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_TCOUNT = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_AD_STATUS = new System.Windows.Forms.ToolStripStatusLabel();
            this.PG_SOUND = new System.Windows.Forms.ToolStripProgressBar();
            this.LV_AUDIO = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RB_STEREO = new System.Windows.Forms.RadioButton();
            this.RB_MONO = new System.Windows.Forms.RadioButton();
            this.LBL_OFF = new System.Windows.Forms.Label();
            this.LBL_BLK = new System.Windows.Forms.Label();
            this.SND_TIMER = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TB_VOL = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LBL_VOL = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.MAINSTATUS_STRIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_VOL)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(720, 24);
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
            this.scanSNDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.scanSNDToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
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
            // BTN_DEBUG
            // 
            this.BTN_DEBUG.Name = "BTN_DEBUG";
            this.BTN_DEBUG.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.BTN_DEBUG.Size = new System.Drawing.Size(151, 22);
            this.BTN_DEBUG.Text = "Debug";
            this.BTN_DEBUG.Click += new System.EventHandler(this.BTN_DEBUG_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTN_PLAY_ALL,
            this.BTN_ABORT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(720, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTN_PLAY_ALL
            // 
            this.BTN_PLAY_ALL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_PLAY_ALL.Image = ((System.Drawing.Image)(resources.GetObject("BTN_PLAY_ALL.Image")));
            this.BTN_PLAY_ALL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_PLAY_ALL.Name = "BTN_PLAY_ALL";
            this.BTN_PLAY_ALL.Size = new System.Drawing.Size(23, 22);
            this.BTN_PLAY_ALL.Text = "toolStripButton1";
            this.BTN_PLAY_ALL.Click += new System.EventHandler(this.BTN_PLAY_ALL_Click);
            // 
            // BTN_ABORT
            // 
            this.BTN_ABORT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_ABORT.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ABORT.Image")));
            this.BTN_ABORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_ABORT.Name = "BTN_ABORT";
            this.BTN_ABORT.Size = new System.Drawing.Size(23, 22);
            this.BTN_ABORT.Text = "toolStripButton2";
            // 
            // MAINSTATUS_STRIP
            // 
            this.MAINSTATUS_STRIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_FILE,
            this.LBL_TCOUNT,
            this.LBL_AD_STATUS,
            this.PG_SOUND});
            this.MAINSTATUS_STRIP.Location = new System.Drawing.Point(0, 516);
            this.MAINSTATUS_STRIP.Name = "MAINSTATUS_STRIP";
            this.MAINSTATUS_STRIP.Size = new System.Drawing.Size(720, 24);
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
            // PG_SOUND
            // 
            this.PG_SOUND.Name = "PG_SOUND";
            this.PG_SOUND.Size = new System.Drawing.Size(100, 18);
            // 
            // LV_AUDIO
            // 
            this.LV_AUDIO.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LV_AUDIO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.LV_AUDIO.Font = new System.Drawing.Font("Bahnschrift", 9.75F);
            this.LV_AUDIO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LV_AUDIO.FullRowSelect = true;
            this.LV_AUDIO.HideSelection = false;
            this.LV_AUDIO.Location = new System.Drawing.Point(6, 52);
            this.LV_AUDIO.MultiSelect = false;
            this.LV_AUDIO.Name = "LV_AUDIO";
            this.LV_AUDIO.Size = new System.Drawing.Size(710, 369);
            this.LV_AUDIO.TabIndex = 13;
            this.LV_AUDIO.UseCompatibleStateImageBehavior = false;
            this.LV_AUDIO.View = System.Windows.Forms.View.Details;
            this.LV_AUDIO.SelectedIndexChanged += new System.EventHandler(this.LV_AUDIO_SelectedIndexChanged);
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
            this.RB_STEREO.Location = new System.Drawing.Point(6, 19);
            this.RB_STEREO.Name = "RB_STEREO";
            this.RB_STEREO.Size = new System.Drawing.Size(72, 20);
            this.RB_STEREO.TabIndex = 14;
            this.RB_STEREO.TabStop = true;
            this.RB_STEREO.Text = "STEREO";
            this.RB_STEREO.UseVisualStyleBackColor = true;
            this.RB_STEREO.CheckedChanged += new System.EventHandler(this.RB_STEREO_CheckedChanged);
            // 
            // RB_MONO
            // 
            this.RB_MONO.AutoSize = true;
            this.RB_MONO.Location = new System.Drawing.Point(6, 42);
            this.RB_MONO.Name = "RB_MONO";
            this.RB_MONO.Size = new System.Drawing.Size(61, 20);
            this.RB_MONO.TabIndex = 15;
            this.RB_MONO.Text = "MONO";
            this.RB_MONO.UseVisualStyleBackColor = true;
            this.RB_MONO.CheckedChanged += new System.EventHandler(this.RB_MONO_CheckedChanged);
            // 
            // LBL_OFF
            // 
            this.LBL_OFF.Location = new System.Drawing.Point(534, 39);
            this.LBL_OFF.Name = "LBL_OFF";
            this.LBL_OFF.Size = new System.Drawing.Size(172, 23);
            this.LBL_OFF.TabIndex = 16;
            this.LBL_OFF.Text = "OFFSET:";
            // 
            // LBL_BLK
            // 
            this.LBL_BLK.Location = new System.Drawing.Point(534, 16);
            this.LBL_BLK.Name = "LBL_BLK";
            this.LBL_BLK.Size = new System.Drawing.Size(172, 23);
            this.LBL_BLK.TabIndex = 17;
            this.LBL_BLK.Text = "BLK SZ:";
            // 
            // SND_TIMER
            // 
            this.SND_TIMER.Tick += new System.EventHandler(this.SND_TIMER_Tick);
            // 
            // TB_VOL
            // 
            this.TB_VOL.AutoSize = false;
            this.TB_VOL.Location = new System.Drawing.Point(105, 39);
            this.TB_VOL.Maximum = 100;
            this.TB_VOL.Name = "TB_VOL";
            this.TB_VOL.Size = new System.Drawing.Size(200, 27);
            this.TB_VOL.TabIndex = 18;
            this.TB_VOL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TB_VOL.Value = 75;
            this.TB_VOL.Scroll += new System.EventHandler(this.TB_VOL_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.LBL_VOL);
            this.groupBox1.Controls.Add(this.TB_VOL);
            this.groupBox1.Controls.Add(this.LBL_OFF);
            this.groupBox1.Controls.Add(this.LBL_BLK);
            this.groupBox1.Controls.Add(this.RB_STEREO);
            this.groupBox1.Controls.Add(this.RB_MONO);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 428);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 85);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio Controls";
            // 
            // LBL_VOL
            // 
            this.LBL_VOL.Location = new System.Drawing.Point(129, 13);
            this.LBL_VOL.Name = "LBL_VOL";
            this.LBL_VOL.Size = new System.Drawing.Size(162, 23);
            this.LBL_VOL.TabIndex = 19;
            this.LBL_VOL.Text = "VOLUME";
            this.LBL_VOL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRM_AUDIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 540);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LV_AUDIO);
            this.Controls.Add(this.MAINSTATUS_STRIP);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRM_AUDIO";
            this.Text = "SOUND MANAGER";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MAINSTATUS_STRIP.ResumeLayout(false);
            this.MAINSTATUS_STRIP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_VOL)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.RadioButton RB_STEREO;
        private System.Windows.Forms.RadioButton RB_MONO;
        private System.Windows.Forms.Label LBL_OFF;
        private System.Windows.Forms.Label LBL_BLK;
        private System.Windows.Forms.Timer SND_TIMER;
        private System.Windows.Forms.ToolStripProgressBar PG_SOUND;
        private System.Windows.Forms.ToolStripMenuItem BTN_DEBUG;
        private System.Windows.Forms.ToolStripButton BTN_PLAY_ALL;
        private System.Windows.Forms.ToolStripButton BTN_ABORT;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TrackBar TB_VOL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LBL_VOL;
    }
}