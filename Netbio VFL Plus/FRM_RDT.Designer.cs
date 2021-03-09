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
            this.components = new System.ComponentModel.Container();
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
            this.BTN_UNPACK = new System.Windows.Forms.ToolStripButton();
            this.BTN_CAM = new System.Windows.Forms.ToolStripButton();
            this.BTN_LIG = new System.Windows.Forms.ToolStripButton();
            this.BTN_SOUND = new System.Windows.Forms.ToolStripButton();
            this.BTN_SGL = new System.Windows.Forms.ToolStripButton();
            this.BTN_MOMO = new System.Windows.Forms.ToolStripButton();
            this.RDT_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unpackSubFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpackSelectedSubFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repackAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repackIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSelectedMemoryRegionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interpretSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RDT_sStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.RDT_ContextMenu.SuspendLayout();
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
            this.LV_RDT.Size = new System.Drawing.Size(532, 523);
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
            this.RDT_sStrip.Size = new System.Drawing.Size(547, 38);
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
            this.LBL_RDTSELECT.Size = new System.Drawing.Size(200, 38);
            this.LBL_RDTSELECT.Text = "{Selected RDT}";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTN_UNPACK,
            this.BTN_CAM,
            this.BTN_LIG,
            this.BTN_SOUND,
            this.BTN_SGL,
            this.BTN_MOMO});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(547, 55);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTN_UNPACK
            // 
            this.BTN_UNPACK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_UNPACK.Image = ((System.Drawing.Image)(resources.GetObject("BTN_UNPACK.Image")));
            this.BTN_UNPACK.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTN_UNPACK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_UNPACK.Name = "BTN_UNPACK";
            this.BTN_UNPACK.Size = new System.Drawing.Size(52, 52);
            this.BTN_UNPACK.Text = "Unpack";
            this.BTN_UNPACK.Click += new System.EventHandler(this.BTN_UNPACK_Click);
            // 
            // BTN_CAM
            // 
            this.BTN_CAM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_CAM.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CAM.Image")));
            this.BTN_CAM.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTN_CAM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_CAM.Name = "BTN_CAM";
            this.BTN_CAM.Size = new System.Drawing.Size(52, 52);
            this.BTN_CAM.Text = "Camera Manager";
            this.BTN_CAM.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // BTN_LIG
            // 
            this.BTN_LIG.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_LIG.Image = ((System.Drawing.Image)(resources.GetObject("BTN_LIG.Image")));
            this.BTN_LIG.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTN_LIG.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_LIG.Name = "BTN_LIG";
            this.BTN_LIG.Size = new System.Drawing.Size(52, 52);
            this.BTN_LIG.Text = "Light Manager";
            // 
            // BTN_SOUND
            // 
            this.BTN_SOUND.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_SOUND.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SOUND.Image")));
            this.BTN_SOUND.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTN_SOUND.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_SOUND.Name = "BTN_SOUND";
            this.BTN_SOUND.Size = new System.Drawing.Size(52, 52);
            this.BTN_SOUND.Text = "GRD SOUND ZONE";
            this.BTN_SOUND.Click += new System.EventHandler(this.BTN_SOUND_Click);
            // 
            // BTN_SGL
            // 
            this.BTN_SGL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_SGL.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SGL.Image")));
            this.BTN_SGL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BTN_SGL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_SGL.Name = "BTN_SGL";
            this.BTN_SGL.Size = new System.Drawing.Size(52, 52);
            this.BTN_SGL.Text = "Script Handler";
            this.BTN_SGL.Click += new System.EventHandler(this.BTN_SGL_Click);
            // 
            // BTN_MOMO
            // 
            this.BTN_MOMO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_MOMO.Image = ((System.Drawing.Image)(resources.GetObject("BTN_MOMO.Image")));
            this.BTN_MOMO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_MOMO.Name = "BTN_MOMO";
            this.BTN_MOMO.Size = new System.Drawing.Size(23, 52);
            this.BTN_MOMO.Text = "toolStripButton1";
            // 
            // RDT_ContextMenu
            // 
            this.RDT_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unpackSubFormatsToolStripMenuItem,
            this.unpackSelectedSubFormatToolStripMenuItem,
            this.repackAllToolStripMenuItem,
            this.repackIndexToolStripMenuItem,
            this.viewSelectedMemoryRegionToolStripMenuItem,
            this.interpretSelectedToolStripMenuItem});
            this.RDT_ContextMenu.Name = "RDT_ContextMenu";
            this.RDT_ContextMenu.Size = new System.Drawing.Size(235, 136);
            this.RDT_ContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RDT_ContextMenu_Opening);
            // 
            // unpackSubFormatsToolStripMenuItem
            // 
            this.unpackSubFormatsToolStripMenuItem.Name = "unpackSubFormatsToolStripMenuItem";
            this.unpackSubFormatsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.unpackSubFormatsToolStripMenuItem.Text = "Unpack All Sub Formats";
            // 
            // unpackSelectedSubFormatToolStripMenuItem
            // 
            this.unpackSelectedSubFormatToolStripMenuItem.Name = "unpackSelectedSubFormatToolStripMenuItem";
            this.unpackSelectedSubFormatToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.unpackSelectedSubFormatToolStripMenuItem.Text = "Unpack Selected Sub Format";
            // 
            // repackAllToolStripMenuItem
            // 
            this.repackAllToolStripMenuItem.Name = "repackAllToolStripMenuItem";
            this.repackAllToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.repackAllToolStripMenuItem.Text = "Repack All";
            // 
            // repackIndexToolStripMenuItem
            // 
            this.repackIndexToolStripMenuItem.Name = "repackIndexToolStripMenuItem";
            this.repackIndexToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.repackIndexToolStripMenuItem.Text = "Repack Index";
            // 
            // viewSelectedMemoryRegionToolStripMenuItem
            // 
            this.viewSelectedMemoryRegionToolStripMenuItem.Name = "viewSelectedMemoryRegionToolStripMenuItem";
            this.viewSelectedMemoryRegionToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.viewSelectedMemoryRegionToolStripMenuItem.Text = "View Selected Memory Region";
            // 
            // interpretSelectedToolStripMenuItem
            // 
            this.interpretSelectedToolStripMenuItem.Name = "interpretSelectedToolStripMenuItem";
            this.interpretSelectedToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.interpretSelectedToolStripMenuItem.Text = "Interpret Selected";
            // 
            // FRM_RDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(547, 624);
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
            this.RDT_ContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton BTN_CAM;
        private System.Windows.Forms.ToolStripButton BTN_SGL;
        private System.Windows.Forms.ToolStripButton BTN_SOUND;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStripButton BTN_LIG;
        private System.Windows.Forms.ToolStripButton BTN_UNPACK;
        private System.Windows.Forms.ContextMenuStrip RDT_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem unpackSubFormatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpackSelectedSubFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repackAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repackIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSelectedMemoryRegionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interpretSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BTN_MOMO;
    }
}