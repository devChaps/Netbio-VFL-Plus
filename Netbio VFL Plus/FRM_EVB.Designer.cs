namespace Netbio_VFL_Plus
{
    partial class FRM_EVB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_EVB));
            this.LV_BYTECODE = new System.Windows.Forms.ListView();
            this.Clm_Line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_INTCODE = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PG_OPCODE = new System.Windows.Forms.PropertyGrid();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Progressbar00 = new System.Windows.Forms.ToolStripProgressBar();
            this.BTN_TOGGLE = new System.Windows.Forms.ToolStripSplitButton();
            this.EVB_DEBUG = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_TOGGLE = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.TSB_SCRIPT_DUMP = new System.Windows.Forms.ToolStripButton();
            this.TB_DETAILS = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_BYTECODE
            // 
            this.LV_BYTECODE.BackColor = System.Drawing.SystemColors.InfoText;
            this.LV_BYTECODE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Clm_Line,
            this.columnHeader12,
            this.columnHeader13});
            this.LV_BYTECODE.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.LV_BYTECODE.ForeColor = System.Drawing.SystemColors.Window;
            this.LV_BYTECODE.FullRowSelect = true;
            this.LV_BYTECODE.HideSelection = false;
            this.LV_BYTECODE.Location = new System.Drawing.Point(1, 134);
            this.LV_BYTECODE.Name = "LV_BYTECODE";
            this.LV_BYTECODE.Size = new System.Drawing.Size(998, 623);
            this.LV_BYTECODE.TabIndex = 1;
            this.LV_BYTECODE.UseCompatibleStateImageBehavior = false;
            this.LV_BYTECODE.View = System.Windows.Forms.View.Details;
            this.LV_BYTECODE.SelectedIndexChanged += new System.EventHandler(this.LV_BYTECODE_SelectedIndexChanged);
            // 
            // Clm_Line
            // 
            this.Clm_Line.Text = "Line";
            this.Clm_Line.Width = 66;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "BYTE CODE";
            this.columnHeader12.Width = 590;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Comment";
            this.columnHeader13.Width = 437;
            // 
            // LV_INTCODE
            // 
            this.LV_INTCODE.BackColor = System.Drawing.SystemColors.InfoText;
            this.LV_INTCODE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader14,
            this.columnHeader15});
            this.LV_INTCODE.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.LV_INTCODE.ForeColor = System.Drawing.SystemColors.Window;
            this.LV_INTCODE.FullRowSelect = true;
            this.LV_INTCODE.HideSelection = false;
            this.LV_INTCODE.Location = new System.Drawing.Point(0, 134);
            this.LV_INTCODE.Name = "LV_INTCODE";
            this.LV_INTCODE.Size = new System.Drawing.Size(998, 623);
            this.LV_INTCODE.TabIndex = 2;
            this.LV_INTCODE.UseCompatibleStateImageBehavior = false;
            this.LV_INTCODE.View = System.Windows.Forms.View.Details;
            this.LV_INTCODE.SelectedIndexChanged += new System.EventHandler(this.LV_INTCODE_SelectedIndexChanged);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Line";
            this.columnHeader11.Width = 66;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Interpreted Code";
            this.columnHeader14.Width = 590;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Comment";
            this.columnHeader15.Width = 437;
            // 
            // PG_OPCODE
            // 
            this.PG_OPCODE.Location = new System.Drawing.Point(1009, 54);
            this.PG_OPCODE.Name = "PG_OPCODE";
            this.PG_OPCODE.Size = new System.Drawing.Size(218, 816);
            this.PG_OPCODE.TabIndex = 3;
            this.PG_OPCODE.ToolbarVisible = false;
            this.PG_OPCODE.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Progressbar00,
            this.BTN_TOGGLE});
            this.statusStrip1.Location = new System.Drawing.Point(0, 860);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1227, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Progressbar00
            // 
            this.Progressbar00.Name = "Progressbar00";
            this.Progressbar00.Size = new System.Drawing.Size(100, 16);
            // 
            // BTN_TOGGLE
            // 
            this.BTN_TOGGLE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_TOGGLE.Image = ((System.Drawing.Image)(resources.GetObject("BTN_TOGGLE.Image")));
            this.BTN_TOGGLE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_TOGGLE.Name = "BTN_TOGGLE";
            this.BTN_TOGGLE.Size = new System.Drawing.Size(32, 20);
            this.BTN_TOGGLE.Text = "toolStripSplitButton1";
            this.BTN_TOGGLE.ButtonClick += new System.EventHandler(this.BTN_TOGGLE_ButtonClick);
            // 
            // EVB_DEBUG
            // 
            this.EVB_DEBUG.BackColor = System.Drawing.SystemColors.WindowText;
            this.EVB_DEBUG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EVB_DEBUG.Font = new System.Drawing.Font("Bahnschrift SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EVB_DEBUG.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.EVB_DEBUG.Location = new System.Drawing.Point(1, 763);
            this.EVB_DEBUG.Name = "EVB_DEBUG";
            this.EVB_DEBUG.Size = new System.Drawing.Size(997, 94);
            this.EVB_DEBUG.TabIndex = 5;
            this.EVB_DEBUG.Text = "EVB_DEBUG";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.TSB_TOGGLE,
            this.TSB_SCRIPT_DUMP});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1227, 51);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSB_TOGGLE
            // 
            this.TSB_TOGGLE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_TOGGLE.Image = ((System.Drawing.Image)(resources.GetObject("TSB_TOGGLE.Image")));
            this.TSB_TOGGLE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_TOGGLE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_TOGGLE.Name = "TSB_TOGGLE";
            this.TSB_TOGGLE.Size = new System.Drawing.Size(47, 48);
            this.TSB_TOGGLE.Text = "toolStripButton1";
            this.TSB_TOGGLE.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(49, 48);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // TSB_SCRIPT_DUMP
            // 
            this.TSB_SCRIPT_DUMP.AutoSize = false;
            this.TSB_SCRIPT_DUMP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_SCRIPT_DUMP.Image = ((System.Drawing.Image)(resources.GetObject("TSB_SCRIPT_DUMP.Image")));
            this.TSB_SCRIPT_DUMP.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSB_SCRIPT_DUMP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_SCRIPT_DUMP.Name = "TSB_SCRIPT_DUMP";
            this.TSB_SCRIPT_DUMP.Size = new System.Drawing.Size(48, 48);
            this.TSB_SCRIPT_DUMP.Text = "toolStripButton3";
            this.TSB_SCRIPT_DUMP.Click += new System.EventHandler(this.TSB_SCRIPT_DUMP_Click);
            // 
            // TB_DETAILS
            // 
            this.TB_DETAILS.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TB_DETAILS.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DETAILS.ForeColor = System.Drawing.Color.SeaShell;
            this.TB_DETAILS.Location = new System.Drawing.Point(1, 80);
            this.TB_DETAILS.Name = "TB_DETAILS";
            this.TB_DETAILS.Size = new System.Drawing.Size(998, 48);
            this.TB_DETAILS.TabIndex = 7;
            this.TB_DETAILS.Text = "This Text Field is to give you details about the selected opcode (if it is known)" +
    "\n";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(997, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "CODE DETAILS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRM_EVB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 882);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_DETAILS);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.EVB_DEBUG);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PG_OPCODE);
            this.Controls.Add(this.LV_INTCODE);
            this.Controls.Add(this.LV_BYTECODE);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_EVB";
            this.Text = "GAME SCRIPT MANAGER";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader Clm_Line;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        public System.Windows.Forms.ListView LV_BYTECODE;
        public System.Windows.Forms.ListView LV_INTCODE;
        public System.Windows.Forms.PropertyGrid PG_OPCODE;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripProgressBar Progressbar00;
        private System.Windows.Forms.ToolStripSplitButton BTN_TOGGLE;
        public System.Windows.Forms.RichTextBox EVB_DEBUG;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSB_TOGGLE;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton TSB_SCRIPT_DUMP;
        private System.Windows.Forms.RichTextBox TB_DETAILS;
        private System.Windows.Forms.Label label1;
    }
}