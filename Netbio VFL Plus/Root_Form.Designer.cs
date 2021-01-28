namespace Netbio_VFL_Plus
{
    partial class Root_Form
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
            this.LBL_VM_SPC = new System.Windows.Forms.Label();
            this.LBL_SEC_SZ = new System.Windows.Forms.Label();
            this.LBL_VNAME = new System.Windows.Forms.Label();
            this.TextBox_PhysicalSz = new System.Windows.Forms.TextBox();
            this.TextBox_Sector_Sz = new System.Windows.Forms.TextBox();
            this.TextBox_Vname = new System.Windows.Forms.TextBox();
            this.TV_Root = new System.Windows.Forms.TreeView();
            this.BTN_RCANCEL = new System.Windows.Forms.Button();
            this.BTN_AFSCHECK = new System.Windows.Forms.Button();
            this.RootForm_Dbg = new System.Windows.Forms.RichTextBox();
            this.TT_NodeInfo = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LBL_VM_SPC
            // 
            this.LBL_VM_SPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_VM_SPC.Location = new System.Drawing.Point(12, 73);
            this.LBL_VM_SPC.Name = "LBL_VM_SPC";
            this.LBL_VM_SPC.Size = new System.Drawing.Size(79, 23);
            this.LBL_VM_SPC.TabIndex = 13;
            this.LBL_VM_SPC.Text = "Volume Space";
            // 
            // LBL_SEC_SZ
            // 
            this.LBL_SEC_SZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_SEC_SZ.Location = new System.Drawing.Point(12, 50);
            this.LBL_SEC_SZ.Name = "LBL_SEC_SZ";
            this.LBL_SEC_SZ.Size = new System.Drawing.Size(79, 23);
            this.LBL_SEC_SZ.TabIndex = 12;
            this.LBL_SEC_SZ.Text = "Sector Size";
            // 
            // LBL_VNAME
            // 
            this.LBL_VNAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_VNAME.Location = new System.Drawing.Point(12, 24);
            this.LBL_VNAME.Name = "LBL_VNAME";
            this.LBL_VNAME.Size = new System.Drawing.Size(93, 23);
            this.LBL_VNAME.TabIndex = 11;
            this.LBL_VNAME.Text = "Volume Name";
            // 
            // TextBox_PhysicalSz
            // 
            this.TextBox_PhysicalSz.Location = new System.Drawing.Point(108, 76);
            this.TextBox_PhysicalSz.Name = "TextBox_PhysicalSz";
            this.TextBox_PhysicalSz.Size = new System.Drawing.Size(144, 20);
            this.TextBox_PhysicalSz.TabIndex = 10;
            // 
            // TextBox_Sector_Sz
            // 
            this.TextBox_Sector_Sz.Location = new System.Drawing.Point(108, 47);
            this.TextBox_Sector_Sz.Name = "TextBox_Sector_Sz";
            this.TextBox_Sector_Sz.Size = new System.Drawing.Size(144, 20);
            this.TextBox_Sector_Sz.TabIndex = 9;
            // 
            // TextBox_Vname
            // 
            this.TextBox_Vname.Location = new System.Drawing.Point(108, 21);
            this.TextBox_Vname.Name = "TextBox_Vname";
            this.TextBox_Vname.Size = new System.Drawing.Size(144, 20);
            this.TextBox_Vname.TabIndex = 8;
            // 
            // TV_Root
            // 
            this.TV_Root.BackColor = System.Drawing.SystemColors.WindowText;
            this.TV_Root.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TV_Root.ForeColor = System.Drawing.Color.Cyan;
            this.TV_Root.Location = new System.Drawing.Point(10, 102);
            this.TV_Root.Name = "TV_Root";
            this.TV_Root.Size = new System.Drawing.Size(242, 377);
            this.TV_Root.TabIndex = 7;
            this.TV_Root.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.TV_Root_NodeMouseHover);
            this.TV_Root.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_Root_NodeMouseDoubleClick);
            // 
            // BTN_RCANCEL
            // 
            this.BTN_RCANCEL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTN_RCANCEL.Location = new System.Drawing.Point(162, 589);
            this.BTN_RCANCEL.Name = "BTN_RCANCEL";
            this.BTN_RCANCEL.Size = new System.Drawing.Size(90, 23);
            this.BTN_RCANCEL.TabIndex = 16;
            this.BTN_RCANCEL.Text = "Cancel";
            this.BTN_RCANCEL.UseVisualStyleBackColor = true;
            this.BTN_RCANCEL.Click += new System.EventHandler(this.BTN_RCANCEL_Click);
            // 
            // BTN_AFSCHECK
            // 
            this.BTN_AFSCHECK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTN_AFSCHECK.Location = new System.Drawing.Point(10, 589);
            this.BTN_AFSCHECK.Name = "BTN_AFSCHECK";
            this.BTN_AFSCHECK.Size = new System.Drawing.Size(89, 23);
            this.BTN_AFSCHECK.TabIndex = 15;
            this.BTN_AFSCHECK.Text = "OK";
            this.BTN_AFSCHECK.UseVisualStyleBackColor = true;
            this.BTN_AFSCHECK.Click += new System.EventHandler(this.BTN_AFSCHECK_Click);
            // 
            // RootForm_Dbg
            // 
            this.RootForm_Dbg.BackColor = System.Drawing.SystemColors.WindowText;
            this.RootForm_Dbg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.RootForm_Dbg.Location = new System.Drawing.Point(12, 485);
            this.RootForm_Dbg.Name = "RootForm_Dbg";
            this.RootForm_Dbg.Size = new System.Drawing.Size(240, 96);
            this.RootForm_Dbg.TabIndex = 14;
            this.RootForm_Dbg.Text = "";
            // 
            // Root_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(263, 624);
            this.Controls.Add(this.BTN_RCANCEL);
            this.Controls.Add(this.BTN_AFSCHECK);
            this.Controls.Add(this.RootForm_Dbg);
            this.Controls.Add(this.LBL_VM_SPC);
            this.Controls.Add(this.LBL_SEC_SZ);
            this.Controls.Add(this.LBL_VNAME);
            this.Controls.Add(this.TextBox_PhysicalSz);
            this.Controls.Add(this.TextBox_Sector_Sz);
            this.Controls.Add(this.TextBox_Vname);
            this.Controls.Add(this.TV_Root);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Name = "Root_Form";
            this.Text = "Root_Form";
            this.Load += new System.EventHandler(this.Root_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_VM_SPC;
        private System.Windows.Forms.Label LBL_SEC_SZ;
        private System.Windows.Forms.Label LBL_VNAME;
        private System.Windows.Forms.TextBox TextBox_PhysicalSz;
        private System.Windows.Forms.TextBox TextBox_Sector_Sz;
        private System.Windows.Forms.TextBox TextBox_Vname;
        private System.Windows.Forms.TreeView TV_Root;
        private System.Windows.Forms.Button BTN_RCANCEL;
        private System.Windows.Forms.Button BTN_AFSCHECK;
        private System.Windows.Forms.RichTextBox RootForm_Dbg;
        private System.Windows.Forms.ToolTip TT_NodeInfo;
    }
}