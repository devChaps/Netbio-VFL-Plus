namespace Netbio_VFL_Plus
{
    partial class FRM_RDT_MEM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_RDT_MEM));
            this.LBL_STATUS = new System.Windows.Forms.Label();
            this.LB_TCAM = new System.Windows.Forms.ListBox();
            this.Memory_Grid = new System.Windows.Forms.PropertyGrid();
            this.BTN_UPDATE = new System.Windows.Forms.Button();
            this.BTN_IDX = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MAINSTATUS_STRIP = new System.Windows.Forms.StatusStrip();
            this.LBL_ROOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_CID = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_POS_X = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_POS_Y = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_POS_Z = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_MEMOFF = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_VERSION = new System.Windows.Forms.ToolStripStatusLabel();
            this.BTN_STAT_HOOK = new System.Windows.Forms.ToolStripSplitButton();
            this.PRG_LOAD = new System.Windows.Forms.ToolStripProgressBar();
            this.Interval_Timer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.MAINSTATUS_STRIP.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBL_STATUS
            // 
            this.LBL_STATUS.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LBL_STATUS.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_STATUS.Location = new System.Drawing.Point(75, -3);
            this.LBL_STATUS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_STATUS.Name = "LBL_STATUS";
            this.LBL_STATUS.Size = new System.Drawing.Size(282, 24);
            this.LBL_STATUS.TabIndex = 12;
            this.LBL_STATUS.Text = ":";
            // 
            // LB_TCAM
            // 
            this.LB_TCAM.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LB_TCAM.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_TCAM.ForeColor = System.Drawing.Color.Black;
            this.LB_TCAM.FormattingEnabled = true;
            this.LB_TCAM.ItemHeight = 16;
            this.LB_TCAM.Location = new System.Drawing.Point(13, 33);
            this.LB_TCAM.Margin = new System.Windows.Forms.Padding(2);
            this.LB_TCAM.Name = "LB_TCAM";
            this.LB_TCAM.Size = new System.Drawing.Size(26, 452);
            this.LB_TCAM.TabIndex = 11;
            this.LB_TCAM.SelectedIndexChanged += new System.EventHandler(this.LB_TCAM_SelectedIndexChanged_1);
            // 
            // Memory_Grid
            // 
            this.Memory_Grid.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Memory_Grid.CategoryForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Memory_Grid.CommandsForeColor = System.Drawing.Color.Cyan;
            this.Memory_Grid.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(32)))), ((int)(((byte)(178)))), ((int)(((byte)(170)))));
            this.Memory_Grid.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Memory_Grid.HelpBackColor = System.Drawing.SystemColors.ControlLight;
            this.Memory_Grid.HelpForeColor = System.Drawing.SystemColors.ControlLight;
            this.Memory_Grid.LineColor = System.Drawing.SystemColors.InfoText;
            this.Memory_Grid.Location = new System.Drawing.Point(48, 36);
            this.Memory_Grid.Margin = new System.Windows.Forms.Padding(2);
            this.Memory_Grid.Name = "Memory_Grid";
            this.Memory_Grid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.Memory_Grid.SelectedItemWithFocusBackColor = System.Drawing.SystemColors.HighlightText;
            this.Memory_Grid.SelectedItemWithFocusForeColor = System.Drawing.SystemColors.ControlText;
            this.Memory_Grid.Size = new System.Drawing.Size(399, 452);
            this.Memory_Grid.TabIndex = 10;
            this.Memory_Grid.ToolbarVisible = false;
            this.Memory_Grid.ViewBackColor = System.Drawing.SystemColors.ControlLight;
            this.Memory_Grid.ViewForeColor = System.Drawing.Color.Black;
            this.Memory_Grid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.Memory_Grid_PropertyValueChanged_1);
            this.Memory_Grid.Click += new System.EventHandler(this.Memory_Grid_Click);
            // 
            // BTN_UPDATE
            // 
            this.BTN_UPDATE.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_UPDATE.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_UPDATE.ForeColor = System.Drawing.Color.Black;
            this.BTN_UPDATE.Image = ((System.Drawing.Image)(resources.GetObject("BTN_UPDATE.Image")));
            this.BTN_UPDATE.Location = new System.Drawing.Point(247, 504);
            this.BTN_UPDATE.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_UPDATE.Name = "BTN_UPDATE";
            this.BTN_UPDATE.Size = new System.Drawing.Size(173, 70);
            this.BTN_UPDATE.TabIndex = 19;
            this.BTN_UPDATE.Text = "SAVE TO DISK";
            this.BTN_UPDATE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_UPDATE.UseVisualStyleBackColor = false;
            this.BTN_UPDATE.Click += new System.EventHandler(this.BTN_UPDATE_Click_1);
            // 
            // BTN_IDX
            // 
            this.BTN_IDX.BackColor = System.Drawing.Color.White;
            this.BTN_IDX.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_IDX.ForeColor = System.Drawing.Color.Black;
            this.BTN_IDX.Location = new System.Drawing.Point(49, 504);
            this.BTN_IDX.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_IDX.Name = "BTN_IDX";
            this.BTN_IDX.Size = new System.Drawing.Size(181, 70);
            this.BTN_IDX.TabIndex = 18;
            this.BTN_IDX.Text = "Write All Index";
            this.BTN_IDX.UseVisualStyleBackColor = false;
            this.BTN_IDX.Click += new System.EventHandler(this.BTN_IDX_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LBL_STATUS);
            this.groupBox1.Controls.Add(this.Memory_Grid);
            this.groupBox1.Controls.Add(this.LB_TCAM);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 487);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Editor";
            // 
            // MAINSTATUS_STRIP
            // 
            this.MAINSTATUS_STRIP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_ROOM,
            this.LBL_CID,
            this.LBL_POS_X,
            this.LBL_POS_Y,
            this.LBL_POS_Z,
            this.LBL_MEMOFF,
            this.LBL_VERSION,
            this.BTN_STAT_HOOK,
            this.PRG_LOAD});
            this.MAINSTATUS_STRIP.Location = new System.Drawing.Point(0, 580);
            this.MAINSTATUS_STRIP.Name = "MAINSTATUS_STRIP";
            this.MAINSTATUS_STRIP.Size = new System.Drawing.Size(454, 24);
            this.MAINSTATUS_STRIP.TabIndex = 22;
            this.MAINSTATUS_STRIP.Text = "statusStrip1";
            // 
            // LBL_ROOM
            // 
            this.LBL_ROOM.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_ROOM.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_ROOM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_ROOM.Name = "LBL_ROOM";
            this.LBL_ROOM.Size = new System.Drawing.Size(61, 19);
            this.LBL_ROOM.Text = "ROOM ID";
            // 
            // LBL_CID
            // 
            this.LBL_CID.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_CID.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_CID.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_CID.Name = "LBL_CID";
            this.LBL_CID.Size = new System.Drawing.Size(52, 19);
            this.LBL_CID.Text = "CAM ID";
            // 
            // LBL_POS_X
            // 
            this.LBL_POS_X.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_POS_X.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_POS_X.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_POS_X.Name = "LBL_POS_X";
            this.LBL_POS_X.Size = new System.Drawing.Size(21, 19);
            this.LBL_POS_X.Text = "X:";
            // 
            // LBL_POS_Y
            // 
            this.LBL_POS_Y.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_POS_Y.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_POS_Y.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_POS_Y.Name = "LBL_POS_Y";
            this.LBL_POS_Y.Size = new System.Drawing.Size(21, 19);
            this.LBL_POS_Y.Text = "Y:";
            // 
            // LBL_POS_Z
            // 
            this.LBL_POS_Z.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_POS_Z.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_POS_Z.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_POS_Z.Name = "LBL_POS_Z";
            this.LBL_POS_Z.Size = new System.Drawing.Size(21, 19);
            this.LBL_POS_Z.Text = "Z:";
            // 
            // LBL_MEMOFF
            // 
            this.LBL_MEMOFF.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_MEMOFF.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_MEMOFF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_MEMOFF.Name = "LBL_MEMOFF";
            this.LBL_MEMOFF.Size = new System.Drawing.Size(19, 19);
            this.LBL_MEMOFF.Text = "{}";
            // 
            // LBL_VERSION
            // 
            this.LBL_VERSION.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_VERSION.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_VERSION.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_VERSION.Name = "LBL_VERSION";
            this.LBL_VERSION.Size = new System.Drawing.Size(19, 19);
            this.LBL_VERSION.Text = "{}";
            // 
            // BTN_STAT_HOOK
            // 
            this.BTN_STAT_HOOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_STAT_HOOK.Image = ((System.Drawing.Image)(resources.GetObject("BTN_STAT_HOOK.Image")));
            this.BTN_STAT_HOOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_STAT_HOOK.Name = "BTN_STAT_HOOK";
            this.BTN_STAT_HOOK.Size = new System.Drawing.Size(32, 22);
            this.BTN_STAT_HOOK.Text = "toolStripSplitButton1";
            this.BTN_STAT_HOOK.ButtonClick += new System.EventHandler(this.BTN_STAT_HOOK_ButtonClick);
            // 
            // PRG_LOAD
            // 
            this.PRG_LOAD.Name = "PRG_LOAD";
            this.PRG_LOAD.Size = new System.Drawing.Size(500, 18);
            this.PRG_LOAD.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // Interval_Timer
            // 
            this.Interval_Timer.Tick += new System.EventHandler(this.Interval_Timer_Tick);
            // 
            // FRM_RDT_MEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(454, 604);
            this.Controls.Add(this.MAINSTATUS_STRIP);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTN_UPDATE);
            this.Controls.Add(this.BTN_IDX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_RDT_MEM";
            this.Text = "Dynamic Camera Manager";
            this.Load += new System.EventHandler(this.FRM_RDT_MEM_Load);
            this.groupBox1.ResumeLayout(false);
            this.MAINSTATUS_STRIP.ResumeLayout(false);
            this.MAINSTATUS_STRIP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBL_STATUS;
        private System.Windows.Forms.ListBox LB_TCAM;
        public System.Windows.Forms.PropertyGrid Memory_Grid;
        private System.Windows.Forms.Button BTN_UPDATE;
        private System.Windows.Forms.Button BTN_IDX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip MAINSTATUS_STRIP;
        private System.Windows.Forms.ToolStripStatusLabel LBL_ROOM;
        private System.Windows.Forms.ToolStripStatusLabel LBL_CID;
        private System.Windows.Forms.ToolStripStatusLabel LBL_POS_X;
        private System.Windows.Forms.ToolStripStatusLabel LBL_POS_Y;
        private System.Windows.Forms.ToolStripStatusLabel LBL_POS_Z;
        private System.Windows.Forms.ToolStripStatusLabel LBL_MEMOFF;
        private System.Windows.Forms.ToolStripSplitButton BTN_STAT_HOOK;
        private System.Windows.Forms.ToolStripProgressBar PRG_LOAD;
        private System.Windows.Forms.Timer Interval_Timer;
        private System.Windows.Forms.ToolStripStatusLabel LBL_VERSION;
    }
}