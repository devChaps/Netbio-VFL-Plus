namespace Netbio_VFL_Plus
{
    partial class FRM_ItemMemory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ItemMemory));
            this.LV_IMEM = new System.Windows.Forms.ListView();
            this.clm_idx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imem_toolstrip = new System.Windows.Forms.ToolStrip();
            this.imem_mainmenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.rescanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combinationDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imem_statuslbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pg_imem = new System.Windows.Forms.PropertyGrid();
            this.imem_dbglog = new System.Windows.Forms.RichTextBox();
            this.IMEM_TIMER = new System.Windows.Forms.Timer(this.components);
            this.nud_itemval = new System.Windows.Forms.NumericUpDown();
            this.nud_soundval = new System.Windows.Forms.NumericUpDown();
            this.nud_mtype = new System.Windows.Forms.NumericUpDown();
            this.nud_durabillity = new System.Windows.Forms.NumericUpDown();
            this.nud_iprops = new System.Windows.Forms.NumericUpDown();
            this.cmb_itemList = new System.Windows.Forms.ComboBox();
            this.GB_IMEM = new System.Windows.Forms.GroupBox();
            this.BTN_UPDATE = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.imem_toolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_itemval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_soundval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mtype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_durabillity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_iprops)).BeginInit();
            this.GB_IMEM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // LV_IMEM
            // 
            this.LV_IMEM.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LV_IMEM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_idx,
            this.clm_offset,
            this.clm_value});
            this.LV_IMEM.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.LV_IMEM.FullRowSelect = true;
            this.LV_IMEM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_IMEM.HideSelection = false;
            this.LV_IMEM.Location = new System.Drawing.Point(0, 43);
            this.LV_IMEM.Name = "LV_IMEM";
            this.LV_IMEM.Size = new System.Drawing.Size(380, 404);
            this.LV_IMEM.TabIndex = 2;
            this.LV_IMEM.UseCompatibleStateImageBehavior = false;
            this.LV_IMEM.View = System.Windows.Forms.View.Details;
            this.LV_IMEM.SelectedIndexChanged += new System.EventHandler(this.LV_IMEM_SelectedIndexChanged);
            this.LV_IMEM.Leave += new System.EventHandler(this.LV_IMEM_Leave);
            // 
            // clm_idx
            // 
            this.clm_idx.Text = "Index";
            this.clm_idx.Width = 47;
            // 
            // clm_offset
            // 
            this.clm_offset.Text = "Offset";
            this.clm_offset.Width = 102;
            // 
            // clm_value
            // 
            this.clm_value.Text = "Item";
            this.clm_value.Width = 185;
            // 
            // imem_toolstrip
            // 
            this.imem_toolstrip.AutoSize = false;
            this.imem_toolstrip.BackColor = System.Drawing.Color.White;
            this.imem_toolstrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imem_toolstrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.imem_toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imem_mainmenu,
            this.toolStripSeparator1,
            this.imem_statuslbl,
            this.toolStripSeparator2});
            this.imem_toolstrip.Location = new System.Drawing.Point(0, 0);
            this.imem_toolstrip.Name = "imem_toolstrip";
            this.imem_toolstrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.imem_toolstrip.Size = new System.Drawing.Size(953, 40);
            this.imem_toolstrip.TabIndex = 11;
            this.imem_toolstrip.Text = "toolStrip1";
            // 
            // imem_mainmenu
            // 
            this.imem_mainmenu.AutoSize = false;
            this.imem_mainmenu.BackColor = System.Drawing.Color.Transparent;
            this.imem_mainmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imem_mainmenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imem_mainmenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rescanToolStripMenuItem,
            this.queriesToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.imem_mainmenu.ForeColor = System.Drawing.Color.Crimson;
            this.imem_mainmenu.Image = ((System.Drawing.Image)(resources.GetObject("imem_mainmenu.Image")));
            this.imem_mainmenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imem_mainmenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imem_mainmenu.Name = "imem_mainmenu";
            this.imem_mainmenu.ShowDropDownArrow = false;
            this.imem_mainmenu.Size = new System.Drawing.Size(40, 40);
            this.imem_mainmenu.Text = "toolStripDropDownButton1";
            // 
            // rescanToolStripMenuItem
            // 
            this.rescanToolStripMenuItem.Name = "rescanToolStripMenuItem";
            this.rescanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.rescanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rescanToolStripMenuItem.Text = "Rescan";
            this.rescanToolStripMenuItem.Click += new System.EventHandler(this.rescanToolStripMenuItem_Click);
            // 
            // queriesToolStripMenuItem
            // 
            this.queriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemValueToolStripMenuItem,
            this.itemNameToolStripMenuItem,
            this.combinationDataToolStripMenuItem});
            this.queriesToolStripMenuItem.Name = "queriesToolStripMenuItem";
            this.queriesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.queriesToolStripMenuItem.Text = "Queries";
            // 
            // itemValueToolStripMenuItem
            // 
            this.itemValueToolStripMenuItem.Name = "itemValueToolStripMenuItem";
            this.itemValueToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.itemValueToolStripMenuItem.Text = "Item Value";
            // 
            // itemNameToolStripMenuItem
            // 
            this.itemNameToolStripMenuItem.Name = "itemNameToolStripMenuItem";
            this.itemNameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.itemNameToolStripMenuItem.Text = "Item Name";
            // 
            // combinationDataToolStripMenuItem
            // 
            this.combinationDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugLogToolStripMenuItem});
            this.combinationDataToolStripMenuItem.Name = "combinationDataToolStripMenuItem";
            this.combinationDataToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.combinationDataToolStripMenuItem.Text = "Combination Data";
            // 
            // debugLogToolStripMenuItem
            // 
            this.debugLogToolStripMenuItem.Name = "debugLogToolStripMenuItem";
            this.debugLogToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.debugLogToolStripMenuItem.Text = "Debug Log";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.CheckOnClick = true;
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // imem_statuslbl
            // 
            this.imem_statuslbl.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imem_statuslbl.ForeColor = System.Drawing.Color.Navy;
            this.imem_statuslbl.Name = "imem_statuslbl";
            this.imem_statuslbl.Size = new System.Drawing.Size(166, 37);
            this.imem_statuslbl.Text = "PCSX2 STATUS";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // pg_imem
            // 
            this.pg_imem.BackColor = System.Drawing.SystemColors.ControlText;
            this.pg_imem.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pg_imem.CategorySplitterColor = System.Drawing.SystemColors.ControlText;
            this.pg_imem.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(173)))));
            this.pg_imem.LineColor = System.Drawing.Color.Black;
            this.pg_imem.Location = new System.Drawing.Point(693, 43);
            this.pg_imem.Name = "pg_imem";
            this.pg_imem.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pg_imem.Size = new System.Drawing.Size(260, 404);
            this.pg_imem.TabIndex = 23;
            this.pg_imem.ToolbarVisible = false;
            this.pg_imem.ViewBackColor = System.Drawing.Color.Black;
            this.pg_imem.ViewForeColor = System.Drawing.Color.NavajoWhite;
            this.pg_imem.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_imem_PropertyValueChanged);
            // 
            // imem_dbglog
            // 
            this.imem_dbglog.BackColor = System.Drawing.SystemColors.WindowText;
            this.imem_dbglog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imem_dbglog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imem_dbglog.Location = new System.Drawing.Point(0, 453);
            this.imem_dbglog.Name = "imem_dbglog";
            this.imem_dbglog.Size = new System.Drawing.Size(941, 163);
            this.imem_dbglog.TabIndex = 24;
            this.imem_dbglog.Text = "";
            // 
            // IMEM_TIMER
            // 
            this.IMEM_TIMER.Enabled = true;
            this.IMEM_TIMER.Interval = 1;
            this.IMEM_TIMER.Tick += new System.EventHandler(this.IMEM_TIMER_Tick);
            // 
            // nud_itemval
            // 
            this.nud_itemval.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_itemval.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_itemval.Location = new System.Drawing.Point(0, 51);
            this.nud_itemval.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_itemval.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.nud_itemval.Name = "nud_itemval";
            this.nud_itemval.Size = new System.Drawing.Size(166, 20);
            this.nud_itemval.TabIndex = 14;
            // 
            // nud_soundval
            // 
            this.nud_soundval.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_soundval.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_soundval.Location = new System.Drawing.Point(0, 188);
            this.nud_soundval.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_soundval.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.nud_soundval.Name = "nud_soundval";
            this.nud_soundval.Size = new System.Drawing.Size(145, 20);
            this.nud_soundval.TabIndex = 16;
            // 
            // nud_mtype
            // 
            this.nud_mtype.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_mtype.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_mtype.Location = new System.Drawing.Point(148, 124);
            this.nud_mtype.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_mtype.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.nud_mtype.Name = "nud_mtype";
            this.nud_mtype.Size = new System.Drawing.Size(147, 20);
            this.nud_mtype.TabIndex = 22;
            // 
            // nud_durabillity
            // 
            this.nud_durabillity.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_durabillity.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_durabillity.Location = new System.Drawing.Point(0, 124);
            this.nud_durabillity.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_durabillity.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.nud_durabillity.Name = "nud_durabillity";
            this.nud_durabillity.Size = new System.Drawing.Size(142, 20);
            this.nud_durabillity.TabIndex = 20;
            // 
            // nud_iprops
            // 
            this.nud_iprops.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_iprops.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_iprops.Location = new System.Drawing.Point(184, 51);
            this.nud_iprops.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.nud_iprops.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.nud_iprops.Name = "nud_iprops";
            this.nud_iprops.Size = new System.Drawing.Size(97, 20);
            this.nud_iprops.TabIndex = 18;
            // 
            // cmb_itemList
            // 
            this.cmb_itemList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmb_itemList.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.cmb_itemList.FormattingEnabled = true;
            this.cmb_itemList.Location = new System.Drawing.Point(0, 28);
            this.cmb_itemList.Name = "cmb_itemList";
            this.cmb_itemList.Size = new System.Drawing.Size(166, 21);
            this.cmb_itemList.TabIndex = 13;
            this.cmb_itemList.Text = "Item Name";
            // 
            // GB_IMEM
            // 
            this.GB_IMEM.Controls.Add(this.label5);
            this.GB_IMEM.Controls.Add(this.numericUpDown1);
            this.GB_IMEM.Controls.Add(this.BTN_UPDATE);
            this.GB_IMEM.Controls.Add(this.label4);
            this.GB_IMEM.Controls.Add(this.label3);
            this.GB_IMEM.Controls.Add(this.label2);
            this.GB_IMEM.Controls.Add(this.label1);
            this.GB_IMEM.Controls.Add(this.cmb_itemList);
            this.GB_IMEM.Controls.Add(this.nud_itemval);
            this.GB_IMEM.Controls.Add(this.nud_iprops);
            this.GB_IMEM.Controls.Add(this.nud_durabillity);
            this.GB_IMEM.Controls.Add(this.nud_mtype);
            this.GB_IMEM.Controls.Add(this.nud_soundval);
            this.GB_IMEM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GB_IMEM.Location = new System.Drawing.Point(386, 43);
            this.GB_IMEM.Name = "GB_IMEM";
            this.GB_IMEM.Size = new System.Drawing.Size(301, 404);
            this.GB_IMEM.TabIndex = 25;
            this.GB_IMEM.TabStop = false;
            this.GB_IMEM.Text = "Item Data";
            // 
            // BTN_UPDATE
            // 
            this.BTN_UPDATE.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_UPDATE.Location = new System.Drawing.Point(0, 361);
            this.BTN_UPDATE.Name = "BTN_UPDATE";
            this.BTN_UPDATE.Size = new System.Drawing.Size(301, 37);
            this.BTN_UPDATE.TabIndex = 30;
            this.BTN_UPDATE.Text = "UPDATE ITEM";
            this.BTN_UPDATE.UseVisualStyleBackColor = true;
            this.BTN_UPDATE.Click += new System.EventHandler(this.BTN_UPDATE_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 23);
            this.label4.TabIndex = 29;
            this.label4.Text = "Sound ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Durabillity";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Menu Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Item Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(151, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "Effect ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numericUpDown1.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.numericUpDown1.Location = new System.Drawing.Point(151, 188);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(145, 20);
            this.numericUpDown1.TabIndex = 31;
            // 
            // FRM_ItemMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 611);
            this.Controls.Add(this.GB_IMEM);
            this.Controls.Add(this.imem_dbglog);
            this.Controls.Add(this.pg_imem);
            this.Controls.Add(this.imem_toolstrip);
            this.Controls.Add(this.LV_IMEM);
            this.Name = "FRM_ItemMemory";
            this.Text = "Item Memory Module";
            this.imem_toolstrip.ResumeLayout(false);
            this.imem_toolstrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_itemval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_soundval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mtype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_durabillity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_iprops)).EndInit();
            this.GB_IMEM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LV_IMEM;
        private System.Windows.Forms.ColumnHeader clm_idx;
        private System.Windows.Forms.ColumnHeader clm_offset;
        private System.Windows.Forms.ColumnHeader clm_value;
        private System.Windows.Forms.ToolStrip imem_toolstrip;
        private System.Windows.Forms.ToolStripDropDownButton imem_mainmenu;
        private System.Windows.Forms.ToolStripMenuItem rescanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combinationDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel imem_statuslbl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PropertyGrid pg_imem;
        private System.Windows.Forms.RichTextBox imem_dbglog;
        private System.Windows.Forms.Timer IMEM_TIMER;
        private System.Windows.Forms.NumericUpDown nud_itemval;
        private System.Windows.Forms.NumericUpDown nud_soundval;
        private System.Windows.Forms.NumericUpDown nud_mtype;
        private System.Windows.Forms.NumericUpDown nud_durabillity;
        private System.Windows.Forms.NumericUpDown nud_iprops;
        public System.Windows.Forms.ComboBox cmb_itemList;
        private System.Windows.Forms.GroupBox GB_IMEM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_UPDATE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}