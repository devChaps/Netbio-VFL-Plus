namespace Netbio_VFL_Plus
{
    partial class FRM_DEBUG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_DEBUG));
            this.DEBUG_LOG = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BTN_CLEAR = new System.Windows.Forms.ToolStripButton();
            this.BTN_EXPORT = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DEBUG_LOG
            // 
            this.DEBUG_LOG.BackColor = System.Drawing.SystemColors.InfoText;
            this.DEBUG_LOG.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEBUG_LOG.ForeColor = System.Drawing.Color.Turquoise;
            this.DEBUG_LOG.Location = new System.Drawing.Point(3, 31);
            this.DEBUG_LOG.Name = "DEBUG_LOG";
            this.DEBUG_LOG.Size = new System.Drawing.Size(722, 484);
            this.DEBUG_LOG.TabIndex = 0;
            this.DEBUG_LOG.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BTN_CLEAR,
            this.BTN_EXPORT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BTN_CLEAR
            // 
            this.BTN_CLEAR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_CLEAR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_CLEAR.Image")));
            this.BTN_CLEAR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_CLEAR.Name = "BTN_CLEAR";
            this.BTN_CLEAR.Size = new System.Drawing.Size(23, 22);
            this.BTN_CLEAR.Text = "toolStripButton1";
            this.BTN_CLEAR.Click += new System.EventHandler(this.BTN_CLEAR_Click);
            // 
            // BTN_EXPORT
            // 
            this.BTN_EXPORT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BTN_EXPORT.Image = ((System.Drawing.Image)(resources.GetObject("BTN_EXPORT.Image")));
            this.BTN_EXPORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BTN_EXPORT.Name = "BTN_EXPORT";
            this.BTN_EXPORT.Size = new System.Drawing.Size(23, 22);
            this.BTN_EXPORT.Text = "toolStripButton2";
            this.BTN_EXPORT.Click += new System.EventHandler(this.BTN_EXPORT_Click);
            // 
            // FRM_DEBUG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 522);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.DEBUG_LOG);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_DEBUG";
            this.Text = "CONTEXTUAL DEBUG FORM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_DEBUG_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BTN_CLEAR;
        private System.Windows.Forms.ToolStripButton BTN_EXPORT;
        public System.Windows.Forms.RichTextBox DEBUG_LOG;
    }
}