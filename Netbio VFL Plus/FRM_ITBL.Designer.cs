namespace Netbio_VFL_Plus
{
    partial class FRM_ITBL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ITBL));
            this.LV_ItemTable = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Btn_TBL_UPDATE = new System.Windows.Forms.Button();
            this.NUD_TBL_OCCURENCE = new System.Windows.Forms.NumericUpDown();
            this.NUD_TBL_QUANTITY = new System.Windows.Forms.NumericUpDown();
            this.NUD_TBL_ItemID = new System.Windows.Forms.NumericUpDown();
            this.CMB_ITEMNAME = new System.Windows.Forms.ComboBox();
            this.Nud_TBL_Index = new System.Windows.Forms.NumericUpDown();
            this.ItemSelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.ItemIco_List = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_OCCURENCE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_QUANTITY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_ItemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_TBL_Index)).BeginInit();
            this.ItemSelectionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_ItemTable
            // 
            this.LV_ItemTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(6)))), ((int)(((byte)(44)))));
            this.LV_ItemTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.LV_ItemTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_ItemTable.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.LV_ItemTable.FullRowSelect = true;
            this.LV_ItemTable.HideSelection = false;
            this.LV_ItemTable.Location = new System.Drawing.Point(0, 2);
            this.LV_ItemTable.Name = "LV_ItemTable";
            this.LV_ItemTable.Size = new System.Drawing.Size(397, 556);
            this.LV_ItemTable.TabIndex = 1;
            this.LV_ItemTable.UseCompatibleStateImageBehavior = false;
            this.LV_ItemTable.View = System.Windows.Forms.View.Details;
            this.LV_ItemTable.SelectedIndexChanged += new System.EventHandler(this.LV_ItemTable_SelectedIndexChanged);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Index";
            this.columnHeader16.Width = 59;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Item ID";
            this.columnHeader17.Width = 68;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Item Name";
            this.columnHeader18.Width = 108;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Quantity";
            this.columnHeader19.Width = 78;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Occurence?";
            this.columnHeader20.Width = 78;
            // 
            // Btn_TBL_UPDATE
            // 
            this.Btn_TBL_UPDATE.Location = new System.Drawing.Point(100, 57);
            this.Btn_TBL_UPDATE.Name = "Btn_TBL_UPDATE";
            this.Btn_TBL_UPDATE.Size = new System.Drawing.Size(279, 42);
            this.Btn_TBL_UPDATE.TabIndex = 6;
            this.Btn_TBL_UPDATE.Text = "Update Entry";
            this.Btn_TBL_UPDATE.UseVisualStyleBackColor = true;
            // 
            // NUD_TBL_OCCURENCE
            // 
            this.NUD_TBL_OCCURENCE.Location = new System.Drawing.Point(0, 56);
            this.NUD_TBL_OCCURENCE.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NUD_TBL_OCCURENCE.Name = "NUD_TBL_OCCURENCE";
            this.NUD_TBL_OCCURENCE.Size = new System.Drawing.Size(85, 20);
            this.NUD_TBL_OCCURENCE.TabIndex = 5;
            // 
            // NUD_TBL_QUANTITY
            // 
            this.NUD_TBL_QUANTITY.Location = new System.Drawing.Point(0, 79);
            this.NUD_TBL_QUANTITY.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NUD_TBL_QUANTITY.Name = "NUD_TBL_QUANTITY";
            this.NUD_TBL_QUANTITY.Size = new System.Drawing.Size(85, 20);
            this.NUD_TBL_QUANTITY.TabIndex = 4;
            // 
            // NUD_TBL_ItemID
            // 
            this.NUD_TBL_ItemID.Location = new System.Drawing.Point(58, 30);
            this.NUD_TBL_ItemID.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NUD_TBL_ItemID.Name = "NUD_TBL_ItemID";
            this.NUD_TBL_ItemID.Size = new System.Drawing.Size(85, 20);
            this.NUD_TBL_ItemID.TabIndex = 3;
            // 
            // CMB_ITEMNAME
            // 
            this.CMB_ITEMNAME.FormattingEnabled = true;
            this.CMB_ITEMNAME.Location = new System.Drawing.Point(149, 30);
            this.CMB_ITEMNAME.Name = "CMB_ITEMNAME";
            this.CMB_ITEMNAME.Size = new System.Drawing.Size(221, 21);
            this.CMB_ITEMNAME.TabIndex = 1;
            // 
            // Nud_TBL_Index
            // 
            this.Nud_TBL_Index.Location = new System.Drawing.Point(0, 30);
            this.Nud_TBL_Index.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Nud_TBL_Index.Name = "Nud_TBL_Index";
            this.Nud_TBL_Index.Size = new System.Drawing.Size(52, 20);
            this.Nud_TBL_Index.TabIndex = 2;
            // 
            // ItemSelectionGroupBox
            // 
            this.ItemSelectionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.ItemSelectionGroupBox.Controls.Add(this.Btn_TBL_UPDATE);
            this.ItemSelectionGroupBox.Controls.Add(this.NUD_TBL_OCCURENCE);
            this.ItemSelectionGroupBox.Controls.Add(this.NUD_TBL_QUANTITY);
            this.ItemSelectionGroupBox.Controls.Add(this.NUD_TBL_ItemID);
            this.ItemSelectionGroupBox.Controls.Add(this.CMB_ITEMNAME);
            this.ItemSelectionGroupBox.Controls.Add(this.Nud_TBL_Index);
            this.ItemSelectionGroupBox.Location = new System.Drawing.Point(0, 564);
            this.ItemSelectionGroupBox.Name = "ItemSelectionGroupBox";
            this.ItemSelectionGroupBox.Size = new System.Drawing.Size(397, 105);
            this.ItemSelectionGroupBox.TabIndex = 4;
            this.ItemSelectionGroupBox.TabStop = false;
            this.ItemSelectionGroupBox.Text = "Edit Selection";
            // 
            // ItemIco_List
            // 
            this.ItemIco_List.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ItemIco_List.ImageStream")));
            this.ItemIco_List.TransparentColor = System.Drawing.Color.Transparent;
            this.ItemIco_List.Images.SetKeyName(0, "Handgun.png");
            this.ItemIco_List.Images.SetKeyName(1, "Handgun Sg.png");
            this.ItemIco_List.Images.SetKeyName(2, "Handgun GL.png");
            this.ItemIco_List.Images.SetKeyName(3, "Assault Rifle.png");
            this.ItemIco_List.Images.SetKeyName(4, "Magnum Revolver.png");
            this.ItemIco_List.Images.SetKeyName(5, "Shotgun.png");
            this.ItemIco_List.Images.SetKeyName(6, "Burst Handgun.png");
            this.ItemIco_List.Images.SetKeyName(7, "Sub Machine Gun.png");
            this.ItemIco_List.Images.SetKeyName(8, "Nail Gun.png");
            this.ItemIco_List.Images.SetKeyName(9, "Rocket Launcher.png");
            this.ItemIco_List.Images.SetKeyName(10, "Survival Knife.png");
            this.ItemIco_List.Images.SetKeyName(11, "Butcher Knife.png");
            this.ItemIco_List.Images.SetKeyName(12, "Iron Pipe.png");
            this.ItemIco_List.Images.SetKeyName(13, "Curved Pipe.png");
            this.ItemIco_List.Images.SetKeyName(14, "Scrub Brush.png");
            this.ItemIco_List.Images.SetKeyName(15, "Crutch.png");
            this.ItemIco_List.Images.SetKeyName(16, "Spear.png");
            this.ItemIco_List.Images.SetKeyName(17, "Wooden Pole.png");
            this.ItemIco_List.Images.SetKeyName(18, "Pesticide Spray.png");
            this.ItemIco_List.Images.SetKeyName(19, "Alcohol Bottle.bmp");
            this.ItemIco_List.Images.SetKeyName(20, "Lighter.bmp");
            this.ItemIco_List.Images.SetKeyName(21, "GL Magazine.png");
            this.ItemIco_List.Images.SetKeyName(22, "Burst Magazine.png");
            this.ItemIco_List.Images.SetKeyName(23, "Handgun Rounds.png");
            this.ItemIco_List.Images.SetKeyName(24, "45 Auto Rounds.png");
            this.ItemIco_List.Images.SetKeyName(25, "Shotgun Rounds.png");
            this.ItemIco_List.Images.SetKeyName(26, "Handgun Magazine.png");
            this.ItemIco_List.Images.SetKeyName(27, "SG Magazine.png");
            this.ItemIco_List.Images.SetKeyName(28, "Blue Herb.bmp");
            this.ItemIco_List.Images.SetKeyName(29, "Red Herb.bmp");
            this.ItemIco_List.Images.SetKeyName(30, "Green Herb.bmp");
            this.ItemIco_List.Images.SetKeyName(31, "First Aid Spray.bmp");
            this.ItemIco_List.Images.SetKeyName(32, "Anti Virus.bmp");
            this.ItemIco_List.Images.SetKeyName(33, "Magnun Revolver Rounds.png");
            this.ItemIco_List.Images.SetKeyName(34, "Ampoule Shooter.png");
            // 
            // FRM_ITBL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 681);
            this.Controls.Add(this.ItemSelectionGroupBox);
            this.Controls.Add(this.LV_ItemTable);
            this.Name = "FRM_ITBL";
            this.Text = "FRM_ITBL";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_OCCURENCE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_QUANTITY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_ItemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_TBL_Index)).EndInit();
            this.ItemSelectionGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.Button Btn_TBL_UPDATE;
        private System.Windows.Forms.NumericUpDown NUD_TBL_OCCURENCE;
        private System.Windows.Forms.NumericUpDown NUD_TBL_QUANTITY;
        private System.Windows.Forms.NumericUpDown NUD_TBL_ItemID;
        private System.Windows.Forms.NumericUpDown Nud_TBL_Index;
        private System.Windows.Forms.GroupBox ItemSelectionGroupBox;
        public System.Windows.Forms.ListView LV_ItemTable;
        public System.Windows.Forms.ComboBox CMB_ITEMNAME;
        public System.Windows.Forms.ImageList ItemIco_List;
    }
}