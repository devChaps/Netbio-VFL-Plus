namespace Netbio_VFL_Plus
{
    partial class FRM_SP_ITEM
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
            this.CB_SP_ITEM_SEL = new System.Windows.Forms.ComboBox();
            this.LB_SP_ITEM = new System.Windows.Forms.ListBox();
            this.GB_DATA = new System.Windows.Forms.GroupBox();
            this.GB_DATA.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_SP_ITEM_SEL
            // 
            this.CB_SP_ITEM_SEL.BackColor = System.Drawing.SystemColors.InfoText;
            this.CB_SP_ITEM_SEL.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.CB_SP_ITEM_SEL.FormattingEnabled = true;
            this.CB_SP_ITEM_SEL.Location = new System.Drawing.Point(12, 22);
            this.CB_SP_ITEM_SEL.Name = "CB_SP_ITEM_SEL";
            this.CB_SP_ITEM_SEL.Size = new System.Drawing.Size(463, 24);
            this.CB_SP_ITEM_SEL.TabIndex = 1;
            // 
            // LB_SP_ITEM
            // 
            this.LB_SP_ITEM.FormattingEnabled = true;
            this.LB_SP_ITEM.ItemHeight = 16;
            this.LB_SP_ITEM.Location = new System.Drawing.Point(12, 60);
            this.LB_SP_ITEM.Name = "LB_SP_ITEM";
            this.LB_SP_ITEM.Size = new System.Drawing.Size(31, 260);
            this.LB_SP_ITEM.TabIndex = 2;
            // 
            // GB_DATA
            // 
            this.GB_DATA.Controls.Add(this.LB_SP_ITEM);
            this.GB_DATA.Controls.Add(this.CB_SP_ITEM_SEL);
            this.GB_DATA.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_DATA.Location = new System.Drawing.Point(12, 12);
            this.GB_DATA.Name = "GB_DATA";
            this.GB_DATA.Size = new System.Drawing.Size(498, 326);
            this.GB_DATA.TabIndex = 3;
            this.GB_DATA.TabStop = false;
            this.GB_DATA.Text = "SP.ITEM DATA";
            // 
            // FRM_SP_ITEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 377);
            this.Controls.Add(this.GB_DATA);
            this.Name = "FRM_SP_ITEM";
            this.Text = "FRM_SP_ITEM";
            this.GB_DATA.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox CB_SP_ITEM_SEL;
        private System.Windows.Forms.GroupBox GB_DATA;
        public System.Windows.Forms.ListBox LB_SP_ITEM;
    }
}