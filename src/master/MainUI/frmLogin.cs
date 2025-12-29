using MainUI.CurrencyHelper;
using MainUI.Procedure.Mask;
using RW.EventLog;
using System.Diagnostics;
namespace MainUI
{
    public partial class frmLogin : Form
    {

        private Process keyboardProcess;
        public frmLogin()
        {
            InitializeComponent();

            // 订阅文本框的焦点事件
            txtPassword.GotFocus += TextBox_GotFocus;
            txtPassword.LostFocus += TextBox_LostFocus;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        //public 
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            InitUser();
            txtPassword.Focus();
        }

        private void InitUser()
        {
            OperateUserBLL bLL = new();
            var users = bLL.GetUsers();
            cboUserName.DataSource = users;
            cboUserName.DisplayMember = "Username";
            cboUserName.ValueMember = "ID";
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnSignIn_Click(object sender, EventArgs e)
        {
            LogOn();
           // CloseScreenKeyboard();
        }

        private void LogOn()
        {
            OperateUserBLL bLL = new();
            string username = cboUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "密码不能为空，请重新输入!";
                lblMessage.Visible = true;
                txtPassword.Focus();
                return;
            }

            var user = bLL.SelectUser(new OperateUserModel { ID = cboUserName.SelectedValue.ToInt32() });
            if (user != null)
            {
                if (user.Password != password)
                {
                    lblMessage.Text = "密码错误，请重新输入!";
                    lblMessage.Visible = true;
                    txtPassword.Focus();
                    return;
                }
                else
                {
                    NewUsers.NewUserInfo.InitUser(user);
                    EventLogHelper.Log(EventLogType.Normal, "用户" + NewUsers.NewUserInfo.Username + "登录。");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                lblMessage.Text = "未找到该用户!";
                lblMessage.Visible = true;
                return;
            }
        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            // 启动屏幕键盘
            StartScreenKeyboard();
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            // 关闭屏幕键盘
            CloseScreenKeyboard();
        }

        private void StartScreenKeyboard()
        {
            try
            {
                if (keyboardProcess == null || keyboardProcess.HasExited)
                {
                   // keyboardProcess = Process.Start("osk.exe"); // 启动Windows屏幕键盘
                                                                // 优先尝试TabTip（Windows 10/11）
                    if (TryStartTabTip()) return;

                    // 如果TabTip不可用，尝试osk
                    if (TryStartOsk()) return;

                    //MessageBox.Show("无法找到可用的屏幕键盘程序");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法启动屏幕键盘: {ex.Message}");
            }
        }
        private bool TryStartTabTip()
        {
            try
            {
                string tabTipPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles),
                    "Microsoft Shared\\ink\\TabTip.exe");

                if (File.Exists(tabTipPath))
                {
                    keyboardProcess = Process.Start(tabTipPath);
                    return true;
                }
            }
            catch
            {
                // 忽略异常，继续尝试其他方法
            }
            return false;
        }

        private bool TryStartOsk()
        {
            try
            {
            
                string oskPath = Application.StartupPath + "osk.exe";//调用系统文件夹下可能读取不到，放置Debug下调用

                //string oskPath = Application.StartupPath + "Keyboard.exe";//调用系统文件夹下可能读取不到，放置Debug下调用
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = oskPath,
                    UseShellExecute = true,
                    Verb = "runas" // 尝试以管理员权限运行
                };
                if (File.Exists(oskPath))
                {
                    keyboardProcess = Process.Start(startInfo);//oskPath
                    return true;
                }
            }
            catch
            {
                // 忽略异常
            }
            return false;
        }

        private void CloseScreenKeyboard()
        {
            try
            {
                if (keyboardProcess != null && !keyboardProcess.HasExited)
                {
                    keyboardProcess.CloseMainWindow();
                    keyboardProcess.Close();
                    keyboardProcess = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法关闭屏幕键盘: {ex.Message}");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // 确保窗体关闭时也关闭屏幕键盘
            CloseScreenKeyboard();
            base.OnFormClosed(e);
        }

    }
}