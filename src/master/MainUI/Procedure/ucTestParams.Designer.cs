namespace MainUI.Procedure
{
    partial class ucTestParams
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.Tabs.StyleCard2 styleCard21 = new AntdUI.Tabs.StyleCard2();
            openFileDialog1 = new OpenFileDialog();
            uiGroupBox1 = new UIGroupBox();
            btnGet = new UIButton();
            uiLabel2 = new UILabel();
            txtModel = new UITextBox();
            btnBrowse = new UIButton();
            btnDelete = new UIButton();
            txtRpt = new UITextBox();
            tabs1 = new AntdUI.Tabs();
            tabPage1 = new AntdUI.TabPage();
            uiLabel7 = new UILabel();
            txtWalkingSpeed = new UITextBox();
            uiLabel8 = new UILabel();
            uiLabel5 = new UILabel();
            txtSprayKpa = new UITextBox();
            uiLabel6 = new UILabel();
            uiLabel4 = new UILabel();
            txtSprayTime = new UITextBox();
            uiLabel1 = new UILabel();
            tabPage2 = new AntdUI.TabPage();
            uiLabel3 = new UILabel();
            btnParameter = new AntdUI.Button();
            btnReport = new AntdUI.Button();
            uiGroupBox1.SuspendLayout();
            tabs1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.BackColor = Color.FromArgb(49, 54, 64);
            uiGroupBox1.Controls.Add(btnGet);
            uiGroupBox1.Controls.Add(uiLabel2);
            uiGroupBox1.Controls.Add(txtModel);
            uiGroupBox1.FillColor = Color.FromArgb(49, 54, 64);
            uiGroupBox1.FillColor2 = Color.FromArgb(49, 54, 64);
            uiGroupBox1.FillDisableColor = Color.FromArgb(42, 47, 55);
            uiGroupBox1.Font = new Font("思源黑体 CN Bold", 14F, FontStyle.Bold);
            uiGroupBox1.ForeColor = Color.FromArgb(235, 227, 221);
            uiGroupBox1.ForeDisableColor = Color.FromArgb(235, 227, 221);
            uiGroupBox1.Location = new Point(0, 0);
            uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            uiGroupBox1.Radius = 15;
            uiGroupBox1.RectColor = Color.FromArgb(49, 54, 64);
            uiGroupBox1.Size = new Size(665, 93);
            uiGroupBox1.TabIndex = 400;
            uiGroupBox1.Text = "参数设置";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnGet
            // 
            btnGet.Cursor = Cursors.Hand;
            btnGet.FillColor = Color.FromArgb(70, 75, 85);
            btnGet.FillColor2 = Color.FromArgb(70, 75, 85);
            btnGet.FillDisableColor = Color.FromArgb(70, 75, 85);
            btnGet.Font = new Font("思源黑体 CN Bold", 11F, FontStyle.Bold);
            btnGet.ForeColor = Color.FromArgb(235, 227, 221);
            btnGet.Location = new Point(530, 32);
            btnGet.MinimumSize = new Size(1, 1);
            btnGet.Name = "btnGet";
            btnGet.RectColor = Color.FromArgb(70, 75, 85);
            btnGet.RectDisableColor = Color.FromArgb(70, 75, 85);
            btnGet.Size = new Size(105, 40);
            btnGet.TabIndex = 389;
            btnGet.Text = "产品选择";
            btnGet.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnGet.TipsText = "1";
            btnGet.Click += btnProductSelection_Click;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel2.Font = new Font("思源黑体 CN Bold", 12F, FontStyle.Bold);
            uiLabel2.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel2.Location = new Point(19, 37);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(75, 23);
            uiLabel2.TabIndex = 82;
            uiLabel2.Text = "产品型号";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtModel
            // 
            txtModel.Enabled = false;
            txtModel.FillColor = Color.FromArgb(43, 46, 57);
            txtModel.FillColor2 = Color.FromArgb(43, 46, 57);
            txtModel.FillDisableColor = Color.FromArgb(43, 46, 57);
            txtModel.FillReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtModel.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            txtModel.ForeColor = Color.FromArgb(235, 227, 221);
            txtModel.ForeDisableColor = Color.FromArgb(235, 227, 221);
            txtModel.ForeReadOnlyColor = Color.FromArgb(235, 227, 221);
            txtModel.Location = new Point(99, 36);
            txtModel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtModel.MinimumSize = new Size(1, 16);
            txtModel.Name = "txtModel";
            txtModel.Padding = new System.Windows.Forms.Padding(5);
            txtModel.ReadOnly = true;
            txtModel.RectColor = Color.FromArgb(43, 46, 57);
            txtModel.RectDisableColor = Color.FromArgb(43, 46, 57);
            txtModel.RectReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtModel.ShowText = false;
            txtModel.Size = new Size(421, 29);
            txtModel.TabIndex = 390;
            txtModel.TextAlignment = ContentAlignment.MiddleLeft;
            txtModel.Watermark = "请选择";
            // 
            // btnBrowse
            // 
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FillColor = Color.FromArgb(70, 75, 85);
            btnBrowse.FillColor2 = Color.FromArgb(70, 75, 85);
            btnBrowse.FillDisableColor = Color.FromArgb(70, 75, 85);
            btnBrowse.Font = new Font("思源黑体 CN Bold", 11F, FontStyle.Bold);
            btnBrowse.ForeColor = Color.FromArgb(235, 227, 221);
            btnBrowse.Location = new Point(480, 126);
            btnBrowse.MinimumSize = new Size(1, 1);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.RectColor = Color.FromArgb(70, 75, 85);
            btnBrowse.RectDisableColor = Color.FromArgb(70, 75, 85);
            btnBrowse.Size = new Size(82, 29);
            btnBrowse.TabIndex = 394;
            btnBrowse.Text = "浏览";
            btnBrowse.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnBrowse.TipsText = "1";
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnDelete
            // 
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FillColor = Color.FromArgb(70, 75, 85);
            btnDelete.FillColor2 = Color.FromArgb(70, 75, 85);
            btnDelete.FillDisableColor = Color.FromArgb(70, 75, 85);
            btnDelete.Font = new Font("思源黑体 CN Bold", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.FromArgb(235, 227, 221);
            btnDelete.Location = new Point(467, 614);
            btnDelete.MinimumSize = new Size(1, 1);
            btnDelete.Name = "btnDelete";
            btnDelete.RectColor = Color.FromArgb(70, 75, 85);
            btnDelete.RectDisableColor = Color.FromArgb(70, 75, 85);
            btnDelete.Size = new Size(183, 40);
            btnDelete.TabIndex = 396;
            btnDelete.Text = "保存";
            btnDelete.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnDelete.TipsText = "1";
            btnDelete.Click += btnOK_Click;
            // 
            // txtRpt
            // 
            txtRpt.Enabled = false;
            txtRpt.FillColor = Color.FromArgb(43, 46, 57);
            txtRpt.FillColor2 = Color.FromArgb(43, 46, 57);
            txtRpt.FillDisableColor = Color.FromArgb(43, 46, 57);
            txtRpt.FillReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtRpt.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            txtRpt.ForeColor = Color.FromArgb(235, 227, 221);
            txtRpt.ForeDisableColor = Color.FromArgb(235, 227, 221);
            txtRpt.ForeReadOnlyColor = Color.FromArgb(235, 227, 221);
            txtRpt.Location = new Point(165, 126);
            txtRpt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtRpt.MinimumSize = new Size(1, 16);
            txtRpt.Name = "txtRpt";
            txtRpt.Padding = new System.Windows.Forms.Padding(5);
            txtRpt.ReadOnly = true;
            txtRpt.RectColor = Color.FromArgb(43, 46, 57);
            txtRpt.RectDisableColor = Color.FromArgb(43, 46, 57);
            txtRpt.RectReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtRpt.ShowText = false;
            txtRpt.Size = new Size(298, 29);
            txtRpt.TabIndex = 393;
            txtRpt.TextAlignment = ContentAlignment.MiddleLeft;
            txtRpt.Watermark = "请选择";
            // 
            // tabs1
            // 
            tabs1.Controls.Add(tabPage1);
            tabs1.Controls.Add(tabPage2);
            tabs1.Location = new Point(0, 136);
            tabs1.Name = "tabs1";
            tabs1.Pages.Add(tabPage1);
            tabs1.Pages.Add(tabPage2);
            tabs1.Size = new Size(665, 470);
            styleCard21.Closable = AntdUI.Tabs.StyleCard2.CloseType.none;
            tabs1.Style = styleCard21;
            tabs1.TabIndex = 401;
            tabs1.TabMenuVisible = false;
            tabs1.Text = "tabs1";
            tabs1.Type = AntdUI.TabType.Card2;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(49, 54, 64);
            tabPage1.Controls.Add(uiLabel7);
            tabPage1.Controls.Add(txtWalkingSpeed);
            tabPage1.Controls.Add(uiLabel8);
            tabPage1.Controls.Add(uiLabel5);
            tabPage1.Controls.Add(txtSprayKpa);
            tabPage1.Controls.Add(uiLabel6);
            tabPage1.Controls.Add(uiLabel4);
            tabPage1.Controls.Add(txtSprayTime);
            tabPage1.Controls.Add(uiLabel1);
            tabPage1.Location = new Point(3, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(659, 464);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "试验参数";
            // 
            // uiLabel7
            // 
            uiLabel7.AutoSize = true;
            uiLabel7.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel7.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            uiLabel7.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel7.Location = new Point(413, 274);
            uiLabel7.Name = "uiLabel7";
            uiLabel7.Size = new Size(85, 26);
            uiLabel7.TabIndex = 406;
            uiLabel7.Text = "mm/Min";
            uiLabel7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtWalkingSpeed
            // 
            txtWalkingSpeed.FillColor = Color.FromArgb(43, 46, 57);
            txtWalkingSpeed.FillColor2 = Color.FromArgb(43, 46, 57);
            txtWalkingSpeed.FillDisableColor = Color.FromArgb(43, 46, 57);
            txtWalkingSpeed.FillReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtWalkingSpeed.Font = new Font("思源黑体 CN Bold", 14F, FontStyle.Bold);
            txtWalkingSpeed.ForeColor = Color.FromArgb(235, 227, 221);
            txtWalkingSpeed.ForeDisableColor = Color.FromArgb(235, 227, 221);
            txtWalkingSpeed.ForeReadOnlyColor = Color.FromArgb(235, 227, 221);
            txtWalkingSpeed.Location = new Point(269, 272);
            txtWalkingSpeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtWalkingSpeed.MinimumSize = new Size(1, 16);
            txtWalkingSpeed.Name = "txtWalkingSpeed";
            txtWalkingSpeed.Padding = new System.Windows.Forms.Padding(5);
            txtWalkingSpeed.RectColor = Color.FromArgb(43, 46, 57);
            txtWalkingSpeed.RectDisableColor = Color.FromArgb(43, 46, 57);
            txtWalkingSpeed.RectReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtWalkingSpeed.ShowText = false;
            txtWalkingSpeed.Size = new Size(126, 29);
            txtWalkingSpeed.TabIndex = 404;
            txtWalkingSpeed.Text = "0";
            txtWalkingSpeed.TextAlignment = ContentAlignment.MiddleCenter;
            txtWalkingSpeed.Type = UITextBox.UIEditType.Integer;
            txtWalkingSpeed.Watermark = "请输入";
            // 
            // uiLabel8
            // 
            uiLabel8.AutoSize = true;
            uiLabel8.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel8.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            uiLabel8.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel8.Location = new Point(160, 272);
            uiLabel8.Name = "uiLabel8";
            uiLabel8.Size = new Size(102, 26);
            uiLabel8.TabIndex = 405;
            uiLabel8.Text = "行走速度：";
            uiLabel8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.AutoSize = true;
            uiLabel5.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel5.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            uiLabel5.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel5.Location = new Point(413, 195);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(47, 26);
            uiLabel5.TabIndex = 403;
            uiLabel5.Text = "Kpa";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSprayKpa
            // 
            txtSprayKpa.FillColor = Color.FromArgb(43, 46, 57);
            txtSprayKpa.FillColor2 = Color.FromArgb(43, 46, 57);
            txtSprayKpa.FillDisableColor = Color.FromArgb(43, 46, 57);
            txtSprayKpa.FillReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtSprayKpa.Font = new Font("思源黑体 CN Bold", 14F, FontStyle.Bold);
            txtSprayKpa.ForeColor = Color.FromArgb(235, 227, 221);
            txtSprayKpa.ForeDisableColor = Color.FromArgb(235, 227, 221);
            txtSprayKpa.ForeReadOnlyColor = Color.FromArgb(235, 227, 221);
            txtSprayKpa.Location = new Point(269, 193);
            txtSprayKpa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtSprayKpa.MinimumSize = new Size(1, 16);
            txtSprayKpa.Name = "txtSprayKpa";
            txtSprayKpa.Padding = new System.Windows.Forms.Padding(5);
            txtSprayKpa.RectColor = Color.FromArgb(43, 46, 57);
            txtSprayKpa.RectDisableColor = Color.FromArgb(43, 46, 57);
            txtSprayKpa.RectReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtSprayKpa.ShowText = false;
            txtSprayKpa.Size = new Size(126, 29);
            txtSprayKpa.TabIndex = 401;
            txtSprayKpa.Text = "0";
            txtSprayKpa.TextAlignment = ContentAlignment.MiddleCenter;
            txtSprayKpa.Type = UITextBox.UIEditType.Integer;
            txtSprayKpa.Watermark = "请输入";
            // 
            // uiLabel6
            // 
            uiLabel6.AutoSize = true;
            uiLabel6.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel6.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            uiLabel6.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel6.Location = new Point(160, 193);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(102, 26);
            uiLabel6.TabIndex = 402;
            uiLabel6.Text = "喷淋压力：";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            uiLabel4.AutoSize = true;
            uiLabel4.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel4.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            uiLabel4.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel4.Location = new Point(413, 118);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(44, 26);
            uiLabel4.TabIndex = 400;
            uiLabel4.Text = "Min";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSprayTime
            // 
            txtSprayTime.FillColor = Color.FromArgb(43, 46, 57);
            txtSprayTime.FillColor2 = Color.FromArgb(43, 46, 57);
            txtSprayTime.FillDisableColor = Color.FromArgb(43, 46, 57);
            txtSprayTime.FillReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtSprayTime.Font = new Font("思源黑体 CN Bold", 14F, FontStyle.Bold);
            txtSprayTime.ForeColor = Color.FromArgb(235, 227, 221);
            txtSprayTime.ForeDisableColor = Color.FromArgb(235, 227, 221);
            txtSprayTime.ForeReadOnlyColor = Color.FromArgb(235, 227, 221);
            txtSprayTime.Location = new Point(269, 116);
            txtSprayTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            txtSprayTime.MinimumSize = new Size(1, 16);
            txtSprayTime.Name = "txtSprayTime";
            txtSprayTime.Padding = new System.Windows.Forms.Padding(5);
            txtSprayTime.RectColor = Color.FromArgb(43, 46, 57);
            txtSprayTime.RectDisableColor = Color.FromArgb(43, 46, 57);
            txtSprayTime.RectReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtSprayTime.ShowText = false;
            txtSprayTime.Size = new Size(126, 29);
            txtSprayTime.TabIndex = 398;
            txtSprayTime.Text = "0";
            txtSprayTime.TextAlignment = ContentAlignment.MiddleCenter;
            txtSprayTime.Type = UITextBox.UIEditType.Integer;
            txtSprayTime.Watermark = "请输入";
            // 
            // uiLabel1
            // 
            uiLabel1.AutoSize = true;
            uiLabel1.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel1.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            uiLabel1.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel1.Location = new Point(160, 116);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(102, 26);
            uiLabel1.TabIndex = 399;
            uiLabel1.Text = "喷淋时间：";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(49, 54, 64);
            tabPage2.Controls.Add(uiLabel3);
            tabPage2.Controls.Add(btnBrowse);
            tabPage2.Controls.Add(txtRpt);
            tabPage2.Location = new Point(-659, -464);
            tabPage2.Name = "tabPage2";
            tabPage2.Size = new Size(659, 464);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "报表模板";
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.FromArgb(49, 54, 64);
            uiLabel3.Font = new Font("思源黑体 CN Bold", 12F, FontStyle.Bold);
            uiLabel3.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel3.Location = new Point(83, 126);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(75, 23);
            uiLabel3.TabIndex = 397;
            uiLabel3.Text = "产品类型";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnParameter
            // 
            btnParameter.BackActive = Color.FromArgb(49, 54, 64);
            btnParameter.BackColor = Color.FromArgb(49, 54, 64);
            btnParameter.BorderWidth = 1F;
            btnParameter.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            btnParameter.ForeColor = Color.FromArgb(235, 227, 221);
            btnParameter.Location = new Point(1, 101);
            btnParameter.Name = "btnParameter";
            btnParameter.Size = new Size(131, 48);
            btnParameter.TabIndex = 404;
            btnParameter.Text = "参数设置";
            btnParameter.Type = AntdUI.TTypeMini.Primary;
            btnParameter.WaveSize = 1;
            btnParameter.Click += btnParameter_Click;
            // 
            // btnReport
            // 
            btnReport.BackActive = Color.FromArgb(49, 54, 64);
            btnReport.BackColor = Color.FromArgb(49, 54, 64);
            btnReport.BorderWidth = 1F;
            btnReport.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            btnReport.ForeColor = Color.FromArgb(235, 227, 221);
            btnReport.Location = new Point(138, 101);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(131, 48);
            btnReport.TabIndex = 405;
            btnReport.Text = "报表模板";
            btnReport.Type = AntdUI.TTypeMini.Primary;
            btnReport.Visible = false;
            btnReport.WaveSize = 1;
            btnReport.Click += btnReport_Click;
            // 
            // ucTestParams
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(42, 47, 55);
            Controls.Add(tabs1);
            Controls.Add(btnDelete);
            Controls.Add(uiGroupBox1);
            Controls.Add(btnParameter);
            Controls.Add(btnReport);
            Name = "ucTestParams";
            Size = new Size(665, 660);
            uiGroupBox1.ResumeLayout(false);
            tabs1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton btnGet;
        private Sunny.UI.UITextBox txtModel;
        private Sunny.UI.UIButton btnDelete;
        private Sunny.UI.UIButton btnBrowse;
        private Sunny.UI.UITextBox txtRpt;
        private AntdUI.Tabs tabs1;
        private AntdUI.TabPage tabPage1;
        private AntdUI.TabPage tabPage2;
        private UILabel uiLabel3;
        private AntdUI.Button btnParameter;
        private AntdUI.Button btnReport;
        private UILabel uiLabel7;
        private UITextBox txtWalkingSpeed;
        private UILabel uiLabel8;
        private UILabel uiLabel5;
        private UITextBox txtSprayKpa;
        private UILabel uiLabel6;
        private UILabel uiLabel4;
        private UITextBox txtSprayTime;
        private UILabel uiLabel1;
    }
}
