namespace MainUI.Procedure.User
{
    public partial class ucUserManager : UserControl
    {
        private OperateUserBLL bLL = new();
        public ucUserManager()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void ucUserManager_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        //数据绑定
        private void DataBind()
        {
            dataGridView1.DataSource = bLL.GetUsers();
        }

        //添加用户按钮
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowEdit(null);
        }

        //点击编辑用户按钮
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row != null)
            {
                ShowEdit(row);
            }
        }

        //双击编辑用户
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowEdit(dataGridView1.Rows[e.RowIndex]);
        }

        //删除用户按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[dataGridView1.CurrentRow.Index];
            Delete(row);
            DataBind();
        }

        //上移按钮
        private void btnUp_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = rows[0];
            int rowIndex = row.Index;
            if (row == null)
            {
                return;
            }
            if (row.Index == 0)
            {
                MessageHelper.MessageOK("已经是第一条记录了，无法上移。");
                return;
            }
            DataGridViewRow rowUp = dataGridView1.Rows[row.Index - 1];

            //userBll.Move(rowUp.Cells["colID"].Value, rowUp.Cells["colSort"].Value, row.Cells["colID"].Value, row.Cells["colSort"].Value);

            DataBind();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[rowIndex - 1].Selected = true;
        }

        //下移按钮
        private void btnBelow_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            if (rows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = rows[0];
            int rowIndex = row.Index;
            if (row == null)
            {
                return;
            }
            if (row.Index == dataGridView1.Rows.Count - 1)
            {
                MessageHelper.MessageOK("已经是最后一条记录了，无法下移。");
                return;
            }
            DataGridViewRow rowDown = dataGridView1.Rows[row.Index + 1];

            //userBll.Move(row.Cells["colID"].Value, row.Cells["colSort"].Value, rowDown.Cells["colID"].Value, rowDown.Cells["colSort"].Value);
            DataBind();
            dataGridView1.ClearSelection();
            dataGridView1.Rows[rowIndex + 1].Selected = true;
        }

        //显示编辑用户的窗口
        private void ShowEdit(DataGridViewRow row)
        {
            Model.OperateUserModel user = new();
            if (row != null)
            {
                user.ID = Convert.ToInt32(row.Cells["colID"].Value);
                user.Password = row.Cells["colPassword"].Value?.ToString();
                user.Username = row.Cells["colUsername"].Value.ToString();
                user.Permission = row.Cells["colPermission"].Value.ToString();
                user.Sort = Convert.ToInt32(row.Cells["colSort"].Value);
                if (user.Username == "admin")
                {
                    MessageHelper.MessageOK("超级管理员无法编辑");
                    return;
                }
            }
            frmUserEdit editUser = new(user);
            if (editUser.ShowDialog() == DialogResult.OK)
            {
                DataBind();
            }
        }

        private void Delete(DataGridViewRow row)
        {
            string userid = row.Cells["colID"].Value.ToString();
            string username = row.Cells["colUsername"].Value.ToString();

            if (username == "admin")
            {
                MessageHelper.MessageOK("系统用户无法删除！");
                return;
            }
            if (username == RW.Components.User.RWUser.Current.Username)
            {
                MessageHelper.MessageOK("当前用户无法删除");
                return;
            }
            if (MessageHelper.MessageYes("确定要删除吗？") == DialogResult.OK)
            {
                int count = bLL.RemoveByUserJob(new OperateUserModel { ID = userid.ToInt32(), });
                if (count > 0)
                {
                    MessageHelper.MessageOK("删除成功！");
                }
                else
                {
                    MessageHelper.MessageOK("删除失败！");
                }
            }
        }

    }
}
