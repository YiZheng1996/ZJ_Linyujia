namespace MainUI.Procedure.User
{
    partial class frmUserEdit
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserEdit));
            uiLabel2 = new UILabel();
            comboBox1 = new UIComboBox();
            btnCancel = new UIButton();
            btnSave = new UIButton();
            uiPanel1 = new UIPanel();
            uiLabel5 = new UILabel();
            txtUserName = new UITextBox();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.Transparent;
            resources.ApplyResources(uiLabel2, "uiLabel2");
            uiLabel2.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel2.Name = "uiLabel2";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(49, 54, 64);
            comboBox1.DataSource = null;
            comboBox1.DropDownStyle = UIDropDownStyle.DropDownList;
            comboBox1.FillColor = Color.FromArgb(42, 47, 55);
            comboBox1.FillColor2 = Color.FromArgb(42, 47, 55);
            comboBox1.FilterMaxCount = 50;
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.ForeColor = Color.FromArgb(235, 227, 221);
            comboBox1.ForeDisableColor = Color.FromArgb(235, 227, 221);
            comboBox1.ItemFillColor = Color.FromArgb(42, 47, 55);
            comboBox1.ItemForeColor = Color.White;
            comboBox1.ItemHoverColor = Color.FromArgb(155, 200, 255);
            comboBox1.Items.AddRange(new object[] { resources.GetString("comboBox1.Items"), resources.GetString("comboBox1.Items1"), resources.GetString("comboBox1.Items2"), resources.GetString("comboBox1.Items3"), resources.GetString("comboBox1.Items4"), resources.GetString("comboBox1.Items5"), resources.GetString("comboBox1.Items6"), resources.GetString("comboBox1.Items7"), resources.GetString("comboBox1.Items8"), resources.GetString("comboBox1.Items9"), resources.GetString("comboBox1.Items10"), resources.GetString("comboBox1.Items11") });
            comboBox1.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBox1.Name = "comboBox1";
            comboBox1.RadiusSides = UICornerRadiusSides.None;
            comboBox1.RectColor = Color.White;
            comboBox1.RectDisableColor = Color.White;
            comboBox1.RectSides = ToolStripStatusLabelBorderSides.None;
            comboBox1.SymbolSize = 24;
            comboBox1.TextAlignment = ContentAlignment.MiddleLeft;
            comboBox1.Watermark = "请选择";
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FillColor = Color.FromArgb(70, 75, 85);
            btnCancel.FillColor2 = Color.FromArgb(70, 75, 85);
            btnCancel.FillDisableColor = Color.FromArgb(70, 75, 85);
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.ForeColor = Color.FromArgb(235, 227, 221);
            btnCancel.Name = "btnCancel";
            btnCancel.RectColor = Color.FromArgb(70, 75, 85);
            btnCancel.RectDisableColor = Color.FromArgb(70, 75, 85);
            btnCancel.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnCancel.TipsText = "1";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Cursor = Cursors.Hand;
            btnSave.FillColor = Color.FromArgb(70, 75, 85);
            btnSave.FillColor2 = Color.FromArgb(70, 75, 85);
            btnSave.FillDisableColor = Color.FromArgb(70, 75, 85);
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.ForeColor = Color.FromArgb(235, 227, 221);
            btnSave.Name = "btnSave";
            btnSave.RectColor = Color.FromArgb(70, 75, 85);
            btnSave.RectDisableColor = Color.FromArgb(70, 75, 85);
            btnSave.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnSave.TipsText = "1";
            btnSave.Click += btnSave_Click;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiLabel5);
            uiPanel1.Controls.Add(uiLabel2);
            uiPanel1.Controls.Add(btnCancel);
            uiPanel1.Controls.Add(comboBox1);
            uiPanel1.Controls.Add(txtUserName);
            uiPanel1.Controls.Add(btnSave);
            uiPanel1.FillColor = Color.FromArgb(49, 54, 64);
            uiPanel1.FillColor2 = Color.FromArgb(49, 54, 64);
            uiPanel1.FillDisableColor = Color.FromArgb(49, 54, 64);
            resources.ApplyResources(uiPanel1, "uiPanel1");
            uiPanel1.ForeColor = Color.FromArgb(49, 54, 64);
            uiPanel1.ForeDisableColor = Color.FromArgb(49, 54, 64);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Radius = 15;
            uiPanel1.RectColor = Color.FromArgb(49, 54, 64);
            uiPanel1.RectDisableColor = Color.FromArgb(49, 54, 64);
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel5
            // 
            uiLabel5.BackColor = Color.Transparent;
            resources.ApplyResources(uiLabel5, "uiLabel5");
            uiLabel5.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel5.Name = "uiLabel5";
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.FromArgb(49, 54, 64);
            txtUserName.FillColor = Color.FromArgb(42, 47, 55);
            txtUserName.FillColor2 = Color.FromArgb(42, 47, 55);
            txtUserName.FillDisableColor = Color.FromArgb(42, 47, 55);
            txtUserName.FillReadOnlyColor = Color.FromArgb(42, 47, 55);
            resources.ApplyResources(txtUserName, "txtUserName");
            txtUserName.ForeColor = Color.FromArgb(235, 227, 221);
            txtUserName.ForeDisableColor = Color.FromArgb(235, 227, 221);
            txtUserName.ForeReadOnlyColor = Color.FromArgb(235, 227, 221);
            txtUserName.Name = "txtUserName";
            txtUserName.RectColor = Color.FromArgb(42, 47, 55);
            txtUserName.RectDisableColor = Color.FromArgb(42, 47, 55);
            txtUserName.RectReadOnlyColor = Color.FromArgb(42, 47, 55);
            txtUserName.ShowText = false;
            txtUserName.TextAlignment = ContentAlignment.MiddleLeft;
            txtUserName.Watermark = "用户名";
            // 
            // frmUserEdit
            // 
            AutoScaleMode = AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            BackColor = Color.FromArgb(42, 47, 55);
            Controls.Add(uiPanel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUserEdit";
            RectColor = Color.FromArgb(49, 54, 64);
            ShowIcon = false;
            ShowInTaskbar = false;
            TitleColor = Color.FromArgb(49, 54, 64);
            TitleFont = new Font("思源黑体 CN Heavy", 15F, FontStyle.Bold);
            TitleForeColor = Color.FromArgb(239, 154, 78);
            ZoomScaleRect = new Rectangle(15, 15, 280, 234);
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox comboBox1;
        private Sunny.UI.UIButton btnCancel;
        private Sunny.UI.UIButton btnSave;
        private UIPanel uiPanel1;
        private UILabel uiLabel5;
        private UITextBox txtUserName;
    }
}