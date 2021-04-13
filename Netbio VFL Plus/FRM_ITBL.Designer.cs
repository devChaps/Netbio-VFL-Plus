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
            this.ItemIco_List = new System.Windows.Forms.ImageList(this.components);
            this.Btn_TBL_UPDATE = new System.Windows.Forms.Button();
            this.NUD_TBL_OCCURENCE = new System.Windows.Forms.NumericUpDown();
            this.NUD_TBL_QUANTITY = new System.Windows.Forms.NumericUpDown();
            this.NUD_TBL_ItemID = new System.Windows.Forms.NumericUpDown();
            this.CMB_ITEMNAME = new System.Windows.Forms.ComboBox();
            this.Nud_TBL_Index = new System.Windows.Forms.NumericUpDown();
            this.ItemSelectionGroupBox = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LBL_DFC = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_ONLINE = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_OCCURENCE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_QUANTITY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_ItemID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_TBL_Index)).BeginInit();
            this.ItemSelectionGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV_ItemTable
            // 
            this.LV_ItemTable.BackColor = System.Drawing.Color.Black;
            this.LV_ItemTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.LV_ItemTable.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_ItemTable.ForeColor = System.Drawing.Color.BlanchedAlmond;
            this.LV_ItemTable.FullRowSelect = true;
            this.LV_ItemTable.HideSelection = false;
            this.LV_ItemTable.Location = new System.Drawing.Point(0, 2);
            this.LV_ItemTable.Name = "LV_ItemTable";
            this.LV_ItemTable.Size = new System.Drawing.Size(397, 556);
            this.LV_ItemTable.SmallImageList = this.ItemIco_List;
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
            // ItemIco_List
            // 
            this.ItemIco_List.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ItemIco_List.ImageStream")));
            this.ItemIco_List.TransparentColor = System.Drawing.Color.Transparent;
            this.ItemIco_List.Images.SetKeyName(0, "0.png");
            this.ItemIco_List.Images.SetKeyName(1, "1.png");
            this.ItemIco_List.Images.SetKeyName(2, "2.png");
            this.ItemIco_List.Images.SetKeyName(3, "3.png");
            this.ItemIco_List.Images.SetKeyName(4, "4.png");
            this.ItemIco_List.Images.SetKeyName(5, "5.png");
            this.ItemIco_List.Images.SetKeyName(6, "7.png");
            this.ItemIco_List.Images.SetKeyName(7, "8.png");
            this.ItemIco_List.Images.SetKeyName(8, "10.png");
            this.ItemIco_List.Images.SetKeyName(9, "11.png");
            this.ItemIco_List.Images.SetKeyName(10, "12.png");
            this.ItemIco_List.Images.SetKeyName(11, "13.png");
            this.ItemIco_List.Images.SetKeyName(12, "14.png");
            this.ItemIco_List.Images.SetKeyName(13, "15.png");
            this.ItemIco_List.Images.SetKeyName(14, "16.png");
            this.ItemIco_List.Images.SetKeyName(15, "17.png");
            this.ItemIco_List.Images.SetKeyName(16, "18.png");
            this.ItemIco_List.Images.SetKeyName(17, "19.png");
            this.ItemIco_List.Images.SetKeyName(18, "20.png");
            this.ItemIco_List.Images.SetKeyName(19, "23.png");
            this.ItemIco_List.Images.SetKeyName(20, "24.png");
            this.ItemIco_List.Images.SetKeyName(21, "25.png");
            this.ItemIco_List.Images.SetKeyName(22, "28.png");
            this.ItemIco_List.Images.SetKeyName(23, "29.png");
            this.ItemIco_List.Images.SetKeyName(24, "30.png");
            this.ItemIco_List.Images.SetKeyName(25, "31.png");
            this.ItemIco_List.Images.SetKeyName(26, "32.png");
            this.ItemIco_List.Images.SetKeyName(27, "100.png");
            this.ItemIco_List.Images.SetKeyName(28, "101.png");
            this.ItemIco_List.Images.SetKeyName(29, "102.png");
            this.ItemIco_List.Images.SetKeyName(30, "103.png");
            this.ItemIco_List.Images.SetKeyName(31, "104.png");
            this.ItemIco_List.Images.SetKeyName(32, "105.png");
            this.ItemIco_List.Images.SetKeyName(33, "106.png");
            this.ItemIco_List.Images.SetKeyName(34, "107.png");
            this.ItemIco_List.Images.SetKeyName(35, "108.png");
            this.ItemIco_List.Images.SetKeyName(36, "109.png");
            this.ItemIco_List.Images.SetKeyName(37, "110.png");
            this.ItemIco_List.Images.SetKeyName(38, "111.png");
            this.ItemIco_List.Images.SetKeyName(39, "112.png");
            this.ItemIco_List.Images.SetKeyName(40, "113.png");
            this.ItemIco_List.Images.SetKeyName(41, "114.png");
            this.ItemIco_List.Images.SetKeyName(42, "115.png");
            this.ItemIco_List.Images.SetKeyName(43, "116.png");
            this.ItemIco_List.Images.SetKeyName(44, "117.png");
            this.ItemIco_List.Images.SetKeyName(45, "118.png");
            this.ItemIco_List.Images.SetKeyName(46, "119.png");
            this.ItemIco_List.Images.SetKeyName(47, "155.png");
            this.ItemIco_List.Images.SetKeyName(48, "157.png");
            this.ItemIco_List.Images.SetKeyName(49, "158.png");
            this.ItemIco_List.Images.SetKeyName(50, "159.png");
            this.ItemIco_List.Images.SetKeyName(51, "160.png");
            this.ItemIco_List.Images.SetKeyName(52, "200.png");
            this.ItemIco_List.Images.SetKeyName(53, "201.png");
            this.ItemIco_List.Images.SetKeyName(54, "202.png");
            this.ItemIco_List.Images.SetKeyName(55, "204.png");
            this.ItemIco_List.Images.SetKeyName(56, "205.png");
            this.ItemIco_List.Images.SetKeyName(57, "206.png");
            this.ItemIco_List.Images.SetKeyName(58, "207.png");
            this.ItemIco_List.Images.SetKeyName(59, "209.png");
            this.ItemIco_List.Images.SetKeyName(60, "210.png");
            this.ItemIco_List.Images.SetKeyName(61, "211.png");
            this.ItemIco_List.Images.SetKeyName(62, "250.png");
            this.ItemIco_List.Images.SetKeyName(63, "251.png");
            this.ItemIco_List.Images.SetKeyName(64, "252.png");
            this.ItemIco_List.Images.SetKeyName(65, "253.png");
            this.ItemIco_List.Images.SetKeyName(66, "254.png");
            this.ItemIco_List.Images.SetKeyName(67, "255.png");
            this.ItemIco_List.Images.SetKeyName(68, "257.png");
            this.ItemIco_List.Images.SetKeyName(69, "258.png");
            this.ItemIco_List.Images.SetKeyName(70, "259.png");
            this.ItemIco_List.Images.SetKeyName(71, "262.png");
            this.ItemIco_List.Images.SetKeyName(72, "300.png");
            this.ItemIco_List.Images.SetKeyName(73, "301.png");
            this.ItemIco_List.Images.SetKeyName(74, "302.png");
            this.ItemIco_List.Images.SetKeyName(75, "303.png");
            this.ItemIco_List.Images.SetKeyName(76, "304.png");
            this.ItemIco_List.Images.SetKeyName(77, "305.png");
            this.ItemIco_List.Images.SetKeyName(78, "306.png");
            this.ItemIco_List.Images.SetKeyName(79, "307.png");
            this.ItemIco_List.Images.SetKeyName(80, "308.png");
            this.ItemIco_List.Images.SetKeyName(81, "309.png");
            this.ItemIco_List.Images.SetKeyName(82, "310.png");
            this.ItemIco_List.Images.SetKeyName(83, "311.png");
            this.ItemIco_List.Images.SetKeyName(84, "312.png");
            this.ItemIco_List.Images.SetKeyName(85, "313.png");
            this.ItemIco_List.Images.SetKeyName(86, "314.png");
            this.ItemIco_List.Images.SetKeyName(87, "315.png");
            this.ItemIco_List.Images.SetKeyName(88, "316.png");
            this.ItemIco_List.Images.SetKeyName(89, "317.png");
            this.ItemIco_List.Images.SetKeyName(90, "318.png");
            this.ItemIco_List.Images.SetKeyName(91, "400.png");
            this.ItemIco_List.Images.SetKeyName(92, "401.png");
            this.ItemIco_List.Images.SetKeyName(93, "403.png");
            this.ItemIco_List.Images.SetKeyName(94, "405.png");
            this.ItemIco_List.Images.SetKeyName(95, "406.png");
            this.ItemIco_List.Images.SetKeyName(96, "407.png");
            this.ItemIco_List.Images.SetKeyName(97, "408.png");
            this.ItemIco_List.Images.SetKeyName(98, "409.png");
            this.ItemIco_List.Images.SetKeyName(99, "410.png");
            this.ItemIco_List.Images.SetKeyName(100, "411.png");
            this.ItemIco_List.Images.SetKeyName(101, "412.png");
            this.ItemIco_List.Images.SetKeyName(102, "413.png");
            this.ItemIco_List.Images.SetKeyName(103, "414.png");
            this.ItemIco_List.Images.SetKeyName(104, "415.png");
            this.ItemIco_List.Images.SetKeyName(105, "416.png");
            this.ItemIco_List.Images.SetKeyName(106, "417.png");
            this.ItemIco_List.Images.SetKeyName(107, "418.png");
            this.ItemIco_List.Images.SetKeyName(108, "419.png");
            this.ItemIco_List.Images.SetKeyName(109, "420.png");
            this.ItemIco_List.Images.SetKeyName(110, "450.png");
            this.ItemIco_List.Images.SetKeyName(111, "451.png");
            this.ItemIco_List.Images.SetKeyName(112, "452.png");
            this.ItemIco_List.Images.SetKeyName(113, "453.png");
            this.ItemIco_List.Images.SetKeyName(114, "454.png");
            this.ItemIco_List.Images.SetKeyName(115, "455.png");
            this.ItemIco_List.Images.SetKeyName(116, "456.png");
            this.ItemIco_List.Images.SetKeyName(117, "10100.png");
            this.ItemIco_List.Images.SetKeyName(118, "10102.png");
            this.ItemIco_List.Images.SetKeyName(119, "10103.png");
            this.ItemIco_List.Images.SetKeyName(120, "10105.png");
            this.ItemIco_List.Images.SetKeyName(121, "10106.png");
            this.ItemIco_List.Images.SetKeyName(122, "10107.png");
            this.ItemIco_List.Images.SetKeyName(123, "10108.png");
            this.ItemIco_List.Images.SetKeyName(124, "10150.png");
            this.ItemIco_List.Images.SetKeyName(125, "10206.png");
            this.ItemIco_List.Images.SetKeyName(126, "10207.png");
            this.ItemIco_List.Images.SetKeyName(127, "10208.png");
            this.ItemIco_List.Images.SetKeyName(128, "10209.png");
            this.ItemIco_List.Images.SetKeyName(129, "10210.png");
            this.ItemIco_List.Images.SetKeyName(130, "10211.png");
            this.ItemIco_List.Images.SetKeyName(131, "10507.png");
            this.ItemIco_List.Images.SetKeyName(132, "10600.png");
            this.ItemIco_List.Images.SetKeyName(133, "10601.png");
            this.ItemIco_List.Images.SetKeyName(134, "10602.png");
            this.ItemIco_List.Images.SetKeyName(135, "10603.png");
            this.ItemIco_List.Images.SetKeyName(136, "10604.png");
            this.ItemIco_List.Images.SetKeyName(137, "10605.png");
            this.ItemIco_List.Images.SetKeyName(138, "10609.png");
            this.ItemIco_List.Images.SetKeyName(139, "10610.png");
            this.ItemIco_List.Images.SetKeyName(140, "10611.png");
            this.ItemIco_List.Images.SetKeyName(141, "10612.png");
            this.ItemIco_List.Images.SetKeyName(142, "10650.png");
            this.ItemIco_List.Images.SetKeyName(143, "10651.png");
            this.ItemIco_List.Images.SetKeyName(144, "10652.png");
            this.ItemIco_List.Images.SetKeyName(145, "11000.png");
            this.ItemIco_List.Images.SetKeyName(146, "11001.png");
            this.ItemIco_List.Images.SetKeyName(147, "11002.png");
            this.ItemIco_List.Images.SetKeyName(148, "11003.png");
            this.ItemIco_List.Images.SetKeyName(149, "11004.png");
            this.ItemIco_List.Images.SetKeyName(150, "11006.png");
            this.ItemIco_List.Images.SetKeyName(151, "11007.png");
            this.ItemIco_List.Images.SetKeyName(152, "11008.png");
            this.ItemIco_List.Images.SetKeyName(153, "11040.png");
            this.ItemIco_List.Images.SetKeyName(154, "11050.png");
            this.ItemIco_List.Images.SetKeyName(155, "11051.png");
            this.ItemIco_List.Images.SetKeyName(156, "11052.png");
            this.ItemIco_List.Images.SetKeyName(157, "11500.png");
            this.ItemIco_List.Images.SetKeyName(158, "11501.png");
            this.ItemIco_List.Images.SetKeyName(159, "11502.png");
            this.ItemIco_List.Images.SetKeyName(160, "11503.png");
            this.ItemIco_List.Images.SetKeyName(161, "11504.png");
            this.ItemIco_List.Images.SetKeyName(162, "11505.png");
            this.ItemIco_List.Images.SetKeyName(163, "11506.png");
            this.ItemIco_List.Images.SetKeyName(164, "11508.png");
            this.ItemIco_List.Images.SetKeyName(165, "11509.png");
            this.ItemIco_List.Images.SetKeyName(166, "11510.png");
            this.ItemIco_List.Images.SetKeyName(167, "11512.png");
            this.ItemIco_List.Images.SetKeyName(168, "11513.png");
            this.ItemIco_List.Images.SetKeyName(169, "11514.png");
            this.ItemIco_List.Images.SetKeyName(170, "11515.png");
            this.ItemIco_List.Images.SetKeyName(171, "11550.png");
            this.ItemIco_List.Images.SetKeyName(172, "12063.png");
            this.ItemIco_List.Images.SetKeyName(173, "12600.png");
            this.ItemIco_List.Images.SetKeyName(174, "12601.png");
            this.ItemIco_List.Images.SetKeyName(175, "12602.png");
            this.ItemIco_List.Images.SetKeyName(176, "12604.png");
            this.ItemIco_List.Images.SetKeyName(177, "12605.png");
            this.ItemIco_List.Images.SetKeyName(178, "12801.png");
            this.ItemIco_List.Images.SetKeyName(179, "12805.png");
            this.ItemIco_List.Images.SetKeyName(180, "12806.png");
            this.ItemIco_List.Images.SetKeyName(181, "12807.png");
            this.ItemIco_List.Images.SetKeyName(182, "12850.png");
            this.ItemIco_List.Images.SetKeyName(183, "12851.png");
            this.ItemIco_List.Images.SetKeyName(184, "13500.png");
            this.ItemIco_List.Images.SetKeyName(185, "13501.png");
            this.ItemIco_List.Images.SetKeyName(186, "13502.png");
            this.ItemIco_List.Images.SetKeyName(187, "13503.png");
            this.ItemIco_List.Images.SetKeyName(188, "13504.png");
            this.ItemIco_List.Images.SetKeyName(189, "13505.png");
            this.ItemIco_List.Images.SetKeyName(190, "13506.png");
            this.ItemIco_List.Images.SetKeyName(191, "13507.png");
            this.ItemIco_List.Images.SetKeyName(192, "13508.png");
            this.ItemIco_List.Images.SetKeyName(193, "14000.png");
            this.ItemIco_List.Images.SetKeyName(194, "14001.png");
            this.ItemIco_List.Images.SetKeyName(195, "14002.png");
            this.ItemIco_List.Images.SetKeyName(196, "14003.png");
            this.ItemIco_List.Images.SetKeyName(197, "14004.png");
            this.ItemIco_List.Images.SetKeyName(198, "14005.png");
            this.ItemIco_List.Images.SetKeyName(199, "14006.png");
            this.ItemIco_List.Images.SetKeyName(200, "14007.png");
            this.ItemIco_List.Images.SetKeyName(201, "14008.png");
            this.ItemIco_List.Images.SetKeyName(202, "14009.png");
            this.ItemIco_List.Images.SetKeyName(203, "14100.png");
            this.ItemIco_List.Images.SetKeyName(204, "14101.png");
            this.ItemIco_List.Images.SetKeyName(205, "14102.png");
            this.ItemIco_List.Images.SetKeyName(206, "14103.png");
            this.ItemIco_List.Images.SetKeyName(207, "14104.png");
            this.ItemIco_List.Images.SetKeyName(208, "14105.png");
            this.ItemIco_List.Images.SetKeyName(209, "14106.png");
            this.ItemIco_List.Images.SetKeyName(210, "14107.png");
            this.ItemIco_List.Images.SetKeyName(211, "14108.png");
            this.ItemIco_List.Images.SetKeyName(212, "14109.png");
            this.ItemIco_List.Images.SetKeyName(213, "14110.png");
            this.ItemIco_List.Images.SetKeyName(214, "14111.png");
            // 
            // Btn_TBL_UPDATE
            // 
            this.Btn_TBL_UPDATE.Location = new System.Drawing.Point(103, 53);
            this.Btn_TBL_UPDATE.Name = "Btn_TBL_UPDATE";
            this.Btn_TBL_UPDATE.Size = new System.Drawing.Size(288, 60);
            this.Btn_TBL_UPDATE.TabIndex = 6;
            this.Btn_TBL_UPDATE.Text = "Update Entry";
            this.Btn_TBL_UPDATE.UseVisualStyleBackColor = true;
            this.Btn_TBL_UPDATE.Click += new System.EventHandler(this.Btn_TBL_UPDATE_Click);
            // 
            // NUD_TBL_OCCURENCE
            // 
            this.NUD_TBL_OCCURENCE.Location = new System.Drawing.Point(12, 53);
            this.NUD_TBL_OCCURENCE.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NUD_TBL_OCCURENCE.Name = "NUD_TBL_OCCURENCE";
            this.NUD_TBL_OCCURENCE.Size = new System.Drawing.Size(85, 27);
            this.NUD_TBL_OCCURENCE.TabIndex = 5;
            // 
            // NUD_TBL_QUANTITY
            // 
            this.NUD_TBL_QUANTITY.Location = new System.Drawing.Point(12, 86);
            this.NUD_TBL_QUANTITY.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NUD_TBL_QUANTITY.Name = "NUD_TBL_QUANTITY";
            this.NUD_TBL_QUANTITY.Size = new System.Drawing.Size(85, 27);
            this.NUD_TBL_QUANTITY.TabIndex = 4;
            this.NUD_TBL_QUANTITY.ValueChanged += new System.EventHandler(this.NUD_TBL_QUANTITY_ValueChanged);
            // 
            // NUD_TBL_ItemID
            // 
            this.NUD_TBL_ItemID.Location = new System.Drawing.Point(81, 20);
            this.NUD_TBL_ItemID.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.NUD_TBL_ItemID.Name = "NUD_TBL_ItemID";
            this.NUD_TBL_ItemID.Size = new System.Drawing.Size(85, 27);
            this.NUD_TBL_ItemID.TabIndex = 3;
            // 
            // CMB_ITEMNAME
            // 
            this.CMB_ITEMNAME.FormattingEnabled = true;
            this.CMB_ITEMNAME.Location = new System.Drawing.Point(170, 20);
            this.CMB_ITEMNAME.Name = "CMB_ITEMNAME";
            this.CMB_ITEMNAME.Size = new System.Drawing.Size(221, 27);
            this.CMB_ITEMNAME.TabIndex = 1;
            // 
            // Nud_TBL_Index
            // 
            this.Nud_TBL_Index.Location = new System.Drawing.Point(12, 20);
            this.Nud_TBL_Index.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Nud_TBL_Index.Name = "Nud_TBL_Index";
            this.Nud_TBL_Index.Size = new System.Drawing.Size(63, 27);
            this.Nud_TBL_Index.TabIndex = 2;
            // 
            // ItemSelectionGroupBox
            // 
            this.ItemSelectionGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.ItemSelectionGroupBox.Controls.Add(this.statusStrip1);
            this.ItemSelectionGroupBox.Controls.Add(this.Btn_TBL_UPDATE);
            this.ItemSelectionGroupBox.Controls.Add(this.NUD_TBL_OCCURENCE);
            this.ItemSelectionGroupBox.Controls.Add(this.NUD_TBL_QUANTITY);
            this.ItemSelectionGroupBox.Controls.Add(this.NUD_TBL_ItemID);
            this.ItemSelectionGroupBox.Controls.Add(this.CMB_ITEMNAME);
            this.ItemSelectionGroupBox.Controls.Add(this.Nud_TBL_Index);
            this.ItemSelectionGroupBox.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemSelectionGroupBox.Location = new System.Drawing.Point(0, 564);
            this.ItemSelectionGroupBox.Name = "ItemSelectionGroupBox";
            this.ItemSelectionGroupBox.Size = new System.Drawing.Size(397, 141);
            this.ItemSelectionGroupBox.TabIndex = 4;
            this.ItemSelectionGroupBox.TabStop = false;
            this.ItemSelectionGroupBox.Text = "Edit Selection";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LBL_DFC,
            this.LBL_ONLINE});
            this.statusStrip1.Location = new System.Drawing.Point(3, 116);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(391, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LBL_DFC
            // 
            this.LBL_DFC.BackColor = System.Drawing.Color.Violet;
            this.LBL_DFC.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_DFC.Name = "LBL_DFC";
            this.LBL_DFC.Size = new System.Drawing.Size(100, 17);
            this.LBL_DFC.Text = "DIFFICULTY :";
            // 
            // LBL_ONLINE
            // 
            this.LBL_ONLINE.BackColor = System.Drawing.Color.Violet;
            this.LBL_ONLINE.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_ONLINE.Name = "LBL_ONLINE";
            this.LBL_ONLINE.Size = new System.Drawing.Size(56, 17);
            this.LBL_ONLINE.Text = "MODE:";
            // 
            // FRM_ITBL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 707);
            this.Controls.Add(this.ItemSelectionGroupBox);
            this.Controls.Add(this.LV_ItemTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_ITBL";
            this.Text = "ITEM TABLE ENTRY EDITOR";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_OCCURENCE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_QUANTITY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TBL_ItemID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_TBL_Index)).EndInit();
            this.ItemSelectionGroupBox.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel LBL_DFC;
        public System.Windows.Forms.ToolStripStatusLabel LBL_ONLINE;
    }
}