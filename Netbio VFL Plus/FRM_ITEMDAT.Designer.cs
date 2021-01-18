namespace Netbio_VFL_Plus
{
    partial class FRM_ITEMDAT
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
            this.LV_IDataHeader = new System.Windows.Forms.ListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LV_ItemData = new System.Windows.Forms.ListView();
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LV_IDataHeader
            // 
            this.LV_IDataHeader.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LV_IDataHeader.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.LV_IDataHeader.HideSelection = false;
            this.LV_IDataHeader.Location = new System.Drawing.Point(12, 12);
            this.LV_IDataHeader.Name = "LV_IDataHeader";
            this.LV_IDataHeader.Size = new System.Drawing.Size(244, 297);
            this.LV_IDataHeader.TabIndex = 5;
            this.LV_IDataHeader.UseCompatibleStateImageBehavior = false;
            this.LV_IDataHeader.View = System.Windows.Forms.View.Details;
            this.LV_IDataHeader.SelectedIndexChanged += new System.EventHandler(this.LV_IDataHeader_SelectedIndexChanged);
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Index";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Offset";
            this.columnHeader22.Width = 69;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Size";
            this.columnHeader23.Width = 54;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Desc";
            this.columnHeader24.Width = 403;
            // 
            // LV_ItemData
            // 
            this.LV_ItemData.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LV_ItemData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader25,
            this.columnHeader26});
            this.LV_ItemData.HideSelection = false;
            this.LV_ItemData.Location = new System.Drawing.Point(262, 12);
            this.LV_ItemData.Name = "LV_ItemData";
            this.LV_ItemData.Size = new System.Drawing.Size(424, 297);
            this.LV_ItemData.TabIndex = 6;
            this.LV_ItemData.UseCompatibleStateImageBehavior = false;
            this.LV_ItemData.View = System.Windows.Forms.View.Details;
            this.LV_ItemData.SelectedIndexChanged += new System.EventHandler(this.LV_ItemData_SelectedIndexChanged);
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Index";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Item";
            this.columnHeader26.Width = 114;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(175, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 67);
            this.button1.TabIndex = 7;
            this.button1.Text = "Memory Module";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FRM_ITEMDAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LV_ItemData);
            this.Controls.Add(this.LV_IDataHeader);
            this.Name = "FRM_ITEMDAT";
            this.Text = "FRM_ITEMDAT";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        public System.Windows.Forms.ListView LV_IDataHeader;
        public System.Windows.Forms.ListView LV_ItemData;
        private System.Windows.Forms.Button button1;
    }
}