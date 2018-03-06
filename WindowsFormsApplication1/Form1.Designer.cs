namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmd_MotionConnect = new System.Windows.Forms.Button();
            this.cmb_MotionPorts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmd_EMGConnect = new System.Windows.Forms.Button();
            this.cmb_EMGPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_ports = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmd_connect = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_thumb_c = new System.Windows.Forms.Label();
            this.lbl_index_c = new System.Windows.Forms.Label();
            this.lbl_middle_c = new System.Windows.Forms.Label();
            this.lbl_ring_c = new System.Windows.Forms.Label();
            this.lbl_pinky_c = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.scroll_thumb = new System.Windows.Forms.TrackBar();
            this.scroll_pinky = new System.Windows.Forms.TrackBar();
            this.scroll_ring = new System.Windows.Forms.TrackBar();
            this.scroll_middle = new System.Windows.Forms.TrackBar();
            this.scroll_index = new System.Windows.Forms.TrackBar();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chk_actemg = new System.Windows.Forms.CheckBox();
            this.numeric_ReleaseTHR = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numeric_GripTHR = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.m_PushGraphCtrl = new CustomUIControls.Graphing.C2DPushGraph();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chk_GestIndexUp = new System.Windows.Forms.Button();
            this.btn_GestPenMode = new System.Windows.Forms.Button();
            this.chk_GestCloseAll = new System.Windows.Forms.Button();
            this.btn_GestOpenAll = new System.Windows.Forms.Button();
            this.EMGSerial = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logtxt = new System.Windows.Forms.RichTextBox();
            this.TimeOutWorker = new System.ComponentModel.BackgroundWorker();
            this.PlotTimer = new System.Windows.Forms.Timer(this.components);
            this.MainBoardSerial = new System.IO.Ports.SerialPort(this.components);
            this.MotionSerial = new System.IO.Ports.SerialPort(this.components);
            this.lbl_EMGPulse = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.EMGTimer = new System.Windows.Forms.Timer(this.components);
            this.EMGStimulatorTrackBar = new System.Windows.Forms.TrackBar();
            this.chk_StimulateEMG = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_thumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_pinky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_ring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_middle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_index)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ReleaseTHR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_GripTHR)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EMGStimulatorTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(511, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 348);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(505, 333);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox9);
            this.tabPage1.Controls.Add(this.pictureBox8);
            this.tabPage1.Controls.Add(this.pictureBox7);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(497, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(392, 104);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(83, 81);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(130, 6);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(209, 45);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 5;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(176, 275);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(120, 22);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmd_MotionConnect);
            this.groupBox1.Controls.Add(this.cmb_MotionPorts);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmd_EMGConnect);
            this.groupBox1.Controls.Add(this.cmb_EMGPorts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_ports);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmd_connect);
            this.groupBox1.Location = new System.Drawing.Point(33, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 185);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Manager";
            // 
            // cmd_MotionConnect
            // 
            this.cmd_MotionConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmd_MotionConnect.Location = new System.Drawing.Point(254, 95);
            this.cmd_MotionConnect.Name = "cmd_MotionConnect";
            this.cmd_MotionConnect.Size = new System.Drawing.Size(69, 25);
            this.cmd_MotionConnect.TabIndex = 13;
            this.cmd_MotionConnect.Text = "Connect";
            this.cmd_MotionConnect.UseVisualStyleBackColor = false;
            // 
            // cmb_MotionPorts
            // 
            this.cmb_MotionPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MotionPorts.FormattingEnabled = true;
            this.cmb_MotionPorts.Location = new System.Drawing.Point(143, 98);
            this.cmb_MotionPorts.Name = "cmb_MotionPorts";
            this.cmb_MotionPorts.Size = new System.Drawing.Size(102, 21);
            this.cmb_MotionPorts.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "MotionCapture Connection:";
            // 
            // cmd_EMGConnect
            // 
            this.cmd_EMGConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmd_EMGConnect.Location = new System.Drawing.Point(254, 60);
            this.cmd_EMGConnect.Name = "cmd_EMGConnect";
            this.cmd_EMGConnect.Size = new System.Drawing.Size(69, 25);
            this.cmd_EMGConnect.TabIndex = 10;
            this.cmd_EMGConnect.Text = "Connect";
            this.cmd_EMGConnect.UseVisualStyleBackColor = false;
            this.cmd_EMGConnect.Click += new System.EventHandler(this.cmd_EMGConnect_Click);
            // 
            // cmb_EMGPorts
            // 
            this.cmb_EMGPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EMGPorts.FormattingEnabled = true;
            this.cmb_EMGPorts.Location = new System.Drawing.Point(143, 63);
            this.cmb_EMGPorts.Name = "cmb_EMGPorts";
            this.cmb_EMGPorts.Size = new System.Drawing.Size(102, 21);
            this.cmb_EMGPorts.TabIndex = 9;
            this.cmb_EMGPorts.SelectedIndexChanged += new System.EventHandler(this.cmb_EMGPorts_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "EMG Connection :";
            // 
            // cmb_ports
            // 
            this.cmb_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ports.FormattingEnabled = true;
            this.cmb_ports.Location = new System.Drawing.Point(143, 29);
            this.cmb_ports.Name = "cmb_ports";
            this.cmb_ports.Size = new System.Drawing.Size(102, 21);
            this.cmb_ports.TabIndex = 6;
            this.cmb_ports.SelectedIndexChanged += new System.EventHandler(this.cmb_ports_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "MainBoard Connection:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(254, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmd_connect
            // 
            this.cmd_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmd_connect.Location = new System.Drawing.Point(254, 26);
            this.cmd_connect.Name = "cmd_connect";
            this.cmd_connect.Size = new System.Drawing.Size(69, 25);
            this.cmd_connect.TabIndex = 3;
            this.cmd_connect.Text = "Connect";
            this.cmd_connect.UseVisualStyleBackColor = false;
            this.cmd_connect.Click += new System.EventHandler(this.cmd_connect_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_thumb_c);
            this.tabPage2.Controls.Add(this.lbl_index_c);
            this.tabPage2.Controls.Add(this.lbl_middle_c);
            this.tabPage2.Controls.Add(this.lbl_ring_c);
            this.tabPage2.Controls.Add(this.lbl_pinky_c);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.pictureBox6);
            this.tabPage2.Controls.Add(this.pictureBox5);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.scroll_thumb);
            this.tabPage2.Controls.Add(this.scroll_pinky);
            this.tabPage2.Controls.Add(this.scroll_ring);
            this.tabPage2.Controls.Add(this.scroll_middle);
            this.tabPage2.Controls.Add(this.scroll_index);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(497, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Control";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_thumb_c
            // 
            this.lbl_thumb_c.AutoSize = true;
            this.lbl_thumb_c.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_thumb_c.Location = new System.Drawing.Point(39, 286);
            this.lbl_thumb_c.Name = "lbl_thumb_c";
            this.lbl_thumb_c.Size = new System.Drawing.Size(25, 13);
            this.lbl_thumb_c.TabIndex = 19;
            this.lbl_thumb_c.Text = "000";
            // 
            // lbl_index_c
            // 
            this.lbl_index_c.AutoSize = true;
            this.lbl_index_c.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_index_c.Location = new System.Drawing.Point(116, 219);
            this.lbl_index_c.Name = "lbl_index_c";
            this.lbl_index_c.Size = new System.Drawing.Size(25, 13);
            this.lbl_index_c.TabIndex = 18;
            this.lbl_index_c.Text = "000";
            // 
            // lbl_middle_c
            // 
            this.lbl_middle_c.AutoSize = true;
            this.lbl_middle_c.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_middle_c.Location = new System.Drawing.Point(200, 211);
            this.lbl_middle_c.Name = "lbl_middle_c";
            this.lbl_middle_c.Size = new System.Drawing.Size(25, 13);
            this.lbl_middle_c.TabIndex = 17;
            this.lbl_middle_c.Text = "000";
            // 
            // lbl_ring_c
            // 
            this.lbl_ring_c.AutoSize = true;
            this.lbl_ring_c.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_ring_c.Location = new System.Drawing.Point(281, 218);
            this.lbl_ring_c.Name = "lbl_ring_c";
            this.lbl_ring_c.Size = new System.Drawing.Size(25, 13);
            this.lbl_ring_c.TabIndex = 16;
            this.lbl_ring_c.Text = "000";
            // 
            // lbl_pinky_c
            // 
            this.lbl_pinky_c.AutoSize = true;
            this.lbl_pinky_c.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lbl_pinky_c.Location = new System.Drawing.Point(368, 235);
            this.lbl_pinky_c.Name = "lbl_pinky_c";
            this.lbl_pinky_c.Size = new System.Drawing.Size(25, 13);
            this.lbl_pinky_c.TabIndex = 15;
            this.lbl_pinky_c.Text = "000";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(25, 259);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 25);
            this.button6.TabIndex = 14;
            this.button6.Text = "Thumb";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(101, 191);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 25);
            this.button5.TabIndex = 13;
            this.button5.Text = "Index";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(185, 183);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 25);
            this.button4.TabIndex = 12;
            this.button4.Text = "Middle";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(271, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 25);
            this.button3.TabIndex = 11;
            this.button3.Text = "Ring";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(358, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "Pinky";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(72, 207);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(13, 14);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(148, 105);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(13, 14);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(232, 86);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(13, 14);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(312, 99);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(13, 14);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(399, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(13, 14);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // scroll_thumb
            // 
            this.scroll_thumb.BackColor = System.Drawing.Color.White;
            this.scroll_thumb.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.scroll_thumb.Location = new System.Drawing.Point(30, 169);
            this.scroll_thumb.Maximum = 100;
            this.scroll_thumb.Minimum = -100;
            this.scroll_thumb.Name = "scroll_thumb";
            this.scroll_thumb.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.scroll_thumb.Size = new System.Drawing.Size(45, 91);
            this.scroll_thumb.TabIndex = 4;
            this.scroll_thumb.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.scroll_thumb.Scroll += new System.EventHandler(this.scroll_thumb_Scroll);
            this.scroll_thumb.ValueChanged += new System.EventHandler(this.scroll_thumb_ValueChanged);
            this.scroll_thumb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_thumb_MouseUp);
            // 
            // scroll_pinky
            // 
            this.scroll_pinky.BackColor = System.Drawing.Color.White;
            this.scroll_pinky.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.scroll_pinky.Location = new System.Drawing.Point(358, 68);
            this.scroll_pinky.Maximum = 100;
            this.scroll_pinky.Minimum = -100;
            this.scroll_pinky.Name = "scroll_pinky";
            this.scroll_pinky.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.scroll_pinky.Size = new System.Drawing.Size(45, 133);
            this.scroll_pinky.TabIndex = 3;
            this.scroll_pinky.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.scroll_pinky.Scroll += new System.EventHandler(this.scroll_pinky_Scroll);
            this.scroll_pinky.ValueChanged += new System.EventHandler(this.scroll_pinky_ValueChanged);
            this.scroll_pinky.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_pinky_MouseUp);
            // 
            // scroll_ring
            // 
            this.scroll_ring.BackColor = System.Drawing.Color.White;
            this.scroll_ring.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.scroll_ring.Location = new System.Drawing.Point(271, 18);
            this.scroll_ring.Maximum = 100;
            this.scroll_ring.Minimum = -100;
            this.scroll_ring.Name = "scroll_ring";
            this.scroll_ring.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.scroll_ring.Size = new System.Drawing.Size(45, 175);
            this.scroll_ring.TabIndex = 2;
            this.scroll_ring.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.scroll_ring.Scroll += new System.EventHandler(this.scroll_ring_Scroll);
            this.scroll_ring.ValueChanged += new System.EventHandler(this.scroll_ring_ValueChanged);
            this.scroll_ring.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_ring_MouseUp);
            // 
            // scroll_middle
            // 
            this.scroll_middle.BackColor = System.Drawing.Color.White;
            this.scroll_middle.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.scroll_middle.Location = new System.Drawing.Point(191, 2);
            this.scroll_middle.Maximum = 100;
            this.scroll_middle.Minimum = -100;
            this.scroll_middle.Name = "scroll_middle";
            this.scroll_middle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.scroll_middle.Size = new System.Drawing.Size(45, 181);
            this.scroll_middle.TabIndex = 1;
            this.scroll_middle.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.scroll_middle.Scroll += new System.EventHandler(this.scroll_middle_Scroll);
            this.scroll_middle.ValueChanged += new System.EventHandler(this.scroll_middle_ValueChanged);
            this.scroll_middle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_middle_MouseUp);
            // 
            // scroll_index
            // 
            this.scroll_index.BackColor = System.Drawing.Color.White;
            this.scroll_index.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.scroll_index.Location = new System.Drawing.Point(108, 34);
            this.scroll_index.Maximum = 100;
            this.scroll_index.Minimum = -100;
            this.scroll_index.Name = "scroll_index";
            this.scroll_index.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.scroll_index.Size = new System.Drawing.Size(45, 159);
            this.scroll_index.TabIndex = 0;
            this.scroll_index.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.scroll_index.Scroll += new System.EventHandler(this.scroll_index_Scroll);
            this.scroll_index.ValueChanged += new System.EventHandler(this.scroll_index_ValueChanged);
            this.scroll_index.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scroll_index_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chk_actemg);
            this.tabPage3.Controls.Add(this.numeric_ReleaseTHR);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.numeric_GripTHR);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.m_PushGraphCtrl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(497, 307);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "EMG Analysis";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chk_actemg
            // 
            this.chk_actemg.AutoSize = true;
            this.chk_actemg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chk_actemg.Location = new System.Drawing.Point(8, 262);
            this.chk_actemg.Name = "chk_actemg";
            this.chk_actemg.Size = new System.Drawing.Size(145, 17);
            this.chk_actemg.TabIndex = 10;
            this.chk_actemg.Text = "Activate EMG Control";
            this.chk_actemg.UseVisualStyleBackColor = true;
            // 
            // numeric_ReleaseTHR
            // 
            this.numeric_ReleaseTHR.Location = new System.Drawing.Point(236, 277);
            this.numeric_ReleaseTHR.Name = "numeric_ReleaseTHR";
            this.numeric_ReleaseTHR.Size = new System.Drawing.Size(46, 20);
            this.numeric_ReleaseTHR.TabIndex = 9;
            this.numeric_ReleaseTHR.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(158, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "ReleaseTHR:";
            // 
            // numeric_GripTHR
            // 
            this.numeric_GripTHR.Location = new System.Drawing.Point(236, 245);
            this.numeric_GripTHR.Name = "numeric_GripTHR";
            this.numeric_GripTHR.Size = new System.Drawing.Size(46, 20);
            this.numeric_GripTHR.TabIndex = 7;
            this.numeric_GripTHR.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(158, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "GripTHR:";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Green;
            this.button9.Location = new System.Drawing.Point(395, 239);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(91, 60);
            this.button9.TabIndex = 3;
            this.button9.Text = "Control Hand";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button8.Location = new System.Drawing.Point(288, 273);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(101, 26);
            this.button8.TabIndex = 2;
            this.button8.Text = "Calibrate LOW";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button7.Location = new System.Drawing.Point(288, 239);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(101, 26);
            this.button7.TabIndex = 1;
            this.button7.Text = "Calibrate HIGH";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // m_PushGraphCtrl
            // 
            this.m_PushGraphCtrl.AutoAdjustPeek = false;
            this.m_PushGraphCtrl.BackColor = System.Drawing.Color.Black;
            this.m_PushGraphCtrl.GridColor = System.Drawing.Color.Green;
            this.m_PushGraphCtrl.GridSize = ((ushort)(20));
            this.m_PushGraphCtrl.HighQuality = true;
            this.m_PushGraphCtrl.LineInterval = ((ushort)(100));
            this.m_PushGraphCtrl.Location = new System.Drawing.Point(3, 6);
            this.m_PushGraphCtrl.MaxLabel = "4000";
            this.m_PushGraphCtrl.MaxPeekMagnitude = 4000;
            this.m_PushGraphCtrl.MinLabel = "-10";
            this.m_PushGraphCtrl.MinPeekMagnitude = -10;
            this.m_PushGraphCtrl.Name = "m_PushGraphCtrl";
            this.m_PushGraphCtrl.ShowGrid = true;
            this.m_PushGraphCtrl.ShowLabels = true;
            this.m_PushGraphCtrl.Size = new System.Drawing.Size(483, 227);
            this.m_PushGraphCtrl.TabIndex = 0;
            this.m_PushGraphCtrl.Text = "c2DPushGraph1";
            this.m_PushGraphCtrl.TextColor = System.Drawing.Color.Yellow;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chk_GestIndexUp);
            this.tabPage4.Controls.Add(this.btn_GestPenMode);
            this.tabPage4.Controls.Add(this.chk_GestCloseAll);
            this.tabPage4.Controls.Add(this.btn_GestOpenAll);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(497, 307);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Gestures";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chk_GestIndexUp
            // 
            this.chk_GestIndexUp.Location = new System.Drawing.Point(240, 18);
            this.chk_GestIndexUp.Name = "chk_GestIndexUp";
            this.chk_GestIndexUp.Size = new System.Drawing.Size(100, 71);
            this.chk_GestIndexUp.TabIndex = 3;
            this.chk_GestIndexUp.Text = "Index Up";
            this.chk_GestIndexUp.UseVisualStyleBackColor = true;
            this.chk_GestIndexUp.Click += new System.EventHandler(this.chk_GestIndexUp_Click);
            // 
            // btn_GestPenMode
            // 
            this.btn_GestPenMode.Location = new System.Drawing.Point(346, 18);
            this.btn_GestPenMode.Name = "btn_GestPenMode";
            this.btn_GestPenMode.Size = new System.Drawing.Size(105, 71);
            this.btn_GestPenMode.TabIndex = 2;
            this.btn_GestPenMode.Text = "Pinch";
            this.btn_GestPenMode.UseVisualStyleBackColor = true;
            this.btn_GestPenMode.Click += new System.EventHandler(this.btn_GestPenMode_Click);
            // 
            // chk_GestCloseAll
            // 
            this.chk_GestCloseAll.Location = new System.Drawing.Point(134, 18);
            this.chk_GestCloseAll.Name = "chk_GestCloseAll";
            this.chk_GestCloseAll.Size = new System.Drawing.Size(100, 71);
            this.chk_GestCloseAll.TabIndex = 1;
            this.chk_GestCloseAll.Text = "Close All";
            this.chk_GestCloseAll.UseVisualStyleBackColor = true;
            this.chk_GestCloseAll.Click += new System.EventHandler(this.chk_GestCloseAll_Click);
            // 
            // btn_GestOpenAll
            // 
            this.btn_GestOpenAll.Location = new System.Drawing.Point(28, 18);
            this.btn_GestOpenAll.Name = "btn_GestOpenAll";
            this.btn_GestOpenAll.Size = new System.Drawing.Size(100, 71);
            this.btn_GestOpenAll.TabIndex = 0;
            this.btn_GestOpenAll.Text = "Open All";
            this.btn_GestOpenAll.UseVisualStyleBackColor = true;
            this.btn_GestOpenAll.Click += new System.EventHandler(this.btn_GestOpenAll_Click);
            // 
            // EMGSerial
            // 
            this.EMGSerial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.EMGSerial_DataReceived);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logtxt);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox2.Location = new System.Drawing.Point(7, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 58);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LogBox";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // logtxt
            // 
            this.logtxt.BackColor = System.Drawing.Color.White;
            this.logtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.logtxt.ForeColor = System.Drawing.Color.Red;
            this.logtxt.Location = new System.Drawing.Point(6, 16);
            this.logtxt.Name = "logtxt";
            this.logtxt.ReadOnly = true;
            this.logtxt.Size = new System.Drawing.Size(725, 39);
            this.logtxt.TabIndex = 4;
            this.logtxt.Text = "";
            this.logtxt.TextChanged += new System.EventHandler(this.logtxt_TextChanged);
            // 
            // TimeOutWorker
            // 
            this.TimeOutWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.TimeOutWorker_DoWork);
            // 
            // PlotTimer
            // 
            this.PlotTimer.Tick += new System.EventHandler(this.PlotTimer_Tick);
            // 
            // MainBoardSerial
            // 
            this.MainBoardSerial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MainBoardSerial_DataReceived);
            // 
            // lbl_EMGPulse
            // 
            this.lbl_EMGPulse.AutoSize = true;
            this.lbl_EMGPulse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_EMGPulse.Location = new System.Drawing.Point(70, 356);
            this.lbl_EMGPulse.Name = "lbl_EMGPulse";
            this.lbl_EMGPulse.Size = new System.Drawing.Size(14, 13);
            this.lbl_EMGPulse.TabIndex = 7;
            this.lbl_EMGPulse.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(4, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "EMGPulse:";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(413, 351);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(88, 23);
            this.button11.TabIndex = 9;
            this.button11.Text = "Open Fingers";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // EMGTimer
            // 
            this.EMGTimer.Tick += new System.EventHandler(this.EMGTimer_Tick);
            // 
            // EMGStimulatorTrackBar
            // 
            this.EMGStimulatorTrackBar.Location = new System.Drawing.Point(247, 347);
            this.EMGStimulatorTrackBar.Maximum = 100;
            this.EMGStimulatorTrackBar.Name = "EMGStimulatorTrackBar";
            this.EMGStimulatorTrackBar.Size = new System.Drawing.Size(146, 45);
            this.EMGStimulatorTrackBar.TabIndex = 10;
            this.EMGStimulatorTrackBar.Scroll += new System.EventHandler(this.EMGStimulatorTrackBar_Scroll);
            // 
            // chk_StimulateEMG
            // 
            this.chk_StimulateEMG.AutoSize = true;
            this.chk_StimulateEMG.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chk_StimulateEMG.Location = new System.Drawing.Point(96, 355);
            this.chk_StimulateEMG.Name = "chk_StimulateEMG";
            this.chk_StimulateEMG.Size = new System.Drawing.Size(145, 17);
            this.chk_StimulateEMG.TabIndex = 11;
            this.chk_StimulateEMG.Text = "Stimulate EMG Signal";
            this.chk_StimulateEMG.UseVisualStyleBackColor = true;
            this.chk_StimulateEMG.CheckedChanged += new System.EventHandler(this.chk_StimulateEMG_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(753, 463);
            this.Controls.Add(this.chk_StimulateEMG);
            this.Controls.Add(this.EMGStimulatorTrackBar);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.lbl_EMGPulse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fum Bionic Hand Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_thumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_pinky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_ring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_middle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_index)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_ReleaseTHR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_GripTHR)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EMGStimulatorTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_ports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cmd_connect;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TrackBar scroll_index;
        private System.Windows.Forms.TrackBar scroll_thumb;
        private System.Windows.Forms.TrackBar scroll_pinky;
        private System.Windows.Forms.TrackBar scroll_ring;
        private System.Windows.Forms.TrackBar scroll_middle;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.IO.Ports.SerialPort EMGSerial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox logtxt;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_thumb_c;
        private System.Windows.Forms.Label lbl_index_c;
        private System.Windows.Forms.Label lbl_middle_c;
        private System.Windows.Forms.Label lbl_ring_c;
        private System.Windows.Forms.Label lbl_pinky_c;
        private System.ComponentModel.BackgroundWorker TimeOutWorker;
        private System.Windows.Forms.TabPage tabPage3;
        private CustomUIControls.Graphing.C2DPushGraph m_PushGraphCtrl;
        private System.Windows.Forms.Timer PlotTimer;
        private System.IO.Ports.SerialPort MainBoardSerial;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Button cmd_MotionConnect;
        private System.Windows.Forms.ComboBox cmb_MotionPorts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmd_EMGConnect;
        private System.Windows.Forms.ComboBox cmb_EMGPorts;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort MotionSerial;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.NumericUpDown numeric_ReleaseTHR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numeric_GripTHR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_EMGPulse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Timer EMGTimer;
        private System.Windows.Forms.CheckBox chk_actemg;
        private System.Windows.Forms.TrackBar EMGStimulatorTrackBar;
        private System.Windows.Forms.CheckBox chk_StimulateEMG;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button chk_GestIndexUp;
        private System.Windows.Forms.Button btn_GestPenMode;
        private System.Windows.Forms.Button chk_GestCloseAll;
        private System.Windows.Forms.Button btn_GestOpenAll;
    }
}

