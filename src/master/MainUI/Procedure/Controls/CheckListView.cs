using System.ComponentModel;

namespace MainUI.Procedure.Controls
{
    // 在类上方添加特性
    [ToolboxBitmap(typeof(ListView))] // 使用标准ListView图标
    [Designer("System.Windows.Forms.Design.ListViewDesigner, System.Design")]
    public partial class CheckListView : ListView
    {
        // 自定义属性：复选框大小
        private int _checkBoxSize = 20;
        public int CheckBoxSize
        {
            get { return _checkBoxSize; }
            set { _checkBoxSize = value; Invalidate(); }
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            // 仅绘制第一列的复选框
            if (e.ColumnIndex == 0 && this.View == View.Details)
            {
                DrawCustomCheckBox(e);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void DrawCustomCheckBox(DrawListViewSubItemEventArgs e)
        {
            // 获取绘制区域
            Rectangle rect = GetCheckBoxRect(e.Bounds);

            // 绘制复选框背景
            ControlPaint.DrawBorder(e.Graphics, rect, SystemColors.ControlDark, ButtonBorderStyle.Solid);

            // 绘制勾选状态
            if (e.Item.Checked)
            {
                using Pen checkPen = new(Color.Green, 2);
                e.Graphics.DrawLines(checkPen, new[]
                {
                new Point(rect.Left + 3, rect.Top + rect.Height / 2),
                new Point(rect.Left + rect.Width / 2, rect.Bottom - 4),
                new Point(rect.Right - 3, rect.Top + 3)
            });
            }

            // 绘制文本（偏移位置）
            Rectangle textRect = new Rectangle(
                e.Bounds.Left + _checkBoxSize + 4,
                e.Bounds.Top,
                e.Bounds.Width - _checkBoxSize - 4,
                e.Bounds.Height
            );

            TextRenderer.DrawText(e.Graphics, e.Item.Text, this.Font,
                textRect, this.ForeColor, TextFormatFlags.VerticalCenter);
        }

        private Rectangle GetCheckBoxRect(Rectangle itemBounds)
        {
            return new Rectangle(
                itemBounds.Left + 2,
                itemBounds.Top + (itemBounds.Height - _checkBoxSize) / 2,
                _checkBoxSize,
                _checkBoxSize
            );
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // 检测是否点击在复选框区域
            ListViewHitTestInfo hit = this.HitTest(e.Location);
            if (hit.SubItem == null) return;

            if (hit.Location == ListViewHitTestLocations.Label &&
                hit.SubItem.Bounds.Contains(e.Location) &&
                hit.Item != null)
            {
                Rectangle checkRect = GetCheckBoxRect(hit.SubItem.Bounds);
                if (checkRect.Contains(e.Location))
                {
                    hit.Item.Checked = !hit.Item.Checked;
                    return; // 阻止基类处理
                }
            }
            base.OnMouseDown(e);
        }

        public CheckListView()
        {
            // 启用双缓冲防止闪烁
            DoubleBuffered = true;
            // 强制使用自定义绘制
            OwnerDraw = true;
        }

        public CheckListView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
