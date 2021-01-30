namespace Netbio_VFL_Plus
{
    partial class FRM_ABOUT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ABOUT));
            this.About_Image = new System.Windows.Forms.PictureBox();
            this.BTN_ABT_CLOSE = new System.Windows.Forms.Button();
            this.lbl_sig = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.About_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // About_Image
            // 
            this.About_Image.BackColor = System.Drawing.Color.DarkGreen;
            this.About_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.About_Image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.About_Image.Image = ((System.Drawing.Image)(resources.GetObject("About_Image.Image")));
            this.About_Image.Location = new System.Drawing.Point(2, 5);
            this.About_Image.Name = "About_Image";
            this.About_Image.Size = new System.Drawing.Size(394, 158);
            this.About_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.About_Image.TabIndex = 5;
            this.About_Image.TabStop = false;
            // 
            // BTN_ABT_CLOSE
            // 
            this.BTN_ABT_CLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ABT_CLOSE.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold);
            this.BTN_ABT_CLOSE.Location = new System.Drawing.Point(2, 632);
            this.BTN_ABT_CLOSE.Name = "BTN_ABT_CLOSE";
            this.BTN_ABT_CLOSE.Size = new System.Drawing.Size(394, 48);
            this.BTN_ABT_CLOSE.TabIndex = 8;
            this.BTN_ABT_CLOSE.Text = "CLOSE";
            this.BTN_ABT_CLOSE.UseVisualStyleBackColor = true;
            this.BTN_ABT_CLOSE.Click += new System.EventHandler(this.BTN_ABT_CLOSE_Click);
            // 
            // lbl_sig
            // 
            this.lbl_sig.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_sig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_sig.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sig.ForeColor = System.Drawing.Color.Black;
            this.lbl_sig.Location = new System.Drawing.Point(2, 207);
            this.lbl_sig.Name = "lbl_sig";
            this.lbl_sig.Size = new System.Drawing.Size(392, 304);
            this.lbl_sig.TabIndex = 6;
            this.lbl_sig.Text = resources.GetString("lbl_sig.Text");
            this.lbl_sig.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_sig.Click += new System.EventHandler(this.lbl_sig_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(2, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 41);
            this.label1.TabIndex = 7;
            this.label1.Text = "© 2018 -2021 Dchaps - devchaps@protonmail.com\r\n    discord chaps#5046\r\n    ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 109);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thanks/Accreditations to the following people\r\n the_mortician \r\nMr.Creamy \r\nHill7" +
    "3n \r\n0Verlord \r\nIgusaTaro\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRM_ABOUT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 680);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.About_Image);
            this.Controls.Add(this.BTN_ABT_CLOSE);
            this.Controls.Add(this.lbl_sig);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_ABOUT";
            this.Text = "ABOUT";
            ((System.ComponentModel.ISupportInitialize)(this.About_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox About_Image;
        private System.Windows.Forms.Button BTN_ABT_CLOSE;
        private System.Windows.Forms.Label lbl_sig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}