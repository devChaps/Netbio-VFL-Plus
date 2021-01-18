namespace Netbio_VFL_Plus
{
    partial class FRM_NPC
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
            this.SuspendLayout();
            // 
            // NPC_Imagebox
            // 
            this.NPC_Imagebox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NPC_Imagebox.Location = new System.Drawing.Point(272, 14);
            this.NPC_Imagebox.Name = "NPC_Imagebox";
            this.NPC_Imagebox.Size = new System.Drawing.Size(360, 236);
            this.NPC_Imagebox.TabIndex = 12;
            this.NPC_Imagebox.TabStop = false;
            this.NPC_Imagebox.Click += new System.EventHandler(this.NPC_Imagebox_Click);
            // 
            // Lst_Entries
            // 
            this.Lst_Entries.BackColor = System.Drawing.Color.White;
            this.Lst_Entries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lst_Entries.ForeColor = System.Drawing.Color.Black;
            this.Lst_Entries.FormattingEnabled = true;
            this.Lst_Entries.Location = new System.Drawing.Point(237, 12);
            this.Lst_Entries.Name = "Lst_Entries";
            this.Lst_Entries.Size = new System.Drawing.Size(29, 238);
            this.Lst_Entries.TabIndex = 11;
            this.Lst_Entries.SelectedIndexChanged += new System.EventHandler(this.Lst_Entries_SelectedIndexChanged);
            // 
            // Lst_Header
            // 
            this.Lst_Header.BackColor = System.Drawing.Color.White;
            this.Lst_Header.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_idx,
            this.clm_offset,
            this.clm_size,
            this.clm_room});
            this.Lst_Header.ForeColor = System.Drawing.Color.Black;
            this.Lst_Header.FullRowSelect = true;
            this.Lst_Header.HideSelection = false;
            this.Lst_Header.Location = new System.Drawing.Point(12, 10);
            this.Lst_Header.Name = "Lst_Header";
            this.Lst_Header.Size = new System.Drawing.Size(219, 236);
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
            this.LBL_BOUNDS.Location = new System.Drawing.Point(538, 324);
            this.LBL_BOUNDS.Name = "LBL_BOUNDS";
            this.LBL_BOUNDS.Size = new System.Drawing.Size(66, 10);
            this.LBL_BOUNDS.TabIndex = 49;
            this.LBL_BOUNDS.Text = "Boundary";
            // 
            // LBL_Alive
            // 
            this.LBL_Alive.ForeColor = System.Drawing.Color.Black;
            this.LBL_Alive.Location = new System.Drawing.Point(478, 324);
            this.LBL_Alive.Name = "LBL_Alive";
            this.LBL_Alive.Size = new System.Drawing.Size(54, 10);
            this.LBL_Alive.TabIndex = 48;
            this.LBL_Alive.Text = "Alive Flag";
            // 
            // Num_bounds
            // 
            this.Num_bounds.BackColor = System.Drawing.Color.White;
            this.Num_bounds.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_bounds.ForeColor = System.Drawing.Color.Black;
            this.Num_bounds.Location = new System.Drawing.Point(541, 337);
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
            this.Num_alive.Location = new System.Drawing.Point(478, 337);
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
            this.LBL_Animflg2.Location = new System.Drawing.Point(421, 324);
            this.LBL_Animflg2.Name = "LBL_Animflg2";
            this.LBL_Animflg2.Size = new System.Drawing.Size(51, 10);
            this.LBL_Animflg2.TabIndex = 45;
            this.LBL_Animflg2.Text = "Flag2";
            // 
            // LBL_AnimID2
            // 
            this.LBL_AnimID2.ForeColor = System.Drawing.Color.Black;
            this.LBL_AnimID2.Location = new System.Drawing.Point(361, 324);
            this.LBL_AnimID2.Name = "LBL_AnimID2";
            this.LBL_AnimID2.Size = new System.Drawing.Size(51, 10);
            this.LBL_AnimID2.TabIndex = 44;
            this.LBL_AnimID2.Text = "Anim ID2";
            // 
            // Num_Animflg2
            // 
            this.Num_Animflg2.BackColor = System.Drawing.Color.White;
            this.Num_Animflg2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_Animflg2.ForeColor = System.Drawing.Color.Black;
            this.Num_Animflg2.Location = new System.Drawing.Point(421, 337);
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
            this.Num_AnimID2.Location = new System.Drawing.Point(364, 337);
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
            this.Num_Rotation.Location = new System.Drawing.Point(410, 381);
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
            this.LBL_animflg1.Location = new System.Drawing.Point(312, 324);
            this.LBL_animflg1.Name = "LBL_animflg1";
            this.LBL_animflg1.Size = new System.Drawing.Size(48, 10);
            this.LBL_animflg1.TabIndex = 40;
            this.LBL_animflg1.Text = "Flag";
            // 
            // LBL_AnimID1
            // 
            this.LBL_AnimID1.ForeColor = System.Drawing.Color.Black;
            this.LBL_AnimID1.Location = new System.Drawing.Point(250, 324);
            this.LBL_AnimID1.Name = "LBL_AnimID1";
            this.LBL_AnimID1.Size = new System.Drawing.Size(51, 10);
            this.LBL_AnimID1.TabIndex = 39;
            this.LBL_AnimID1.Text = "Anim ID";
            // 
            // Num_Animflg
            // 
            this.Num_Animflg.BackColor = System.Drawing.Color.White;
            this.Num_Animflg.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_Animflg.ForeColor = System.Drawing.Color.Black;
            this.Num_Animflg.Location = new System.Drawing.Point(307, 337);
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
            this.Num_AnimID.Location = new System.Drawing.Point(250, 337);
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
            this.LBL_NID.Location = new System.Drawing.Point(188, 324);
            this.LBL_NID.Name = "LBL_NID";
            this.LBL_NID.Size = new System.Drawing.Size(51, 10);
            this.LBL_NID.TabIndex = 36;
            this.LBL_NID.Text = "NPC ID";
            // 
            // LBL_RID
            // 
            this.LBL_RID.ForeColor = System.Drawing.Color.Black;
            this.LBL_RID.Location = new System.Drawing.Point(131, 324);
            this.LBL_RID.Name = "LBL_RID";
            this.LBL_RID.Size = new System.Drawing.Size(51, 10);
            this.LBL_RID.TabIndex = 35;
            this.LBL_RID.Text = "Room ID";
            // 
            // Num_CoordX
            // 
            this.Num_CoordX.BackColor = System.Drawing.Color.White;
            this.Num_CoordX.DecimalPlaces = 4;
            this.Num_CoordX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_CoordX.ForeColor = System.Drawing.Color.Black;
            this.Num_CoordX.Location = new System.Drawing.Point(315, 381);
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
            this.Num_CoordY.Location = new System.Drawing.Point(220, 381);
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
            this.Num_NID.Location = new System.Drawing.Point(193, 337);
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
            this.Num_RID.Location = new System.Drawing.Point(134, 337);
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
            this.Btn_Confirm.Location = new System.Drawing.Point(58, 408);
            this.Btn_Confirm.Name = "Btn_Confirm";
            this.Btn_Confirm.Size = new System.Drawing.Size(625, 33);
            this.Btn_Confirm.TabIndex = 50;
            this.Btn_Confirm.Text = "Confirm Edit";
            this.Btn_Confirm.UseVisualStyleBackColor = true;
            // 
            // FRM_NPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Confirm);
            this.Controls.Add(this.LBL_BOUNDS);
            this.Controls.Add(this.LBL_Alive);
            this.Controls.Add(this.Num_bounds);
            this.Controls.Add(this.Num_alive);
            this.Controls.Add(this.LBL_Animflg2);
            this.Controls.Add(this.LBL_AnimID2);
            this.Controls.Add(this.Num_Animflg2);
            this.Controls.Add(this.Num_AnimID2);
            this.Controls.Add(this.Num_Rotation);
            this.Controls.Add(this.LBL_animflg1);
            this.Controls.Add(this.LBL_AnimID1);
            this.Controls.Add(this.Num_Animflg);
            this.Controls.Add(this.Num_AnimID);
            this.Controls.Add(this.LBL_NID);
            this.Controls.Add(this.LBL_RID);
            this.Controls.Add(this.Num_CoordX);
            this.Controls.Add(this.Num_CoordY);
            this.Controls.Add(this.Num_NID);
            this.Controls.Add(this.Num_RID);
            this.Controls.Add(this.NPC_Imagebox);
            this.Controls.Add(this.Lst_Entries);
            this.Controls.Add(this.Lst_Header);
            this.Name = "FRM_NPC";
            this.Text = "FRM_NPC";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox NPC_Imagebox;
        private System.Windows.Forms.ListBox Lst_Entries;
        private System.Windows.Forms.ListView Lst_Header;
        private System.Windows.Forms.ColumnHeader clm_idx;
        private System.Windows.Forms.ColumnHeader clm_offset;
        private System.Windows.Forms.ColumnHeader clm_size;
        private System.Windows.Forms.ColumnHeader clm_room;
        private System.Windows.Forms.Label LBL_BOUNDS;
        private System.Windows.Forms.Label LBL_Alive;
        private System.Windows.Forms.NumericUpDown Num_bounds;
        private System.Windows.Forms.NumericUpDown Num_alive;
        private System.Windows.Forms.Label LBL_Animflg2;
        private System.Windows.Forms.Label LBL_AnimID2;
        private System.Windows.Forms.NumericUpDown Num_Animflg2;
        private System.Windows.Forms.NumericUpDown Num_AnimID2;
        private System.Windows.Forms.NumericUpDown Num_Rotation;
        private System.Windows.Forms.Label LBL_animflg1;
        private System.Windows.Forms.Label LBL_AnimID1;
        private System.Windows.Forms.NumericUpDown Num_Animflg;
        private System.Windows.Forms.NumericUpDown Num_AnimID;
        private System.Windows.Forms.Label LBL_NID;
        private System.Windows.Forms.Label LBL_RID;
        private System.Windows.Forms.NumericUpDown Num_CoordX;
        private System.Windows.Forms.NumericUpDown Num_CoordY;
        private System.Windows.Forms.NumericUpDown Num_NID;
        private System.Windows.Forms.NumericUpDown Num_RID;
        private System.Windows.Forms.Button Btn_Confirm;
    }
}