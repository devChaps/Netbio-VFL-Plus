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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pg_imem = new System.Windows.Forms.PropertyGrid();
            this.IMEM_TIMER = new System.Windows.Forms.Timer(this.components);
            this.nud_itemval = new System.Windows.Forms.NumericUpDown();
            this.nud_soundval = new System.Windows.Forms.NumericUpDown();
            this.nud_mtype = new System.Windows.Forms.NumericUpDown();
            this.nud_durabillity = new System.Windows.Forms.NumericUpDown();
            this.nud_iprops = new System.Windows.Forms.NumericUpDown();
            this.cmb_itemList = new System.Windows.Forms.ComboBox();
            this.GB_IMEM = new System.Windows.Forms.GroupBox();
            this.PB_MTYPE = new System.Windows.Forms.PictureBox();
            this.PB_ITEMID = new System.Windows.Forms.PictureBox();
            this.BTN_UPDATE = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LBL_PCSX2_STATUS = new System.Windows.Forms.ToolStripStatusLabel();
            this.BTN_MEMHOOK = new System.Windows.Forms.ToolStripSplitButton();
            this.ItemIco_List = new System.Windows.Forms.ImageList(this.components);
            this.memoryDumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imem_toolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_itemval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_soundval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mtype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_durabillity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_iprops)).BeginInit();
            this.GB_IMEM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MTYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ITEMID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_IMEM
            // 
            this.LV_IMEM.BackColor = System.Drawing.SystemColors.ControlText;
            this.LV_IMEM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_idx,
            this.clm_offset,
            this.clm_value});
            this.LV_IMEM.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_IMEM.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.LV_IMEM.FullRowSelect = true;
            this.LV_IMEM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LV_IMEM.HideSelection = false;
            this.LV_IMEM.Location = new System.Drawing.Point(0, 53);
            this.LV_IMEM.Name = "LV_IMEM";
            this.LV_IMEM.Size = new System.Drawing.Size(342, 512);
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
            this.imem_toolstrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imem_toolstrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.imem_toolstrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.imem_toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imem_mainmenu,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.imem_toolstrip.Location = new System.Drawing.Point(0, 0);
            this.imem_toolstrip.Name = "imem_toolstrip";
            this.imem_toolstrip.Size = new System.Drawing.Size(1061, 40);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 37);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // pg_imem
            // 
            this.pg_imem.BackColor = System.Drawing.SystemColors.ControlText;
            this.pg_imem.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pg_imem.CategorySplitterColor = System.Drawing.SystemColors.ControlText;
            this.pg_imem.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(173)))));
            this.pg_imem.LineColor = System.Drawing.Color.Black;
            this.pg_imem.Location = new System.Drawing.Point(431, 19);
            this.pg_imem.Name = "pg_imem";
            this.pg_imem.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pg_imem.Size = new System.Drawing.Size(260, 503);
            this.pg_imem.TabIndex = 23;
            this.pg_imem.ToolbarVisible = false;
            this.pg_imem.ViewBackColor = System.Drawing.Color.Black;
            this.pg_imem.ViewForeColor = System.Drawing.Color.NavajoWhite;
            this.pg_imem.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_imem_PropertyValueChanged);
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
            this.nud_itemval.Location = new System.Drawing.Point(186, 412);
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
            this.nud_itemval.Size = new System.Drawing.Size(133, 27);
            this.nud_itemval.TabIndex = 14;
            // 
            // nud_soundval
            // 
            this.nud_soundval.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_soundval.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_soundval.Location = new System.Drawing.Point(274, 103);
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
            this.nud_soundval.Size = new System.Drawing.Size(151, 27);
            this.nud_soundval.TabIndex = 16;
            // 
            // nud_mtype
            // 
            this.nud_mtype.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_mtype.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_mtype.Location = new System.Drawing.Point(6, 250);
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
            this.nud_mtype.Size = new System.Drawing.Size(114, 27);
            this.nud_mtype.TabIndex = 22;
            // 
            // nud_durabillity
            // 
            this.nud_durabillity.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_durabillity.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_durabillity.Location = new System.Drawing.Point(274, 46);
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
            this.nud_durabillity.Size = new System.Drawing.Size(151, 27);
            this.nud_durabillity.TabIndex = 20;
            // 
            // nud_iprops
            // 
            this.nud_iprops.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nud_iprops.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.nud_iprops.Location = new System.Drawing.Point(126, 101);
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
            this.nud_iprops.Size = new System.Drawing.Size(142, 27);
            this.nud_iprops.TabIndex = 18;
            this.nud_iprops.ValueChanged += new System.EventHandler(this.nud_iprops_ValueChanged);
            // 
            // cmb_itemList
            // 
            this.cmb_itemList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmb_itemList.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.cmb_itemList.FormattingEnabled = true;
            this.cmb_itemList.Location = new System.Drawing.Point(126, 45);
            this.cmb_itemList.Name = "cmb_itemList";
            this.cmb_itemList.Size = new System.Drawing.Size(142, 27);
            this.cmb_itemList.TabIndex = 13;
            this.cmb_itemList.Text = "Item Name";
            // 
            // GB_IMEM
            // 
            this.GB_IMEM.Controls.Add(this.PB_MTYPE);
            this.GB_IMEM.Controls.Add(this.PB_ITEMID);
            this.GB_IMEM.Controls.Add(this.BTN_UPDATE);
            this.GB_IMEM.Controls.Add(this.label5);
            this.GB_IMEM.Controls.Add(this.numericUpDown1);
            this.GB_IMEM.Controls.Add(this.pg_imem);
            this.GB_IMEM.Controls.Add(this.label4);
            this.GB_IMEM.Controls.Add(this.label3);
            this.GB_IMEM.Controls.Add(this.label2);
            this.GB_IMEM.Controls.Add(this.nud_soundval);
            this.GB_IMEM.Controls.Add(this.label1);
            this.GB_IMEM.Controls.Add(this.cmb_itemList);
            this.GB_IMEM.Controls.Add(this.nud_itemval);
            this.GB_IMEM.Controls.Add(this.nud_iprops);
            this.GB_IMEM.Controls.Add(this.nud_durabillity);
            this.GB_IMEM.Controls.Add(this.nud_mtype);
            this.GB_IMEM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GB_IMEM.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_IMEM.Location = new System.Drawing.Point(348, 43);
            this.GB_IMEM.Name = "GB_IMEM";
            this.GB_IMEM.Size = new System.Drawing.Size(705, 554);
            this.GB_IMEM.TabIndex = 25;
            this.GB_IMEM.TabStop = false;
            this.GB_IMEM.Text = "Item Data";
            // 
            // PB_MTYPE
            // 
            this.PB_MTYPE.Location = new System.Drawing.Point(6, 159);
            this.PB_MTYPE.Name = "PB_MTYPE";
            this.PB_MTYPE.Size = new System.Drawing.Size(114, 85);
            this.PB_MTYPE.TabIndex = 34;
            this.PB_MTYPE.TabStop = false;
            // 
            // PB_ITEMID
            // 
            this.PB_ITEMID.Location = new System.Drawing.Point(6, 45);
            this.PB_ITEMID.Name = "PB_ITEMID";
            this.PB_ITEMID.Size = new System.Drawing.Size(114, 85);
            this.PB_ITEMID.TabIndex = 33;
            this.PB_ITEMID.TabStop = false;
            // 
            // BTN_UPDATE
            // 
            this.BTN_UPDATE.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_UPDATE.Location = new System.Drawing.Point(0, 459);
            this.BTN_UPDATE.Name = "BTN_UPDATE";
            this.BTN_UPDATE.Size = new System.Drawing.Size(425, 63);
            this.BTN_UPDATE.TabIndex = 30;
            this.BTN_UPDATE.Text = "UPDATE ITEM";
            this.BTN_UPDATE.UseVisualStyleBackColor = true;
            this.BTN_UPDATE.Click += new System.EventHandler(this.BTN_UPDATE_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "Effect ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numericUpDown1.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.numericUpDown1.Location = new System.Drawing.Point(186, 379);
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
            this.numericUpDown1.Size = new System.Drawing.Size(142, 27);
            this.numericUpDown1.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(274, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 23);
            this.label4.TabIndex = 29;
            this.label4.Text = "Sound ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Durabillity/Quantity";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "Menu Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Item Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Courier New", 15.75F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_PCSX2_STATUS,
            this.BTN_MEMHOOK});
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1061, 32);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LBL_PCSX2_STATUS
            // 
            this.LBL_PCSX2_STATUS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LBL_PCSX2_STATUS.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.LBL_PCSX2_STATUS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LBL_PCSX2_STATUS.ForeColor = System.Drawing.Color.Navy;
            this.LBL_PCSX2_STATUS.Name = "LBL_PCSX2_STATUS";
            this.LBL_PCSX2_STATUS.Size = new System.Drawing.Size(170, 27);
            this.LBL_PCSX2_STATUS.Text = "PCSX2 STATUS";
            // 
            // BTN_MEMHOOK
            // 
            this.BTN_MEMHOOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_MEMHOOK.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoryDumpToolStripMenuItem});
            this.BTN_MEMHOOK.Image = ((System.Drawing.Image)(resources.GetObject("BTN_MEMHOOK.Image")));
            this.BTN_MEMHOOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_MEMHOOK.Name = "BTN_MEMHOOK";
            this.BTN_MEMHOOK.Size = new System.Drawing.Size(32, 30);
            this.BTN_MEMHOOK.Text = "toolStripSplitButton1";
            // 
            // ItemIco_List
            // 
            this.ItemIco_List.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ItemIco_List.ImageStream")));
            this.ItemIco_List.TransparentColor = System.Drawing.Color.Transparent;
            this.ItemIco_List.Images.SetKeyName(0, "0gM0pQq.png");
            this.ItemIco_List.Images.SetKeyName(1, "3eKm8bv.png");
            this.ItemIco_List.Images.SetKeyName(2, "4iDnaPi.png");
            this.ItemIco_List.Images.SetKeyName(3, "5ysKkv3.png");
            this.ItemIco_List.Images.SetKeyName(4, "6tbhuV3.png");
            this.ItemIco_List.Images.SetKeyName(5, "7C4STsH.png");
            this.ItemIco_List.Images.SetKeyName(6, "8qjmEnF.png");
            this.ItemIco_List.Images.SetKeyName(7, "8wEKIIR.png");
            this.ItemIco_List.Images.SetKeyName(8, "9Q72uLv.png");
            this.ItemIco_List.Images.SetKeyName(9, "18keawU.png");
            this.ItemIco_List.Images.SetKeyName(10, "a1ADjpn.png");
            this.ItemIco_List.Images.SetKeyName(11, "ace-key.png");
            this.ItemIco_List.Images.SetKeyName(12, "administrators-office-key.png");
            this.ItemIco_List.Images.SetKeyName(13, "alcohol-bottle.png");
            this.ItemIco_List.Images.SetKeyName(14, "alligator-key (1).png");
            this.ItemIco_List.Images.SetKeyName(15, "alligator-key.png");
            this.ItemIco_List.Images.SetKeyName(16, "amethyst-plate.png");
            this.ItemIco_List.Images.SetKeyName(17, "auxiliary-building-key.png");
            this.ItemIco_List.Images.SetKeyName(18, "b2f-key.png");
            this.ItemIco_List.Images.SetKeyName(19, "b2KmNND.png");
            this.ItemIco_List.Images.SetKeyName(20, "b47Iys8.png");
            this.ItemIco_List.Images.SetKeyName(21, "bcr44Et (1).png");
            this.ItemIco_List.Images.SetKeyName(22, "bcr44Et.png");
            this.ItemIco_List.Images.SetKeyName(23, "blank-tape.png");
            this.ItemIco_List.Images.SetKeyName(24, "blood-infusion-pack.png");
            this.ItemIco_List.Images.SetKeyName(25, "blood-pack.png");
            this.ItemIco_List.Images.SetKeyName(26, "blowtorch.png");
            this.ItemIco_List.Images.SetKeyName(27, "blue-jewel.png");
            this.ItemIco_List.Images.SetKeyName(28, "bolt-cutter.png");
            this.ItemIco_List.Images.SetKeyName(29, "brass-spectacles.png");
            this.ItemIco_List.Images.SetKeyName(30, "card-key.png");
            this.ItemIco_List.Images.SetKeyName(31, "card-key-level-1.png");
            this.ItemIco_List.Images.SetKeyName(32, "card-key-level-2.png");
            this.ItemIco_List.Images.SetKeyName(33, "charlies-id-tag.png");
            this.ItemIco_List.Images.SetKeyName(34, "chemical-bottle-solvent.png");
            this.ItemIco_List.Images.SetKeyName(35, "CLhVCtA.png");
            this.ItemIco_List.Images.SetKeyName(36, "cLOZqEh.png");
            this.ItemIco_List.Images.SetKeyName(37, "daylight.png");
            this.ItemIco_List.Images.SetKeyName(38, "detonator.png");
            this.ItemIco_List.Images.SetKeyName(39, "detonator-handle.png");
            this.ItemIco_List.Images.SetKeyName(40, "detonator-main-unit.png");
            this.ItemIco_List.Images.SetKeyName(41, "DwZy1Tk.png");
            this.ItemIco_List.Images.SetKeyName(42, "elephant-key (1).png");
            this.ItemIco_List.Images.SetKeyName(43, "elephant-key.png");
            this.ItemIco_List.Images.SetKeyName(44, "emerald-plate.png");
            this.ItemIco_List.Images.SetKeyName(45, "employee-area-key.png");
            this.ItemIco_List.Images.SetKeyName(46, "empty-chemical-bottle.png");
            this.ItemIco_List.Images.SetKeyName(47, "examination-room-key.png");
            this.ItemIco_List.Images.SetKeyName(48, "film-a.png");
            this.ItemIco_List.Images.SetKeyName(49, "film-b.png");
            this.ItemIco_List.Images.SetKeyName(50, "film-c.png");
            this.ItemIco_List.Images.SetKeyName(51, "film-d.png");
            this.ItemIco_List.Images.SetKeyName(52, "fJUUtDv.png");
            this.ItemIco_List.Images.SetKeyName(53, "forklift-key.png");
            this.ItemIco_List.Images.SetKeyName(54, "founders-emblem-oral.png");
            this.ItemIco_List.Images.SetKeyName(55, "founders-emblem-werner.png");
            this.ItemIco_List.Images.SetKeyName(56, "frozen-wrench.png");
            this.ItemIco_List.Images.SetKeyName(57, "gas-neutralizing-canister.png");
            this.ItemIco_List.Images.SetKeyName(58, "gold-key.png");
            this.ItemIco_List.Images.SetKeyName(59, "IC6fsWB.png");
            this.ItemIco_List.Images.SetKeyName(60, "id-card-lv1.png");
            this.ItemIco_List.Images.SetKeyName(61, "id-card-lv2.png");
            this.ItemIco_List.Images.SetKeyName(62, "ijjrJPd.png");
            this.ItemIco_List.Images.SetKeyName(63, "investigation-request-item.png");
            this.ItemIco_List.Images.SetKeyName(64, "iNxIGY0.png");
            this.ItemIco_List.Images.SetKeyName(65, "joker-key.png");
            this.ItemIco_List.Images.SetKeyName(66, "key-with-a-red-tag.png");
            this.ItemIco_List.Images.SetKeyName(67, "key-with-blue-tag.png");
            this.ItemIco_List.Images.SetKeyName(68, "KF7hCgy.png");
            this.ItemIco_List.Images.SetKeyName(69, "kfMH9LU.png");
            this.ItemIco_List.Images.SetKeyName(70, "lab-cardkey.png");
            this.ItemIco_List.Images.SetKeyName(71, "lens-id-tag.png");
            this.ItemIco_List.Images.SetKeyName(72, "LEnTZx6.png");
            this.ItemIco_List.Images.SetKeyName(73, "lion-emblem-blue.png");
            this.ItemIco_List.Images.SetKeyName(74, "lion-emblem-red.png");
            this.ItemIco_List.Images.SetKeyName(75, "lion-key.png");
            this.ItemIco_List.Images.SetKeyName(76, "male-nurses-diary-item.png");
            this.ItemIco_List.Images.SetKeyName(77, "mHCW6CB.png");
            this.ItemIco_List.Images.SetKeyName(78, "model-train-wheel.png");
            this.ItemIco_List.Images.SetKeyName(79, "mo-disk.png");
            this.ItemIco_List.Images.SetKeyName(80, "mo-disk-code-a.png");
            this.ItemIco_List.Images.SetKeyName(81, "mo-disk-code-b.png");
            this.ItemIco_List.Images.SetKeyName(82, "mr-raccoon-medal.png");
            this.ItemIco_List.Images.SetKeyName(83, "N07ZPkQ.png");
            this.ItemIco_List.Images.SetKeyName(84, "newspaper-bottle.png");
            this.ItemIco_List.Images.SetKeyName(85, "office-key.png");
            this.ItemIco_List.Images.SetKeyName(86, "ohzOE0k.png");
            this.ItemIco_List.Images.SetKeyName(87, "onyx-plate.png");
            this.ItemIco_List.Images.SetKeyName(88, "padlock-key (1).png");
            this.ItemIco_List.Images.SetKeyName(89, "padlock-key.png");
            this.ItemIco_List.Images.SetKeyName(90, "parade-bgm-tape.png");
            this.ItemIco_List.Images.SetKeyName(91, "p-base.png");
            this.ItemIco_List.Images.SetKeyName(92, "p-base-sealed.png");
            this.ItemIco_List.Images.SetKeyName(93, "pendant.png");
            this.ItemIco_List.Images.SetKeyName(94, "plywood-board.png");
            this.ItemIco_List.Images.SetKeyName(95, "qh1ukbg.png");
            this.ItemIco_List.Images.SetKeyName(96, "QJXr7z4.png");
            this.ItemIco_List.Images.SetKeyName(97, "qMwbceG.png");
            this.ItemIco_List.Images.SetKeyName(98, "Qr55ag1.png");
            this.ItemIco_List.Images.SetKeyName(99, "QxzFf0K.png");
            this.ItemIco_List.Images.SetKeyName(100, "raccoon-today-item.png");
            this.ItemIco_List.Images.SetKeyName(101, "reagent-case.png");
            this.ItemIco_List.Images.SetKeyName(102, "red-jewel-hellfire.png");
            this.ItemIco_List.Images.SetKeyName(103, "repair-tape.png");
            this.ItemIco_List.Images.SetKeyName(104, "researchers-diary-item.png");
            this.ItemIco_List.Images.SetKeyName(105, "RIY78RQ.png");
            this.ItemIco_List.Images.SetKeyName(106, "ruby-plate.png");
            this.ItemIco_List.Images.SetKeyName(107, "rusty-key.png");
            this.ItemIco_List.Images.SetKeyName(108, "saOzZ8r.png");
            this.ItemIco_List.Images.SetKeyName(109, "sapphire-plate.png");
            this.ItemIco_List.Images.SetKeyName(110, "sealed-reagent-case.png");
            this.ItemIco_List.Images.SetKeyName(111, "secret-file-item.png");
            this.ItemIco_List.Images.SetKeyName(112, "security-room-card-key.png");
            this.ItemIco_List.Images.SetKeyName(113, "silver-key.png");
            this.ItemIco_List.Images.SetKeyName(114, "ST2nDvS.png");
            this.ItemIco_List.Images.SetKeyName(115, "staff-room-key.png");
            this.ItemIco_List.Images.SetKeyName(116, "storage-room-key.png");
            this.ItemIco_List.Images.SetKeyName(117, "syringe-empty.png");
            this.ItemIco_List.Images.SetKeyName(118, "syringe-solvent.png");
            this.ItemIco_List.Images.SetKeyName(119, "t-blood.png");
            this.ItemIco_List.Images.SetKeyName(120, "tbNNB0f.png");
            this.ItemIco_List.Images.SetKeyName(121, "TgX3U9W.png");
            this.ItemIco_List.Images.SetKeyName(122, "tkg1zZO.png");
            this.ItemIco_List.Images.SetKeyName(123, "turn-table-key.png");
            this.ItemIco_List.Images.SetKeyName(124, "umb-no-3.png");
            this.ItemIco_List.Images.SetKeyName(125, "unicorn-medal.png");
            this.ItemIco_List.Images.SetKeyName(126, "UPo64ij.png");
            this.ItemIco_List.Images.SetKeyName(127, "v9jguDQ.png");
            this.ItemIco_List.Images.SetKeyName(128, "valve-handle (1).png");
            this.ItemIco_List.Images.SetKeyName(129, "valve-handle.png");
            this.ItemIco_List.Images.SetKeyName(130, "ventilation-tower-key.png");
            this.ItemIco_List.Images.SetKeyName(131, "v-jolt.png");
            this.ItemIco_List.Images.SetKeyName(132, "voi27DK.png");
            this.ItemIco_List.Images.SetKeyName(133, "vp-017.png");
            this.ItemIco_List.Images.SetKeyName(134, "v-poison.png");
            this.ItemIco_List.Images.SetKeyName(135, "W68c1Bn.png");
            this.ItemIco_List.Images.SetKeyName(136, "WGUexVH.png");
            this.ItemIco_List.Images.SetKeyName(137, "wileuM0.png");
            this.ItemIco_List.Images.SetKeyName(138, "wrench.png");
            this.ItemIco_List.Images.SetKeyName(139, "WXZ4YRz.png");
            this.ItemIco_List.Images.SetKeyName(140, "WZbOR9U.png");
            this.ItemIco_List.Images.SetKeyName(141, "xOQcGuk.png");
            this.ItemIco_List.Images.SetKeyName(142, "yzHNlUW.png");
            // 
            // memoryDumpToolStripMenuItem
            // 
            this.memoryDumpToolStripMenuItem.Name = "memoryDumpToolStripMenuItem";
            this.memoryDumpToolStripMenuItem.Size = new System.Drawing.Size(223, 28);
            this.memoryDumpToolStripMenuItem.Text = "Memory Dump";
            this.memoryDumpToolStripMenuItem.Click += new System.EventHandler(this.memoryDumpToolStripMenuItem_Click);
            // 
            // FRM_ItemMemory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 597);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.GB_IMEM);
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
            ((System.ComponentModel.ISupportInitialize)(this.PB_MTYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_ITEMID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PropertyGrid pg_imem;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LBL_PCSX2_STATUS;
        private System.Windows.Forms.ToolStripSplitButton BTN_MEMHOOK;
        public System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PictureBox PB_MTYPE;
        private System.Windows.Forms.PictureBox PB_ITEMID;
        public System.Windows.Forms.ImageList ItemIco_List;
        private System.Windows.Forms.ToolStripMenuItem memoryDumpToolStripMenuItem;
    }
}