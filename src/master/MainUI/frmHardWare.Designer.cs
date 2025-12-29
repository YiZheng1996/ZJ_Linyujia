namespace MainUI
{
    partial class frmHardWare
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label7 = new Label();
            label2 = new Label();
            label8 = new Label();
            label9 = new Label();
            label3 = new Label();
            label1 = new Label();
            label12 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            grpAI = new UIGroupBox();
            panel3 = new Panel();
            ucCalibration9 = new MainUI.Procedure.UCCalibration();
            ucCalibration10 = new MainUI.Procedure.UCCalibration();
            ucCalibration11 = new MainUI.Procedure.UCCalibration();
            ucCalibration12 = new MainUI.Procedure.UCCalibration();
            ucCalibration13 = new MainUI.Procedure.UCCalibration();
            ucCalibration14 = new MainUI.Procedure.UCCalibration();
            ucCalibration15 = new MainUI.Procedure.UCCalibration();
            ucCalibration8 = new MainUI.Procedure.UCCalibration();
            ucCalibration7 = new MainUI.Procedure.UCCalibration();
            ucCalibration5 = new MainUI.Procedure.UCCalibration();
            ucCalibration6 = new MainUI.Procedure.UCCalibration();
            ucCalibration3 = new MainUI.Procedure.UCCalibration();
            ucCalibration4 = new MainUI.Procedure.UCCalibration();
            ucCalibration2 = new MainUI.Procedure.UCCalibration();
            ucCalibration1 = new MainUI.Procedure.UCCalibration();
            panel2 = new Panel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            grpAO = new UIGroupBox();
            panel1.SuspendLayout();
            grpAI.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            grpAO.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 154, 78);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1262, 38);
            panel1.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(975, 7);
            label7.Name = "label7";
            label7.Size = new Size(66, 26);
            label7.TabIndex = 19;
            label7.Text = "增益值";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(340, 7);
            label2.Name = "label2";
            label2.Size = new Size(66, 26);
            label2.TabIndex = 7;
            label2.Text = "增益值";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label8.ImeMode = ImeMode.NoControl;
            label8.Location = new Point(789, 7);
            label8.Name = "label8";
            label8.Size = new Size(66, 26);
            label8.TabIndex = 20;
            label8.Text = "测定值";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label9.ImeMode = ImeMode.NoControl;
            label9.Location = new Point(885, 7);
            label9.Name = "label9";
            label9.Size = new Size(66, 26);
            label9.TabIndex = 21;
            label9.Text = "零点值";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(154, 7);
            label3.Name = "label3";
            label3.Size = new Size(66, 26);
            label3.TabIndex = 7;
            label3.Text = "测定值";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(250, 7);
            label1.Name = "label1";
            label1.Size = new Size(66, 26);
            label1.TabIndex = 7;
            label1.Text = "零点值";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("思源黑体 CN Bold", 17F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(235, 227, 221);
            label12.ImeMode = ImeMode.NoControl;
            label12.Location = new Point(19, 615);
            label12.Name = "label12";
            label12.Size = new Size(481, 33);
            label12.TabIndex = 54;
            label12.Text = "计算公式：测定值 = 工程值 * 增益值 - 零点值  ";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // grpAI
            // 
            grpAI.Controls.Add(panel3);
            grpAI.FillColor = Color.FromArgb(49, 54, 64);
            grpAI.FillColor2 = Color.FromArgb(49, 54, 64);
            grpAI.FillDisableColor = Color.FromArgb(49, 54, 64);
            grpAI.Font = new Font("思源黑体 CN Bold", 17F, FontStyle.Bold);
            grpAI.ForeColor = Color.FromArgb(235, 227, 221);
            grpAI.ForeDisableColor = Color.FromArgb(235, 227, 221);
            grpAI.Location = new Point(19, 65);
            grpAI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            grpAI.MinimumSize = new Size(1, 1);
            grpAI.Name = "grpAI";
            grpAI.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            grpAI.Radius = 15;
            grpAI.RectColor = Color.FromArgb(49, 54, 64);
            grpAI.RectDisableColor = Color.FromArgb(49, 54, 64);
            grpAI.Size = new Size(1262, 541);
            grpAI.TabIndex = 382;
            grpAI.Text = "输入检测";
            grpAI.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.BackColor = Color.FromArgb(49, 54, 64);
            panel3.Controls.Add(ucCalibration9);
            panel3.Controls.Add(ucCalibration10);
            panel3.Controls.Add(ucCalibration11);
            panel3.Controls.Add(ucCalibration12);
            panel3.Controls.Add(ucCalibration13);
            panel3.Controls.Add(ucCalibration14);
            panel3.Controls.Add(ucCalibration15);
            panel3.Controls.Add(ucCalibration8);
            panel3.Controls.Add(ucCalibration7);
            panel3.Controls.Add(ucCalibration5);
            panel3.Controls.Add(ucCalibration6);
            panel3.Controls.Add(ucCalibration3);
            panel3.Controls.Add(ucCalibration4);
            panel3.Controls.Add(ucCalibration2);
            panel3.Controls.Add(ucCalibration1);
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 32);
            panel3.Name = "panel3";
            panel3.Size = new Size(1262, 509);
            panel3.TabIndex = 17;
            // 
            // ucCalibration9
            // 
            ucCalibration9.Font = new Font("微软雅黑", 11F);
            ucCalibration9.GainValue = 0D;
            ucCalibration9.Index = 14;
            ucCalibration9.Location = new Point(647, 376);
            ucCalibration9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration9.Name = "ucCalibration9";
            ucCalibration9.Size = new Size(561, 36);
            ucCalibration9.TabIndex = 25;
            ucCalibration9.Text = "压力传感器7";
            ucCalibration9.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration10
            // 
            ucCalibration10.Font = new Font("微软雅黑", 11F);
            ucCalibration10.GainValue = 0D;
            ucCalibration10.Index = 13;
            ucCalibration10.Location = new Point(647, 323);
            ucCalibration10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration10.Name = "ucCalibration10";
            ucCalibration10.Size = new Size(561, 36);
            ucCalibration10.TabIndex = 24;
            ucCalibration10.Text = "压力传感器6";
            ucCalibration10.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration11
            // 
            ucCalibration11.Font = new Font("微软雅黑", 11F);
            ucCalibration11.GainValue = 0D;
            ucCalibration11.Index = 12;
            ucCalibration11.Location = new Point(647, 270);
            ucCalibration11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration11.Name = "ucCalibration11";
            ucCalibration11.Size = new Size(561, 36);
            ucCalibration11.TabIndex = 23;
            ucCalibration11.Text = "压力传感器5";
            ucCalibration11.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration12
            // 
            ucCalibration12.Font = new Font("微软雅黑", 11F);
            ucCalibration12.GainValue = 0D;
            ucCalibration12.Index = 11;
            ucCalibration12.Location = new Point(647, 217);
            ucCalibration12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration12.Name = "ucCalibration12";
            ucCalibration12.Size = new Size(561, 36);
            ucCalibration12.TabIndex = 22;
            ucCalibration12.Text = "压力传感器4";
            ucCalibration12.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration13
            // 
            ucCalibration13.Font = new Font("微软雅黑", 11F);
            ucCalibration13.GainValue = 0D;
            ucCalibration13.Index = 10;
            ucCalibration13.Location = new Point(647, 164);
            ucCalibration13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration13.Name = "ucCalibration13";
            ucCalibration13.Size = new Size(561, 36);
            ucCalibration13.TabIndex = 21;
            ucCalibration13.Text = "压力传感器3";
            ucCalibration13.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration14
            // 
            ucCalibration14.Font = new Font("微软雅黑", 11F);
            ucCalibration14.GainValue = 0D;
            ucCalibration14.Index = 9;
            ucCalibration14.Location = new Point(647, 111);
            ucCalibration14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration14.Name = "ucCalibration14";
            ucCalibration14.Size = new Size(561, 36);
            ucCalibration14.TabIndex = 20;
            ucCalibration14.Text = "压力传感器2";
            ucCalibration14.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration15
            // 
            ucCalibration15.Font = new Font("微软雅黑", 11F);
            ucCalibration15.GainValue = 0D;
            ucCalibration15.Index = 8;
            ucCalibration15.Location = new Point(647, 58);
            ucCalibration15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration15.Name = "ucCalibration15";
            ucCalibration15.Size = new Size(561, 36);
            ucCalibration15.TabIndex = 19;
            ucCalibration15.Text = "压力传感器1";
            ucCalibration15.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration8
            // 
            ucCalibration8.Font = new Font("微软雅黑", 11F);
            ucCalibration8.GainValue = 0D;
            ucCalibration8.Index = 15;
            ucCalibration8.Location = new Point(21, 429);
            ucCalibration8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration8.Name = "ucCalibration8";
            ucCalibration8.Size = new Size(561, 36);
            ucCalibration8.TabIndex = 18;
            ucCalibration8.Text = "液位计";
            ucCalibration8.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration7
            // 
            ucCalibration7.Font = new Font("微软雅黑", 11F);
            ucCalibration7.GainValue = 0D;
            ucCalibration7.Index = 6;
            ucCalibration7.Location = new Point(21, 376);
            ucCalibration7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration7.Name = "ucCalibration7";
            ucCalibration7.Size = new Size(561, 36);
            ucCalibration7.TabIndex = 17;
            ucCalibration7.Text = "压力传感器7";
            ucCalibration7.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration5
            // 
            ucCalibration5.Font = new Font("微软雅黑", 11F);
            ucCalibration5.GainValue = 0D;
            ucCalibration5.Index = 5;
            ucCalibration5.Location = new Point(21, 323);
            ucCalibration5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration5.Name = "ucCalibration5";
            ucCalibration5.Size = new Size(561, 36);
            ucCalibration5.TabIndex = 16;
            ucCalibration5.Text = "压力传感器6";
            ucCalibration5.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration6
            // 
            ucCalibration6.Font = new Font("微软雅黑", 11F);
            ucCalibration6.GainValue = 0D;
            ucCalibration6.Index = 4;
            ucCalibration6.Location = new Point(21, 270);
            ucCalibration6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration6.Name = "ucCalibration6";
            ucCalibration6.Size = new Size(561, 36);
            ucCalibration6.TabIndex = 15;
            ucCalibration6.Text = "压力传感器5";
            ucCalibration6.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration3
            // 
            ucCalibration3.Font = new Font("微软雅黑", 11F);
            ucCalibration3.GainValue = 0D;
            ucCalibration3.Index = 3;
            ucCalibration3.Location = new Point(21, 217);
            ucCalibration3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration3.Name = "ucCalibration3";
            ucCalibration3.Size = new Size(561, 36);
            ucCalibration3.TabIndex = 14;
            ucCalibration3.Text = "压力传感器4";
            ucCalibration3.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration4
            // 
            ucCalibration4.Font = new Font("微软雅黑", 11F);
            ucCalibration4.GainValue = 0D;
            ucCalibration4.Index = 2;
            ucCalibration4.Location = new Point(21, 164);
            ucCalibration4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration4.Name = "ucCalibration4";
            ucCalibration4.Size = new Size(561, 36);
            ucCalibration4.TabIndex = 13;
            ucCalibration4.Text = "压力传感器3";
            ucCalibration4.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration2
            // 
            ucCalibration2.Font = new Font("微软雅黑", 11F);
            ucCalibration2.GainValue = 0D;
            ucCalibration2.Index = 1;
            ucCalibration2.Location = new Point(21, 111);
            ucCalibration2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration2.Name = "ucCalibration2";
            ucCalibration2.Size = new Size(561, 36);
            ucCalibration2.TabIndex = 12;
            ucCalibration2.Text = "压力传感器2";
            ucCalibration2.Submited += ucCalibration_AI_Submited;
            // 
            // ucCalibration1
            // 
            ucCalibration1.Font = new Font("微软雅黑", 11F);
            ucCalibration1.GainValue = 0D;
            ucCalibration1.Location = new Point(21, 58);
            ucCalibration1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            ucCalibration1.Name = "ucCalibration1";
            ucCalibration1.Size = new Size(561, 36);
            ucCalibration1.TabIndex = 11;
            ucCalibration1.Text = "压力传感器1";
            ucCalibration1.Submited += ucCalibration_AI_Submited;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(239, 154, 78);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("微软雅黑", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            panel2.Location = new Point(0, 32);
            panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(42, 38);
            panel2.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(235, 227, 221);
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(340, 7);
            label4.Name = "label4";
            label4.Size = new Size(66, 26);
            label4.TabIndex = 7;
            label4.Text = "增益值";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(235, 227, 221);
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(154, 7);
            label5.Name = "label5";
            label5.Size = new Size(66, 26);
            label5.TabIndex = 7;
            label5.Text = "测定值";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(235, 227, 221);
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(250, 7);
            label6.Name = "label6";
            label6.Size = new Size(66, 26);
            label6.TabIndex = 7;
            label6.Text = "零点值";
            // 
            // grpAO
            // 
            grpAO.BackColor = Color.FromArgb(49, 54, 64);
            grpAO.Controls.Add(panel2);
            grpAO.FillColor = Color.FromArgb(49, 54, 64);
            grpAO.FillColor2 = Color.FromArgb(49, 54, 64);
            grpAO.FillDisableColor = Color.FromArgb(49, 54, 64);
            grpAO.Font = new Font("思源黑体 CN Bold", 17F, FontStyle.Bold);
            grpAO.ForeColor = Color.FromArgb(235, 227, 221);
            grpAO.Location = new Point(544, 619);
            grpAO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            grpAO.MinimumSize = new Size(1, 1);
            grpAO.Name = "grpAO";
            grpAO.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            grpAO.RectColor = Color.FromArgb(49, 54, 64);
            grpAO.RectDisableColor = Color.FromArgb(49, 54, 64);
            grpAO.Size = new Size(42, 29);
            grpAO.TabIndex = 383;
            grpAO.Text = "输出检测";
            grpAO.TextAlignment = ContentAlignment.MiddleCenter;
            grpAO.Visible = false;
            // 
            // frmHardWare
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(42, 47, 55);
            ClientSize = new Size(1311, 664);
            Controls.Add(grpAO);
            Controls.Add(grpAI);
            Controls.Add(label12);
            Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmHardWare";
            RectColor = Color.FromArgb(49, 54, 64);
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "硬件校准";
            TitleColor = Color.FromArgb(47, 55, 64);
            TitleFont = new Font("思源黑体 CN Heavy", 15F, FontStyle.Bold);
            TitleForeColor = Color.FromArgb(239, 154, 78);
            ZoomScaleRect = new Rectangle(15, 15, 1270, 771);
            Load += frmHardWare_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grpAI.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            grpAO.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIGroupBox grpAI;
        private System.Windows.Forms.Panel panel3;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private Label label6;
        private UIGroupBox grpAO;
        private Procedure.UCCalibration ucCalibration7;
        private Procedure.UCCalibration ucCalibration5;
        private Procedure.UCCalibration ucCalibration6;
        private Procedure.UCCalibration ucCalibration3;
        private Procedure.UCCalibration ucCalibration4;
        private Procedure.UCCalibration ucCalibration2;
        private Procedure.UCCalibration ucCalibration1;
        private Procedure.UCCalibration ucCalibration8;
        private Label label7;
        private Label label8;
        private Label label9;
        private Procedure.UCCalibration ucCalibration9;
        private Procedure.UCCalibration ucCalibration10;
        private Procedure.UCCalibration ucCalibration11;
        private Procedure.UCCalibration ucCalibration12;
        private Procedure.UCCalibration ucCalibration13;
        private Procedure.UCCalibration ucCalibration14;
        private Procedure.UCCalibration ucCalibration15;
    }
}