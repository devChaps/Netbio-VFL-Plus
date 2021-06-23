namespace Netbio_VFL_Plus
{
    partial class NPC_FORM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPC_FORM));
            this.NPC_Imagebox = new System.Windows.Forms.PictureBox();
            this.Lst_Entries = new System.Windows.Forms.ListBox();
            this.Lst_Header = new System.Windows.Forms.ListView();
            this.clm_idx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_offset = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_room = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LBL_BOUNDS = new System.Windows.Forms.Label();
            this.LBL_Alive = new System.Windows.Forms.Label();
            this.Num_bounds = new System.Windows.Forms.NumericUpDown();
            this.Num_alive = new System.Windows.Forms.NumericUpDown();
            this.LBL_Animflg2 = new System.Windows.Forms.Label();
            this.LBL_AnimID2 = new System.Windows.Forms.Label();
            this.Num_Animflg2 = new System.Windows.Forms.NumericUpDown();
            this.Num_AnimID2 = new System.Windows.Forms.NumericUpDown();
            this.Num_Rotation = new System.Windows.Forms.NumericUpDown();
            this.LBL_animflg1 = new System.Windows.Forms.Label();
            this.LBL_AnimID1 = new System.Windows.Forms.Label();
            this.Num_Animflg = new System.Windows.Forms.NumericUpDown();
            this.Num_AnimID = new System.Windows.Forms.NumericUpDown();
            this.LBL_NID = new System.Windows.Forms.Label();
            this.LBL_RID = new System.Windows.Forms.Label();
            this.Num_CoordX = new System.Windows.Forms.NumericUpDown();
            this.Num_CoordY = new System.Windows.Forms.NumericUpDown();
            this.Num_NID = new System.Windows.Forms.NumericUpDown();
            this.Num_RID = new System.Windows.Forms.NumericUpDown();
            this.Btn_Confirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PB_CURRENT_ROOM = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.NPC_Imagebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_bounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_alive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Animflg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_AnimID2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Rotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Animflg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_AnimID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CoordX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CoordY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_NID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_RID)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_CURRENT_ROOM)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // NPC_Imagebox
            // 
            this.NPC_Imagebox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NPC_Imagebox.Location = new System.Drawing.Point(6, 26);
            this.NPC_Imagebox.Name = "NPC_Imagebox";
            this.NPC_Imagebox.Size = new System.Drawing.Size(224, 197);
            this.NPC_Imagebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.NPC_Imagebox.TabIndex = 12;
            this.NPC_Imagebox.TabStop = false;
            this.NPC_Imagebox.Click += new System.EventHandler(this.NPC_Imagebox_Click);
            // 
            // Lst_Entries
            // 
            this.Lst_Entries.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Lst_Entries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lst_Entries.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.Lst_Entries.ForeColor = System.Drawing.Color.Black;
            this.Lst_Entries.FormattingEnabled = true;
            this.Lst_Entries.ItemHeight = 19;
            this.Lst_Entries.Location = new System.Drawing.Point(410, 45);
            this.Lst_Entries.Name = "Lst_Entries";
            this.Lst_Entries.Size = new System.Drawing.Size(40, 173);
            this.Lst_Entries.TabIndex = 11;
            this.Lst_Entries.SelectedIndexChanged += new System.EventHandler(this.Lst_Entries_SelectedIndexChanged);
            // 
            // Lst_Header
            // 
            this.Lst_Header.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Lst_Header.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_idx,
            this.clm_offset,
            this.clm_size,
            this.clm_room});
            this.Lst_Header.ForeColor = System.Drawing.Color.Black;
            this.Lst_Header.FullRowSelect = true;
            this.Lst_Header.HideSelection = false;
            this.Lst_Header.Location = new System.Drawing.Point(189, 45);
            this.Lst_Header.Name = "Lst_Header";
            this.Lst_Header.Size = new System.Drawing.Size(217, 171);
            this.Lst_Header.TabIndex = 10;
            this.Lst_Header.UseCompatibleStateImageBehavior = false;
            this.Lst_Header.View = System.Windows.Forms.View.Details;
            this.Lst_Header.SelectedIndexChanged += new System.EventHandler(this.Lst_Header_SelectedIndexChanged);
            // 
            // clm_idx
            // 
            this.clm_idx.Text = "Index";
            this.clm_idx.Width = 48;
            // 
            // clm_offset
            // 
            this.clm_offset.Text = "Offset";
            this.clm_offset.Width = 49;
            // 
            // clm_size
            // 
            this.clm_size.Text = "Size";
            this.clm_size.Width = 44;
            // 
            // clm_room
            // 
            this.clm_room.Text = "Room ID";
            this.clm_room.Width = 70;
            // 
            // LBL_BOUNDS
            // 
            this.LBL_BOUNDS.ForeColor = System.Drawing.Color.Black;
            this.LBL_BOUNDS.Location = new System.Drawing.Point(269, 97);
            this.LBL_BOUNDS.Name = "LBL_BOUNDS";
            this.LBL_BOUNDS.Size = new System.Drawing.Size(80, 22);
            this.LBL_BOUNDS.TabIndex = 49;
            this.LBL_BOUNDS.Text = "Boundary";
            // 
            // LBL_Alive
            // 
            this.LBL_Alive.ForeColor = System.Drawing.Color.Black;
            this.LBL_Alive.Location = new System.Drawing.Point(218, 98);
            this.LBL_Alive.Name = "LBL_Alive";
            this.LBL_Alive.Size = new System.Drawing.Size(54, 22);
            this.LBL_Alive.TabIndex = 48;
            this.LBL_Alive.Text = "Alive Flag";
            // 
            // Num_bounds
            // 
            this.Num_bounds.BackColor = System.Drawing.Color.White;
            this.Num_bounds.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_bounds.ForeColor = System.Drawing.Color.Black;
            this.Num_bounds.Location = new System.Drawing.Point(273, 123);
            this.Num_bounds.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_bounds.Name = "Num_bounds";
            this.Num_bounds.Size = new System.Drawing.Size(51, 21);
            this.Num_bounds.TabIndex = 47;
            // 
            // Num_alive
            // 
            this.Num_alive.BackColor = System.Drawing.Color.White;
            this.Num_alive.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_alive.ForeColor = System.Drawing.Color.Black;
            this.Num_alive.Location = new System.Drawing.Point(213, 123);
            this.Num_alive.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_alive.Name = "Num_alive";
            this.Num_alive.Size = new System.Drawing.Size(51, 21);
            this.Num_alive.TabIndex = 46;
            // 
            // LBL_Animflg2
            // 
            this.LBL_Animflg2.ForeColor = System.Drawing.Color.Black;
            this.LBL_Animflg2.Location = new System.Drawing.Point(269, 48);
            this.LBL_Animflg2.Name = "LBL_Animflg2";
            this.LBL_Animflg2.Size = new System.Drawing.Size(51, 22);
            this.LBL_Animflg2.TabIndex = 45;
            this.LBL_Animflg2.Text = "Flag2";
            // 
            // LBL_AnimID2
            // 
            this.LBL_AnimID2.ForeColor = System.Drawing.Color.Black;
            this.LBL_AnimID2.Location = new System.Drawing.Point(209, 48);
            this.LBL_AnimID2.Name = "LBL_AnimID2";
            this.LBL_AnimID2.Size = new System.Drawing.Size(51, 22);
            this.LBL_AnimID2.TabIndex = 44;
            this.LBL_AnimID2.Text = "Anim ID2";
            // 
            // Num_Animflg2
            // 
            this.Num_Animflg2.BackColor = System.Drawing.Color.White;
            this.Num_Animflg2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_Animflg2.ForeColor = System.Drawing.Color.Black;
            this.Num_Animflg2.Location = new System.Drawing.Point(264, 73);
            this.Num_Animflg2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_Animflg2.Name = "Num_Animflg2";
            this.Num_Animflg2.Size = new System.Drawing.Size(51, 21);
            this.Num_Animflg2.TabIndex = 43;
            // 
            // Num_AnimID2
            // 
            this.Num_AnimID2.BackColor = System.Drawing.Color.White;
            this.Num_AnimID2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_AnimID2.ForeColor = System.Drawing.Color.Black;
            this.Num_AnimID2.Location = new System.Drawing.Point(207, 73);
            this.Num_AnimID2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_AnimID2.Name = "Num_AnimID2";
            this.Num_AnimID2.Size = new System.Drawing.Size(51, 21);
            this.Num_AnimID2.TabIndex = 42;
            // 
            // Num_Rotation
            // 
            this.Num_Rotation.BackColor = System.Drawing.Color.White;
            this.Num_Rotation.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_Rotation.ForeColor = System.Drawing.Color.Black;
            this.Num_Rotation.Location = new System.Drawing.Point(105, 62);
            this.Num_Rotation.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Num_Rotation.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.Num_Rotation.Name = "Num_Rotation";
            this.Num_Rotation.Size = new System.Drawing.Size(89, 21);
            this.Num_Rotation.TabIndex = 41;
            // 
            // LBL_animflg1
            // 
            this.LBL_animflg1.ForeColor = System.Drawing.Color.Black;
            this.LBL_animflg1.Location = new System.Drawing.Point(154, 98);
            this.LBL_animflg1.Name = "LBL_animflg1";
            this.LBL_animflg1.Size = new System.Drawing.Size(48, 22);
            this.LBL_animflg1.TabIndex = 40;
            this.LBL_animflg1.Text = "Flag";
            // 
            // LBL_AnimID1
            // 
            this.LBL_AnimID1.ForeColor = System.Drawing.Color.Black;
            this.LBL_AnimID1.Location = new System.Drawing.Point(95, 98);
            this.LBL_AnimID1.Name = "LBL_AnimID1";
            this.LBL_AnimID1.Size = new System.Drawing.Size(51, 22);
            this.LBL_AnimID1.TabIndex = 39;
            this.LBL_AnimID1.Text = "Anim ID";
            // 
            // Num_Animflg
            // 
            this.Num_Animflg.BackColor = System.Drawing.Color.White;
            this.Num_Animflg.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_Animflg.ForeColor = System.Drawing.Color.Black;
            this.Num_Animflg.Location = new System.Drawing.Point(151, 123);
            this.Num_Animflg.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_Animflg.Name = "Num_Animflg";
            this.Num_Animflg.Size = new System.Drawing.Size(51, 21);
            this.Num_Animflg.TabIndex = 38;
            // 
            // Num_AnimID
            // 
            this.Num_AnimID.BackColor = System.Drawing.Color.White;
            this.Num_AnimID.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_AnimID.ForeColor = System.Drawing.Color.Black;
            this.Num_AnimID.Location = new System.Drawing.Point(95, 123);
            this.Num_AnimID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_AnimID.Name = "Num_AnimID";
            this.Num_AnimID.Size = new System.Drawing.Size(51, 21);
            this.Num_AnimID.TabIndex = 37;
            // 
            // LBL_NID
            // 
            this.LBL_NID.ForeColor = System.Drawing.Color.Black;
            this.LBL_NID.Location = new System.Drawing.Point(147, 50);
            this.LBL_NID.Name = "LBL_NID";
            this.LBL_NID.Size = new System.Drawing.Size(51, 22);
            this.LBL_NID.TabIndex = 36;
            this.LBL_NID.Text = "NPC ID";
            // 
            // LBL_RID
            // 
            this.LBL_RID.ForeColor = System.Drawing.Color.Black;
            this.LBL_RID.Location = new System.Drawing.Point(90, 50);
            this.LBL_RID.Name = "LBL_RID";
            this.LBL_RID.Size = new System.Drawing.Size(51, 22);
            this.LBL_RID.TabIndex = 35;
            this.LBL_RID.Text = "Room ID";
            // 
            // Num_CoordX
            // 
            this.Num_CoordX.BackColor = System.Drawing.Color.White;
            this.Num_CoordX.DecimalPlaces = 4;
            this.Num_CoordX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_CoordX.ForeColor = System.Drawing.Color.Black;
            this.Num_CoordX.Location = new System.Drawing.Point(105, 89);
            this.Num_CoordX.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_CoordX.Name = "Num_CoordX";
            this.Num_CoordX.Size = new System.Drawing.Size(89, 21);
            this.Num_CoordX.TabIndex = 34;
            // 
            // Num_CoordY
            // 
            this.Num_CoordY.BackColor = System.Drawing.Color.White;
            this.Num_CoordY.DecimalPlaces = 4;
            this.Num_CoordY.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_CoordY.ForeColor = System.Drawing.Color.Black;
            this.Num_CoordY.Location = new System.Drawing.Point(105, 35);
            this.Num_CoordY.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_CoordY.Name = "Num_CoordY";
            this.Num_CoordY.Size = new System.Drawing.Size(89, 21);
            this.Num_CoordY.TabIndex = 33;
            // 
            // Num_NID
            // 
            this.Num_NID.BackColor = System.Drawing.Color.White;
            this.Num_NID.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_NID.ForeColor = System.Drawing.Color.Black;
            this.Num_NID.Location = new System.Drawing.Point(151, 75);
            this.Num_NID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_NID.Name = "Num_NID";
            this.Num_NID.Size = new System.Drawing.Size(51, 21);
            this.Num_NID.TabIndex = 32;
            // 
            // Num_RID
            // 
            this.Num_RID.BackColor = System.Drawing.Color.White;
            this.Num_RID.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_RID.ForeColor = System.Drawing.Color.Black;
            this.Num_RID.Location = new System.Drawing.Point(95, 75);
            this.Num_RID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Num_RID.Name = "Num_RID";
            this.Num_RID.Size = new System.Drawing.Size(51, 21);
            this.Num_RID.TabIndex = 31;
            // 
            // Btn_Confirm
            // 
            this.Btn_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Confirm.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Confirm.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Confirm.Image")));
            this.Btn_Confirm.Location = new System.Drawing.Point(3, 444);
            this.Btn_Confirm.Name = "Btn_Confirm";
            this.Btn_Confirm.Size = new System.Drawing.Size(701, 67);
            this.Btn_Confirm.TabIndex = 50;
            this.Btn_Confirm.Text = "SAVE";
            this.Btn_Confirm.UseVisualStyleBackColor = true;
            this.Btn_Confirm.Click += new System.EventHandler(this.Btn_Confirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Lst_Header);
            this.groupBox1.Controls.Add(this.Lst_Entries);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 229);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MAP DATA";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 59;
            this.label1.Text = "ROOM INDEX";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(405, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 58;
            this.label2.Text = "NPC INDEX";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.LBL_RID);
            this.groupBox2.Controls.Add(this.Num_RID);
            this.groupBox2.Controls.Add(this.Num_NID);
            this.groupBox2.Controls.Add(this.LBL_BOUNDS);
            this.groupBox2.Controls.Add(this.LBL_Alive);
            this.groupBox2.Controls.Add(this.Num_bounds);
            this.groupBox2.Controls.Add(this.LBL_NID);
            this.groupBox2.Controls.Add(this.Num_alive);
            this.groupBox2.Controls.Add(this.Num_AnimID);
            this.groupBox2.Controls.Add(this.LBL_Animflg2);
            this.groupBox2.Controls.Add(this.Num_Animflg);
            this.groupBox2.Controls.Add(this.LBL_AnimID2);
            this.groupBox2.Controls.Add(this.LBL_AnimID1);
            this.groupBox2.Controls.Add(this.Num_Animflg2);
            this.groupBox2.Controls.Add(this.LBL_animflg1);
            this.groupBox2.Controls.Add(this.Num_AnimID2);
            this.groupBox2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 190);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NPC DATA";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Num_Rotation);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.Num_CoordX);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.Num_CoordY);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(417, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 154);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Position Data";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 52;
            this.label5.Text = "Z";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 51;
            this.label4.Text = "Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 50;
            this.label3.Text = "X";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NPC_Imagebox);
            this.groupBox3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(474, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(237, 229);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NPC PREVIEW";
            // 
            // PB_CURRENT_ROOM
            // 
            this.PB_CURRENT_ROOM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PB_CURRENT_ROOM.Location = new System.Drawing.Point(8, 26);
            this.PB_CURRENT_ROOM.Name = "PB_CURRENT_ROOM";
            this.PB_CURRENT_ROOM.Size = new System.Drawing.Size(171, 154);
            this.PB_CURRENT_ROOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_CURRENT_ROOM.TabIndex = 54;
            this.PB_CURRENT_ROOM.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.PB_CURRENT_ROOM);
            this.groupBox5.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(188, 195);
            this.groupBox5.TabIndex = 60;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ROOM ID";
            // 
            // NPC_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(716, 523);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Confirm);
            this.Name = "NPC_FORM";
            this.Text = "NPC MANAGER";
            this.Load += new System.EventHandler(this.PB_CURROOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NPC_Imagebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_bounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_alive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Animflg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_AnimID2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Rotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Animflg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_AnimID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CoordX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_CoordY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_NID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_RID)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_CURRENT_ROOM)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader clm_idx;
        private System.Windows.Forms.ColumnHeader clm_offset;
        private System.Windows.Forms.ColumnHeader clm_size;
        private System.Windows.Forms.ColumnHeader clm_room;
        public System.Windows.Forms.PictureBox NPC_Imagebox;
        public System.Windows.Forms.ListBox Lst_Entries;
        public System.Windows.Forms.ListView Lst_Header;
        public System.Windows.Forms.Label LBL_BOUNDS;
        public System.Windows.Forms.Label LBL_Alive;
        public System.Windows.Forms.NumericUpDown Num_bounds;
        public System.Windows.Forms.NumericUpDown Num_alive;
        public System.Windows.Forms.Label LBL_Animflg2;
        public System.Windows.Forms.Label LBL_AnimID2;
        public System.Windows.Forms.NumericUpDown Num_Animflg2;
        public System.Windows.Forms.NumericUpDown Num_AnimID2;
        public System.Windows.Forms.NumericUpDown Num_Rotation;
        public System.Windows.Forms.Label LBL_animflg1;
        public System.Windows.Forms.Label LBL_AnimID1;
        public System.Windows.Forms.NumericUpDown Num_Animflg;
        public System.Windows.Forms.NumericUpDown Num_AnimID;
        public System.Windows.Forms.Label LBL_NID;
        public System.Windows.Forms.Label LBL_RID;
        public System.Windows.Forms.NumericUpDown Num_CoordX;
        public System.Windows.Forms.NumericUpDown Num_CoordY;
        public System.Windows.Forms.NumericUpDown Num_NID;
        public System.Windows.Forms.NumericUpDown Num_RID;
        public System.Windows.Forms.Button Btn_Confirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.PictureBox PB_CURRENT_ROOM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}