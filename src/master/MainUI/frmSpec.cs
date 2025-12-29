namespace MainUI
{
    public partial class frmSpec : UIForm
    {
        public frmSpec()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSpec_Load(object sender, EventArgs e)
        {
            uiDataGridView1.AutoGenerateColumns = false;
            BindModels();
        }
        ModelBLL pbll = new();
        /// <summary>
        /// 获取被试品类别列表
        /// </summary>
        private void BindModels()
        {
            uiDataGridView1.DataSource = pbll.GetNewModels();
        }
        /// <summary>
        /// 上翻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (uiDataGridView1.Rows.Count > 0)
            {
                if (this.uiDataGridView1.CurrentRow.Index > 0)
                {
                    int i = uiDataGridView1.Rows.GetPreviousRow(uiDataGridView1.CurrentRow.Index, DataGridViewElementStates.None);//获取原选定上一行索引
                    uiDataGridView1.Rows[i].Selected = true; //选中整行
                    uiDataGridView1.CurrentCell = uiDataGridView1[1, i];//指针上移
                }
            }
        }
        /// <summary>
        /// 下翻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (uiDataGridView1.Rows.Count > 0)
            {
                if (this.uiDataGridView1.CurrentRow.Index < this.uiDataGridView1.Rows.Count - 1)
                {
                    int i = uiDataGridView1.Rows.GetNextRow(uiDataGridView1.CurrentRow.Index, DataGridViewElementStates.None);//获取原选定下一行索引
                    uiDataGridView1.Rows[i].Selected = true; //选中整行
                    uiDataGridView1.CurrentCell = uiDataGridView1[1, i];//指针下移
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetModel();
        }

        public void GetModel()
        {
            try
            {
                VarHelper.mTestViewModel.ModelID = Convert.ToInt32(uiDataGridView1.Rows[uiDataGridView1.CurrentRow.Index].Cells["colID"].Value);//得到当前选择的型号ID
                VarHelper.mTestViewModel.TypeName = uiDataGridView1.Rows[uiDataGridView1.CurrentRow.Index].Cells["TypeName"].Value.ToString();//得到当前选择的型号类别
                VarHelper.mTestViewModel.ModelName = uiDataGridView1.Rows[uiDataGridView1.CurrentRow.Index].Cells["colUsername"].Value.ToString();//得到当前选择的型号名称
                //VarHelper.mTestViewModel.TypeID = dicType[cboModel.Text.ToString()];//得到当前选择的类型ID
                VarHelper.mTestViewModel.Mark = uiDataGridView1.Rows[uiDataGridView1.CurrentRow.Index].Cells["colPassword"].Value.ToString();//得到当前选择的备注
                Close();
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK($"选择型号数据错误：{ex.Message}");
            }
        }

        private void dataGridView_Spec_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                GetModel();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error(ex.Message);
            }
        }
    }
}
