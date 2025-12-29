namespace MainUI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            lblSoftName = new Label();
            lblMessage = new Label();
            uiLabel3 = new UILabel();
            uiLabel1 = new UILabel();
            Logo = new PictureBox();
            uiPanel1 = new UIPanel();
            cboUserName = new UIComboBox();
            txtPassword = new UITextBox();
            btnExit = new UISymbolButton();
            btnSignIn = new UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblSoftName
            // 
            resources.ApplyResources(lblSoftName, "lblSoftName");
            lblSoftName.ForeColor = Color.FromArgb(239, 154, 78);
            lblSoftName.Name = "lblSoftName";
            // 
            // lblMessage
            // 
            resources.ApplyResources(lblMessage, "lblMessage");
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = Color.Red;
            lblMessage.Name = "lblMessage";
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.Transparent;
            resources.ApplyResources(uiLabel3, "uiLabel3");
            uiLabel3.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel3.Name = "uiLabel3";
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            resources.ApplyResources(uiLabel1, "uiLabel1");
            uiLabel1.ForeColor = Color.FromArgb(235, 227, 221);
            uiLabel1.Name = "uiLabel1";
            // 
            // Logo
            // 
            Logo.BackColor = Color.FromArgb(49, 54, 64);
            resources.ApplyResources(Logo, "Logo");
            Logo.Name = "Logo";
            Logo.TabStop = false;
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(cboUserName);
            uiPanel1.Controls.Add(txtPassword);
            uiPanel1.Controls.Add(btnExit);
            uiPanel1.Controls.Add(btnSignIn);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.Controls.Add(Logo);
            uiPanel1.Controls.Add(uiLabel3);
            uiPanel1.Controls.Add(lblMessage);
            uiPanel1.FillColor = Color.FromArgb(49, 54, 64);
            uiPanel1.FillColor2 = Color.FromArgb(49, 54, 64);
            uiPanel1.FillDisableColor = Color.FromArgb(49, 54, 64);
            resources.ApplyResources(uiPanel1, "uiPanel1");
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Radius = 15;
            uiPanel1.RectColor = Color.FromArgb(42, 47, 55);
            uiPanel1.RectDisableColor = Color.FromArgb(42, 47, 55);
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cboUserName
            // 
            cboUserName.DataSource = null;
            cboUserName.DropDownStyle = UIDropDownStyle.DropDownList;
            cboUserName.FillColor = Color.FromArgb(43, 46, 57);
            cboUserName.FillColor2 = Color.FromArgb(43, 46, 57);
            cboUserName.FillDisableColor = Color.FromArgb(49, 54, 64);
            cboUserName.FilterMaxCount = 50;
            resources.ApplyResources(cboUserName, "cboUserName");
            cboUserName.ForeColor = Color.FromArgb(235, 227, 221);
            cboUserName.ForeDisableColor = Color.FromArgb(235, 227, 221);
            cboUserName.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboUserName.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboUserName.Name = "cboUserName";
            cboUserName.RadiusSides = UICornerRadiusSides.None;
            cboUserName.RectColor = Color.FromArgb(243, 249, 255);
            cboUserName.RectDisableColor = Color.FromArgb(243, 249, 255);
            cboUserName.RectSides = ToolStripStatusLabelBorderSides.None;
            cboUserName.SymbolSize = 24;
            cboUserName.TextAlignment = ContentAlignment.MiddleLeft;
            cboUserName.Watermark = "请选择";
            // 
            // txtPassword
            // 
            txtPassword.FillColor = Color.FromArgb(43, 46, 57);
            txtPassword.FillColor2 = Color.FromArgb(43, 46, 57);
            txtPassword.FillDisableColor = Color.FromArgb(43, 46, 57);
            txtPassword.FillReadOnlyColor = Color.FromArgb(43, 46, 57);
            resources.ApplyResources(txtPassword, "txtPassword");
            txtPassword.ForeColor = Color.White;
            txtPassword.ForeDisableColor = Color.White;
            txtPassword.ForeReadOnlyColor = Color.White;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.RectColor = Color.FromArgb(43, 46, 57);
            txtPassword.RectDisableColor = Color.FromArgb(43, 46, 57);
            txtPassword.RectReadOnlyColor = Color.FromArgb(43, 46, 57);
            txtPassword.ShowText = false;
            txtPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtPassword.Watermark = "请输入密码";
            // 
            // btnExit
            // 
            btnExit.FillColor = Color.FromArgb(70, 75, 85);
            btnExit.FillColor2 = Color.FromArgb(70, 75, 85);
            btnExit.FillDisableColor = Color.FromArgb(70, 75, 85);
            resources.ApplyResources(btnExit, "btnExit");
            btnExit.ForeColor = Color.FromArgb(235, 227, 221);
            btnExit.ForeDisableColor = Color.FromArgb(235, 227, 221);
            btnExit.Name = "btnExit";
            btnExit.RectColor = Color.FromArgb(70, 75, 85);
            btnExit.RectDisableColor = Color.FromArgb(70, 75, 85);
            btnExit.Symbol = 0;
            btnExit.TipsFont = new Font("宋体", 11F);
            btnExit.Click += btnExit_Click;
            // 
            // btnSignIn
            // 
            btnSignIn.FillColor = Color.FromArgb(70, 75, 85);
            btnSignIn.FillColor2 = Color.FromArgb(70, 75, 85);
            btnSignIn.FillDisableColor = Color.FromArgb(70, 75, 85);
            resources.ApplyResources(btnSignIn, "btnSignIn");
            btnSignIn.ForeColor = Color.FromArgb(235, 227, 221);
            btnSignIn.ForeDisableColor = Color.FromArgb(235, 227, 221);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.RectColor = Color.FromArgb(70, 75, 85);
            btnSignIn.RectDisableColor = Color.FromArgb(70, 75, 85);
            btnSignIn.Symbol = 0;
            btnSignIn.TipsFont = new Font("宋体", 11F);
            btnSignIn.Click += btnSignIn_Click;
            // 
            // frmLogin
            // 
            AcceptButton = btnSignIn;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(42, 47, 55);
            resources.ApplyResources(this, "$this");
            Controls.Add(lblSoftName);
            Controls.Add(uiPanel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmLogin";
            ShowIcon = false;
            ShowInTaskbar = false;
            Load += frmLogin_Load;
            MouseDown += frmLogin_MouseDown;
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            uiPanel1.ResumeLayout(false);
            uiPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel1;
        public System.Windows.Forms.PictureBox Logo;
        public System.Windows.Forms.Label lblSoftName;
        private UITextBox txtPassword;
        private UIPanel uiPanel1;
        private UISymbolButton btnSignIn;
        private UISymbolButton btnExit;
        private UIComboBox cboUserName;
    }
}