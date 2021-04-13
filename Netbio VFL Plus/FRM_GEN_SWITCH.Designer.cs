namespace Netbio_VFL_Plus
{
    partial class FRM_GEN_SWITCH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_GEN_SWITCH));
            this.RB_SNP00 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RB_SNP01 = new System.Windows.Forms.RadioButton();
            this.BTN_CONFIRM = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RB_SNP00
            // 
            this.RB_SNP00.AutoSize = true;
            this.RB_SNP00.ForeColor = System.Drawing.Color.DarkKhaki;
            this.RB_SNP00.Location = new System.Drawing.Point(18, 40);
            this.RB_SNP00.Name = "RB_SNP00";
            this.RB_SNP00.Size = new System.Drawing.Size(98, 23);
            this.RB_SNP00.TabIndex = 0;
            this.RB_SNP00.TabStop = true;
            this.RB_SNP00.Text = "Footsteps";
            this.RB_SNP00.UseVisualStyleBackColor = true;
            this.RB_SNP00.CheckedChanged += new System.EventHandler(this.RB_SNP00_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RB_SNP01);
            this.groupBox1.Controls.Add(this.RB_SNP00);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SNP Switch";
            // 
            // RB_SNP01
            // 
            this.RB_SNP01.AutoSize = true;
            this.RB_SNP01.ForeColor = System.Drawing.Color.DarkKhaki;
            this.RB_SNP01.Location = new System.Drawing.Point(127, 40);
            this.RB_SNP01.Name = "RB_SNP01";
            this.RB_SNP01.Size = new System.Drawing.Size(114, 23);
            this.RB_SNP01.TabIndex = 2;
            this.RB_SNP01.TabStop = true;
            this.RB_SNP01.Text = "Room Audio";
            this.RB_SNP01.UseVisualStyleBackColor = true;
            this.RB_SNP01.CheckedChanged += new System.EventHandler(this.RB_SNP01_CheckedChanged);
            // 
            // BTN_CONFIRM
            // 
            this.BTN_CONFIRM.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.BTN_CONFIRM.Location = new System.Drawing.Point(12, 118);
            this.BTN_CONFIRM.Name = "BTN_CONFIRM";
            this.BTN_CONFIRM.Size = new System.Drawing.Size(254, 35);
            this.BTN_CONFIRM.TabIndex = 2;
            this.BTN_CONFIRM.Text = "CONFIRM";
            this.BTN_CONFIRM.UseVisualStyleBackColor = true;
            this.BTN_CONFIRM.Click += new System.EventHandler(this.BTN_CONFIRM_Click);
            // 
            // FRM_GEN_SWITCH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(275, 155);
            this.Controls.Add(this.BTN_CONFIRM);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_GEN_SWITCH";
            this.Text = "SNP SWITCH";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton RB_SNP00;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RB_SNP01;
        private System.Windows.Forms.Button BTN_CONFIRM;
    }
}