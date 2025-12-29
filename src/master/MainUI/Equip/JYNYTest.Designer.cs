namespace RWTEST.UI.Valve
{
    partial class JYNYTest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTuichu = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DiLed12 = new RW.UI.Controls.SwitchPictureBox();
            this.DiLed13 = new RW.UI.Controls.SwitchPictureBox();
            this.DiLed14 = new RW.UI.Controls.SwitchPictureBox();
            this.rbnJYNY = new System.Windows.Forms.RadioButton();
            this.rbnJYDZ = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpNY = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNYstop = new System.Windows.Forms.Button();
            this.btnNYStart = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblNYrst = new System.Windows.Forms.Label();
            this.lblNYstate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.nudNYLDLUP = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudNYtime = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudNYVol = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.grpJYDZ = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnStopJYtest = new System.Windows.Forms.Button();
            this.btnStartJYtest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblJYDZrst = new System.Windows.Forms.Label();
            this.lblJYDZState = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudJYDZlow = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudJYDZtime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudJYDZVol = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.timerNY = new System.Windows.Forms.Timer(this.components);
            this.timerJY = new System.Windows.Forms.Timer(this.components);
            this.serialPortTH9320 = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiLed12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiLed13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiLed14)).BeginInit();
            this.grpNY.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNYLDLUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNYtime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNYVol)).BeginInit();
            this.grpJYDZ.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJYDZlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJYDZtime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJYDZVol)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnTuichu);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.rbnJYNY);
            this.panel1.Controls.Add(this.rbnJYDZ);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.grpNY);
            this.panel1.Controls.Add(this.grpJYDZ);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 695);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            //this.pictureBox1.Image = global::RWTEST.UI.Properties.Resources.绝缘试验;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(416, 600);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 164;
            this.pictureBox1.TabStop = false;
            // 
            // btnTuichu
            // 
            this.btnTuichu.Location = new System.Drawing.Point(889, 630);
            this.btnTuichu.Name = "btnTuichu";
            this.btnTuichu.Size = new System.Drawing.Size(96, 48);
            this.btnTuichu.TabIndex = 163;
            this.btnTuichu.Text = "退出";
            this.btnTuichu.UseVisualStyleBackColor = true;
            this.btnTuichu.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DiLed14);
            this.groupBox3.Controls.Add(this.DiLed13);
            this.groupBox3.Controls.Add(this.DiLed12);
            this.groupBox3.Location = new System.Drawing.Point(76, 611);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 67);
            this.groupBox3.TabIndex = 162;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "状态显示";
            // 
            // DiLed12
            // 
            this.DiLed12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DiLed12.CanClick = false;
            this.DiLed12.ClickSwitch = false;
            this.DiLed12.Cursor = System.Windows.Forms.Cursors.Default;
            this.DiLed12.FalseImage = global::RWTEST.UI.Properties.Resources.Gray;
            this.DiLed12.Image = global::RWTEST.UI.Properties.Resources.Gray;
            this.DiLed12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DiLed12.Location = new System.Drawing.Point(22, 25);
            this.DiLed12.Name = "DiLed12";
            this.DiLed12.Size = new System.Drawing.Size(20, 20);
            this.DiLed12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DiLed12.Switch = false;
            this.DiLed12.TabIndex = 152;
            this.DiLed12.TabStop = false;
            this.DiLed12.Text = "试验中";
            this.DiLed12.TextLayout = RW.UI.Controls.TextLayout.Right;
            this.DiLed12.TrueImage = global::RWTEST.UI.Properties.Resources.Green;
            // 
            // DiLed13
            // 
            this.DiLed13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DiLed13.CanClick = false;
            this.DiLed13.ClickSwitch = false;
            this.DiLed13.Cursor = System.Windows.Forms.Cursors.Default;
            this.DiLed13.FalseImage = global::RWTEST.UI.Properties.Resources.Gray;
            this.DiLed13.Image = global::RWTEST.UI.Properties.Resources.Gray;
            this.DiLed13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DiLed13.Location = new System.Drawing.Point(211, 24);
            this.DiLed13.Name = "DiLed13";
            this.DiLed13.Size = new System.Drawing.Size(20, 20);
            this.DiLed13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DiLed13.Switch = false;
            this.DiLed13.TabIndex = 154;
            this.DiLed13.TabStop = false;
            this.DiLed13.Text = "失败";
            this.DiLed13.TextLayout = RW.UI.Controls.TextLayout.Right;
            this.DiLed13.TrueImage = global::RWTEST.UI.Properties.Resources.Green;
            // 
            // DiLed14
            // 
            this.DiLed14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DiLed14.CanClick = false;
            this.DiLed14.ClickSwitch = false;
            this.DiLed14.Cursor = System.Windows.Forms.Cursors.Default;
            this.DiLed14.FalseImage = global::RWTEST.UI.Properties.Resources.Gray;
            this.DiLed14.Image = global::RWTEST.UI.Properties.Resources.Gray;
            this.DiLed14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DiLed14.Location = new System.Drawing.Point(118, 24);
            this.DiLed14.Name = "DiLed14";
            this.DiLed14.Size = new System.Drawing.Size(20, 20);
            this.DiLed14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DiLed14.Switch = false;
            this.DiLed14.TabIndex = 156;
            this.DiLed14.TabStop = false;
            this.DiLed14.Text = "成功";
            this.DiLed14.TextLayout = RW.UI.Controls.TextLayout.Right;
            this.DiLed14.TrueImage = global::RWTEST.UI.Properties.Resources.Green;
            // 
            // rbnJYNY
            // 
            this.rbnJYNY.AutoSize = true;
            this.rbnJYNY.Font = new System.Drawing.Font("宋体", 13F);
            this.rbnJYNY.Location = new System.Drawing.Point(761, 70);
            this.rbnJYNY.Name = "rbnJYNY";
            this.rbnJYNY.Size = new System.Drawing.Size(152, 22);
            this.rbnJYNY.TabIndex = 7;
            this.rbnJYNY.TabStop = true;
            this.rbnJYNY.Text = "线圈电阻值测试";
            this.rbnJYNY.UseVisualStyleBackColor = true;
            this.rbnJYNY.CheckedChanged += new System.EventHandler(this.rbnJYDZ_CheckedChanged);
            // 
            // rbnJYDZ
            // 
            this.rbnJYDZ.AutoSize = true;
            this.rbnJYDZ.Font = new System.Drawing.Font("宋体", 13F);
            this.rbnJYDZ.Location = new System.Drawing.Point(191, 70);
            this.rbnJYDZ.Name = "rbnJYDZ";
            this.rbnJYDZ.Size = new System.Drawing.Size(134, 22);
            this.rbnJYDZ.TabIndex = 8;
            this.rbnJYDZ.TabStop = true;
            this.rbnJYDZ.Text = "绝缘电阻测试";
            this.rbnJYDZ.UseVisualStyleBackColor = true;
            this.rbnJYDZ.CheckedChanged += new System.EventHandler(this.rbnJYDZ_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.LightGray;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 20F);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1068, 40);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "绝缘测试";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpNY
            // 
            this.grpNY.Controls.Add(this.panel2);
            this.grpNY.Controls.Add(this.groupBox5);
            this.grpNY.Controls.Add(this.groupBox6);
            this.grpNY.Location = new System.Drawing.Point(547, 113);
            this.grpNY.Name = "grpNY";
            this.grpNY.Size = new System.Drawing.Size(501, 481);
            this.grpNY.TabIndex = 5;
            this.grpNY.TabStop = false;
            this.grpNY.Text = "线圈电阻值测试";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNYstop);
            this.panel2.Controls.Add(this.btnNYStart);
            this.panel2.Location = new System.Drawing.Point(50, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 70);
            this.panel2.TabIndex = 2;
            // 
            // btnNYstop
            // 
            this.btnNYstop.Location = new System.Drawing.Point(259, 19);
            this.btnNYstop.Name = "btnNYstop";
            this.btnNYstop.Size = new System.Drawing.Size(129, 41);
            this.btnNYstop.TabIndex = 0;
            this.btnNYstop.Text = "停止线圈电阻值测试";
            this.btnNYstop.UseVisualStyleBackColor = true;
            this.btnNYstop.Click += new System.EventHandler(this.btnNYstop_Click);
            // 
            // btnNYStart
            // 
            this.btnNYStart.Location = new System.Drawing.Point(44, 19);
            this.btnNYStart.Name = "btnNYStart";
            this.btnNYStart.Size = new System.Drawing.Size(140, 41);
            this.btnNYStart.TabIndex = 0;
            this.btnNYStart.Text = "开始线圈电阻值测试";
            this.btnNYStart.UseVisualStyleBackColor = true;
            this.btnNYStart.Click += new System.EventHandler(this.btnNYStart_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblNYrst);
            this.groupBox5.Controls.Add(this.lblNYstate);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(50, 323);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(431, 144);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "测试结果";
            // 
            // lblNYrst
            // 
            this.lblNYrst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNYrst.Location = new System.Drawing.Point(215, 94);
            this.lblNYrst.Name = "lblNYrst";
            this.lblNYrst.Size = new System.Drawing.Size(156, 24);
            this.lblNYrst.TabIndex = 3;
            this.lblNYrst.Text = "通过/失败";
            this.lblNYrst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNYstate
            // 
            this.lblNYstate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNYstate.Location = new System.Drawing.Point(215, 43);
            this.lblNYstate.Name = "lblNYstate";
            this.lblNYstate.Size = new System.Drawing.Size(154, 24);
            this.lblNYstate.TabIndex = 3;
            this.lblNYstate.Text = "正在测试/测试完成";
            this.lblNYstate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "绝缘耐压测试结果：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "绝缘测试状态：";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.nudNYLDLUP);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.nudNYtime);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.nudNYVol);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(50, 42);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(431, 192);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "线圈电阻值测试参数";
            // 
            // nudNYLDLUP
            // 
            this.nudNYLDLUP.Location = new System.Drawing.Point(238, 130);
            this.nudNYLDLUP.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudNYLDLUP.Name = "nudNYLDLUP";
            this.nudNYLDLUP.Size = new System.Drawing.Size(105, 21);
            this.nudNYLDLUP.TabIndex = 2;
            this.nudNYLDLUP.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "漏电流上限(mA)";
            // 
            // nudNYtime
            // 
            this.nudNYtime.Location = new System.Drawing.Point(238, 79);
            this.nudNYtime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudNYtime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNYtime.Name = "nudNYtime";
            this.nudNYtime.Size = new System.Drawing.Size(105, 21);
            this.nudNYtime.TabIndex = 2;
            this.nudNYtime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(148, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "测试时间(S)";
            // 
            // nudNYVol
            // 
            this.nudNYVol.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudNYVol.Location = new System.Drawing.Point(238, 34);
            this.nudNYVol.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNYVol.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudNYVol.Name = "nudNYVol";
            this.nudNYVol.Size = new System.Drawing.Size(105, 21);
            this.nudNYVol.TabIndex = 2;
            this.nudNYVol.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(120, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "测试电压AC（V）";
            // 
            // grpJYDZ
            // 
            this.grpJYDZ.Controls.Add(this.panel3);
            this.grpJYDZ.Controls.Add(this.groupBox2);
            this.grpJYDZ.Controls.Add(this.groupBox1);
            this.grpJYDZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpJYDZ.Location = new System.Drawing.Point(26, 113);
            this.grpJYDZ.Name = "grpJYDZ";
            this.grpJYDZ.Size = new System.Drawing.Size(501, 481);
            this.grpJYDZ.TabIndex = 4;
            this.grpJYDZ.TabStop = false;
            this.grpJYDZ.Text = "绝缘电阻测试";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnStopJYtest);
            this.panel3.Controls.Add(this.btnStartJYtest);
            this.panel3.Location = new System.Drawing.Point(50, 240);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(428, 70);
            this.panel3.TabIndex = 2;
            // 
            // btnStopJYtest
            // 
            this.btnStopJYtest.Location = new System.Drawing.Point(236, 19);
            this.btnStopJYtest.Name = "btnStopJYtest";
            this.btnStopJYtest.Size = new System.Drawing.Size(140, 41);
            this.btnStopJYtest.TabIndex = 0;
            this.btnStopJYtest.Text = "停止绝缘电阻测试";
            this.btnStopJYtest.UseVisualStyleBackColor = true;
            this.btnStopJYtest.Click += new System.EventHandler(this.btnStopJYtest_Click);
            // 
            // btnStartJYtest
            // 
            this.btnStartJYtest.Location = new System.Drawing.Point(37, 19);
            this.btnStartJYtest.Name = "btnStartJYtest";
            this.btnStartJYtest.Size = new System.Drawing.Size(140, 41);
            this.btnStartJYtest.TabIndex = 0;
            this.btnStartJYtest.Text = "开始绝缘电阻试验";
            this.btnStartJYtest.UseVisualStyleBackColor = true;
            this.btnStartJYtest.Click += new System.EventHandler(this.btnStartJYtest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblJYDZrst);
            this.groupBox2.Controls.Add(this.lblJYDZState);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(50, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 144);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测试结果";
            // 
            // lblJYDZrst
            // 
            this.lblJYDZrst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJYDZrst.Location = new System.Drawing.Point(205, 94);
            this.lblJYDZrst.Name = "lblJYDZrst";
            this.lblJYDZrst.Size = new System.Drawing.Size(156, 24);
            this.lblJYDZrst.TabIndex = 3;
            this.lblJYDZrst.Text = "通过/失败";
            this.lblJYDZrst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJYDZState
            // 
            this.lblJYDZState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJYDZState.Location = new System.Drawing.Point(205, 43);
            this.lblJYDZState.Name = "lblJYDZState";
            this.lblJYDZState.Size = new System.Drawing.Size(154, 24);
            this.lblJYDZState.TabIndex = 3;
            this.lblJYDZState.Text = "正在测试/测试完成";
            this.lblJYDZState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "绝缘电阻测试结果：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "绝缘测试状态：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudJYDZlow);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudJYDZtime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudJYDZVol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(50, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "绝缘电阻试验参数";
            // 
            // nudJYDZlow
            // 
            this.nudJYDZlow.Location = new System.Drawing.Point(215, 130);
            this.nudJYDZlow.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudJYDZlow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudJYDZlow.Name = "nudJYDZlow";
            this.nudJYDZlow.Size = new System.Drawing.Size(105, 21);
            this.nudJYDZlow.TabIndex = 2;
            this.nudJYDZlow.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "电阻下限(MΩ)";
            // 
            // nudJYDZtime
            // 
            this.nudJYDZtime.Location = new System.Drawing.Point(215, 79);
            this.nudJYDZtime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudJYDZtime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudJYDZtime.Name = "nudJYDZtime";
            this.nudJYDZtime.Size = new System.Drawing.Size(105, 21);
            this.nudJYDZtime.TabIndex = 2;
            this.nudJYDZtime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "测试时间(S)";
            // 
            // nudJYDZVol
            // 
            this.nudJYDZVol.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudJYDZVol.Location = new System.Drawing.Point(215, 34);
            this.nudJYDZVol.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudJYDZVol.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudJYDZVol.Name = "nudJYDZVol";
            this.nudJYDZVol.Size = new System.Drawing.Size(105, 21);
            this.nudJYDZVol.TabIndex = 2;
            this.nudJYDZVol.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "测试电压DC（V）";
            // 
            // timerNY
            // 
            this.timerNY.Interval = 500;
            this.timerNY.Tick += new System.EventHandler(this.timerNY_Tick);
            // 
            // timerJY
            // 
            this.timerJY.Interval = 500;
            this.timerJY.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPortTH9320
            // 
            this.serialPortTH9320.PortName = "COM3";
            // 
            // JYNYTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 695);
            this.Controls.Add(this.panel1);
            this.Name = "JYNYTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "绝缘耐压测试";
            this.Load += new System.EventHandler(this.JYNYTest_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiLed12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiLed13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiLed14)).EndInit();
            this.grpNY.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNYLDLUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNYtime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNYVol)).EndInit();
            this.grpJYDZ.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJYDZlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJYDZtime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudJYDZVol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpNY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNYstop;
        private System.Windows.Forms.Button btnNYStart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblNYrst;
        private System.Windows.Forms.Label lblNYstate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown nudNYLDLUP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudNYtime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudNYVol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpJYDZ;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnStopJYtest;
        private System.Windows.Forms.Button btnStartJYtest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblJYDZrst;
        private System.Windows.Forms.Label lblJYDZState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudJYDZlow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudJYDZtime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudJYDZVol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbnJYNY;
        private System.Windows.Forms.RadioButton rbnJYDZ;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer timerNY;
        private System.Windows.Forms.Timer timerJY;
        private System.IO.Ports.SerialPort serialPortTH9320;
        private System.Windows.Forms.GroupBox groupBox3;
        private RW.UI.Controls.SwitchPictureBox DiLed14;
        private RW.UI.Controls.SwitchPictureBox DiLed13;
        private RW.UI.Controls.SwitchPictureBox DiLed12;
        private System.Windows.Forms.Button btnTuichu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}