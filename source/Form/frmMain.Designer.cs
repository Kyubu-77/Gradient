namespace LED_Planer
{
    partial class FrmGradient
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
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.cboGradients = new System.Windows.Forms.ComboBox();
            this.btnDeleteGradient = new System.Windows.Forms.Button();
            this.picGradientPointColor = new System.Windows.Forms.PictureBox();
            this.picRed = new System.Windows.Forms.PictureBox();
            this.picGreen = new System.Windows.Forms.PictureBox();
            this.picBlue = new System.Windows.Forms.PictureBox();
            this.txtBlue = new System.Windows.Forms.TextBox();
            this.txtGreen = new System.Windows.Forms.TextBox();
            this.txtRed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbrPosition = new System.Windows.Forms.TrackBar();
            this.btnAddNewPoint = new System.Windows.Forms.Button();
            this.btnDeletePoint = new System.Windows.Forms.Button();
            this.btnNewGradient = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpGradientInput = new System.Windows.Forms.GroupBox();
            this.grdPoints = new System.Windows.Forms.DataGridView();
            this.grpPointInput = new System.Windows.Forms.GroupBox();
            this.cboSegment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxH_Snap = new System.Windows.Forms.CheckBox();
            this.txtH_SnapKeySpace = new System.Windows.Forms.TextBox();
            this.txtV_SnapKeySpace = new System.Windows.Forms.TextBox();
            this.cbxV_Snap = new System.Windows.Forms.CheckBox();
            this.cbxUseRelativeSnap = new System.Windows.Forms.CheckBox();
            this.cbxShowAnchors = new System.Windows.Forms.CheckBox();
            this.txtH_GridSpace = new System.Windows.Forms.TextBox();
            this.txtV_GridSpace = new System.Windows.Forms.TextBox();
            this.cbxH_ShowGrid = new System.Windows.Forms.CheckBox();
            this.cbxV_ShowGrid = new System.Windows.Forms.CheckBox();
            this.txtH_MainLineEveryXth = new System.Windows.Forms.TextBox();
            this.cbxH_HighlightMainGrid = new System.Windows.Forms.CheckBox();
            this.txtV_MainLineEveryXth = new System.Windows.Forms.TextBox();
            this.cbxV_HighlightMainGrid = new System.Windows.Forms.CheckBox();
            this.cbxOnlyMain = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxV_SnapAnchor = new System.Windows.Forms.CheckBox();
            this.cbxH_SnapAnchor = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtV_SnapAnchorSpace = new System.Windows.Forms.TextBox();
            this.txtH_SnapAnchorSpace = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxAllowSelectingAnchors = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCameraReset = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGradientPointColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrPosition)).BeginInit();
            this.grpGradientInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPoints)).BeginInit();
            this.grpPointInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picGraph
            // 
            this.picGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picGraph.Location = new System.Drawing.Point(245, 42);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(1154, 434);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            this.picGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.picGraph_Paint);
            this.picGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseDown);
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            this.picGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseUp);
            this.picGraph.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseWheel);
            this.picGraph.Resize += new System.EventHandler(this.picGraph_Resize);
            // 
            // cboGradients
            // 
            this.cboGradients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradients.FormattingEnabled = true;
            this.cboGradients.Location = new System.Drawing.Point(12, 12);
            this.cboGradients.Name = "cboGradients";
            this.cboGradients.Size = new System.Drawing.Size(227, 24);
            this.cboGradients.Sorted = true;
            this.cboGradients.TabIndex = 1;
            this.cboGradients.SelectionChangeCommitted += new System.EventHandler(this.cboGradient_SelectionChangeCommitted);
            // 
            // btnDeleteGradient
            // 
            this.btnDeleteGradient.Location = new System.Drawing.Point(12, 85);
            this.btnDeleteGradient.Name = "btnDeleteGradient";
            this.btnDeleteGradient.Size = new System.Drawing.Size(227, 37);
            this.btnDeleteGradient.TabIndex = 2;
            this.btnDeleteGradient.Text = "Delete";
            this.btnDeleteGradient.UseVisualStyleBackColor = true;
            this.btnDeleteGradient.Click += new System.EventHandler(this.btnDeleteGradient_Click);
            // 
            // picGradientPointColor
            // 
            this.picGradientPointColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picGradientPointColor.Location = new System.Drawing.Point(719, 19);
            this.picGradientPointColor.Name = "picGradientPointColor";
            this.picGradientPointColor.Size = new System.Drawing.Size(128, 119);
            this.picGradientPointColor.TabIndex = 3;
            this.picGradientPointColor.TabStop = false;
            // 
            // picRed
            // 
            this.picRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picRed.Location = new System.Drawing.Point(273, 43);
            this.picRed.Name = "picRed";
            this.picRed.Size = new System.Drawing.Size(440, 22);
            this.picRed.TabIndex = 3;
            this.picRed.TabStop = false;
            this.picRed.Paint += new System.Windows.Forms.PaintEventHandler(this.picRed_Paint);
            this.picRed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picRed_MouseMove);
            this.picRed.Resize += new System.EventHandler(this.picRed_Resize);
            // 
            // picGreen
            // 
            this.picGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picGreen.Location = new System.Drawing.Point(273, 71);
            this.picGreen.Name = "picGreen";
            this.picGreen.Size = new System.Drawing.Size(440, 22);
            this.picGreen.TabIndex = 3;
            this.picGreen.TabStop = false;
            this.picGreen.Paint += new System.Windows.Forms.PaintEventHandler(this.picGreen_Paint);
            this.picGreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGreen_MouseMove);
            this.picGreen.Resize += new System.EventHandler(this.picGreen_Resize);
            // 
            // picBlue
            // 
            this.picBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBlue.Location = new System.Drawing.Point(273, 99);
            this.picBlue.Name = "picBlue";
            this.picBlue.Size = new System.Drawing.Size(440, 22);
            this.picBlue.TabIndex = 3;
            this.picBlue.TabStop = false;
            this.picBlue.Paint += new System.Windows.Forms.PaintEventHandler(this.picBlue_Paint);
            this.picBlue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBlue_MouseMove);
            this.picBlue.Resize += new System.EventHandler(this.picBlue_Resize);
            // 
            // txtBlue
            // 
            this.txtBlue.Location = new System.Drawing.Point(208, 99);
            this.txtBlue.Name = "txtBlue";
            this.txtBlue.Size = new System.Drawing.Size(59, 22);
            this.txtBlue.TabIndex = 4;
            this.txtBlue.TextChanged += new System.EventHandler(this.txtBlue_TextChanged);
            // 
            // txtGreen
            // 
            this.txtGreen.Location = new System.Drawing.Point(209, 71);
            this.txtGreen.Name = "txtGreen";
            this.txtGreen.Size = new System.Drawing.Size(58, 22);
            this.txtGreen.TabIndex = 4;
            this.txtGreen.TextChanged += new System.EventHandler(this.txtGreen_TextChanged);
            // 
            // txtRed
            // 
            this.txtRed.Location = new System.Drawing.Point(209, 43);
            this.txtRed.Name = "txtRed";
            this.txtRed.Size = new System.Drawing.Size(58, 22);
            this.txtRed.TabIndex = 4;
            this.txtRed.TextChanged += new System.EventHandler(this.txtRed_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Red value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Green Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Blue Value";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(209, 15);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(58, 22);
            this.txtPosition.TabIndex = 4;
            this.txtPosition.TextChanged += new System.EventHandler(this.txtPosition_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Key position";
            // 
            // tbrPosition
            // 
            this.tbrPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbrPosition.AutoSize = false;
            this.tbrPosition.LargeChange = 10;
            this.tbrPosition.Location = new System.Drawing.Point(273, 15);
            this.tbrPosition.Maximum = 1000;
            this.tbrPosition.Name = "tbrPosition";
            this.tbrPosition.Size = new System.Drawing.Size(440, 22);
            this.tbrPosition.TabIndex = 0;
            this.tbrPosition.Scroll += new System.EventHandler(this.tbrPosition_Scroll);
            // 
            // btnAddNewPoint
            // 
            this.btnAddNewPoint.Location = new System.Drawing.Point(163, 20);
            this.btnAddNewPoint.Name = "btnAddNewPoint";
            this.btnAddNewPoint.Size = new System.Drawing.Size(60, 23);
            this.btnAddNewPoint.TabIndex = 7;
            this.btnAddNewPoint.Text = "Add";
            this.btnAddNewPoint.UseVisualStyleBackColor = true;
            this.btnAddNewPoint.Click += new System.EventHandler(this.btnAddNewPoint_Click);
            // 
            // btnDeletePoint
            // 
            this.btnDeletePoint.Location = new System.Drawing.Point(229, 21);
            this.btnDeletePoint.Name = "btnDeletePoint";
            this.btnDeletePoint.Size = new System.Drawing.Size(60, 23);
            this.btnDeletePoint.TabIndex = 7;
            this.btnDeletePoint.Text = "Delete";
            this.btnDeletePoint.UseVisualStyleBackColor = true;
            this.btnDeletePoint.Click += new System.EventHandler(this.btnDeleteGradientPoint_Click);
            // 
            // btnNewGradient
            // 
            this.btnNewGradient.Location = new System.Drawing.Point(12, 42);
            this.btnNewGradient.Name = "btnNewGradient";
            this.btnNewGradient.Size = new System.Drawing.Size(227, 37);
            this.btnNewGradient.TabIndex = 2;
            this.btnNewGradient.Text = "new Gradient";
            this.btnNewGradient.UseVisualStyleBackColor = true;
            this.btnNewGradient.Click += new System.EventHandler(this.btnNewGradient_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(57, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 10;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Name";
            // 
            // grpGradientInput
            // 
            this.grpGradientInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGradientInput.Controls.Add(this.grdPoints);
            this.grpGradientInput.Controls.Add(this.grpPointInput);
            this.grpGradientInput.Controls.Add(this.txtName);
            this.grpGradientInput.Controls.Add(this.label6);
            this.grpGradientInput.Controls.Add(this.label7);
            this.grpGradientInput.Controls.Add(this.btnDeletePoint);
            this.grpGradientInput.Controls.Add(this.btnAddNewPoint);
            this.grpGradientInput.Location = new System.Drawing.Point(245, 479);
            this.grpGradientInput.Name = "grpGradientInput";
            this.grpGradientInput.Size = new System.Drawing.Size(1154, 173);
            this.grpGradientInput.TabIndex = 11;
            this.grpGradientInput.TabStop = false;
            this.grpGradientInput.Text = "Palette";
            // 
            // grdPoints
            // 
            this.grdPoints.AllowUserToAddRows = false;
            this.grdPoints.AllowUserToDeleteRows = false;
            this.grdPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPoints.Location = new System.Drawing.Point(6, 49);
            this.grdPoints.Name = "grdPoints";
            this.grdPoints.ReadOnly = true;
            this.grdPoints.RowTemplate.Height = 24;
            this.grdPoints.Size = new System.Drawing.Size(283, 117);
            this.grdPoints.TabIndex = 13;
            this.grdPoints.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPoints_ColumnHeaderMouseClick);
            this.grdPoints.SelectionChanged += new System.EventHandler(this.grdPoints_SelectionChanged);
            // 
            // grpPointInput
            // 
            this.grpPointInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPointInput.Controls.Add(this.cboSegment);
            this.grpPointInput.Controls.Add(this.picGradientPointColor);
            this.grpPointInput.Controls.Add(this.picRed);
            this.grpPointInput.Controls.Add(this.label8);
            this.grpPointInput.Controls.Add(this.label5);
            this.grpPointInput.Controls.Add(this.txtRed);
            this.grpPointInput.Controls.Add(this.txtBlue);
            this.grpPointInput.Controls.Add(this.picBlue);
            this.grpPointInput.Controls.Add(this.picGreen);
            this.grpPointInput.Controls.Add(this.txtGreen);
            this.grpPointInput.Controls.Add(this.tbrPosition);
            this.grpPointInput.Controls.Add(this.txtPosition);
            this.grpPointInput.Controls.Add(this.label1);
            this.grpPointInput.Controls.Add(this.label3);
            this.grpPointInput.Controls.Add(this.label2);
            this.grpPointInput.Location = new System.Drawing.Point(295, 21);
            this.grpPointInput.Name = "grpPointInput";
            this.grpPointInput.Size = new System.Drawing.Size(853, 146);
            this.grpPointInput.TabIndex = 11;
            this.grpPointInput.TabStop = false;
            this.grpPointInput.Text = "Point";
            // 
            // cboSegment
            // 
            this.cboSegment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSegment.FormattingEnabled = true;
            this.cboSegment.Location = new System.Drawing.Point(6, 38);
            this.cboSegment.Name = "cboSegment";
            this.cboSegment.Size = new System.Drawing.Size(96, 24);
            this.cboSegment.TabIndex = 6;
            this.cboSegment.SelectedIndexChanged += new System.EventHandler(this.cboSegment_SelectedIndexChanged);
            this.cboSegment.SelectionChangeCommitted += new System.EventHandler(this.cboSegment_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "SegmentType";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Points";
            // 
            // cbxH_Snap
            // 
            this.cbxH_Snap.AutoSize = true;
            this.cbxH_Snap.Checked = true;
            this.cbxH_Snap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxH_Snap.Location = new System.Drawing.Point(6, 212);
            this.cbxH_Snap.Name = "cbxH_Snap";
            this.cbxH_Snap.Size = new System.Drawing.Size(131, 21);
            this.cbxH_Snap.TabIndex = 15;
            this.cbxH_Snap.Text = "Key - Horizontal";
            this.cbxH_Snap.UseVisualStyleBackColor = true;
            this.cbxH_Snap.CheckedChanged += new System.EventHandler(this.cbxH_Snap_CheckedChanged);
            // 
            // txtH_SnapKeySpace
            // 
            this.txtH_SnapKeySpace.Location = new System.Drawing.Point(159, 210);
            this.txtH_SnapKeySpace.Name = "txtH_SnapKeySpace";
            this.txtH_SnapKeySpace.Size = new System.Drawing.Size(62, 22);
            this.txtH_SnapKeySpace.TabIndex = 10;
            this.txtH_SnapKeySpace.Text = "0,05";
            this.txtH_SnapKeySpace.TextChanged += new System.EventHandler(this.txtH_Snap_TextChanged);
            // 
            // txtV_SnapKeySpace
            // 
            this.txtV_SnapKeySpace.Location = new System.Drawing.Point(159, 236);
            this.txtV_SnapKeySpace.Name = "txtV_SnapKeySpace";
            this.txtV_SnapKeySpace.Size = new System.Drawing.Size(62, 22);
            this.txtV_SnapKeySpace.TabIndex = 10;
            this.txtV_SnapKeySpace.Text = "0,1";
            this.txtV_SnapKeySpace.TextChanged += new System.EventHandler(this.txtV_Snap_TextChanged);
            // 
            // cbxV_Snap
            // 
            this.cbxV_Snap.AutoSize = true;
            this.cbxV_Snap.Checked = true;
            this.cbxV_Snap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxV_Snap.Location = new System.Drawing.Point(6, 240);
            this.cbxV_Snap.Name = "cbxV_Snap";
            this.cbxV_Snap.Size = new System.Drawing.Size(114, 21);
            this.cbxV_Snap.TabIndex = 15;
            this.cbxV_Snap.Text = "Key - Vertical";
            this.cbxV_Snap.UseVisualStyleBackColor = true;
            this.cbxV_Snap.CheckedChanged += new System.EventHandler(this.cbxV_Snap_CheckedChanged);
            // 
            // cbxUseRelativeSnap
            // 
            this.cbxUseRelativeSnap.AutoSize = true;
            this.cbxUseRelativeSnap.Location = new System.Drawing.Point(6, 264);
            this.cbxUseRelativeSnap.Name = "cbxUseRelativeSnap";
            this.cbxUseRelativeSnap.Size = new System.Drawing.Size(140, 21);
            this.cbxUseRelativeSnap.TabIndex = 15;
            this.cbxUseRelativeSnap.Text = "Use relative snap";
            this.cbxUseRelativeSnap.UseVisualStyleBackColor = true;
            this.cbxUseRelativeSnap.CheckedChanged += new System.EventHandler(this.cbxSnapRelative_CheckedChanged);
            // 
            // cbxShowAnchors
            // 
            this.cbxShowAnchors.AutoSize = true;
            this.cbxShowAnchors.Checked = true;
            this.cbxShowAnchors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxShowAnchors.Location = new System.Drawing.Point(6, 44);
            this.cbxShowAnchors.Name = "cbxShowAnchors";
            this.cbxShowAnchors.Size = new System.Drawing.Size(64, 21);
            this.cbxShowAnchors.TabIndex = 15;
            this.cbxShowAnchors.Text = "Show";
            this.cbxShowAnchors.UseVisualStyleBackColor = true;
            this.cbxShowAnchors.CheckedChanged += new System.EventHandler(this.cbxShowAnchors_CheckedChanged);
            // 
            // txtH_GridSpace
            // 
            this.txtH_GridSpace.Location = new System.Drawing.Point(159, 42);
            this.txtH_GridSpace.Name = "txtH_GridSpace";
            this.txtH_GridSpace.Size = new System.Drawing.Size(62, 22);
            this.txtH_GridSpace.TabIndex = 10;
            this.txtH_GridSpace.Text = "0,05";
            this.txtH_GridSpace.TextChanged += new System.EventHandler(this.txtH_GridSpace_TextChanged);
            // 
            // txtV_GridSpace
            // 
            this.txtV_GridSpace.Location = new System.Drawing.Point(159, 69);
            this.txtV_GridSpace.Name = "txtV_GridSpace";
            this.txtV_GridSpace.Size = new System.Drawing.Size(62, 22);
            this.txtV_GridSpace.TabIndex = 10;
            this.txtV_GridSpace.Text = "0,1";
            this.txtV_GridSpace.TextChanged += new System.EventHandler(this.txtV_GridSpace_TextChanged);
            // 
            // cbxH_ShowGrid
            // 
            this.cbxH_ShowGrid.AutoSize = true;
            this.cbxH_ShowGrid.Checked = true;
            this.cbxH_ShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxH_ShowGrid.Location = new System.Drawing.Point(6, 44);
            this.cbxH_ShowGrid.Name = "cbxH_ShowGrid";
            this.cbxH_ShowGrid.Size = new System.Drawing.Size(94, 21);
            this.cbxH_ShowGrid.TabIndex = 15;
            this.cbxH_ShowGrid.Text = "Horizontal";
            this.cbxH_ShowGrid.UseVisualStyleBackColor = true;
            this.cbxH_ShowGrid.CheckedChanged += new System.EventHandler(this.cbxH_GridShow_CheckedChanged);
            // 
            // cbxV_ShowGrid
            // 
            this.cbxV_ShowGrid.AutoSize = true;
            this.cbxV_ShowGrid.Checked = true;
            this.cbxV_ShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxV_ShowGrid.Location = new System.Drawing.Point(6, 71);
            this.cbxV_ShowGrid.Name = "cbxV_ShowGrid";
            this.cbxV_ShowGrid.Size = new System.Drawing.Size(77, 21);
            this.cbxV_ShowGrid.TabIndex = 15;
            this.cbxV_ShowGrid.Text = "Vertical";
            this.cbxV_ShowGrid.UseVisualStyleBackColor = true;
            this.cbxV_ShowGrid.CheckedChanged += new System.EventHandler(this.cbxV_GridShow_CheckedChanged);
            // 
            // txtH_MainLineEveryXth
            // 
            this.txtH_MainLineEveryXth.Location = new System.Drawing.Point(159, 113);
            this.txtH_MainLineEveryXth.Name = "txtH_MainLineEveryXth";
            this.txtH_MainLineEveryXth.Size = new System.Drawing.Size(62, 22);
            this.txtH_MainLineEveryXth.TabIndex = 10;
            this.txtH_MainLineEveryXth.Text = "5";
            this.txtH_MainLineEveryXth.TextChanged += new System.EventHandler(this.txtH_MainLineEveryXth_TextChanged);
            // 
            // cbxH_HighlightMainGrid
            // 
            this.cbxH_HighlightMainGrid.AutoSize = true;
            this.cbxH_HighlightMainGrid.Checked = true;
            this.cbxH_HighlightMainGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxH_HighlightMainGrid.Location = new System.Drawing.Point(6, 115);
            this.cbxH_HighlightMainGrid.Name = "cbxH_HighlightMainGrid";
            this.cbxH_HighlightMainGrid.Size = new System.Drawing.Size(94, 21);
            this.cbxH_HighlightMainGrid.TabIndex = 15;
            this.cbxH_HighlightMainGrid.Text = "Horizontal";
            this.cbxH_HighlightMainGrid.UseVisualStyleBackColor = true;
            this.cbxH_HighlightMainGrid.CheckedChanged += new System.EventHandler(this.cbxH_HighlightMainGrid_CheckedChanged);
            // 
            // txtV_MainLineEveryXth
            // 
            this.txtV_MainLineEveryXth.Location = new System.Drawing.Point(159, 140);
            this.txtV_MainLineEveryXth.Name = "txtV_MainLineEveryXth";
            this.txtV_MainLineEveryXth.Size = new System.Drawing.Size(62, 22);
            this.txtV_MainLineEveryXth.TabIndex = 10;
            this.txtV_MainLineEveryXth.Text = "4";
            this.txtV_MainLineEveryXth.TextChanged += new System.EventHandler(this.txtV_MainLineEveryXth_TextChanged);
            // 
            // cbxV_HighlightMainGrid
            // 
            this.cbxV_HighlightMainGrid.AutoSize = true;
            this.cbxV_HighlightMainGrid.Checked = true;
            this.cbxV_HighlightMainGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxV_HighlightMainGrid.Location = new System.Drawing.Point(6, 142);
            this.cbxV_HighlightMainGrid.Name = "cbxV_HighlightMainGrid";
            this.cbxV_HighlightMainGrid.Size = new System.Drawing.Size(77, 21);
            this.cbxV_HighlightMainGrid.TabIndex = 15;
            this.cbxV_HighlightMainGrid.Text = "Vertical";
            this.cbxV_HighlightMainGrid.UseVisualStyleBackColor = true;
            this.cbxV_HighlightMainGrid.CheckedChanged += new System.EventHandler(this.cbxV_HighlightMainGrid_CheckedChanged);
            // 
            // cbxOnlyMain
            // 
            this.cbxOnlyMain.AutoSize = true;
            this.cbxOnlyMain.Location = new System.Drawing.Point(6, 168);
            this.cbxOnlyMain.Name = "cbxOnlyMain";
            this.cbxOnlyMain.Size = new System.Drawing.Size(157, 21);
            this.cbxOnlyMain.TabIndex = 15;
            this.cbxOnlyMain.Text = "Show only mainlines";
            this.cbxOnlyMain.UseVisualStyleBackColor = true;
            this.cbxOnlyMain.CheckedChanged += new System.EventHandler(this.cbxOnlyMain_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbxV_Snap);
            this.groupBox1.Controls.Add(this.cbxV_SnapAnchor);
            this.groupBox1.Controls.Add(this.cbxH_SnapAnchor);
            this.groupBox1.Controls.Add(this.cbxUseRelativeSnap);
            this.groupBox1.Controls.Add(this.cbxOnlyMain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtV_SnapAnchorSpace);
            this.groupBox1.Controls.Add(this.txtV_SnapKeySpace);
            this.groupBox1.Controls.Add(this.txtH_SnapAnchorSpace);
            this.groupBox1.Controls.Add(this.cbxV_HighlightMainGrid);
            this.groupBox1.Controls.Add(this.txtH_SnapKeySpace);
            this.groupBox1.Controls.Add(this.cbxH_Snap);
            this.groupBox1.Controls.Add(this.cbxV_ShowGrid);
            this.groupBox1.Controls.Add(this.cbxH_HighlightMainGrid);
            this.groupBox1.Controls.Add(this.cbxH_ShowGrid);
            this.groupBox1.Controls.Add(this.txtH_GridSpace);
            this.groupBox1.Controls.Add(this.txtV_MainLineEveryXth);
            this.groupBox1.Controls.Add(this.txtV_GridSpace);
            this.groupBox1.Controls.Add(this.txtH_MainLineEveryXth);
            this.groupBox1.Location = new System.Drawing.Point(12, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 355);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "Snap";
            // 
            // cbxV_SnapAnchor
            // 
            this.cbxV_SnapAnchor.AutoSize = true;
            this.cbxV_SnapAnchor.Location = new System.Drawing.Point(6, 329);
            this.cbxV_SnapAnchor.Name = "cbxV_SnapAnchor";
            this.cbxV_SnapAnchor.Size = new System.Drawing.Size(135, 21);
            this.cbxV_SnapAnchor.TabIndex = 15;
            this.cbxV_SnapAnchor.Text = "Anchor - Vertical";
            this.cbxV_SnapAnchor.UseVisualStyleBackColor = true;
            this.cbxV_SnapAnchor.CheckedChanged += new System.EventHandler(this.cbxV_SnapAnchor_CheckedChanged);
            // 
            // cbxH_SnapAnchor
            // 
            this.cbxH_SnapAnchor.AutoSize = true;
            this.cbxH_SnapAnchor.Location = new System.Drawing.Point(6, 302);
            this.cbxH_SnapAnchor.Name = "cbxH_SnapAnchor";
            this.cbxH_SnapAnchor.Size = new System.Drawing.Size(152, 21);
            this.cbxH_SnapAnchor.TabIndex = 15;
            this.cbxH_SnapAnchor.Text = "Anchor - Horizontal";
            this.cbxH_SnapAnchor.UseVisualStyleBackColor = true;
            this.cbxH_SnapAnchor.CheckedChanged += new System.EventHandler(this.cbxH_SnapAnchor_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Major grid Lines";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Grid Lines";
            // 
            // txtV_SnapAnchorSpace
            // 
            this.txtV_SnapAnchorSpace.Location = new System.Drawing.Point(159, 327);
            this.txtV_SnapAnchorSpace.Name = "txtV_SnapAnchorSpace";
            this.txtV_SnapAnchorSpace.Size = new System.Drawing.Size(62, 22);
            this.txtV_SnapAnchorSpace.TabIndex = 10;
            this.txtV_SnapAnchorSpace.Text = "0,05";
            this.txtV_SnapAnchorSpace.TextChanged += new System.EventHandler(this.txtV_SnapAnchor_TextChanged);
            // 
            // txtH_SnapAnchorSpace
            // 
            this.txtH_SnapAnchorSpace.Location = new System.Drawing.Point(159, 300);
            this.txtH_SnapAnchorSpace.Name = "txtH_SnapAnchorSpace";
            this.txtH_SnapAnchorSpace.Size = new System.Drawing.Size(62, 22);
            this.txtH_SnapAnchorSpace.TabIndex = 10;
            this.txtH_SnapAnchorSpace.Text = "0,025";
            this.txtH_SnapAnchorSpace.TextChanged += new System.EventHandler(this.txtH_SnapAnchor_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxAllowSelectingAnchors);
            this.groupBox2.Controls.Add(this.cbxShowAnchors);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 80);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // cbxAllowSelectingAnchors
            // 
            this.cbxAllowSelectingAnchors.AutoSize = true;
            this.cbxAllowSelectingAnchors.Checked = true;
            this.cbxAllowSelectingAnchors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxAllowSelectingAnchors.Location = new System.Drawing.Point(76, 44);
            this.cbxAllowSelectingAnchors.Name = "cbxAllowSelectingAnchors";
            this.cbxAllowSelectingAnchors.Size = new System.Drawing.Size(69, 21);
            this.cbxAllowSelectingAnchors.TabIndex = 15;
            this.cbxAllowSelectingAnchors.Text = "Select";
            this.cbxAllowSelectingAnchors.UseVisualStyleBackColor = true;
            this.cbxAllowSelectingAnchors.CheckedChanged += new System.EventHandler(this.cbxShowAnchors_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "Anchors";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 128);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 35);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(130, 129);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(109, 34);
            this.btnLoad.TabIndex = 19;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCameraReset
            // 
            this.btnCameraReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCameraReset.Location = new System.Drawing.Point(1172, 12);
            this.btnCameraReset.Name = "btnCameraReset";
            this.btnCameraReset.Size = new System.Drawing.Size(101, 24);
            this.btnCameraReset.TabIndex = 20;
            this.btnCameraReset.Text = "Reset View";
            this.btnCameraReset.UseVisualStyleBackColor = true;
            this.btnCameraReset.Click += new System.EventHandler(this.btnCameraReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 169);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(227, 37);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmGradient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1411, 660);
            this.Controls.Add(this.btnCameraReset);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNewGradient);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnDeleteGradient);
            this.Controls.Add(this.cboGradients);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.grpGradientInput);
            this.Name = "FrmGradient";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmGradient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGradientPointColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrPosition)).EndInit();
            this.grpGradientInput.ResumeLayout(false);
            this.grpGradientInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPoints)).EndInit();
            this.grpPointInput.ResumeLayout(false);
            this.grpPointInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.ComboBox cboGradients;
        private System.Windows.Forms.Button btnDeleteGradient;
        private System.Windows.Forms.PictureBox picGradientPointColor;
        private System.Windows.Forms.PictureBox picRed;
        private System.Windows.Forms.PictureBox picGreen;
        private System.Windows.Forms.PictureBox picBlue;
        private System.Windows.Forms.TextBox txtBlue;
        private System.Windows.Forms.TextBox txtGreen;
        private System.Windows.Forms.TextBox txtRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbrPosition;
        private System.Windows.Forms.Button btnAddNewPoint;
        private System.Windows.Forms.Button btnDeletePoint;
        private System.Windows.Forms.Button btnNewGradient;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpGradientInput;
        private System.Windows.Forms.GroupBox grpPointInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSegment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbxH_Snap;
        private System.Windows.Forms.TextBox txtH_SnapKeySpace;
        private System.Windows.Forms.TextBox txtV_SnapKeySpace;
        private System.Windows.Forms.CheckBox cbxV_Snap;
        private System.Windows.Forms.CheckBox cbxUseRelativeSnap;
        private System.Windows.Forms.CheckBox cbxShowAnchors;
        private System.Windows.Forms.TextBox txtH_GridSpace;
        private System.Windows.Forms.TextBox txtV_GridSpace;
        private System.Windows.Forms.CheckBox cbxH_ShowGrid;
        private System.Windows.Forms.CheckBox cbxV_ShowGrid;
        private System.Windows.Forms.TextBox txtH_MainLineEveryXth;
        private System.Windows.Forms.CheckBox cbxH_HighlightMainGrid;
        private System.Windows.Forms.TextBox txtV_MainLineEveryXth;
        private System.Windows.Forms.CheckBox cbxV_HighlightMainGrid;
        private System.Windows.Forms.CheckBox cbxOnlyMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbxAllowSelectingAnchors;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbxV_SnapAnchor;
        private System.Windows.Forms.CheckBox cbxH_SnapAnchor;
        private System.Windows.Forms.TextBox txtV_SnapAnchorSpace;
        private System.Windows.Forms.TextBox txtH_SnapAnchorSpace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCameraReset;
        private System.Windows.Forms.DataGridView grdPoints;
        private System.Windows.Forms.Button btnExport;
    }
}

