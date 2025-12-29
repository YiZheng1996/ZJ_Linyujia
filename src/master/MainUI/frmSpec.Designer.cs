namespace MainUI
{
    partial class frmSpec
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            uiButton1 = new UIButton();
            uiButton2 = new UIButton();
            uiButton3 = new UIButton();
            uiDataGridView1 = new UIDataGridView();
            colID = new DataGridViewTextBoxColumn();
            TypeName = new DataGridViewTextBoxColumn();
            colUsername = new DataGridViewTextBoxColumn();
            colPassword = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).BeginInit();
            SuspendLayout();
            // 
            // uiButton1
            // 
            uiButton1.Cursor = Cursors.Hand;
            uiButton1.FillColor = Color.FromArgb(70, 75, 85);
            uiButton1.FillColor2 = Color.FromArgb(70, 75, 85);
            uiButton1.Font = new Font("思源黑体 CN Bold", 11F, FontStyle.Bold);
            uiButton1.ForeColor = Color.FromArgb(235, 227, 221);
            uiButton1.Location = new Point(18, 675);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.RectColor = Color.FromArgb(70, 75, 85);
            uiButton1.RectDisableColor = Color.FromArgb(70, 75, 85);
            uiButton1.Size = new Size(86, 38);
            uiButton1.TabIndex = 389;
            uiButton1.Text = "▲";
            uiButton1.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton1.TipsText = "1";
            uiButton1.Click += button1_Click;
            // 
            // uiButton2
            // 
            uiButton2.Cursor = Cursors.Hand;
            uiButton2.FillColor = Color.FromArgb(70, 75, 85);
            uiButton2.FillColor2 = Color.FromArgb(70, 75, 85);
            uiButton2.Font = new Font("思源黑体 CN Bold", 11F, FontStyle.Bold);
            uiButton2.ForeColor = Color.FromArgb(235, 227, 221);
            uiButton2.Location = new Point(110, 675);
            uiButton2.MinimumSize = new Size(1, 1);
            uiButton2.Name = "uiButton2";
            uiButton2.RectColor = Color.FromArgb(70, 75, 85);
            uiButton2.RectDisableColor = Color.FromArgb(70, 75, 85);
            uiButton2.Size = new Size(86, 38);
            uiButton2.TabIndex = 390;
            uiButton2.Text = "▼";
            uiButton2.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton2.TipsText = "1";
            uiButton2.Click += button2_Click;
            // 
            // uiButton3
            // 
            uiButton3.Cursor = Cursors.Hand;
            uiButton3.DialogResult = DialogResult.OK;
            uiButton3.FillColor = Color.FromArgb(70, 75, 85);
            uiButton3.FillColor2 = Color.FromArgb(70, 75, 85);
            uiButton3.Font = new Font("思源黑体 CN Bold", 11F, FontStyle.Bold);
            uiButton3.ForeColor = Color.FromArgb(235, 227, 221);
            uiButton3.Location = new Point(651, 673);
            uiButton3.MinimumSize = new Size(1, 1);
            uiButton3.Name = "uiButton3";
            uiButton3.RectColor = Color.FromArgb(70, 75, 85);
            uiButton3.RectDisableColor = Color.FromArgb(70, 75, 85);
            uiButton3.Size = new Size(120, 40);
            uiButton3.TabIndex = 391;
            uiButton3.Text = "选择实行";
            uiButton3.TipsFont = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiButton3.TipsText = "1";
            uiButton3.Click += button3_Click;
            // 
            // uiDataGridView1
            // 
            uiDataGridView1.AllowUserToAddRows = false;
            uiDataGridView1.AllowUserToDeleteRows = false;
            uiDataGridView1.AllowUserToResizeColumns = false;
            uiDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(49, 54, 64);
            uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            uiDataGridView1.BackgroundColor = Color.FromArgb(49, 54, 64);
            uiDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(239, 154, 78);
            dataGridViewCellStyle2.Font = new Font("思源黑体 CN Bold", 13F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(235, 227, 221);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 154, 78);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(235, 227, 221);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            uiDataGridView1.ColumnHeadersHeight = 32;
            uiDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            uiDataGridView1.Columns.AddRange(new DataGridViewColumn[] { colID, TypeName, colUsername, colPassword });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(235, 227, 221);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            uiDataGridView1.EnableHeadersVisualStyles = false;
            uiDataGridView1.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            uiDataGridView1.GridColor = Color.FromArgb(42, 47, 55);
            uiDataGridView1.Location = new Point(17, 48);
            uiDataGridView1.Name = "uiDataGridView1";
            uiDataGridView1.ReadOnly = true;
            uiDataGridView1.RectColor = Color.FromArgb(49, 54, 64);
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(49, 54, 64);
            dataGridViewCellStyle5.Font = new Font("思源黑体 CN Bold", 12F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(235, 227, 221);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(235, 227, 221);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(49, 54, 64);
            uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            uiDataGridView1.RowTemplate.Height = 37;
            uiDataGridView1.ScrollBarColor = Color.FromArgb(42, 47, 55);
            uiDataGridView1.ScrollBarStyleInherited = false;
            uiDataGridView1.SelectedIndex = -1;
            uiDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            uiDataGridView1.Size = new Size(753, 612);
            uiDataGridView1.StripeEvenColor = Color.FromArgb(49, 54, 64);
            uiDataGridView1.StripeOddColor = Color.FromArgb(49, 54, 64);
            uiDataGridView1.TabIndex = 392;
            uiDataGridView1.CellDoubleClick += dataGridView_Spec_CellDoubleClick;
            // 
            // colID
            // 
            colID.DataPropertyName = "ID";
            colID.HeaderText = "ID";
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Visible = false;
            // 
            // TypeName
            // 
            TypeName.DataPropertyName = "modeltype";
            TypeName.HeaderText = "产品类型";
            TypeName.Name = "TypeName";
            TypeName.ReadOnly = true;
            TypeName.Visible = false;
            TypeName.Width = 250;
            // 
            // colUsername
            // 
            colUsername.DataPropertyName = "Name";
            colUsername.HeaderText = "产品型号";
            colUsername.Name = "colUsername";
            colUsername.ReadOnly = true;
            colUsername.Width = 400;
            // 
            // colPassword
            // 
            colPassword.DataPropertyName = "mark";
            colPassword.HeaderText = "备注";
            colPassword.Name = "colPassword";
            colPassword.ReadOnly = true;
            colPassword.Width = 310;
            // 
            // frmSpec
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(42, 47, 55);
            ClientSize = new Size(786, 722);
            Controls.Add(uiDataGridView1);
            Controls.Add(uiButton3);
            Controls.Add(uiButton2);
            Controls.Add(uiButton1);
            Font = new Font("思源黑体 CN Bold", 11F, FontStyle.Bold);
            ForeColor = Color.FromArgb(235, 227, 221);
            Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSpec";
            Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            RectColor = Color.FromArgb(49, 54, 64);
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "车型选择";
            TitleColor = Color.FromArgb(47, 55, 64);
            TitleFont = new Font("思源黑体 CN Heavy", 15F, FontStyle.Bold);
            TitleForeColor = Color.FromArgb(239, 154, 78);
            TitleHeight = 32;
            ZoomScaleRect = new Rectangle(15, 15, 786, 678);
            Load += frmSpec_Load;
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private DataGridViewTextBoxColumn colID;
        private DataGridViewTextBoxColumn TypeName;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colPassword;
    }
}