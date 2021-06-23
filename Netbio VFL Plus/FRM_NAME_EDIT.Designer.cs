namespace Netbio_VFL_Plus
{
    partial class FRM_NAME_EDIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_NAME_EDIT));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LV_NAMES = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TB_TEXT = new System.Windows.Forms.TextBox();
            this.BTN_UPDATE = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LV_NAMES);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NPC NAME EDITOR";
            // 
            // LV_NAMES
            // 
            this.LV_NAMES.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LV_NAMES.FullRowSelect = true;
            this.LV_NAMES.HideSelection = false;
            this.LV_NAMES.Location = new System.Drawing.Point(6, 26);
            this.LV_NAMES.MultiSelect = false;
            this.LV_NAMES.Name = "LV_NAMES";
            this.LV_NAMES.Size = new System.Drawing.Size(371, 365);
            this.LV_NAMES.TabIndex = 2;
            this.LV_NAMES.UseCompatibleStateImageBehavior = false;
            this.LV_NAMES.View = System.Windows.Forms.View.Details;
            this.LV_NAMES.SelectedIndexChanged += new System.EventHandler(this.LV_NAMES_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            this.columnHeader1.Width = 68;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Offset";
            this.columnHeader2.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "C. Name";
            this.columnHeader3.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "O. Name";
            this.columnHeader4.Width = 99;
            // 
            // TB_TEXT
            // 
            this.TB_TEXT.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_TEXT.Location = new System.Drawing.Point(18, 415);
            this.TB_TEXT.MaxLength = 8;
            this.TB_TEXT.Name = "TB_TEXT";
            this.TB_TEXT.Size = new System.Drawing.Size(371, 27);
            this.TB_TEXT.TabIndex = 1;
            this.TB_TEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_TEXT.WordWrap = false;
            this.TB_TEXT.TextChanged += new System.EventHandler(this.TB_TEXT_TextChanged);
            // 
            // BTN_UPDATE
            // 
            this.BTN_UPDATE.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_UPDATE.Location = new System.Drawing.Point(18, 446);
            this.BTN_UPDATE.Name = "BTN_UPDATE";
            this.BTN_UPDATE.Size = new System.Drawing.Size(371, 53);
            this.BTN_UPDATE.TabIndex = 2;
            this.BTN_UPDATE.Text = "UPDATE";
            this.BTN_UPDATE.UseVisualStyleBackColor = true;
            this.BTN_UPDATE.Click += new System.EventHandler(this.BTN_UPDATE_Click);
            // 
            // FRM_NAME_EDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 511);
            this.Controls.Add(this.BTN_UPDATE);
            this.Controls.Add(this.TB_TEXT);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_NAME_EDIT";
            this.Text = "NPC NAME EDITOR";
            this.Load += new System.EventHandler(this.FRM_NAME_EDIT_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TB_TEXT;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button BTN_UPDATE;
        public System.Windows.Forms.ListView LV_NAMES;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}