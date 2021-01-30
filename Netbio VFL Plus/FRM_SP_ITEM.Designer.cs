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
            this.CB_EMD_SEL = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CB_EMD_SEL
            // 
            this.CB_EMD_SEL.BackColor = System.Drawing.SystemColors.InfoText;
            this.CB_EMD_SEL.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.CB_EMD_SEL.FormattingEnabled = true;
            this.CB_EMD_SEL.Location = new System.Drawing.Point(12, 12);
            this.CB_EMD_SEL.Name = "CB_EMD_SEL";
            this.CB_EMD_SEL.Size = new System.Drawing.Size(500, 21);
            this.CB_EMD_SEL.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(73, 199);
            this.listBox1.TabIndex = 2;
            // 
            // FRM_SP_ITEM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 251);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.CB_EMD_SEL);
            this.Name = "FRM_SP_ITEM";
            this.Text = "FRM_SP_ITEM";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox CB_EMD_SEL;
        private System.Windows.Forms.ListBox listBox1;
    }
}