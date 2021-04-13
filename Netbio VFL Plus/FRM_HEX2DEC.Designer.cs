namespace Netbio_VFL_Plus
{
    partial class FRM_HEX2DEC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_HEX2DEC));
            this.TB_DEC = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BTN_HEX = new System.Windows.Forms.Button();
            this.BTN_DEC = new System.Windows.Forms.Button();
            this.TB_HEX = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_DEC
            // 
            this.TB_DEC.Location = new System.Drawing.Point(126, 42);
            this.TB_DEC.Multiline = true;
            this.TB_DEC.Name = "TB_DEC";
            this.TB_DEC.Size = new System.Drawing.Size(401, 36);
            this.TB_DEC.TabIndex = 0;
            this.TB_DEC.TextChanged += new System.EventHandler(this.TB_DEC_TextChanged);
            this.TB_DEC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_DEC_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.BTN_HEX);
            this.groupBox1.Controls.Add(this.BTN_DEC);
            this.groupBox1.Controls.Add(this.TB_HEX);
            this.groupBox1.Controls.Add(this.TB_DEC);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 188);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HEX 2 DECIMAL CONVERTER";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(401, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "CLEAR ALL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTN_HEX
            // 
            this.BTN_HEX.Location = new System.Drawing.Point(0, 84);
            this.BTN_HEX.Name = "BTN_HEX";
            this.BTN_HEX.Size = new System.Drawing.Size(120, 38);
            this.BTN_HEX.TabIndex = 3;
            this.BTN_HEX.Text = "HEX > DEC";
            this.BTN_HEX.UseVisualStyleBackColor = true;
            this.BTN_HEX.Click += new System.EventHandler(this.BTN_HEX_Click);
            // 
            // BTN_DEC
            // 
            this.BTN_DEC.Location = new System.Drawing.Point(0, 40);
            this.BTN_DEC.Name = "BTN_DEC";
            this.BTN_DEC.Size = new System.Drawing.Size(120, 38);
            this.BTN_DEC.TabIndex = 2;
            this.BTN_DEC.Text = "DEC > HEX";
            this.BTN_DEC.UseVisualStyleBackColor = true;
            this.BTN_DEC.Click += new System.EventHandler(this.BTN_DEC_Click);
            // 
            // TB_HEX
            // 
            this.TB_HEX.Location = new System.Drawing.Point(126, 82);
            this.TB_HEX.Multiline = true;
            this.TB_HEX.Name = "TB_HEX";
            this.TB_HEX.Size = new System.Drawing.Size(401, 37);
            this.TB_HEX.TabIndex = 1;
            this.TB_HEX.TextChanged += new System.EventHandler(this.TB_HEX_TextChanged);
            this.TB_HEX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_HEX_KeyPress);
            this.TB_HEX.Validating += new System.ComponentModel.CancelEventHandler(this.TB_HEX_Validating);
            // 
            // FRM_HEX2DEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 190);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_HEX2DEC";
            this.Text = "HEX CONVERTER";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox TB_DEC;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TB_HEX;
        private System.Windows.Forms.Button BTN_HEX;
        private System.Windows.Forms.Button BTN_DEC;
        private System.Windows.Forms.Button button1;
    }
}