using MainUI.CurrencyHelper;

namespace MainUI.Procedure.User
{
    public partial class frmUserEdit : UIForm
    {
        public frmUserEdit()
        {
            InitializeComponent();
            InitRadioButton();
        }

        private Model.OperateUserModel User;
        public frmUserEdit(Model.OperateUserModel user)
        {
            InitializeComponent();
            InitRadioButton();
            User = user;
            txtUserName.Text = user.Username;
            comboBox1.Text = user.Permission;
            string level = user.Permission;
            if (level != null)
                comboBox1.Text = level;
        }

        void InitRadioButton()
        {
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = RW.Components.User.RWUser.Permissions;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            OperateUserBLL bLL = new();
            User ??= new OperateUserModel();
            User.Username = txtUserName.Text;
            User.Permission = comboBox1.Text;
            User.Password =  "1";
            try
            {
                bool count = bLL.HandMovementUserTable(User);
                if (count)
                {
                    MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("保存失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}