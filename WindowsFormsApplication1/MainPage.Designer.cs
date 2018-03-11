namespace WindowsFormsApplication1
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCharts = new System.Windows.Forms.Button();
            this.btnControls = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPanelGlove = new System.Windows.Forms.Panel();
            this.pnlGLOVE = new System.Windows.Forms.Panel();
            this.btnGlove = new System.Windows.Forms.Button();
            this.btnPanelHand = new System.Windows.Forms.Panel();
            this.pnlHAND = new System.Windows.Forms.Panel();
            this.btnHand = new System.Windows.Forms.Button();
            this.btnPanelRFID = new System.Windows.Forms.Panel();
            this.pnlRFID = new System.Windows.Forms.Panel();
            this.btnRFID = new System.Windows.Forms.Button();
            this.btnPanelEMG = new System.Windows.Forms.Panel();
            this.pnlEMG = new System.Windows.Forms.Panel();
            this.btnEMG = new System.Windows.Forms.Button();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl4 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelConnect = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.PanelHAND = new System.Windows.Forms.Panel();
            this.panelCharts = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnTcpConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuDragControl5 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.PanelEMG = new System.Windows.Forms.Panel();
            this.PanelRFID = new System.Windows.Forms.Panel();
            this.PanelGLOVE = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.panel1.SuspendLayout();
            this.btnPanelGlove.SuspendLayout();
            this.btnPanelHand.SuspendLayout();
            this.btnPanelRFID.SuspendLayout();
            this.btnPanelEMG.SuspendLayout();
            this.panelConnect.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(53)))), ((int)(((byte)(147)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(205, 53);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bionic Hand";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.bunifuImageButton1);
            this.panel3.Controls.Add(this.btnCharts);
            this.panel3.Controls.Add(this.btnControls);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(871, 53);
            this.panel3.TabIndex = 1;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(826, 8);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(33, 39);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 0;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 20;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // btnCharts
            // 
            this.btnCharts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCharts.FlatAppearance.BorderSize = 0;
            this.btnCharts.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnCharts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCharts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCharts.Font = new System.Drawing.Font("Segoe UI Semilight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCharts.Location = new System.Drawing.Point(379, 3);
            this.btnCharts.Name = "btnCharts";
            this.btnCharts.Size = new System.Drawing.Size(101, 44);
            this.btnCharts.TabIndex = 2;
            this.btnCharts.Text = "Charts";
            this.btnCharts.UseVisualStyleBackColor = true;
            this.btnCharts.Click += new System.EventHandler(this.btnCharts_Click);
            this.btnCharts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnCharts_MouseDown);
            this.btnCharts.MouseEnter += new System.EventHandler(this.btnCharts_MouseEnter);
            this.btnCharts.MouseLeave += new System.EventHandler(this.btnCharts_MouseLeave);
            // 
            // btnControls
            // 
            this.btnControls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnControls.FlatAppearance.BorderSize = 0;
            this.btnControls.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnControls.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnControls.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControls.Font = new System.Drawing.Font("Segoe UI Semilight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnControls.Location = new System.Drawing.Point(251, 3);
            this.btnControls.Name = "btnControls";
            this.btnControls.Size = new System.Drawing.Size(101, 44);
            this.btnControls.TabIndex = 2;
            this.btnControls.Text = "Controls";
            this.btnControls.UseVisualStyleBackColor = true;
            this.btnControls.Click += new System.EventHandler(this.btnControls_Click);
            this.btnControls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnControls_MouseDown);
            this.btnControls.MouseEnter += new System.EventHandler(this.btnControls_MouseEnter);
            this.btnControls.MouseLeave += new System.EventHandler(this.btnControls_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.btnPanelGlove);
            this.panel1.Controls.Add(this.btnPanelHand);
            this.panel1.Controls.Add(this.btnPanelRFID);
            this.panel1.Controls.Add(this.btnPanelEMG);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 548);
            this.panel1.TabIndex = 2;
            // 
            // btnPanelGlove
            // 
            this.btnPanelGlove.Controls.Add(this.pnlGLOVE);
            this.btnPanelGlove.Controls.Add(this.btnGlove);
            this.btnPanelGlove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPanelGlove.Location = new System.Drawing.Point(0, 255);
            this.btnPanelGlove.Name = "btnPanelGlove";
            this.btnPanelGlove.Size = new System.Drawing.Size(205, 80);
            this.btnPanelGlove.TabIndex = 7;
            this.btnPanelGlove.Click += new System.EventHandler(this.btnPanelGlove_Click);
            this.btnPanelGlove.MouseEnter += new System.EventHandler(this.btnPanelGlove_MouseEnter);
            this.btnPanelGlove.MouseLeave += new System.EventHandler(this.btnPanelGlove_MouseLeave);
            // 
            // pnlGLOVE
            // 
            this.pnlGLOVE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlGLOVE.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGLOVE.Location = new System.Drawing.Point(0, 0);
            this.pnlGLOVE.Name = "pnlGLOVE";
            this.pnlGLOVE.Size = new System.Drawing.Size(5, 80);
            this.pnlGLOVE.TabIndex = 4;
            // 
            // btnGlove
            // 
            this.btnGlove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnGlove.FlatAppearance.BorderSize = 0;
            this.btnGlove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGlove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGlove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlove.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGlove.ForeColor = System.Drawing.Color.White;
            this.btnGlove.Image = ((System.Drawing.Image)(resources.GetObject("btnGlove.Image")));
            this.btnGlove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGlove.Location = new System.Drawing.Point(58, 25);
            this.btnGlove.Name = "btnGlove";
            this.btnGlove.Size = new System.Drawing.Size(101, 27);
            this.btnGlove.TabIndex = 0;
            this.btnGlove.Text = "GLOVE";
            this.btnGlove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGlove.UseVisualStyleBackColor = true;
            this.btnGlove.Click += new System.EventHandler(this.btnPanelGlove_Click);
            this.btnGlove.MouseEnter += new System.EventHandler(this.btnPanelGlove_MouseEnter);
            this.btnGlove.MouseLeave += new System.EventHandler(this.btnPanelGlove_MouseLeave);
            // 
            // btnPanelHand
            // 
            this.btnPanelHand.Controls.Add(this.pnlHAND);
            this.btnPanelHand.Controls.Add(this.btnHand);
            this.btnPanelHand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPanelHand.Location = new System.Drawing.Point(0, 170);
            this.btnPanelHand.Name = "btnPanelHand";
            this.btnPanelHand.Size = new System.Drawing.Size(205, 80);
            this.btnPanelHand.TabIndex = 6;
            this.btnPanelHand.Click += new System.EventHandler(this.btnPanelHand_Click);
            this.btnPanelHand.MouseEnter += new System.EventHandler(this.btnPanelHand_MouseEnter);
            this.btnPanelHand.MouseLeave += new System.EventHandler(this.btnPanelHand_MouseLeave);
            // 
            // pnlHAND
            // 
            this.pnlHAND.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlHAND.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlHAND.Location = new System.Drawing.Point(0, 0);
            this.pnlHAND.Name = "pnlHAND";
            this.pnlHAND.Size = new System.Drawing.Size(5, 80);
            this.pnlHAND.TabIndex = 3;
            // 
            // btnHand
            // 
            this.btnHand.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnHand.FlatAppearance.BorderSize = 0;
            this.btnHand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHand.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHand.ForeColor = System.Drawing.Color.White;
            this.btnHand.Image = ((System.Drawing.Image)(resources.GetObject("btnHand.Image")));
            this.btnHand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHand.Location = new System.Drawing.Point(56, 23);
            this.btnHand.Name = "btnHand";
            this.btnHand.Size = new System.Drawing.Size(101, 34);
            this.btnHand.TabIndex = 0;
            this.btnHand.Text = "HAND";
            this.btnHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHand.UseVisualStyleBackColor = true;
            this.btnHand.Click += new System.EventHandler(this.btnPanelHand_Click);
            this.btnHand.MouseEnter += new System.EventHandler(this.btnPanelHand_MouseEnter);
            this.btnHand.MouseLeave += new System.EventHandler(this.btnPanelHand_MouseLeave);
            // 
            // btnPanelRFID
            // 
            this.btnPanelRFID.Controls.Add(this.pnlRFID);
            this.btnPanelRFID.Controls.Add(this.btnRFID);
            this.btnPanelRFID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPanelRFID.Location = new System.Drawing.Point(0, 85);
            this.btnPanelRFID.Name = "btnPanelRFID";
            this.btnPanelRFID.Size = new System.Drawing.Size(205, 80);
            this.btnPanelRFID.TabIndex = 5;
            this.btnPanelRFID.Click += new System.EventHandler(this.btnPanelRFID_Click);
            this.btnPanelRFID.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.btnPanelRFID.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // pnlRFID
            // 
            this.pnlRFID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlRFID.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRFID.Location = new System.Drawing.Point(0, 0);
            this.pnlRFID.Name = "pnlRFID";
            this.pnlRFID.Size = new System.Drawing.Size(5, 80);
            this.pnlRFID.TabIndex = 2;
            // 
            // btnRFID
            // 
            this.btnRFID.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnRFID.FlatAppearance.BorderSize = 0;
            this.btnRFID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRFID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRFID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRFID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRFID.ForeColor = System.Drawing.Color.White;
            this.btnRFID.Image = ((System.Drawing.Image)(resources.GetObject("btnRFID.Image")));
            this.btnRFID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRFID.Location = new System.Drawing.Point(56, 24);
            this.btnRFID.Name = "btnRFID";
            this.btnRFID.Size = new System.Drawing.Size(92, 31);
            this.btnRFID.TabIndex = 0;
            this.btnRFID.Text = "RFID";
            this.btnRFID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRFID.UseVisualStyleBackColor = true;
            this.btnRFID.Click += new System.EventHandler(this.btnPanelRFID_Click);
            this.btnRFID.MouseEnter += new System.EventHandler(this.panel5_MouseEnter);
            this.btnRFID.MouseLeave += new System.EventHandler(this.panel5_MouseLeave);
            // 
            // btnPanelEMG
            // 
            this.btnPanelEMG.Controls.Add(this.pnlEMG);
            this.btnPanelEMG.Controls.Add(this.btnEMG);
            this.btnPanelEMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPanelEMG.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPanelEMG.Location = new System.Drawing.Point(0, 0);
            this.btnPanelEMG.Name = "btnPanelEMG";
            this.btnPanelEMG.Size = new System.Drawing.Size(205, 80);
            this.btnPanelEMG.TabIndex = 0;
            this.btnPanelEMG.Click += new System.EventHandler(this.btnPanelEMG_Click);
            this.btnPanelEMG.MouseEnter += new System.EventHandler(this.btnPanelEMG_MouseEnter);
            this.btnPanelEMG.MouseLeave += new System.EventHandler(this.btnPanelEMG_MouseLeave);
            // 
            // pnlEMG
            // 
            this.pnlEMG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlEMG.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEMG.Location = new System.Drawing.Point(0, 0);
            this.pnlEMG.Name = "pnlEMG";
            this.pnlEMG.Size = new System.Drawing.Size(5, 80);
            this.pnlEMG.TabIndex = 1;
            // 
            // btnEMG
            // 
            this.btnEMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEMG.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnEMG.FlatAppearance.BorderSize = 0;
            this.btnEMG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEMG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEMG.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEMG.ForeColor = System.Drawing.Color.White;
            this.btnEMG.Image = ((System.Drawing.Image)(resources.GetObject("btnEMG.Image")));
            this.btnEMG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEMG.Location = new System.Drawing.Point(56, 27);
            this.btnEMG.Name = "btnEMG";
            this.btnEMG.Size = new System.Drawing.Size(92, 26);
            this.btnEMG.TabIndex = 4;
            this.btnEMG.Text = "EMG";
            this.btnEMG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEMG.UseVisualStyleBackColor = true;
            this.btnEMG.Click += new System.EventHandler(this.btnPanelEMG_Click);
            this.btnEMG.MouseEnter += new System.EventHandler(this.btnPanelEMG_MouseEnter);
            this.btnEMG.MouseLeave += new System.EventHandler(this.btnPanelEMG_MouseLeave);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.panel3;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.panel2;
            this.bunifuDragControl3.Vertical = true;
            // 
            // bunifuDragControl4
            // 
            this.bunifuDragControl4.Fixed = true;
            this.bunifuDragControl4.Horizontal = true;
            this.bunifuDragControl4.TargetControl = this.label1;
            this.bunifuDragControl4.Vertical = true;
            // 
            // panelConnect
            // 
            this.panelConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.panelConnect.Controls.Add(this.panel8);
            this.panelConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConnect.Location = new System.Drawing.Point(0, 0);
            this.panelConnect.Name = "panelConnect";
            this.panelConnect.Size = new System.Drawing.Size(666, 548);
            this.panelConnect.TabIndex = 3;
            // 
            // panelControls
            // 
            this.panelControls.Location = new System.Drawing.Point(51, 146);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(138, 66);
            this.panelControls.TabIndex = 3;
            // 
            // PanelHAND
            // 
            this.PanelHAND.Location = new System.Drawing.Point(199, 161);
            this.PanelHAND.Name = "PanelHAND";
            this.PanelHAND.Size = new System.Drawing.Size(200, 100);
            this.PanelHAND.TabIndex = 6;
            // 
            // panelCharts
            // 
            this.panelCharts.Location = new System.Drawing.Point(182, 44);
            this.panelCharts.Name = "panelCharts";
            this.panelCharts.Size = new System.Drawing.Size(171, 96);
            this.panelCharts.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Controls.Add(this.btnTcpConnect);
            this.panel8.Controls.Add(this.txtPort);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.txtIP);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Location = new System.Drawing.Point(173, 55);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(321, 438);
            this.panel8.TabIndex = 2;
            // 
            // btnTcpConnect
            // 
            this.btnTcpConnect.AutoEllipsis = true;
            this.btnTcpConnect.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTcpConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTcpConnect.FlatAppearance.BorderSize = 0;
            this.btnTcpConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTcpConnect.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTcpConnect.ForeColor = System.Drawing.Color.White;
            this.btnTcpConnect.Location = new System.Drawing.Point(66, 343);
            this.btnTcpConnect.Name = "btnTcpConnect";
            this.btnTcpConnect.Size = new System.Drawing.Size(198, 45);
            this.btnTcpConnect.TabIndex = 2;
            this.btnTcpConnect.Text = "Connect";
            this.btnTcpConnect.UseVisualStyleBackColor = false;
            this.btnTcpConnect.Click += new System.EventHandler(this.btnTcpConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPort.Location = new System.Drawing.Point(66, 268);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(186, 27);
            this.txtPort.TabIndex = 0;
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.label3.Location = new System.Drawing.Point(3, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port :";
            // 
            // txtIP
            // 
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtIP.Location = new System.Drawing.Point(66, 187);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(186, 27);
            this.txtIP.TabIndex = 0;
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.label2.Location = new System.Drawing.Point(21, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP :";
            // 
            // bunifuDragControl5
            // 
            this.bunifuDragControl5.Fixed = true;
            this.bunifuDragControl5.Horizontal = true;
            this.bunifuDragControl5.TargetControl = this.panel1;
            this.bunifuDragControl5.Vertical = true;
            // 
            // PanelEMG
            // 
            this.PanelEMG.Location = new System.Drawing.Point(25, 242);
            this.PanelEMG.Name = "PanelEMG";
            this.PanelEMG.Size = new System.Drawing.Size(164, 91);
            this.PanelEMG.TabIndex = 4;
            // 
            // PanelRFID
            // 
            this.PanelRFID.Location = new System.Drawing.Point(426, 146);
            this.PanelRFID.Name = "PanelRFID";
            this.PanelRFID.Size = new System.Drawing.Size(169, 75);
            this.PanelRFID.TabIndex = 5;
            // 
            // PanelGLOVE
            // 
            this.PanelGLOVE.Location = new System.Drawing.Point(359, 22);
            this.PanelGLOVE.Name = "PanelGLOVE";
            this.PanelGLOVE.Size = new System.Drawing.Size(200, 100);
            this.PanelGLOVE.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panelConnect);
            this.panel4.Controls.Add(this.PanelGLOVE);
            this.panel4.Controls.Add(this.PanelEMG);
            this.panel4.Controls.Add(this.panelCharts);
            this.panel4.Controls.Add(this.PanelHAND);
            this.panel4.Controls.Add(this.panelControls);
            this.panel4.Controls.Add(this.PanelRFID);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(205, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(666, 548);
            this.panel4.TabIndex = 8;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 601);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.btnPanelGlove.ResumeLayout(false);
            this.btnPanelHand.ResumeLayout(false);
            this.btnPanelRFID.ResumeLayout(false);
            this.btnPanelEMG.ResumeLayout(false);
            this.panelConnect.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel btnPanelEMG;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button btnEMG;
        private System.Windows.Forms.Panel pnlEMG;
        private System.Windows.Forms.Panel btnPanelRFID;
        private System.Windows.Forms.Button btnRFID;
        private System.Windows.Forms.Panel pnlRFID;
        private System.Windows.Forms.Panel btnPanelHand;
        private System.Windows.Forms.Panel btnPanelGlove;
        private System.Windows.Forms.Button btnGlove;
        private System.Windows.Forms.Panel pnlHAND;
        private System.Windows.Forms.Button btnHand;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private System.Windows.Forms.Panel pnlGLOVE;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl4;
        private System.Windows.Forms.Panel panelConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnTcpConnect;
        private System.Windows.Forms.Button btnControls;
        private System.Windows.Forms.Button btnCharts;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl5;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelCharts;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel PanelGLOVE;
        private System.Windows.Forms.Panel PanelHAND;
        private System.Windows.Forms.Panel PanelEMG;
        private System.Windows.Forms.Panel PanelRFID;
        private System.Windows.Forms.Panel panel4;
    }
}