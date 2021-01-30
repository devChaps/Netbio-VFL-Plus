namespace Netbio_VFL_Plus
{
    partial class FRM_RDT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_RDT));
            this.LV_RDT = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RDT_sStrip = new System.Windows.Forms.StatusStrip();
            this.LBL_RDT_OFFSET = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_RDTSIZE = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_RDT_OFF = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_RDTSELECT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BTN_SGL = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.RDT_sStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_RDT
            // 
            this.LV_RDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LV_RDT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader1});
            this.LV_RDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_RDT.ForeColor = System.Drawing.SystemColors.Window;
            this.LV_RDT.FullRowSelect = true;
            this.LV_RDT.GridLines = true;
            this.LV_RDT.HideSelection = false;
            this.LV_RDT.Location = new System.Drawing.Point(12, 62);
            this.LV_RDT.Name = "LV_RDT";
            this.LV_RDT.Size = new System.Drawing.Size(536, 523);
            this.LV_RDT.TabIndex = 1;
            this.LV_RDT.UseCompatibleStateImageBehavior = false;
            this.LV_RDT.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "#";
            this.columnHeader7.Width = 35;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Offset";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Size";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Block ID";
            this.columnHeader10.Width = 111;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 135;
            // 
            // RDT_sStrip
            // 
            this.RDT_sStrip.AutoSize = false;
            this.RDT_sStrip.BackColor = System.Drawing.Color.LavenderBlush;
            this.RDT_sStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_RDT_OFFSET,
            this.LBL_RDTSIZE,
            this.LBL_RDT_OFF,
            this.LBL_RDTSELECT});
            this.RDT_sStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.RDT_sStrip.Location = new System.Drawing.Point(0, 586);
            this.RDT_sStrip.Name = "RDT_sStrip";
            this.RDT_sStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.RDT_sStrip.Size = new System.Drawing.Size(560, 38);
            this.RDT_sStrip.SizingGrip = false;
            this.RDT_sStrip.TabIndex = 5;
            this.RDT_sStrip.Text = "statusStrip2";
            // 
            // LBL_RDT_OFFSET
            // 
            this.LBL_RDT_OFFSET.AutoSize = false;
            this.LBL_RDT_OFFSET.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LBL_RDT_OFFSET.ForeColor = System.Drawing.Color.Cyan;
            this.LBL_RDT_OFFSET.Name = "LBL_RDT_OFFSET";
            this.LBL_RDT_OFFSET.Size = new System.Drawing.Size(15, 38);
            // 
            // LBL_RDTSIZE
            // 
            this.LBL_RDTSIZE.AutoSize = false;
            this.LBL_RDTSIZE.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.LBL_RDTSIZE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LBL_RDTSIZE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LBL_RDTSIZE.Name = "LBL_RDTSIZE";
            this.LBL_RDTSIZE.Size = new System.Drawing.Size(100, 38);
            this.LBL_RDTSIZE.Text = "{RDT SIZE}";
            // 
            // LBL_RDT_OFF
            // 
            this.LBL_RDT_OFF.AutoSize = false;
            this.LBL_RDT_OFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.LBL_RDT_OFF.ForeColor = System.Drawing.Color.Black;
            this.LBL_RDT_OFF.Name = "LBL_RDT_OFF";
            this.LBL_RDT_OFF.Size = new System.Drawing.Size(150, 38);
            this.LBL_RDT_OFF.Text = "{RDT OFF}";
            // 
            // LBL_RDTSELECT
            // 
            this.LBL_RDTSELECT.ActiveLinkColor = System.Drawing.Color.Black;
            this.LBL_RDTSELECT.AutoSize = false;
            this.LBL_RDTSELECT.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.LBL_RDTSELECT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_RDTSELECT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LBL_RDTSELECT.Name = "LBL_RDTSELECT";
            this.LBL_RDTSELECT.Size = new System.Drawing.Size(100, 38);
            this.LBL_RDTSELECT.Text = "{Selected RDT}";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripButton1,
            this.BTN_SGL,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(560, 55);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton1.Text = "toolStripButton4";
            // 
            // BTN_SGL
            // 
            this.BTN_SGL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_SGL.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SGL.Image")));
            this.BTN_SGL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTN_SGL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_SGL.Name = "BTN_SGL";
            this.BTN_SGL.Size = new System.Drawing.Size(52, 52);
            this.BTN_SGL.Text = "toolStripButton4";
            this.BTN_SGL.Click += new System.EventHandler(this.BTN_SGL_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 52);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // FRM_RDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(560, 624);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.RDT_sStrip);
            this.Controls.Add(this.LV_RDT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_RDT";
            this.Text = "RDT MANAGER";
            this.RDT_sStrip.ResumeLayout(false);
            this.RDT_sStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        public System.Windows.Forms.ListView LV_RDT;
        private System.Windows.Forms.StatusStrip RDT_sStrip;
        private System.Windows.Forms.ToolStripStatusLabel LBL_RDT_OFFSET;
        public System.Windows.Forms.ToolStripStatusLabel LBL_RDTSIZE;
        public System.Windows.Forms.ToolStripStatusLabel LBL_RDT_OFF;
        public System.Windows.Forms.ToolStripStatusLabel LBL_RDTSELECT;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton BTN_SGL;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}